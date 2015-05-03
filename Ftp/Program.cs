using System;
using Ftp.InputCommand;

namespace Ftp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCommands = new InputCommands();          

            if (inputCommands.ParseInputCommands(args))
            {           
                Run(inputCommands, inputCommands.IsConsole);
            }
        }

        private static void Run(InputCommands inputCommands, bool isConsole = false)
        {
            
        }
    }
}
