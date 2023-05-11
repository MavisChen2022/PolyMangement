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
    public partial class RedopantView : Form,IRedopantView
    {
        public RedopantView()
        {
            InitializeComponent();
            btnRecipe1.Click += delegate
            {
                CalTimeIntervalEvent?.Invoke(this, EventArgs.Empty);
                ShowCorrespondRecipeEvent?.Invoke(this, EventArgs.Empty);
                CalRedopantEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string YearText 
        {
            get => txtEndYear.Text;
            set => txtEndYear.Text=value;
        }
        public string MonthDayText 
        { 
            get => txtEndMD.Text;
            set => txtEndMD.Text=value;
        }
        public string HourMinsText 
        { 
            get => txtEndHM.Text;
            set => txtEndHM.Text=value;
        }
        public string NeckTimes 
        {
            get => comboboxNeckTimes.Text;
            set => comboboxNeckTimes.Text=value;
        }
        public string RealText 
        { 
            get => lbReal.Text;
            set => lbReal.Text=value;
        }
        public string RemeltText 
        { 
            get => lbRedopantTime.Text;
            set => lbRedopantTime.Text=value;
        }
        public string testTime
        {
            get => YearText+"-" + MonthDayText + " " + HourMinsText;
        }
        public string testStartTime
        {
            get => DateTime.Now.ToString("yyyy-MMDD HHmm");
        }

        public event EventHandler ShowCorrespondRecipeEvent;
        public event EventHandler CalTimeIntervalEvent;
        public event EventHandler CalRedopantEvent;

        public void SetRedopantBindingSource(BindingSource redopantRecipe)
        {
            dataGridView1.DataSource = redopantRecipe;
        }
        private static RedopantView instance;
        public static RedopantView GetInstance(Form parenterContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new RedopantView();
                instance.MdiParent = parenterContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
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
