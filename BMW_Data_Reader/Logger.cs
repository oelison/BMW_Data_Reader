using System;
using System.IO;

namespace SciPhyLib
{
    class Logger
    {
        TextWriter LogFile;
        public void Open(String FileName)
        {
            LogFile = new StreamWriter(FileName, true);
        }
        public void Close()
        {
            LogFile.Close();
        }
        public void WriteLogLine(String LogText)
        {
            LogFile.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " " + LogText);
        }
    }
}
