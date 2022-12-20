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
            try
            {
                _Application excel = new _Excel.Application();
                string path = Path.GetFullPath("Questions.xlsx");
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
                                question.QAnswers = value;
                                break;
                            case 4:
                                question.QCorrectAns = value;
                                break;
                        }
                    }
                    questionsList.Add(question);
                }
                Questions = questionsList;
                workbook.Close(false);
                excel.Quit();
            }
            catch {
                /////// SOMETHING WENT WRONG MESSAGE //////
            }
        }
    }
}
