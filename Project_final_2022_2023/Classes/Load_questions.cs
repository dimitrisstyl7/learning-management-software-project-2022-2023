using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Project_final_2022_2023.Classes
{
    internal class Load_questions
    {
        private _Application excel;
        private string path;
        private int sheet;
        private Workbook wb;
        private Worksheet ws;

        public Load_questions(RichTextBox box) {
            excel = new _Excel.Application();
            path = "Questions.xlsx";
            sheet = 1;
            path = System.IO.Path.GetFullPath(path);
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
            ReadCell(box);
            wb.Close(false);
            excel.Quit();
        }

        private void ReadCell(RichTextBox box)
        {
            int i = 2, j = 1; // i row, j cell.
            if (ws.Cells[i, j].Value2 != null)
                box.Text = ws.Cells[i, j].Value2;
        }
    }
}
