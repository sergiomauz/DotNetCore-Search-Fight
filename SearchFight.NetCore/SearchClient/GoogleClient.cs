using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace SearchFight.NetCoreApp
{
    public class GoogleClient : SearchClient
    {
        public override async Task<Int64> Search(String query)
        {
            Dictionary<String, String> queryVars = new Dictionary<String, String>();
            queryVars.Add("key", AppConfig.GOOGLE_KEY);
            queryVars.Add("cx", AppConfig.GOOGLE_CX);
            queryVars.Add("q", query);

            String jsonResponseGoogle = await MakeGetRequest(AppConfig.GOOGLE_END_POINT, AppConfig.GOOGLE_SEARCH_ACTION, null, queryVars);            
            try
            {
                // Parsing using System.Text.Json (better performance than Newtonsoft)
                var parsedResponseGoogle = JsonDocument.Parse(jsonResponseGoogle);                
                String totalResults = parsedResponseGoogle.RootElement
                                        .GetProperty("searchInformation")
                                        .GetProperty("totalResults").GetString();

                return Convert.ToInt64(totalResults);
            }
            catch
            {
                return -1;
            }
        }
    }
}
