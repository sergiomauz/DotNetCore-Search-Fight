using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SearchFight.NetCoreApp
{
    public class BingClient : SearchClient
    {
        public override async Task<Int64> Search(String query)
        {
            Dictionary<String, String> headers = new Dictionary<String, String>();
            headers.Add("Ocp-Apim-Subscription-Key", AppConfig.BING_OCP_APIM_SUBSCRIPTION_KEY);

            Dictionary<String, String> queryVars = new Dictionary<String, String>();
            queryVars.Add("q", query);

            String jsonResponseBing = await MakeGetRequest(AppConfig.BING_END_POINT, AppConfig.BING_SEARCH_ACTION, headers, queryVars);
            try
            {
                // Deserializing to dynamic object using Newtonsoft.Json
                dynamic parsedResponseBing = JsonConvert.DeserializeObject(jsonResponseBing);

                return Convert.ToInt64(parsedResponseBing.webPages.totalEstimatedMatches);
            }
            catch
            {
                return -1;
            }
        }
    }
}
