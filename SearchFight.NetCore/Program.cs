using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.NetCoreApp
{
    class Program
    {
        static void PrintTable(DataTable fightTable)
        {
            DataColumn dataColumn;
            DataRow dataRow;

            Console.WriteLine("".PadRight(25 * fightTable.Columns.Count, '-'));

            StringBuilder strToPrint = new StringBuilder();
            for (int j = 0; j < fightTable.Columns.Count; j++)
            {
                dataColumn = fightTable.Columns[j];
                strToPrint.Append(dataColumn.ColumnName.ToUpper().PadRight(25, ' '));
                strToPrint.Append("\t");
            }
            Console.WriteLine(strToPrint);

            for (int i = 0; i < fightTable.Rows.Count; i++)
            {
                strToPrint.Clear();
                dataRow = fightTable.Rows[i];
                for (int j = 0; j < fightTable.Columns.Count; j++)
                {
                    strToPrint.Append((dataRow.ItemArray[j].ToString() == "-1"
                                        ? "(*)"
                                        : dataRow.ItemArray[j].ToString()
                                       ).PadRight(25, ' '));
                    strToPrint.Append("\t");
                }
                Console.WriteLine(strToPrint);
            }
        }

        static void PrintWinners(FightEngine fightEngine, DataTable fightTable)
        {
            DataRow dataRow;
            DataColumn dataColumn;

            Console.WriteLine("".PadRight(25 * fightTable.Columns.Count, '-'));

            for (Int32 j = 1; j < fightTable.Columns.Count; j++)
            {
                dataRow = fightEngine.GetWinner(fightTable, j);
                dataColumn = fightTable.Columns[j];

                if (Convert.ToInt64(dataRow.ItemArray[j]) > 0)
                {
                    Console.WriteLine(String.Format("{0}: \"{1}\" with {2} coincidences."
                                        , dataColumn.ColumnName.ToUpper()
                                        , dataRow.ItemArray[0].ToString()
                                        , dataColumn.ToString()));
                }
                else if (Convert.ToInt64(dataRow.ItemArray[j]) == 0)
                {
                    Console.WriteLine(String.Format("{0}: There are no coincidences to evaluate."
                                        , dataColumn.ColumnName.ToUpper()));
                }
                else
                {
                    Console.WriteLine(String.Format("{0}: There was a problem while getting information from the API."
                                        , dataColumn.ColumnName.ToUpper()));
                }
            }
        }

        static void PrintErrors(String[] errors)
        {
            Console.WriteLine("".PadRight(25, '-') + "\nERRORS DETECTED");
            for (Int32 i = 0; i < errors.Length; i++)
            {
                Console.WriteLine(String.Format("{0}: {1}", i + 1, errors[i]));
            }
        }

        static async Task Main(String[] args)
        {
            String[] stringArrayToEval;
            if (args.Length == 0)
            {
                List<String> exampleList = new List<String>();
                exampleList.Add("python");
                exampleList.Add("java");
                exampleList.Add("ruby");
                exampleList.Add("c sharp");

                stringArrayToEval = exampleList.ToArray();
            }
            else
            {
                stringArrayToEval = args;
            }

            Console.Clear();
            Console.WriteLine(String.Format("You are comparing {0} languages: {1}\n", stringArrayToEval.Length, String.Join(" | ", stringArrayToEval)));

            FightEngine fightEngine = new FightEngine();
            DataTable fightTable = await fightEngine.GetResultsFromSearchEngines(stringArrayToEval);

            PrintTable(fightTable);
            PrintWinners(fightEngine, fightTable);

            // OPTIONAL: Print errors if they exist
            String[] errors = fightEngine.GetErrorsLog();
            if (errors.Length > 0)
            {
                PrintErrors(errors);
            }

            Console.WriteLine("\nFinishing the program...");
        }
    }
}
