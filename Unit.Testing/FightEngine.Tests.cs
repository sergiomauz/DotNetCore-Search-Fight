using NUnit.Framework;
using System;
using System.Data;
using System.Threading.Tasks;
using SearchFight.NetCoreApp;

namespace Unit.Testing
{
    [TestFixture]
    public class FightEngine_Tests
    {
        FightEngine fightEngine;

        [SetUp]
        public void Setup()
        {
            fightEngine = new FightEngine();
        }

        [Test]
        public async Task Search_ShouldHave_4Columns_And_NRows()
        {            
            // Arrange
            String[] queries = new String[4];
            queries[0] = "Javascript";
            queries[1] = "Python";
            queries[2] = "C sharp";
            queries[3] = "Ruby";

            Int32 expectedColumns = 4;
            Int32 expectedRows = queries.Length;

            // Act
            DataTable fightTable = await fightEngine.GetResultsFromSearchEngines(queries);

            // Assert
            Assert.AreEqual(expectedRows, fightTable.Rows.Count);
            Assert.AreEqual(expectedColumns, fightTable.Columns.Count);
        }

        [Test]
        public async Task Search_ShouldHave_QErrors_EqualsTo_QNegatives()
        {
            // Arrange
            String[] queries = new String[4];
            queries[0] = "Javascript";
            queries[1] = "Python";
            queries[2] = "C sharp";
            queries[3] = "Ruby";
            Int32 expectedErrors = 0;

            // Act
            DataTable fightTable = await fightEngine.GetResultsFromSearchEngines(queries);
            for (Int32 i = 0; i < fightTable.Rows.Count; i++)
            {
                for (Int32 j = 1; j < fightTable.Columns.Count - 1; j++)
                {
                    if (Convert.ToInt64(fightTable.Rows[i].ItemArray[j]) < 0)
                    {
                        expectedErrors++;
                    }
                }
            }
            String[] errorsLog = fightEngine.GetErrorsLog();

            // Assert
            Assert.AreEqual(expectedErrors, errorsLog.Length);
        }

        [Test]
        public void Search_ShouldHaveA_EngineWinner_If_AtLeastAPositive()
        {
            // Arrange
            DataRow dataRow;

            DataTable searchDataTable = new DataTable();
            searchDataTable.Columns.Add("Language", typeof(String));
            searchDataTable.Columns.Add("Google", typeof(Int64));
            searchDataTable.Columns.Add("Bing", typeof(Int64));
            searchDataTable.Columns.Add("Total", typeof(Int64));

            dataRow = searchDataTable.NewRow();
            dataRow["Language"] = "Javascript";
            dataRow["Google"] = 10000000;
            dataRow["Bing"] = -1;
            dataRow["Total"] = 10000000;
            searchDataTable.Rows.Add(dataRow);

            dataRow = searchDataTable.NewRow();
            dataRow["Language"] = "Python";
            dataRow["Google"] = -1;
            dataRow["Bing"] = 50000000;
            dataRow["Total"] = 50000000;
            searchDataTable.Rows.Add(dataRow);

            // Act 1 & 2
            DataRow drWinner1 = fightEngine.GetWinner(searchDataTable, 1);
            DataRow drWinner2 = fightEngine.GetWinner(searchDataTable, 2);


            // Assert
            Assert.IsTrue(Convert.ToInt64(drWinner1.ItemArray[1]) > 0);
            Assert.IsTrue(Convert.ToInt64(drWinner2.ItemArray[2]) > 0);
        }

        [Test]
        public void Search_ShouldNotHaveA_TotalWinner_If_TotalIsZero()
        {
            // Arrange
            DataRow dataRow;

            DataTable searchDataTable = new DataTable();
            searchDataTable.Columns.Add("Language", typeof(String));
            searchDataTable.Columns.Add("Google", typeof(Int64));
            searchDataTable.Columns.Add("Bing", typeof(Int64));
            searchDataTable.Columns.Add("Total", typeof(Int64));

            dataRow = searchDataTable.NewRow();
            dataRow["Language"] = "Javascript";
            dataRow["Google"] = -1;
            dataRow["Bing"] = -1;
            dataRow["Total"] = 0;
            searchDataTable.Rows.Add(dataRow);

            dataRow = searchDataTable.NewRow();
            dataRow["Language"] = "Python";
            dataRow["Google"] = -1;
            dataRow["Bing"] = -1;
            dataRow["Total"] = 0;
            searchDataTable.Rows.Add(dataRow);

            // Act
            DataRow drWinner = fightEngine.GetWinner(searchDataTable, 3);

            // Assert
            Assert.IsFalse(Convert.ToInt64(drWinner.ItemArray[3]) > 0);
        }
    }
}