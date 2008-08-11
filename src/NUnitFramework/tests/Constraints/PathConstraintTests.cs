using System;

namespace NUnit.Framework.Constraints.Tests
{
    /// <summary>
    /// Summary description for PathConstraintTests.
    /// </summary>]
    [TestFixture]
    public class SamePathTest_Windows : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Matcher = new SamePathConstraint( @"C:\folder1\file.tmp" ).IgnoreCase;
            GoodValues = new object[] 
                { 
                    @"C:\folder1\file.tmp", 
                    @"C:\Folder1\File.TMP",
                    @"C:\folder1\.\file.tmp",
                    @"C:\folder1\folder2\..\file.tmp",
                    @"C:\FOLDER1\.\folder2\..\File.TMP",
                    @"C:/folder1/file.tmp"
                };
            BadValues = new object[] 
                { 
                    123,
                    @"C:\folder2\file.tmp",
                    @"C:\folder1\.\folder2\..\file.temp"
                };
            Description = @"Path matching ""C:\folder1\file.tmp""";
        }
    }

    [TestFixture]
    public class SamePathTest_Linux : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Matcher = new SamePathConstraint(@"/folder1/file.tmp").RespectCase;
            GoodValues = new object[] 
                { 
                    @"/folder1/file.tmp", 
                    @"/folder1/./file.tmp",
                    @"/folder1/folder2/../file.tmp",
                    @"/folder1/./folder2/../file.tmp",
                    @"\folder1\file.tmp"
                };
            BadValues = new object[] 
                { 
                    123,
                    @"/folder2/file.tmp",
                    @"/folder1/./folder2/../file.temp",
                    @"/Folder1/File.TMP",
                    @"/FOLDER1/./folder2/../File.TMP",
                };
            Description = @"Path matching ""/folder1/file.tmp""";
        }
    }

    [TestFixture]
    public class SamePathOrUnderTest_Windows : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Matcher = new SamePathOrUnderConstraint( @"C:\folder1\folder2" ).IgnoreCase;
            GoodValues = new object[]
                {
                    @"C:\folder1\folder2",
                    @"C:\Folder1\Folder2",
                    @"C:\folder1\.\folder2",
                    @"C:\folder1\junk\..\folder2",
                    @"C:\FOLDER1\.\junk\..\Folder2",
                    @"C:/folder1/folder2",
                    @"C:\folder1\folder2\folder3",
                    @"C:\folder1\.\folder2\folder3",
                    @"C:\folder1\junk\..\folder2\folder3",
                    @"C:\FOLDER1\.\junk\..\Folder2\temp\..\Folder3",
                    @"C:/folder1/folder2/folder3",
                };
            BadValues = new object[]
                {
                    123,
                    @"C:\folder1\folder3",
                    @"C:\folder1\.\folder2\..\file.temp"
                };
            Description = @"Path under or matching ""C:\folder1\folder2""";
        }
    }

    [TestFixture]
    public class SamePathOrUnderTest_Linux : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Matcher = new SamePathOrUnderConstraint( @"/folder1/folder2"  ).RespectCase;
            GoodValues = new object[]
                {
                    @"/folder1/folder2",
                    @"/folder1/./folder2",
                    @"/folder1/junk/../folder2",
                    @"\folder1\folder2",
                    @"/folder1/folder2/folder3",
                    @"/folder1/./folder2/folder3",
                    @"/folder1/junk/../folder2/folder3",
                    @"\folder1\folder2\folder3",
                };
            BadValues = new object[]
                {
                    123,
                    @"/Folder1/Folder2",
                    @"/FOLDER1/./junk/../Folder2",
                    @"/FOLDER1/./junk/../Folder2/temp/../Folder3",
                    @"/folder1/folder3",
                    @"/folder1/./folder2/../folder3",
					@"/folder1"
                };
            Description = @"Path under or matching ""/folder1/folder2""";
        }
    }
}