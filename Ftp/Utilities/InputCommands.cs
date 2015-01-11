using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int i = 0;
            for (i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-s":
                        StoreFile = true;
                        break;
                }
                else if (args[i].equals("-a")) {
                    localActive = true;
                }
                else if (args[i].equals("-A")) {
                    username = "anonymous";
                    password = System.getProperty("user.name")+"@"+InetAddress.getLocalHost().getHostName();
                }
                else if (args[i].equals("-b")) {
                    binaryTransfer = true;
                }
                else if (args[i].equals("-c")) {
                    doCommand = args[++i];
                    minParams = 3;
                }
                else if (args[i].equals("-d")) {
                    mlsd = true;
                    minParams = 3;
                }
                else if (args[i].equals("-e")) {
                    useEpsvWithIPv4 = true;
                }
                else if (args[i].equals("-f")) {
                    feat = true;
                    minParams = 3;
                }
                else if (args[i].equals("-h")) {
                    hidden = true;
                }
                else if (args[i].equals("-k")) {
                    keepAliveTimeout = Long.parseLong(args[++i]);
                }
                else if (args[i].equals("-l")) {
                    listFiles = true;
                    minParams = 3;
                }
                else if (args[i].equals("-L")) {
                    lenient = true;
                }
                else if (args[i].equals("-n")) {
                    listNames = true;
                    minParams = 3;
                }
                else if (args[i].equals("-p")) {
                    protocol = args[++i];
                }
                else if (args[i].equals("-t")) {
                    mlst = true;
                    minParams = 3;
                }
                else if (args[i].equals("-w")) {
                    controlKeepAliveReplyTimeout = Integer.parseInt(args[++i]);
                }
                else if (args[i].equals("-T")) {
                    trustmgr = args[++i];
                }
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
                }
            }
        }
    }
}
