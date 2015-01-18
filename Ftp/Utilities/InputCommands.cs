using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace Ftp.Utilities
{
    public sealed class InputCommands
    {
        [ParserState]
        public IParserState LastParserState { get; set; }

        [Option('a', "local-mode-active", Required = false, HelpText = "Use local active mode (default is local passive)")]
        public bool IsLocalModeActive { get; set; }

        [Option('A', "anonymous-login", Required = false, HelpText = "Anonymous login (omit username and password parameters)")]
        public bool IsAnonymousLogin { get; set; }

        [Option('s', "upload-file", Required = false, HelpText = "Store file on server (upload)")]
        public bool IsStoreFile { get; set; }

        [Option('b', "binary-mode", Required = false, HelpText = "Use binary transfer mode")]
        public bool IsBinaryTransfer { get; set; }

        [Option('c', "command", Required = false, HelpText = "Issue arbitrary command (remote is used as a parameter if provided)")]
        public string Command { get; set; }

        [Option('d', "mlsd", Required = false, HelpText = "List directory details using MLSD (remote is used as the pathname if provided)")]
        public bool IsMlsd { get; set; }

        [Option('e', "epsv-with-ipv4", Required = false, HelpText = "Use EPSV with IPv4 (default false)")]
        public bool IsEpsvWithIPv4 { get; set; }

        [Option('f', "feat", Required = false, HelpText = "Issue FEAT command (remote and local files are ignored)")]
        public bool IsFeat { get; set; }

        [Option('h', "include-hidden", Required = false, HelpText = "List hidden files (applies to -l and -n only)")]
        public bool IsIncludeHidden { get; set; }

        [Option('k', "keep-alive-timeout", DefaultValue = 0, Required = false, HelpText = "Use keep-alive timer (in seconds)")]
        public long KeepAliveTimeout { get; set; }

        [Option('l', "list-files", Required = false, HelpText = "List files using LIST (remote is used as the pathname if provided). Files are listed twice: first in raw mode, then as the formatted parsed data.")]
        public bool ListFiles { get; set; }

        [Option('L', "lenient-dates", Required = false, HelpText = "Use lenient future dates (server dates may be up to 1 day into future)")]
        public bool IsLenient { get; set; }

        [Option('n', "list-names", Required = false, HelpText = "List file names using NLST (remote is used as the pathname if provided)")]
        public bool ListNames { get; set; }

        [Option('p', "ftps", Required = false, HelpText = "Use FTPSClient with the specified protocol and/or isImplicit setting (options: true|false|protocol[,true|false])")]
        public string Protocol { get; set; }

        [Option('t', "mlst", Required = false, HelpText = "List file details using MLST (remote is used as the pathname if provided)")]
        public bool IsMlst { get; set; }

        [Option('w', "keep-alive-reply-timeout", DefaultValue = 0, Required = false, HelpText = "Wait time for keep-alive reply (in miliseconds)")]
        public int KeepAliveReplyTimeout { get; set; }

        [Option('T', "trust-manager", DefaultValue = "none", Required = false, HelpText = "Use one of the built-in TrustManager implementations (none = default) (options: all|valid|none)")]
        public string TrustManager { get; set; }

        [OptionList('H', "proxy-server", Required = false, HelpText = "HTTP Proxy host and optional port[80] (options: server[:port])")]
        public IList<string> ProxyServerAndPortList { get; set; }

        [Option('u', "proxy-user", DefaultValue = "anonymous", Required = false, HelpText = "HTTP Proxy server username")]
        public string ProxyUser { get; set; }

        [Option('P', "proxy-password", DefaultValue = "anonymous", Required = false, HelpText = "HTTP Proxy server password")]
        public string ProxyPassword { get; set; }

        [Option('#', "print-hash", Required = false, HelpText = "Add hash display during transfers")]
        public bool IsPrintHash { get; set; }

        [HelpOption(HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var help = new HelpText
            {
                Heading = new HeadingInfo(assembly.GetExecutingAssemblyProductName(), assembly.GetExecutingAssemblyInformationalVersion()),
                Copyright = new CopyrightInfo(assembly.GetExecutingAssemblyCopyright(), int.Parse(assembly.GetExecutingAssemblyDescription())),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine(assembly.GetExecutingAssemblyLicence());
            help.AddPreOptionsLine(assembly.GetExecutingAssemblyUsage());
            help.AddOptions(this);
            return help;           
        }

        public bool ParseInputCommands(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments(args, this);             
        }        

    }
}
