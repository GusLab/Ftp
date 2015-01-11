using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftp.Utilities
{
    public sealed class InputCommands
    {
        Boolean StoreFile = false, 
            BinaryTransfer = false, 
            Error = false, 
            ListFiles = false, 
            ListNames = false, 
            Hidden = false;
        Boolean LocalActive = false, 
            UseEpsvWithIPv4 = false, 
            Feat = false, 
            PrintHash = false;
        Boolean Mlst = false, 
            Mlsd = false;
        Boolean Lenient = false;
        long KeepAliveTimeout = -1;
        int ControlKeepAliveReplyTimeout = -1;
        int MinParams = 5; // listings require 3 params
        String Protocol = null; // SSL protocol
        String DoCommand = null;
        String Trustmgr = null;
        String ProxyHost = null;
        int ProxyPort = 80;
        String ProxyUser = null;
        String ProxyPassword = null;
        String Username = null;
        String Password = null;

        public void ParseInputCommands()
        {
            int base = 0;
            for (base = 0; base < args.length; base++)
            {
                if (args[base].equals("-s")) {
                    storeFile = true;
                }
                else if (args[base].equals("-a")) {
                    localActive = true;
                }
                else if (args[base].equals("-A")) {
                    username = "anonymous";
                    password = System.getProperty("user.name")+"@"+InetAddress.getLocalHost().getHostName();
                }
                else if (args[base].equals("-b")) {
                    binaryTransfer = true;
                }
                else if (args[base].equals("-c")) {
                    doCommand = args[++base];
                    minParams = 3;
                }
                else if (args[base].equals("-d")) {
                    mlsd = true;
                    minParams = 3;
                }
                else if (args[base].equals("-e")) {
                    useEpsvWithIPv4 = true;
                }
                else if (args[base].equals("-f")) {
                    feat = true;
                    minParams = 3;
                }
                else if (args[base].equals("-h")) {
                    hidden = true;
                }
                else if (args[base].equals("-k")) {
                    keepAliveTimeout = Long.parseLong(args[++base]);
                }
                else if (args[base].equals("-l")) {
                    listFiles = true;
                    minParams = 3;
                }
                else if (args[base].equals("-L")) {
                    lenient = true;
                }
                else if (args[base].equals("-n")) {
                    listNames = true;
                    minParams = 3;
                }
                else if (args[base].equals("-p")) {
                    protocol = args[++base];
                }
                else if (args[base].equals("-t")) {
                    mlst = true;
                    minParams = 3;
                }
                else if (args[base].equals("-w")) {
                    controlKeepAliveReplyTimeout = Integer.parseInt(args[++base]);
                }
                else if (args[base].equals("-T")) {
                    trustmgr = args[++base];
                }
                else if (args[base].equals("-PrH")) {
                    proxyHost = args[++base];
                    String parts[] = proxyHost.split(":");
                    if (parts.length == 2){
                        proxyHost=parts[0];
                        proxyPort=Integer.parseInt(parts[1]);
                    }
                }
                else if (args[base].equals("-PrU")) {
                    proxyUser = args[++base];
                }
                else if (args[base].equals("-PrP")) {
                    proxyPassword = args[++base];
                }
                else if (args[base].equals("-#")) {
                    printHash = true;
                }
                else {
                    break;
                }
            }
        }
    }
}
