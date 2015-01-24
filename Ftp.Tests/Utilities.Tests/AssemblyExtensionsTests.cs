using System;
using System.IO;
using Ftp.InputCommand;
using NUnit.Framework;
using Rhino.Mocks;
using System.Reflection;

namespace Ftp.UnitTests.Utilities.Tests
{
    [TestFixture]
    public class AssemblyExtensionsTests
    {
        public interface IAssemblyLoader
        {
            Assembly GetEntryAssembly();
        }

        public class AssemblyLoader : IAssemblyLoader
        {
            public Assembly GetEntryAssembly()
            {
                return Assembly.GetEntryAssembly();
            }
        }

        private static Assembly GetStubbedAssembly()
        {
            var stubbedAssemblyLoader = MockRepository.GenerateStub<IAssemblyLoader>();

            #if DEBUG
                var stubFilePath = Properties.Resources.DebugAssemblyTestDllFileLocation;
            #else
                var stubFilePath = Properties.Resources.ReleaseAssemblyTestDllFileLocation;
            #endif            
            stubbedAssemblyLoader.Stub(x => x.GetEntryAssembly()).Return(Assembly.LoadFrom(stubFilePath));

            return stubbedAssemblyLoader.GetEntryAssembly();
        }

        [Test]
        public void GetExecutingAssemblyInformationalVersionTest()
        {

            var expected = GetStubbedAssembly().GetExecutingAssemblyInformationalVersion();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyInformationalVersion();

            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetExecutingAssemblyProductNameTest()
        {
            var expected = GetStubbedAssembly().GetExecutingAssemblyProductName();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyProductName();

            StringAssert.AreEqualIgnoringCase(expected, actual);           
        }

        [Test]
        public void GetExecutingAssemblyCopyrightTest()
        {
            var expected = GetStubbedAssembly().GetExecutingAssemblyCopyright();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyCopyright();

            StringAssert.AreEqualIgnoringCase(expected, actual);  

        }

        [Test]
        public void GetExecutingAssemblyDescriptionTest()
        {
            var expected = GetStubbedAssembly().GetExecutingAssemblyDescription();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyDescription();

            StringAssert.AreEqualIgnoringCase(expected, actual);

        }

        [Test]
        public void GetExecutingAssemblyLicenceTest()
        {
            var expected = GetStubbedAssembly().GetExecutingAssemblyLicence();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyLicence();

            StringAssert.AreEqualIgnoringCase(expected, actual);

        }

        [Test]
        public void GetExecutingAssemblyUsageTest()
        {
            var expected = GetStubbedAssembly().GetExecutingAssemblyUsage();
            var actual = Assembly.GetExecutingAssembly().GetExecutingAssemblyUsage();

            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

    }
}
