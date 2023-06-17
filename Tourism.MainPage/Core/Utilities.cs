using Microsoft.Office.Interop.Excel;
using System;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Tourism.MainPage.Core
{
    public static class Utilities
    {

        public static void ExportCustomerOperationToExcel(DataGrid dataGrid, string documentCode)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet = (Worksheet)workbook.Worksheets[1];

                Range rangeDocumentCode = (Range)sheet.Cells[1, 1];
                rangeDocumentCode.Cells[1, 1].Font.Bold = true;
                rangeDocumentCode.Columns[1].ColumnWidth = documentCode.Length;
                rangeDocumentCode.Value2 = documentCode;

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    Range range = (Range)sheet.Cells[2, i + 1];
                    sheet.Cells[2, i + 1].Font.Bold = true;
                    //sheet.Columns[i + 1].ColumnWidth = dataGrid.Columns[i].MinWidth;
                    sheet.Columns[i + 1].ColumnWidth = 20;
                    range.Value2 = dataGrid.Columns[i].Header;
                }

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Items.Count; j++)
                    {
                        TextBlock textBlock = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                        Range range = (Range)sheet.Cells[j + 3, i + 1];
                        range.Value2 = textBlock.Text;
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Tarot", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public static void ExportToExcel(DataGrid dataGrid)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet = (Worksheet)workbook.Worksheets[1];

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    Range range = (Range)sheet.Cells[1, i + 1];
                    sheet.Cells[1, i + 1].Font.Bold = true;
                    //sheet.Columns[i + 1].ColumnWidth = dataGrid.Columns[i].MinWidth;
                    sheet.Columns[i + 1].ColumnWidth = 20;
                    range.Value2 = dataGrid.Columns[i].Header;
                }

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Items.Count; j++)
                    {
                        TextBlock textBlock = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                        Range range = (Range)sheet.Cells[j + 2, i + 1];
                        range.Value2 = textBlock.Text;
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Tarot", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        public static void ExportReservationDetailToExcel(DataGrid dataGrid, string reservationCode)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet = (Worksheet)workbook.Worksheets[1];

                Range rangeDocumentCode = (Range)sheet.Cells[1, 1];
                rangeDocumentCode.Cells[1, 1].Font.Bold = true;
                rangeDocumentCode.Columns[1].ColumnWidth = reservationCode.Length;
                rangeDocumentCode.Value2 = reservationCode;

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    Range range = (Range)sheet.Cells[2, i + 1];
                    sheet.Cells[2, i + 1].Font.Bold = true;
                    //sheet.Columns[i + 1].ColumnWidth = dataGrid.Columns[i].MinWidth;
                    sheet.Columns[i + 1].ColumnWidth = 20;
                    range.Value2 = dataGrid.Columns[i].Header;
                }

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Items.Count; j++)
                    {
                        TextBlock textBlock = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                        Range range = (Range)sheet.Cells[j + 3, i + 1];
                        range.Value2 = textBlock.Text;
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Tarot", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
