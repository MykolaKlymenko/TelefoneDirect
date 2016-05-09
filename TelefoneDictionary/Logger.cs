using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TelefoneDictionary
{
    public class Logger:ILogger
    {
        public void Log(string text)
        {
            File.WriteAllText("C://log.txt",text);
        }

        public void LogError(string text)
        {
            File.WriteAllText("C://error.txt", text);
        }
    }
}