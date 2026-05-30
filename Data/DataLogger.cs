using System.Collections.Concurrent;

namespace Data
{
    public interface IDataLogger : IDisposable
    {
        void Log(string message);
    }

    public class DataLogger : IDataLogger
    {
        private readonly string _filePath;
        private readonly BlockingCollection<string> _logQueue;
        private readonly Task _loggingTask;
        private readonly CancellationTokenSource _cts;

        public DataLogger(string filePath)
        {
            _filePath = filePath;
            _logQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
            _cts = new CancellationTokenSource();

            // Ensure the file is fresh or exists
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            _loggingTask = Task.Run(ProcessQueue, _cts.Token);
        }

        public void Log(string message)
        {
            if (!_logQueue.IsAddingCompleted)
            {
                _logQueue.Add(message);
            }
        }

        private void ProcessQueue()
        {
            try
            {
                foreach (var logEntry in _logQueue.GetConsumingEnumerable(_cts.Token))
                {
                    File.AppendAllText(_filePath, logEntry + Environment.NewLine);
                }
            }
            catch (OperationCanceledException)
            {
                // Task was cancelled
            }
            catch (IOException)
            {
                // In case of file access issues, we just ignore it as per requirements
                // (handling "temporary lack of throughput")
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