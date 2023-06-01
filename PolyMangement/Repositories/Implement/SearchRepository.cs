using PolyMangement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace PolyMangement.Repositories
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(string connection)
        {
            connectionString=connection;
        }

        public void ExportExcel(DateTime currentTime, string shift)     
        {
            string timeInterval = UseCondition(currentTime, shift);
            BuildExcel(timeInterval);
        }
        public IEnumerable<StockModel> GetByValue(DateTime currentTime, string shift)
        {
            string timeInterval=UseCondition(currentTime, shift);
            return GetDataFromSQLite(timeInterval);
        }
        private void BuildExcel(string timeInterval)
        {
            var searchList = new List<StockModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                var adapter = new SQLiteDataAdapter(timeInterval, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = table.Columns[i].ColumnName;
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = table.Rows[i][j].ToString();
                    }
                }
                workbook.SaveAs("output.xlsx");  
                workbook.Close();
                excel.Quit();
                conn.Close();
            }
        }
        protected string UseCondition(DateTime selectedTime, string shift)
        {
            string targetStart;
            string targetEnd;
            if (shift == "當班使用情況")
            {
                TimeSpan choiceTime = Convert.ToDateTime(selectedTime.ToShortTimeString()).TimeOfDay;
                TimeSpan dayStart = DateTime.Parse("08:00").TimeOfDay;
                TimeSpan dayEnd = DateTime.Parse("20:00").TimeOfDay;
                targetEnd = selectedTime.ToLongTimeString();
                if (choiceTime >= dayStart && choiceTime < dayEnd)
                {
                    targetStart = selectedTime.ToString("yyyy-MM-dd 08:00:00");
                }
                else if (choiceTime > dayEnd)
                {
                    targetStart = selectedTime.ToString("yyyy-MM-dd 20:00:00");
                }
                else
                {
                    targetStart = selectedTime.AddDays(-1).ToString("yyyy-MM-dd 20:00:00");
                }
            }
            else
            {
                targetStart = shift == "日班" ? selectedTime.ToString("yyyy-MM-dd 08:00:00") : selectedTime.ToString("yyyy-MM-dd 20:00:00");
                targetEnd = shift == "日班" ? selectedTime.ToString("yyyy-MM-dd 20:00:00") : selectedTime.AddDays(1).ToString("yyyy-MM-dd 08:00:00");
            }
            return $@"SELECT id,machine,SUM(poly1),SUM(poly2),SUM(poly3),SUM(poly4),SUM(poly5),
                    SUM(dopant1),SUM(dopant2),SUM(dopant3),SUM(crucible1) ,SUM(crucible2),SUM(crucible3),SUM(crucible4),time
                    FROM  test
                    WHERE time>='{targetStart}' AND time<'{targetEnd}' 
                    GROUP BY machine";
        }
    }
}
