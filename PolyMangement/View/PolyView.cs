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
    public partial class PolyView : Form,IPolyView
    {
        private bool isEdit;
        private bool aqmRad;
        private bool yoxingRad;
        private bool aqmG3Rad;
        private bool mejingRad;

        public PolyView()
        {
            InitializeComponent();
            ButtonFunctionList();
            tabControl1.TabPages.Remove(ChargeDetail);
        }

        private void ButtonFunctionList()
        {
            btnAdd.Click += delegate 
            {
                tabControl1.TabPages.Remove(ChargeList);
                tabControl1.TabPages.Add(ChargeDetail);
            };
            btnEdit.Click+=delegate 
            { 
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeList);
                tabControl1.TabPages.Add(ChargeDetail);
            };
            btnDel.Click+=delegate 
            { 
                DeleteEvent?.Invoke(this, EventArgs.Empty);

            };
            btnSave.Click += delegate 
            { 
                SaveEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Add(ChargeList);
            };
            btnCancel.Click += delegate 
            { 
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Add(ChargeList);
            };
        }

        public string PCAText 
        { 
            get => txtPCA.Text;
            set => txtPCA.Text=value;
        }
        public string XinhuaText 
        {
            get => txtXinhua.Text;
            set => txtXinhua.Text = value;
        }
        public string ASText 
        {
            get => txtAS.Text;
            set => txtAS.Text=value;    
        }
        public string ARText 
        { 
            get => txtAR.Text;
            set => txtAR.Text = value;
        }
        public string HemlockText 
        {
            get => txtHemLock.Text; 
            set => txtHemLock.Text=value;
        }
        
        public string machineNum 
        {
            get => comboBoxMachine.Text;
            set => comboBoxMachine.Text=value;
        }
        public bool IsEdit 
        {
            get => isEdit;
            set => isEdit = value;
        }
        public string chargeTime 
        { 
            get => lbTime.Text;
            set => lbTime.Text=value;
        }
        public string idText 
        { 
            get => lbId.Text;
            set => lbId.Text=value;
        }
        public string ASDopantText 
        {
            get => txtASDopant.Text;
            set => txtASDopant.Text=value;
        }
        public string PHDopantText 
        { 
            get => txtPhDopant.Text;
            set => txtPhDopant.Text=value;
        }
        public string BDopantText 
        { 
            get => txtBDopant.Text;
            set => txtBDopant.Text=value;
        }
        public bool AqmRadio 
        {
            get => radioButtonAQM.Checked;
            set => aqmRad=value;
        }
        public bool YoxingRad 
        {
            get => radioButtonYoXin.Checked;
            set => yoxingRad=value;
        }
        public bool AqmG3Rad 
        {
            get => radioButtonAQMG3.Checked;
            set => aqmG3Rad=value;
        }
        public bool MejingRad 
        {
            get => radioButtonMejing.Checked;
            set => mejingRad=value;
        }

        public string RemainPCA
        {
            get => lbPCA.Text;
            set => lbPCA.Text = value;
        }
        public string RemainXinhua
        {
            get => lbXinhua.Text;
            set => lbXinhua.Text = value;
        }
        public string RemainAS
        {
            get => lbAS.Text;
            set => lbAS.Text = value;
        }
        public string RemainAR
        {
            get => lbAR.Text;
            set => lbAR.Text = value;
        }
        public string RemainHemLock
        {
            get => lbHemLock.Text;
            set => lbHemLock.Text = value;
        }
        public string RemainASDopant 
        {
            get => lbAsDopant.Text; 
            set => lbAsDopant.Text=value;
        }
        public string RemainPHDopant 
        {
            get => lbPhDopant.Text;
            set => lbPhDopant.Text=value;
        }
        public string RemainBDopant 
        { 
            get => lbBDopant.Text;
            set => lbBDopant.Text=value;
        }
        public string RemainAQM 
        {
            get => lbAQM.Text;
            set => lbAQM.Text=value;
        }
        public string RemainYoXing 
        {
            get => lbYoXin.Text;
            set => lbYoXin.Text=value;
        }
        public string RemainAQMG3 
        {
            get => lbAQMG3.Text;
            set => lbAQMG3.Text=value;
        }
        public string RemainMeJing 
        { 
            get => lbMejing.Text;
            set => lbMejing.Text=value;
        }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPolyBindingSource(BindingSource stockList)
        {
            dataGridView1.DataSource = stockList;
        }


        private static PolyView instance;
        public static PolyView GetInstance(Form parenterContainer)
        {
            if (instance==null || instance.IsDisposed)
            {
                instance = new PolyView();
                instance.MdiParent = parenterContainer;
                instance.FormBorderStyle=FormBorderStyle.None;
            }
            else
            {
                if (instance.WindowState==FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }
                instance.BringToFront();
            }
            return instance;
        }
    }
}
