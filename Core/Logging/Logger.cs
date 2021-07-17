using System;
using System.IO;

namespace NakaEngine.Core.Logging
{
    public sealed class Logger : IDisposable
    {
        private readonly string path;

        private FileStream stream;

        private StreamWriter writer;

        public Logger(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"Path should not be null or empty");
            }

            this.path = path;
        }

        public void Log(string message, LogType logType = LogType.Debug)
        {
            if (!File.Exists(path))
            {
                return;
            }

            string time = DateTime.UtcNow.ToLongTimeString();
            string assembly = GetType().Assembly.GetName().Name;

            writer.WriteLine($"[{time}] [{assembly}] [{logType}]: {message}");
            writer.Flush();
        }

        public void Configurate()
        {
            new DirectoryInfo(Path.GetDirectoryName(path)).Create();

            stream = new(path, FileMode.OpenOrCreate);
            writer = new(stream);
        }

        public void Dispose()
        {
            writer.Dispose();
            stream.Dispose();
        }
    }
}
