using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate | FileMode.Append);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            streamWriter.Write(message);
        }

        public void Dispose()
        {
            streamWriter?.Dispose();
            GC.SuppressFinalize(this);
        }
   }
}