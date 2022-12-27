using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Project_final_2022_2023.Classes
{
    internal static class ImportData
    {
        //one list with the 6 final questions
        public static List<Question> finalQuestions = new();

        //one list for each type of Question
        private static List<Question> questionsType1 = new();
        private static List<Question> questionsType2 = new();
        private static List<Question> questionsType3 = new();
        private static List<Question> questionsType4 = new();
        private static List<Question> questionsType5 = new();
        private static List<Question> questionsType6 = new();

        static ImportData()
        {
            ReadFile();
            SelectQuestions();
        }
        
        private static void ReadFile()
        {
            _Application excel = new _Excel.Application();
            try
            {
                //open and read the file

                string path = Path.GetFullPath("questions.xlsx"); //copy relative path of excel file
                Workbook workbook = excel.Workbooks.Open(path); //open it
                Worksheet worksheet = workbook.Worksheets.get_Item(1); //open the first sheet
                _Excel.Range xlRange = worksheet.UsedRange; //save the range value of saved data of the first worksheet
                ReadAndSaveQuestions(xlRange, worksheet, workbook); //read and save questions from the sheet
            }
            catch
            {
                /////// SOMETHING WENT WRONG MESSAGE //////
            }
            finally
            {
                excel.Quit();
            }
        }

        private static void ReadAndSaveQuestions(_Excel.Range xlRange, Worksheet worksheet, Workbook workbook)
        {
            for (int row = 2; row <= xlRange.Rows.Count; row++)
            {
                Question question = ReadQuestion(xlRange, worksheet, row);
                SaveQuestion(question);
            }
            workbook.Close(false);
        }

        private static Question ReadQuestion(_Excel.Range xlRange, Worksheet worksheet, int row)
        {
            Question question = new();

            for (int column = 1; column <= xlRange.Columns.Count; column++)
            {
                var value_temp = worksheet.Cells[row, column].Value2;
                if (value_temp == null) break;
                string value = value_temp.ToString();
                switch (column)
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
                    case 5:
                        question.QTime = Int32.Parse(value);
                        break;
                }
            }
            return question;
        }

        private static void SaveQuestion(Question question)
        {
            switch (question.QType)
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

        private static void SelectQuestions()
        {
            int duration = 0;
            Question question;

            question = questionsType1[RndIndex(questionsType1.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            question = questionsType2[RndIndex(questionsType2.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            question = questionsType3[RndIndex(questionsType3.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            question = questionsType4[RndIndex(questionsType4.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            question = questionsType5[RndIndex(questionsType5.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            question = questionsType6[RndIndex(questionsType6.Count)];
            finalQuestions.Add(question);
            duration += question.QTime;

            SetTotalTime(duration);
        }

        private static int RndIndex(int length)
        {
            return new Random().Next(length);
        }

        private static void SetTotalTime(int duration)
        {
            Question.QTotalTime = duration;
        }
    }
}
