﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace Ftp.InputCommand
{
    public sealed class InputCommands
    {
        
        [ParserState]
        public IParserState LastParserState { get; set; }

        [Option('#', "print-hash", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Add hash display during transfers")]
        public bool IsPrintHash { get; set; }

        [Option('a', "local-mode-active", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Use local active mode (default is local passive)")]
        public bool IsLocalModeActive { get; set; }

        [Option('A', "anonymous-login", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Anonymous login (omit username and password parameters)")]
        public bool IsAnonymousLogin { get; set; }

        [Option('b', "binary-mode", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Use binary transfer mode")]
        public bool IsBinaryTransfer { get; set; }

        [Option('c', "command", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Issue arbitrary command (remote is used as a parameter if provided)")]
        public string Command { get; set; }

        [Option('C', "console", MutuallyExclusiveSet = "console", Required = false, HelpText = "Starts console")]
        public bool IsConsole { get; set; }

        [Option('d', "mlsd", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "List directory details using MLSD (remote is used as the pathname if provided)")]
        public bool IsMlsd { get; set; }

        [Option('D', "lenient-dates", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Use lenient future dates (server dates may be up to 1 day into future)")]
        public bool IsLenient { get; set; }

        [Option('e', "epsv-with-ipv4", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Use EPSV with IPv4 (default false)")]
        public bool IsEpsvWithIPv4 { get; set; }

        [Option('f', "feat", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Issue FEAT command (remote and local files are ignored)")]
        public bool IsFeat { get; set; }

        [Option('F', "upload-file", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Store file on server (upload)")]
        public bool IsStoreFile { get; set; }

        [Option('h', "include-hidden", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "List hidden files (applies to -l and -n only)")]
        public bool IsIncludeHidden { get; set; }

        [Option('k', "keep-alive-timeout", MutuallyExclusiveSet = "no-console", DefaultValue = 0, Required = false, HelpText = "Use keep-alive timer (in seconds)")]
        public long KeepAliveTimeout { get; set; }

        [Option('l', "local-path", MutuallyExclusiveSet = "no-console", Required = true, HelpText = "Sets local path, defaults to current")]
        public string LocalPath { get; set; }

        [Option('L', "list-files", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "List files using LIST (remote is used as the pathname if provided). Files are listed twice: first in raw mode, then as the formatted parsed data.")]
        public bool ListFiles { get; set; }

        [Option('n', "list-names", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "List file names using NLST (remote is used as the pathname if provided)")]
        public bool ListNames { get; set; }

        [Option('p', "password", DefaultValue = "anonymous", Required = true, HelpText = "FTP server password")]
        public string Password { get; set; }

        [Option('P', "proxy-password", MutuallyExclusiveSet = "no-console", DefaultValue = "anonymous", Required = false, HelpText = "HTTP Proxy server password")]
        public string ProxyPassword { get; set; }

        [Option('r', "remote-path", MutuallyExclusiveSet = "no-console", Required = true, HelpText = "Sets remote path to connect to, defaults to server/user default")]
        public string RemotePath { get; set; }

        [Option('R', "ftps", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "Use FTPSClient with the specified protocol and/or isImplicit setting (options: true|false|protocol[,true|false])")]
        public string Protocol { get; set; }

        [OptionList('s', "server", MutuallyExclusiveSet = "no-console", Required = true, HelpText = "Server in format server[:port], if no port provided, default is 21")]
        public IList<string> Server { get; set; }

        [OptionList('S', "proxy-server", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "HTTP Proxy host and optional port[80] (options: server[:port])")]
        public IList<string> ProxyServerAndPortList { get; set; }

        [Option('t', "mlst", MutuallyExclusiveSet = "no-console", Required = false, HelpText = "List file details using MLST (remote is used as the pathname if provided)")]
        public bool IsMlst { get; set; }

        [Option('u', "user", MutuallyExclusiveSet = "no-console", Required = true, DefaultValue = "anonymous", HelpText = "FTP server username")]
        public string Username { get; set; }

        [Option('U', "proxy-user", MutuallyExclusiveSet = "no-console", DefaultValue = "anonymous", Required = false, HelpText = "HTTP Proxy server username")]
        public string ProxyUser { get; set; }

        [Option('w', "keep-alive-reply-timeout", MutuallyExclusiveSet = "no-console", DefaultValue = 0, Required = false, HelpText = "Wait time for keep-alive reply (in miliseconds)")]
        public int KeepAliveReplyTimeout { get; set; }

        [Option('T', "trust-manager", MutuallyExclusiveSet = "no-console", DefaultValue = "none", Required = false, HelpText = "Use one of the built-in TrustManager implementations (none = default) (options: all|valid|none)")]
        public string TrustManager { get; set; }

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

            if (LastParserState == null) return help;
            if (LastParserState.Errors.Any())
            {
                var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces

                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
                    help.AddPreOptionsLine(errors);
                }
            }
            return help;           
        }

        public bool ParseInputCommands(string[] args)
        {
            var parser = new Parser(with =>
            {
                with.CaseSensitive = true;
                with.HelpWriter = Console.Error;
                with.IgnoreUnknownArguments = true;
                with.MutuallyExclusive = true;
                with.ParsingCulture = CultureInfo.InvariantCulture;
            });
            return parser.ParseArguments(args, this);
        }
        
    }
}
