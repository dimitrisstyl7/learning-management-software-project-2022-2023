using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Project_final_2022_2023.Classes
{
    internal static class ImportData
    {
        //one list for each type of Question
        public static List<Question> questionsType1 = new();
        public static List<Question> questionsType2 = new();
        public static List<Question> questionsType3 = new();
        public static List<Question> questionsType4 = new();
        public static List<Question> questionsType5 = new();
        public static List<Question> questionsType6 = new();

        static ImportData()
        {
            Import_Data();
        }

        private static void Import_Data()
        {
            _Application excel = new _Excel.Application();
            try
            {
                //open and read the file
                
                string path = Path.GetFullPath("questions.xlsx"); //copy relative path of excel file
                Workbook workbook = excel.Workbooks.Open(path); //open it
                Worksheet worksheet = workbook.Worksheets.get_Item(1); //open the first sheet
                _Excel.Range xlRange = worksheet.UsedRange; //save the range value of saved data of the first worksheet

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
                                List<string[]> list = new();

                                // Example : 10+5=|6-3=|9x3=!9÷3|25-10|15+12
                                string[] listElement = value.Split("!");
                                // listElement[0] = 10+5=|6-3=|9x3=
                                // listElement[1] = 9÷3|25-10|15+12

                                string[] colA = listElement[0].Split("|"); // colA = { 10+5=,6-3=,9x3= }
                                list.Add(colA);

                                if (listElement.Length == 2) // Type 5,6.
                                {
                                    string[] colB = listElement[1].Split("|"); // colB = { 9÷3,25-10,15+12 }
                                    list.Add(colB);
                                }
                                question.QAnswers = list;
                                break;
                            case 4:
                                question.QCorrectAns = value.Split("|");
                                break;
                        }
                    }
                    switch(question.QType)
                    {
                        case "1":
                            questionsType1.Add(question);
                            break;
                        case "2":
                            questionsType2.Add(question);
                            break;
                        case "3":
                            questionsType3.Add(question);
                            break;
                        case "4":
                            questionsType4.Add(question);
                            break;
                        case "5":
                            questionsType5.Add(question);
                            break;
                        case "6":
                            questionsType6.Add(question);
                            break;
                    }
                }
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
        
        private static void ReadData()
        {

        }
    }
}
