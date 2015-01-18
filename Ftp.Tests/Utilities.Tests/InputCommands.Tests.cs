using System;
using System.IO;
using Ftp.Utilities;
using NUnit.Framework;

namespace Ftp.UnitTests.Utilities.Tests
{
    [TestFixture]
    public class InputCommandsTests
    {

        private static string LoadUsageTestFile()
        {
            #if DEBUG
            var filePath = Properties.Resources.DebugUsageTestFileLocation;
            #else
            var filePath = Properties.Resources.ReleaseUsageTestFileLocation;
            #endif

            var streamReader = new StreamReader(filePath);
            var usageText = streamReader.ReadToEnd();
            streamReader.Close();

            return usageText;
        }

        [Test]
        public void GetUsageTest()
        {
            
            var inputCommands = new InputCommands();
            var expected = LoadUsageTestFile().Replace("\r\n","\n").Replace("\n",Environment.NewLine);            
            var actual = inputCommands.GetUsage();

            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
        
        [Test]
        public void ParseInputCommandsTest()
        {
            var inputCommands = new InputCommands();

            var parseInputCommandArgs = new String[5]
            {
                "--keep-alive-reply-timeout",
                "55",
                "-u",
                "user",
                "-#"
            };

            inputCommands.ParseInputCommands(parseInputCommandArgs);

            Assert.IsTrue(inputCommands.KeepAliveReplyTimeout == 55);
            Assert.IsTrue(inputCommands.ProxyUser == "user");
            Assert.IsTrue(inputCommands.IsPrintHash == true);
            
        }
    }
}
