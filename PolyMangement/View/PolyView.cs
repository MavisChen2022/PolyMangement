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
                //AddEvent?.Invoke(this, EventArgs.Empty);
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
            set => txtXinhua.Text=value;
        }
        public string ASText 
        {
            get => txtAS.Text;
            set => txtAS.Text=value;    
        }
        public string ARText 
        { 
            get => txtAR.Text;
            set => txtAR.Text=value;
        }
        public string HemlockText 
        {
            get => txtHemLock.Text; 
            set => txtHemLock.Text=value;
        }
        public string RemainPCA 
        {
            get => lbPCA.Text;
            set => lbPCA.Text=value;
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
        public string machineNum 
        {
            get => comboBoxMachine.Text;
            set => comboBoxMachine.Text=value;
        }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateRemainPolyEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPolyBindingSource(BindingSource stockList)
        {
            dataGridView1.DataSource = stockList;
        }
    }
}
