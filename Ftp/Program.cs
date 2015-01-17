using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ftp.Utilities;

namespace Ftp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputCommands inputCommands = new InputCommands();

            inputCommands.ParseInputCommands(args);           
        }
    }
}
