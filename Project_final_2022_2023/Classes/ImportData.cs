using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Project_final_2022_2023.Classes
{
    internal static class ImportData
    {
        public static List<Question> Questions { get; set; }

        static ImportData()
        {
            Import_Data();
        }
        private static void Import_Data()
        {
            _Application excel = new _Excel.Application();
            try
            {
                string path = Path.GetFullPath("questions.xlsx");
                Workbook workbook = excel.Workbooks.Open(path);
                Worksheet worksheet = workbook.Worksheets.get_Item(1);
                var xlRange = worksheet.UsedRange;
                List<Question> questionsList = new();

                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    Question question = new();

                    for (int j = 1; j <= xlRange.Columns.Count; j++)
                    {
                        var value_temp = worksheet.Cells[i, j].Value2;
                        if (value_temp == null) break;
                        string value = value_temp.ToString();
                        switch (j)
                        {
                            case 1:
                                question.QText = value;
                                break;
                            case 2:
                                question.QType = value;
                                break;
                            case 3:
                                List<String[]> list = new();

                                // Example : 10+5=|6-3=|9x3=!9÷3|25-10|15+12
                                String[] listElement = value.Split("!");
                                // listElement[0] = 10+5=|6-3=|9x3=
                                // listElement[1] = 9÷3|25-10|15+12

                                String[] colA = listElement[0].Split("|"); // colA = { 10+5=,6-3=,9x3= }
                                list.Add(colA);

                                if (listElement.Length == 2) // Type 5,6.
                                {
                                    String[] colB = listElement[1].Split("|"); // colB = { 9÷3,25-10,15+12 }
                                    list.Add(colB);
                                }
                                question.QAnswers = list;
                                break;
                            case 4:
                                question.QCorrectAns = value.Split("|");
                                break;
                        }
                    }
                    questionsList.Add(question);
                }
                Questions = questionsList;
                workbook.Close(false);
            }
            catch {
                /////// SOMETHING WENT WRONG MESSAGE //////
            }
            finally
            {
                excel.Quit();
            }
        }
    }
}
