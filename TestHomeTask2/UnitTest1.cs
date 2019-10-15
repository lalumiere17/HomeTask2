using HomeTask2;
using System;
using System.IO;
using Xunit;

namespace TestHomeTask2
{
    public class UnitTest1
    {
        [Fact]
        public void TestFileCompressorOutFileExists()
        {
            Assert.Throws<IOException>( () =>
            {
                File.Create("./../../../files/test 2.txt");
                FileCopressor.Compress("./../../../files/test 1.txt", "./../../../files/test 2.txt");
            });
        }

        [Fact]
        public void TestFileCompressorException()
        {
            Assert.Throws<Exception>(() =>
            {
                FileCopressor.Compress("./../../../files/test 3.txt", "./../../../files/test_3.txt");
            });
        }

        [Fact]
        public void TestFileDumperWithoutParameters()
        {
            Assert.Throws<Exception>(() =>
            {
                FileDumper.Minidump();
            });
        }

        [Fact]
        public void TestFileDumper1000AsPerameter()
        {
            Assert.Throws<Exception>(() =>
            {
                FileDumper.Minidump(1000);
            });
        }
    }
}