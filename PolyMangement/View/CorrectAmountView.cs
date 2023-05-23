using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View.Interface
{
    public partial class CorrectAmountView : Form,ICorrectAmountView
    {
        public CorrectAmountView()
        {
            InitializeComponent();
            btnCorrect.Click += delegate { CorrectEvent?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += delegate { this.Close(); };
        }
        public string PCAText 
        {
            get => txtPca.Text;
            set => txtPca.Text = value; 
        }
        public string XinhuaText 
        {
            get => txtXinhua.Text; 
            set => txtXinhua.Text=value;
        }
        public string ASText 
        {
            get => txtAspoly.Text; 
            set => txtAspoly.Text=value;
        }
        public string ARText 
        {
            get => txtArpoly.Text;
            set => txtArpoly.Text=value;
        }
        public string HemlockText 
        { 
            get => txtHemlock.Text;
            set => txtHemlock.Text=value;
        }
        public string ASDopantText 
        { 
            get => txtAsdopant.Text;
            set => txtAsdopant.Text=value;
        }
        public string PHDopantText 
        {
            get => txtPhdopant.Text; 
            set => txtPhdopant.Text=value;
        }
        public string BDopantText 
        {
            get => txtBdopant.Text;
            set => txtBdopant.Text=value;
        }
        public string AqmText 
        {
            get => txtAqm.Text;
            set => txtAqm.Text = value;
        }
        public string YoxingText 
        {
            get => txtYoxing.Text;
            set => txtYoxing.Text=value;
        }
        public string AqmG3Text 
        {
            get => txtAqmG3.Text; 
            set => txtAqmG3.Text=value;
        }
        public string MejingText 
        { 
            get => txtMeijing.Text;
            set => txtMeijing.Text=value;
        }
        public string RemainPCA 
        {
            get => lbPca.Text;
            set => lbPca.Text=value;
        }
        public string RemainXinhua 
        { 
            get => lbXinhua.Text;
            set => lbXinhua.Text=value;
        }
        public string RemainAS 
        { 
            get => lbAspoly.Text;
            set => lbAspoly.Text=value;
        }
        public string RemainAR 
        { 
            get => lbArpoly.Text;
            set => lbArpoly.Text=value;
        }
        public string RemainHemLock 
        { 
            get => lbHemlock.Text;
            set => lbHemlock.Text=value;
        }
        public string RemainASDopant 
        {
            get => lbAsdopant.Text;
            set => lbAsdopant.Text=value;
        }
        public string RemainPHDopant 
        { 
            get => lbPhdopant.Text;
            set => lbPhdopant.Text=value;
        }
        public string RemainBDopant 
        { 
            get => lbBdopant.Text;
            set => lbBdopant.Text=value;
        }
        public string RemainAQM 
        { 
            get => lbAqm.Text;
            set => lbAqm.Text=value;
        }
        public string RemainYoXing 
        { 
            get => lbYoxing.Text;
            set => lbYoxing.Text=value;
        }
        public string RemainAQMG3 
        { 
            get => lbAqmG3.Text;
            set => lbAqmG3.Text=value;
        }
        public string RemainMeJing 
        { 
            get => lbMeijing.Text;
            set => lbMeijing.Text=value;
        }

        public event EventHandler CorrectEvent;


        public static CorrectAmountView instance;
        public static CorrectAmountView GetInstance(Form parenterContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CorrectAmountView();
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
