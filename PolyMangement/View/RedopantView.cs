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

        public event EventHandler ShowCorrespondRecipeEvent;
        public event EventHandler CalTimeIntervalEvent;
        public event EventHandler CalRedopantEvent;
    }
}
