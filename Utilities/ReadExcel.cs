using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2demo.Utilities
{
    public class ReadExcel
    {
        public static string ExcelData(int Cell, int Rowvalue)
        {
            string path = @"C:\Users\mindtree2090\source\repos\2demo\InputData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0); //sheet number
            var row = sheet.GetRow(Rowvalue); //row number
            string Data = row.GetCell(Cell).StringCellValue.Trim(); //clm/cell number
            Console.WriteLine("the search data from excels is " + Data);
            return Data;

        }
    }
}
