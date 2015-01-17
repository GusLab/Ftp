using System;
using System.Text;
using CommandLine;

namespace Ftp.Utilities
{
    public sealed class InputCommands
    {
        [Option('a', "local-mode-active", Required = false, HelpText = "Use local active mode (default is local passive)")]
        public bool IsLocalModeActive { get; set; }

        [Option('A', "anonymous-login", Required = false, HelpText = "Anonymous login (omit username and password parameters)")]
        public bool IsAnonymousLogin { get; set; }

        [Option('s', "upload-file", Required = false, HelpText = "Store file on server (upload)")]
        public bool IsStoreFile { get; set; }

        [Option('b', "binary-mode", Required = false, HelpText = "Use binary transfer mode")]
        public bool IsBinaryTransfer { get; set; }

        [Option('c', "command", Required = false, HelpText = "Cmd - issue arbitrary command (remote is used as a parameter if provided)")]
        public string Command { get; set; }

        [Option('d', "mlsd", Required = false, HelpText = "List directory details using MLSD (remote is used as the pathname if provided)")]
        public bool IsMlsd { get; set; }

        [Option('e', "epsv-with-ipv4", Required = false, HelpText = "Use EPSV with IPv4 (default false)")]
        public bool IsEpsvWithIPv4 { get; set; }

        [Option('f', "feat", Required = false, HelpText = "Issue FEAT command (remote and local files are ignored)")]
        public bool IsFeat { get; set; }

        [Option('h', "include-hidden", Required = false, HelpText = "List hidden files (applies to -l and -n only)")]
        public bool IsIncludeHidden { get; set; }

        [Option('k', "keep-alive-timeout", DefaultValue = 5, Required = false, HelpText = "Secs - use keep-alive timer (setControlKeepAliveTimeout)")]
        public long KeepAliveTimeout { get; set; }

        [Option('l', "list-files", Required = false, HelpText = "List files using LIST (remote is used as the pathname if provided)\n" + 
                                                                "Files are listed twice: first in raw mode, then as the formatted parsed data.")]
        public bool ListFiles { get; set; }

        [Option('L', "lenient-dates", Required = false, HelpText = "Use lenient future dates (server dates may be up to 1 day into future)")]
        public bool IsLenient { get; set; }

        [Option('n', "list-names", Required = false, HelpText = "List file names using NLST (remote is used as the pathname if provided)")]
        public bool ListNames { get; set; }

        [HelpOption(HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            var usage = new StringBuilder();            
            usage.AppendLine("Ftp - version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            usage.AppendLine("Usage: ftp [options] <hostname> <username> <password> [<remote file> [<local file>]]");
            usage.AppendLine("Default behavior is to download a file and use ASCII transfer mode.");
            return usage.ToString();
        }

        /*
        public void ParseInputCommands(string[] args)
        {
            var i = 0;
            for (i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
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
