using System;
using System.IO;

namespace Nedeljni2_Andreja_Kolesar.Model
{
    class LogIntoFile
    {
        public string path { get; } = @"..\..\LogActions.txt";
        private object locker = new object();
        private static LogIntoFile log;
        private LogIntoFile() { }
        public static LogIntoFile getInstance()
        {
            if (log == null)
                log = new LogIntoFile();
            return log;
        }
        /// <summary>
        /// Print currrent action with current time into file
        /// </summary>
        /// <param name="content"></param>
        public void PrintActionIntoFile(string content)
        {
            string currentDate = DateTime.Now.ToShortDateString();
            string currentTime = DateTime.Now.ToShortTimeString();
            content = currentDate + " " + currentTime + " " + content;
            //print to file
            StreamWriter str = new StreamWriter(path, true);
            str.WriteLine(content);
            str.Close();

        }
    }
}
