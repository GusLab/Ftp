using System;

namespace Ftp.Utilities
{
    public sealed class InputCommands
    {
        public Boolean StoreFile = false, 
            BinaryTransfer = false, 
            Error = false, 
            ListFiles = false, 
            ListNames = false, 
            Hidden = false;
        public Boolean LocalActive = false, 
            UseEpsvWithIPv4 = false, 
            Feat = false, 
            PrintHash = false;
        public Boolean Mlst = false, 
            Mlsd = false;
        public Boolean Lenient = false;
        public long KeepAliveTimeout = -1;
        public int ControlKeepAliveReplyTimeout = -1;
        public int MinParams = 5; // listings require 3 params
        public String Protocol = null; // SSL protocol
        public String DoCommand = null;
        public String Trustmgr = null;
        public String ProxyHost = null;
        public int ProxyPort = 80;
        public String ProxyUser = null;
        public String ProxyPassword = null;
        public String Username = null;
        public String Password = null;

        public void ParseInputCommands(string[] args)
        {
            var i = 0;
            for (i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-s":
                        StoreFile = true;
                        break;
                    case "-a":
                        LocalActive = true;
                        break;
                    case "-A":
                        Username = "anonymous";
                        Password = "anonymous@" + System.Environment.GetEnvironmentVariable("COMPUTERNAME");
                        break;
                    case "-b":
                        BinaryTransfer = true;
                        break;
                    case "-c":
                        DoCommand = args[++i];
                        MinParams = 3;
                        break;
                    case "-d":
                        Mlsd = true;
                        MinParams = 3;
                        break;
                    case "-e":
                        UseEpsvWithIPv4 = true;
                        break;
                    case "-f":
                        Feat = true;
                        MinParams = 3;
                        break;
                    case "-h":
                        Hidden = true;
                        break;
                    case "-k":
                        KeepAliveTimeout = long.Parse(args[++i]);
                        break;
                    case "-l":
                        ListFiles = true;
                        MinParams = 3;
                        break;
                    case "-L":
                        Lenient = true;
                        break;
                    case "-n":
                        ListNames = true;
                        MinParams = 3;
                        break;
                    case "-p":
                        Protocol = args[++i];
                        break;
                    case "-t":
                        Mlst = true;
                        MinParams = 3;
                        break;
                    case "-w":
                        ControlKeepAliveReplyTimeout = int.Parse(args[++i]);
                        break;
                    case "-T":
                        Trustmgr = args[++i];
                        break;

                }              
                /*                                              
                else if (args[i].equals("-PrH")) {
                    proxyHost = args[++i];
                    String parts[] = proxyHost.split(":");
                    if (parts.length == 2){
                        proxyHost=parts[0];
                        proxyPort=Integer.parseInt(parts[1]);
                    }
                }
                else if (args[i].equals("-PrU")) {
                    proxyUser = args[++i];
                }
                else if (args[i].equals("-PrP")) {
                    proxyPassword = args[++i];
                }
                else if (args[i].equals("-#")) {
                    printHash = true;
                }
                else {
                    break;
                }*/
            }
        }
    }
}
