using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SearchFight.NetCoreApp;

namespace Unit.Testing
{
    [TestFixture]
    public class GoogleClient_Tests
    {
        GoogleClient googleClient;

        [SetUp]
        public void Setup()
        {
            googleClient = new GoogleClient();
        }

        [TestCase("Python")]
        [TestCase("Java")]
        [TestCase("C sharp")]
        [TestCase("Ruby")]
        public async Task Google_Search_ShouldReturn_Number_GreaterOrEqual_Than_Zero_IfKeysAreValids(String value)
        {
            // Act
            Int64 searchWithGoogle = await googleClient.Search(value);

            // Assert
            if (googleClient.ErrorsLog.Length == 0)
            {
                Assert.GreaterOrEqual(searchWithGoogle, 0);
            }
            else
            {
                Assert.Less(searchWithGoogle, 0);
            }
        }

    }
}
