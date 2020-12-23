using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SearchFight.NetCoreApp;

namespace Unit.Testing
{
    [TestFixture]
    public class BingClient_Tests
    {
        BingClient bingClient;

        [SetUp]
        public void Setup()
        {
            bingClient = new BingClient();
        }

        [TestCase("Python")]
        [TestCase("Java")]
        [TestCase("C sharp")]
        [TestCase("Ruby")]
        public async Task Bing_Search_ShouldReturn_Number_GreaterOrEqual_Than_Zero_IfKeyIsValid(String value)
        {
            // Act
            Int64 searchWithBing = await bingClient.Search(value);

            // Assert
            if (bingClient.ErrorsLog.Length == 0)
            {
                Assert.GreaterOrEqual(searchWithBing, 0);
            }
            else
            {
                Assert.Less(searchWithBing, 0);
            }
        }
    }
}
