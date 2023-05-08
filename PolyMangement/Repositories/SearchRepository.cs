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
            UseCondition(currentTime, shift);
            BuildExcel(targetStart, targetEnd);
        }
        public IEnumerable<SearchModel> GetByValue(DateTime currentTime, string shift)
        {
            UseCondition(currentTime, shift);
            return GetDataFromSQLite(targetStart, targetEnd);
        }
        private void BuildExcel(string targetStart, string targetEnd)
        {
            var searchList = new List<SearchModel>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                var adapter = new SQLiteDataAdapter($"SELECT * FROM  test WHERE time>='{targetStart}' AND time<'{targetEnd}'", conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // 建立一個Excel物件
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                // 將DataGridView中的資料輸出到Excel檔案中
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
                workbook.SaveAs("output.xlsx");  // 儲存Excel檔案
                // 關閉所有物件
                workbook.Close();
                excel.Quit();
                conn.Close();
            }
        }
    }
}
