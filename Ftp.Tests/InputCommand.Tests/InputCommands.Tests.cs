using System;
using System.IO;
using System.Linq;
using System.Text;
using Ftp.InputCommand;
using NUnit.Framework;

namespace Ftp.UnitTests.InputCommand.Tests
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
        public void GetUsageAllHelpTextListedTest()
        {
            
            var inputCommands = new InputCommands();
            var expected = LoadUsageTestFile().Replace("\r\n","\n").Replace("\n",Environment.NewLine);            
            var actual = inputCommands.GetUsage();

            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
        
        [Test]
        public void ParseInputMandatoryCommandsOkTest()
        {
            var inputCommands = new InputCommands();

            var parseInputCommandArgs = new String[10]
            {
                "--server",
                "255.255.255.255:21",
                "-u",
                "user",
                "-p",
                "password",
                "--remote-path",
                "\\test",
                "--local-path",
                "\\local"
            };

            var result = inputCommands.ParseInputCommands(parseInputCommandArgs);

            Assert.IsTrue(result);
            Assert.IsTrue(inputCommands.Server.Contains("255.255.255.255"));
            Assert.IsTrue(inputCommands.Server.Contains("21"));
            Assert.IsTrue(inputCommands.Username == "user");
            Assert.IsTrue(inputCommands.Password == "password");
            Assert.IsTrue(inputCommands.RemotePath == "\\test");
            Assert.IsTrue(inputCommands.LocalPath == "\\local");
            
        }

        [Test]
        public void ParseInputMandatoryCommandsMissingErrorHelpShownTest()
        {
            var inputCommands = new InputCommands();
            var fakeConsoleBuffer = new StringBuilder();
            var fakeConsole = new StringWriter(fakeConsoleBuffer);
            var result = false;
            var consoleOutput = "";
            Console.SetOut(fakeConsole);
            Console.SetError(fakeConsole);

            var parseInputCommandArgs = new String[1]
            {
                "--console"
            };

            result = inputCommands.ParseInputCommands(parseInputCommandArgs);

            consoleOutput = fakeConsoleBuffer.ToString();

            Assert.IsTrue(!result);
            StringAssert.Contains("--local-path required option is missing.",consoleOutput);
            StringAssert.Contains("--password required option " + Environment.NewLine + "is missing.", consoleOutput);
            StringAssert.Contains("--server " + Environment.NewLine + "required option is missing.", consoleOutput);
            StringAssert.Contains("--user required option is missing.", consoleOutput);
            StringAssert.Contains("--remote-path required option is missing.", consoleOutput);
        }

        [Test]
        public void ParseInputUnsupportedCommandsAreIgnoredTest()
        {
            var inputCommands = new InputCommands();
            var fakeConsoleBuffer = new StringBuilder();
            var fakeConsole = new StringWriter(fakeConsoleBuffer);
            var result = false;
            var consoleOutput = "";
            Console.SetOut(fakeConsole);
            Console.SetError(fakeConsole);

            var parseInputCommandArgs = new String[11]
            {
                "--server",
                "255.255.255.255:21",
                "-u",
                "user",
                "-p",
                "password",
                "--remote-path",
                "\\test",
                "--local-path",
                "\\local",
                "--asdigASId"
            };

            result = inputCommands.ParseInputCommands(parseInputCommandArgs);

            consoleOutput = fakeConsoleBuffer.ToString();

            Assert.IsTrue(result);     
            StringAssert.AreEqualIgnoringCase("",consoleOutput);
        }

        [Test]
        public void ParseInputParseErrorsShowErrorTextTest()
        {
            var inputCommands = new InputCommands();
            var fakeConsoleBuffer = new StringBuilder();
            var fakeConsole = new StringWriter(fakeConsoleBuffer);
            var result = false;
            var consoleOutput = "";
            Console.SetOut(fakeConsole);
            Console.SetError(fakeConsole);

            var parseInputCommandArgs = new String[14]
            {
                "--server",
                "255.255.255.255:21",
                "-u",
                "user",
                "-p",
                "password",
                "--remote-path",
                "\\test",
                "--local-path",
                "\\local",
                "--keep-alive-timeout",
                "forest",
                "--keep-alive-reply-timeout",
                "forest2"
            };

            result = inputCommands.ParseInputCommands(parseInputCommandArgs);

            consoleOutput = fakeConsoleBuffer.ToString();

            Assert.IsTrue(!result);
            StringAssert.Contains("--keep-alive-timeout option violates format.", consoleOutput);
            StringAssert.Contains("--keep-alive-reply-timeout option violates format.", consoleOutput);
        } 
    }
}
