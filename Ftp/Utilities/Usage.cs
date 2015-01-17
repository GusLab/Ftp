using System;

namespace Ftp.Utilities
{
    public sealed class Usage
    {
        private const String UsageText =
            "Usage: ftp [options] <hostname> <username> <password> [<remote file> [<local file>]]\n" +
            "\nDefault behavior is to download a file and use ASCII transfer mode.\n" +

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
