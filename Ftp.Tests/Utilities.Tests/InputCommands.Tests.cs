using System;
using Ftp.Utilities;
using NUnit.Framework;

namespace Ftp.UnitTests.Utilities.Tests
{
    [TestFixture]
    public class InputCommandsTests
    {
        [Test]
        public void ParseInputCommandsTest()
        {
            var inputCommands = new InputCommands();

            var parseInputCommandArgs = new String[5]
            {
                "-s",
                "-e",
                "-PrP",
                "password",
                "-#"
            };
            

            Assert.IsTrue(inputCommands.StoreFile);
            Assert.IsTrue(inputCommands.UseEpsvWithIPv4);
            StringAssert.AreEqualIgnoringCase(parseInputCommandArgs[3],inputCommands.ProxyPassword);
            Assert.IsTrue(inputCommands.PrintHash);
        }

        [Test]
        public void ParseInputCommandsFailTimeoutTest()
        {
            var inputCommands = new InputCommands();

            var parseInputCommandArgs = new String[5]
            {
                "-s",
                "-e",
                "-PrP",
                "password",
                "-#"
            };

            Assert.IsTrue(inputCommands.StoreFile);
            Assert.IsTrue(inputCommands.UseEpsvWithIPv4);
            StringAssert.AreEqualIgnoringCase(parseInputCommandArgs[3], inputCommands.ProxyPassword);
            Assert.IsTrue(inputCommands.PrintHash);
        }
    }
}
