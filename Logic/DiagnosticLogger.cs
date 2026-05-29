using Data;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Logic
{

    public class DiagnosticLogger : IDisposable
    {
        private readonly IDataLogger _dataLogger;
        private readonly BlockingCollection<string> _logQueue;
        private readonly Task _loggingTask;
        private readonly CancellationTokenSource _cts;

        public DiagnosticLogger(IDataLogger dataLogger)
        {
            _dataLogger = dataLogger;
            _logQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
            _cts = new CancellationTokenSource();
            _loggingTask = Task.Run(ProcessQueue, _cts.Token);
        }

        public void LogBallState(ILogicBall ball)
        {
            var dto = new BallStateDto(ball);
            string json = JsonSerializer.Serialize(dto);
            
            // Non-blocking add to queue
            _logQueue.Add(json);
        }

        private void ProcessQueue()
        {
            try
            {
                foreach (var logEntry in _logQueue.GetConsumingEnumerable(_cts.Token))
                {
                    _dataLogger.Log(logEntry);
                }
            }
            catch (OperationCanceledException)
            {
                // Task was cancelled
            }
        }

        public void Dispose()
        {
            _logQueue.CompleteAdding();
            _cts.Cancel();
            try
            {
                _loggingTask.Wait(1000);
            }
            catch { }
            _logQueue.Dispose();
            _cts.Dispose();
        }
    }
}