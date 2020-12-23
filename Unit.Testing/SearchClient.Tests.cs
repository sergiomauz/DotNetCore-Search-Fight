using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SearchFight.NetCoreApp;
using System.Collections.Generic;

namespace Unit.Testing
{
    [TestFixture]
    class SearchClient_Tests
    {
        SearchClient searchClient;

        [SetUp]
        public void Setup()
        {
            searchClient = new SearchClient();
        }

        [TestCase("Python")]
        [TestCase("Java")]
        [TestCase("C sharp")]
        [TestCase("Ruby")]
        public async Task Generic_Search_ShouldReturn_Number_GreaterOrEqual_Than_Zero_If_KeyIsValid(String value)
        {            
            // Act
            Int64 searchWithGeneric= await searchClient.Search(value);

            // Assert
            if (searchClient.ErrorsLog.Length == 0)
            {
                Assert.GreaterOrEqual(searchWithGeneric, 0);
            }
            else
            {
                Assert.Less(searchWithGeneric, 0);
            }
        }

        [Test]
        public void ErrorsLog_AlwaysReturns_Number_GreaterOrEqual_Than_Zero()
        {
            // Assert
            Assert.GreaterOrEqual(searchClient.ErrorsLog.Length, 0);
        }

        [Test]
        public async Task MakeGetRequest_ToGoogle_AlwaysReturns_anHTMLDocument_WithValueOfQueryVarsInside()
        {
            // Arrange
            Dictionary<String, String> headers = new Dictionary<String, String>();
            headers.Add("Something", "Anything");

            Dictionary<String, String> queryVars = new Dictionary<String, String>();
            queryVars.Add("q", "javascript");            

            String googleHtmlResponse = await searchClient
                                        .MakeGetRequest("https://www.google.com", 
                                                        "/", 
                                                        headers,
                                                        queryVars);

            // Assert
            Assert.IsTrue(googleHtmlResponse.Contains("autocomplete=\"off\" value=\"javascript\" title=\"Buscar con Google\" maxlength=\"2048\" name=\"q\""));
        }
    }
}
