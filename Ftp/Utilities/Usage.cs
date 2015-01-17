﻿using System;

namespace Ftp.Utilities
{
    public sealed class Usage
    {
        private const String UsageText =
            "Usage: ftp [options] <hostname> <username> <password> [<remote file> [<local file>]]\n" +
            "\nDefault behavior is to download a file and use ASCII transfer mode.\n" +

            "\t-h - list hidden files (applies to -l and -n only)\n" +
            "\t-k secs - use keep-alive timer (setControlKeepAliveTimeout)\n" +
            "\t-l - list files using LIST (remote is used as the pathname if provided)\n" +
            "\t     Files are listed twice: first in raw mode, then as the formatted parsed data.\n" +
            "\t-L - use lenient future dates (server dates may be up to 1 day into future)\n" +
            "\t-n - list file names using NLST (remote is used as the pathname if provided)\n" +
            "\t-p true|false|protocol[,true|false] - use FTPSClient with the specified protocol and/or isImplicit setting\n" +
            "\t-t - list file details using MLST (remote is used as the pathname if provided)\n" +
            "\t-w msec - wait time for keep-alive reply (setControlKeepAliveReplyTimeout)\n" +
            "\t-T  all|valid|none - use one of the built-in TrustManager implementations (none = JVM default)\n" +
            "\t-PrH server[:port] - HTTP Proxy host and optional port[80] \n" +
            "\t-PrU user - HTTP Proxy server username\n" +
            "\t-PrP password - HTTP Proxy server password\n" +
            "\t-# - add hash display during transfers\n";

        public void PrintUsageText()
        {
            Console.WriteLine(UsageText);
        }
    }
}
