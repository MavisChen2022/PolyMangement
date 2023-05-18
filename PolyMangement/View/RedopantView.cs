using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private string recipeName;
        public RedopantView()
        {
            InitializeComponent();
            Default();
            ButtonCollections();
        }

        private void Default()
        {
            comboboxNeckTimes.SelectedItem = "1";
            txtStartYear.Text = DateTime.Now.Year.ToString();
            txtEndYear.Text = DateTime.Now.Year.ToString();
            txtStartMD.MaxLength = 5;
            txtStartHM.MaxLength = 4;
        }
        private void ButtonCollections()
        {
            btnRecipe1.Click += delegate
            {
                recipeName = btnRecipe1.Text;
                ButtonActions();
            };
            btnRecipe2.Click += delegate
            {
                recipeName = btnRecipe2.Text;
                ButtonActions();
            };
            btnRecipe3.Click += delegate
            {
                recipeName = btnRecipe3.Text;
                ButtonActions();
            };
            btnRecipe4.Click += delegate
            {
                recipeName = btnRecipe4.Text;
                ButtonActions();
            };
            btnRecipe5.Click += delegate
            {
                recipeName = btnRecipe5.Text;
                ButtonActions();
            };
        }
        private void ButtonActions()
        {
            CalculateTimeIntervalEvent?.Invoke(this, EventArgs.Empty);
            ShowCorrespondRecipeEvent?.Invoke(this, EventArgs.Empty);
            UpdateRecipeNameEvent?.Invoke(this, EventArgs.Empty);
            CalRedopantEvent?.Invoke(this, EventArgs.Empty);
        }

        [StringLength(4)]
        public string StartYearText 
        {
            get => txtStartYear.Text;
            set => txtStartYear.Text=value;
        }

        [StringLength(5,MinimumLength =3)]
        public string StartMonthDayText 
        { 
            get => txtStartMD.Text;
            set => txtStartMD.Text=value;
        }

        [StringLength(5, MinimumLength = 4)]
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

        [StringLength(4)]
        public string EndYearText 
        {
            get => txtEndYear.Text;
            set => txtEndYear.Text=value;
        }

        [StringLength(5, MinimumLength = 3)]
        public string EndMonthDayText 
        { 
            get => txtEndMD.Text;
            set => txtEndMD.Text = value;
        }

        [StringLength(5, MinimumLength = 4)]
        public string EndHourMinsText 
        {
            get => txtEndHM.Text;
            set => txtEndHM.Text = value;
        }
        public string RecipeName 
        {
            get => recipeName;
        }
        public string RecipeNameText
        {
            get => lbRecipeName.Text;
            set => lbRecipeName.Text = value;
        }
        public string RedopantWeightText 
        { 
            get => lbRedopantWeight.Text; 
            set => lbRedopantWeight.Text=value;
        }

        public event EventHandler ShowCorrespondRecipeEvent;
        public event EventHandler CalculateTimeIntervalEvent;
        public event EventHandler CalRedopantEvent;
        public event EventHandler UpdateRecipeNameEvent;

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
                instance.Dock = DockStyle.Fill;
                instance.AutoSize = true;
                instance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Maximized;
                }
                instance.BringToFront();
            }
            return instance;
        }
    }
}
