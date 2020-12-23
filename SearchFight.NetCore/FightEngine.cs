using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SearchFight.NetCoreApp
{
    public class FightEngine
    {
        private List<String> errorsLog = new List<String>();
        
        public String[] GetErrorsLog()
        {
            return errorsLog.ToArray();
        }
        public async Task<DataTable> GetResultsFromSearchEngines(String[] queries)
        {
            DataRow dataRow;

            errorsLog.Clear();

            GoogleClient googleClient = new GoogleClient();
            BingClient bingClient = new BingClient();

            DataTable searchDataTable = new DataTable();
            searchDataTable.Columns.Add("Language", typeof(String));
            searchDataTable.Columns.Add("Google", typeof(Int64));
            searchDataTable.Columns.Add("Bing", typeof(Int64));
            searchDataTable.Columns.Add("Total", typeof(Int64));

            foreach (String q in queries)
            {
                var searchWithGoogle = googleClient.Search(q);
                var searchWithBing = bingClient.Search(q);

                await Task.WhenAll(searchWithBing, searchWithGoogle);
                
                dataRow = searchDataTable.NewRow();
                dataRow["Language"] = q;
                dataRow["Google"] = searchWithGoogle.Result;
                dataRow["Bing"] = searchWithBing.Result;
                dataRow["Total"] = (searchWithGoogle.Result == -1 ? 0 : searchWithGoogle.Result)
                                + (searchWithBing.Result == -1 ? 0 : searchWithBing.Result);

                searchDataTable.Rows.Add(dataRow);
            }

            errorsLog.AddRange(googleClient.ErrorsLog);
            errorsLog.AddRange(bingClient.ErrorsLog);

            return searchDataTable;
        }
        public DataRow GetWinner(DataTable fightTable, Int32 engine)
        {
            Int32 indexWinner = 0;
            for (Int32 i = 1; i < fightTable.Rows.Count; i++)
            {
                if (Convert.ToInt64(fightTable.Rows[i].ItemArray[engine]) > Convert.ToInt64(fightTable.Rows[indexWinner].ItemArray[engine]))
                {
                    indexWinner = i;
                }
            }

            DataRow dataRow = fightTable.Rows[indexWinner];

            return dataRow;
        }
    }
}
