using Microsoft.Office.Interop.Excel;
using System.Runtime.CompilerServices;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Project_final_2022_2023.Classes
{
    internal static class ImportData
    {
        /*public static List<Question> Questions 
        { 
            get { return Questions; }
            set { Questions = value; }
        }*/
        private static List<Question> questions;

        public static List<Question> getQuestions() { return questions; }

        public static void Import_Data()
        {
            try
            {
                _Application excel = new _Excel.Application();
                string path = Path.GetFullPath("Questions.xlsx");
                Workbook workbook = excel.Workbooks.Open(path);
                Worksheet worksheet = workbook.Worksheets.get_Item(1);
                var xlRange = worksheet.UsedRange;

                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    Question question = new();

                    for (int j = 1; j <= xlRange.Columns.Count; j++)
                    {
                        var value = worksheet.Cells[i, j].Value2;
                        if (value == null) break;

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
                    questions.Add(question);
                }
                workbook.Close(false);
                excel.Quit();
            }
            catch {
                /////// SOMETHING WENT WRONG MESSAGE //////
            }
        }
    }
}
