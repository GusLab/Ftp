using System;
using Ftp.Utilities;
using NUnit.Framework;

namespace Ftp.Tests
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
            inputCommands.ParseInputCommands(parseInputCommandArgs);

            Assert.IsTrue(inputCommands.StoreFile);
            Assert.IsTrue(inputCommands.UseEpsvWithIPv4);
            StringAssert.AreEqualIgnoringCase(parseInputCommandArgs[3],inputCommands.ProxyPassword);
            Assert.IsTrue(inputCommands.PrintHash);
        }
    }
}
