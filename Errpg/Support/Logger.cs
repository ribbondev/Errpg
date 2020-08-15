using System;
using static System.Console;

namespace Errpg.Support
{
    public class Logger : ILogger
    {
        public void Write(string message)
        {
            WriteLine($"Errpg: {message}");
        }

        public void Write(Exception exception)
        {
            WriteLine($"Errpg Error: {exception.Message}");
        }
    }
}
