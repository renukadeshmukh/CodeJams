using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace JuggleFest
{
    public class ExcelLibrary
    {
        public Application App { get; set; }
        public Workbook Wb { get; set; }
        public Worksheet Ws { get; set; }

        public void Initialize() 
        {
            object misValue = System.Reflection.Missing.Value;
            App = new Microsoft.Office.Interop.Excel.Application();
            if (App == null)
            {
                Console.WriteLine("\nExcel is not properly installed!!");
                return;
            }
            App.Visible = true;
            Wb = App.Workbooks.Add(1);
            //Wb.Save();
            Wb.SaveAs(@"G:\GitHub\CodeJams\JuggleFest\JuggleFest\Fest11.xlsx");
            Ws = Wb.Sheets.Add();
            Ws.Name = "JuggleFest";
        }

        public void WriteToExcel(int row, int col, int value)
        {
            string colName = GetColumnNumberToName(col);
            Ws.Cells[row, colName].Value2 = value;
            
        }

        public void WriteRangeToExcel(int sRow,int sCol, int eRow, int eCol, int[,] values)
        {
            string begin = string.Empty;
            string end = string.Empty;
            var startCell = Ws.Cells[sRow, sCol];
            var endCell = Ws.Cells[eRow, eCol];
            try
            {
                // access range by Property and cells indicating start and end           
                var writeRange = Ws.Range[startCell, endCell];
                writeRange.Value2 = values;
            }
            catch (COMException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int[,] ReadRangeFromExcel(int sRow, int sCol, int eRow, int eCol) {
            string begin = string.Concat(sRow, GetColumnNumberToName(sCol));
            string end = string.Concat(eRow, GetColumnNumberToName(eCol));
            int[,] values = (int[,])Ws.Cells[begin+":"+end].Value;
            return values;
        }

        public void Close()
        {
            Wb.Close(true);
            App.Quit();

            ReleaseObject(Ws);
            ReleaseObject(Wb);
            ReleaseObject(App);
        }

        public int ReadExcel(int row, int column) {
            string colName = GetColumnNumberToName(column);
            return -1;
        }

        public string GetColumnNumberToName(int col)
        {
            int dividend = col;
            string colName = string.Empty;
            int mod;

            while (dividend > 0)
            {
                mod = (dividend - 1) % 26;
                colName = Convert.ToChar(65 + mod).ToString() + colName;
                dividend = (int)((dividend - mod) / 26);
            }
            return colName;
        }

        public int GetColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("\nException Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
