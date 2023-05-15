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
                CalculateTimeIntervalEvent?.Invoke(this, EventArgs.Empty);
                ShowCorrespondRecipeEvent?.Invoke(this, EventArgs.Empty);
                CalRedopantEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string StartYearText 
        {
            get => txtStartYear.Text;
            set => txtStartYear.Text=value;
        }
        public string StartMonthDayText 
        { 
            get => txtStartMD.Text;
            set => txtStartMD.Text=value;
        }
        public string StartHourMinsText 
        { 
            get => txtStartHM.Text;
            set => txtStartHM.Text=value;
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
        public string RuleText 
        { 
            get => lbRedopantTime.Text;
            set => lbRedopantTime.Text=value;
        }


        public string EndYearText 
        {
            get => txtEndYear.Text;
            set => txtEndYear.Text=value;
        }
        public string EndMonthDayText 
        { 
            get => txtEndMD.Text;
            set => txtEndMD.Text = value;
        }
        public string EndHourMinsText 
        {
            get => txtEndHM.Text;
            set => txtEndHM.Text = value;
        }
        public event EventHandler ShowCorrespondRecipeEvent;
        public event EventHandler CalculateTimeIntervalEvent;
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
