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
            memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Dispose()
        {
            if (streamWriter != null)
                streamWriter.Dispose();
            if (memoryStream !=null)
                memoryStream.Dispose();            
        }

        public void Log(string message)
        {
            streamWriter.Write(message);
        }

   }
}