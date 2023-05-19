using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public partial class SearchView : Form,ISearchView
    {
        public SearchView()
        {
            InitializeComponent();
            ButtonFunctionCollection();
        }

        private void ButtonFunctionCollection()
        {
            btnSearch.Click +=delegate{ SearchEvent?.Invoke(this, EventArgs.Empty); };
            btnExportExcel.Click += delegate { ExportExcelEvent?.Invoke(this, EventArgs.Empty); };
        }

        public DateTime SearchTime 
        { 
            get => dateTimePicker1.Value;
            set => dateTimePicker1.Value=value;
        }
        public string DayNight 
        {
            get => comboBoxDayNight.Text;
            set => comboBoxDayNight.Text=value;
        }
        private bool isExportCurrentFile;
        public bool IsExportCurrentFile 
        { 
            get => isExportCurrentFile;
            set => isExportCurrentFile=value; 
        }

        public event EventHandler SearchEvent;
        public event EventHandler ExportExcelEvent;

        public void SetSearchBindingSource(BindingSource stockList)
        {
            dataGridView1.DataSource = stockList;
        }

        private static SearchView instance;
        public static SearchView GetInstance(Form parenterContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SearchView();
                instance.MdiParent = parenterContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
                instance.AutoSize = true;
                instance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }
                instance.BringToFront();
            }
            return instance;
        }
    }
}
