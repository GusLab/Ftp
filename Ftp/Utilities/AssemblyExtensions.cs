using System;
using System.Diagnostics;
using System.Reflection;
using CommandLine;

namespace Ftp.InputCommand
{
    public static class AssemblyExtensions
    {
        public static String GetExecutingAssemblyInformationalVersion(this Assembly executingAssembly)
        {
            return ((AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(
            executingAssembly, typeof(AssemblyInformationalVersionAttribute), false))
           .InformationalVersion; 
        }

        public static String GetExecutingAssemblyProductName(this Assembly executingAssembly)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return versionInfo.ProductName;
        }

        public static String GetExecutingAssemblyCopyright(this Assembly executingAssembly)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return versionInfo.LegalCopyright;
        }

        public static String GetExecutingAssemblyDescription(this Assembly executingAssembly)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return versionInfo.Comments;
        }

        public static String GetExecutingAssemblyLicence(this Assembly executingAssembly)
        {
            return ((AssemblyLicenseAttribute)Attribute.GetCustomAttribute(
            executingAssembly, typeof(AssemblyLicenseAttribute), false))
           .Value;
        }

        public static String GetExecutingAssemblyUsage(this Assembly executingAssembly)
        {
            return ((AssemblyUsageAttribute)Attribute.GetCustomAttribute(
            executingAssembly, typeof(AssemblyUsageAttribute), false))
           .Value;
        }

        
    }
}
