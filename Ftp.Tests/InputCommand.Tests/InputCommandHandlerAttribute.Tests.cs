using Ftp.InputCommand;
using NUnit.Framework;
using StringAssert = NUnit.Framework.StringAssert;

namespace Ftp.UnitTests.InputCommand.Tests
{
    [TestFixture]
    public class InputCommandHandlerAttributeTests
    {
        class InputCommandHandlerTestClass
        {
            [InputCommandHandler(TestPropertyMethod,new InputCommands())]
            public string TestPropertyAttribute
            { get; set; }

            private static bool TestPropertyMethod(InputCommands command)
            {
                return false;
            }
        }

        [Test]
        public void CheckPerformCommandAttributeWorksTest()
        {

            

            StringAssert.AreEqualIgnoringCase("", "1");
        }
    }
}
