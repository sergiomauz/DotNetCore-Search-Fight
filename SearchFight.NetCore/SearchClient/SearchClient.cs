using System;
using System.Linq;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SearchFight.NetCoreApp
{
    interface ISearchClient
    {
        Task<String> MakeGetRequest(String endPoint, String action, Dictionary<String, String> headers, Dictionary<String, String> queryVars);
        Task<DataTable> Search(String[] queries);        
        String[] GetErrorsLog();
    }

    public class SearchClient
    {
        private List<String> errorsLog = new List<String>();

        public async Task<String> MakeGetRequest(String endPoint, String action, Dictionary<String, String> headers, Dictionary<String, String> queryVars)
        {
            try
            {
                HttpClient http_client = new HttpClient();

                if (headers != null)
                {
                    foreach (KeyValuePair<String, String> header in headers)
                    {
                        http_client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                String queryString = "";
                if (queryVars != null)
                {
                    queryString = "?" + String.Join("&", queryVars.Select(queryvar => queryvar.Key + "=" + queryvar.Value));
                }

                String taskSearch = await http_client.GetStringAsync(String.Format("{0}{1}{2}", endPoint, action, queryString));

                return taskSearch;
            }
            catch (Exception e)
            {
                this.errorsLog.Add(e.Message);
                return String.Empty;
            }
        }        
        
        public virtual async Task<Int64> Search(String query)
        {
            Dictionary<String, String> headers = new Dictionary<String, String>();
            headers.Add("Authorization", AppConfig.GENERIC_AUTHORIZATION_KEY);

            Dictionary<String, String> queryVars = new Dictionary<String, String>();
            queryVars.Add("q", query);

            String jsonResponse = await MakeGetRequest(AppConfig.GENERIC_END_POINT, AppConfig.GENERIC_SEARCH_ACTION, headers, queryVars);

            try
            {
                // Deserializing to dynamic object using Newtonsoft.Json
                dynamic parsedResponse = JsonConvert.DeserializeObject(jsonResponse);

                return Convert.ToInt64(parsedResponse.totalResults);
            }
            catch
            {
                return -1;
            }
        }

        public String[] ErrorsLog
        {
            get
            {
                return errorsLog.ToArray();
            }            
        }
    }
}
