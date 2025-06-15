using System;

namespace LoggerExample
{
    delegate void LoggerDelegate(string message);
    class Logger
    {
        public static void LogToConsole(string msg)
        {
            Console.WriteLine("[Console]: " + msg);
        }
        public static void LogToFile(string msg)
        {
            Console.WriteLine("[File]: " + msg);
        }
    }
    class Program
    {
        static void Main()
        {
            LoggerDelegate logConsole = Logger.LogToConsole;
            logConsole("Thong diep gui toi console");
            LoggerDelegate logFile = Logger.LogToFile;
            logFile("Thong diep gui toi file");
            LoggerDelegate multiLogger = Logger.LogToConsole;
            multiLogger += Logger.LogToFile;
            multiLogger("Thong diep gui toi ca console và file");
            multiLogger -= Logger.LogToConsole;
            multiLogger("Thong diep chi gui toi file");
            Console.ReadLine(); 
        }
    }
}