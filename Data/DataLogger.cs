namespace Data
{
    public interface IDataLogger
    {
        void Log(string message);
    }

    public class DataLogger : IDataLogger
    {
        private readonly string _filePath;

        public DataLogger(string filePath)
        {
            _filePath = filePath;
            // Ensure the file is fresh or exists
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        public void Log(string message)
        {
            try
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
            catch (IOException)
            {
                // In case of file access issues, we just ignore it as per requirements
                // (handling "temporary lack of throughput")
            }
        }
    }
}