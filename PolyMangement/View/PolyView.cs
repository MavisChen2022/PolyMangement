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
    public partial class PolyView : Form, IPolyView
    {
        private bool isEdit;
        private bool cru1Rad=false;
        private bool cru2Rad = false;
        private bool cru3Rad = false;
        private bool cru4Rad = false;

        public PolyView()
        {
            InitializeComponent();
            Default();
            ButtonCollections();
            tabControl1.TabPages.Remove(ChargeDetail);
        }

        private void Default()
        {
            comboBoxMachine.Text = "K01";
        }

        private void ButtonCollections()
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
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Add(ChargeList);
            };
        }

        public string poly1Text
        { 
            get => txtPoly1.Text;
            set => txtPoly1.Text=value;
        }
        public string poly2Text
        {
            get => txtPoly2.Text;
            set => txtPoly2.Text = value;
        }
        public string poly3Text
        {
            get => txtPoly3.Text;
            set => txtPoly3.Text=value;    
        }
        public string poly4Text
        { 
            get => txtPoly4.Text;
            set => txtPoly4.Text = value;
        }
        public string poly5Text
        {
            get => txtPoly5.Text; 
            set => txtPoly5.Text=value;
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
        public string dopant1Text
        {
            get => txtDopant1.Text;
            set => txtDopant1.Text=value;
        }
        public string dopant2Text
        { 
            get => txtDopant2.Text;
            set => txtDopant2.Text=value;
        }
        public string dopant3Text
        { 
            get => txtDopant3.Text;
            set => txtDopant3.Text=value;
        }
        public bool crucible1Rad
        {
            get => cru1Rad;
            set => cru1Rad = value;
        }
        public bool crucible2Rad
        {
            get => cru2Rad;
            set => cru2Rad=value;
        }
        public bool crucible3Rad
        {
            get => cru3Rad;
            set => cru3Rad=value;
        }
        public bool crucible4Rad
        {
            get => cru4Rad;
            set => cru4Rad=value;
        }

        public string RemainPoly1
        {
            get => lbPoly1.Text;
            set => lbPoly1.Text = value;
        }
        public string RemainPoly2
        {
            get => lbPoly2.Text;
            set => lbPoly2.Text = value;
        }
        public string RemainPoly3
        {
            get => lbPoly3.Text;
            set => lbPoly3.Text = value;
        }
        public string RemainPoly4
        {
            get => lbPoly4.Text;
            set => lbPoly4.Text = value;
        }
        public string RemainPoly5
        {
            get => lbPoly5.Text;
            set => lbPoly5.Text = value;
        }
        public string RemainDopant1 
        {
            get => lbDopant1.Text; 
            set => lbDopant1.Text=value;
        }
        public string RemainDopant2 
        {
            get => lbDopant2.Text;
            set => lbDopant2.Text=value;
        }
        public string RemainDopant3 
        { 
            get => lbDopant3.Text;
            set => lbDopant3.Text=value;
        }
        public string RemainCrucible1 
        {
            get => lbCrucible1.Text;
            set => lbCrucible1.Text=value;
        }
        public string RemainCrucible2 
        {
            get => lbCrucible2.Text;
            set => lbCrucible2.Text=value;
        }
        public string RemainCrucible3 
        {
            get => lbCrucible3.Text;
            set => lbCrucible3.Text=value;
        }
        public string RemainCrucible4 
        { 
            get => lbCrucible4.Text;
            set => lbCrucible4.Text=value;
        }
        

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;

        public void SetPolyBindingSource(BindingSource stockList)
        {
            dataGridView1.DataSource = stockList;
        }
        
        
        public static PolyView instance;
        public static PolyView GetInstance(Form parenterContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PolyView();
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
        private void cru1RadChecked(object sender, EventArgs e)
        {
            if (cru1Rad)
            {
                radioButtonCrucible1.Checked = false;
                cru1Rad = false;
            }
            else
            {
                radioButtonCrucible1.Checked = true;
                cru1Rad = true;
                cru2Rad = false;
                cru3Rad = false;
                cru4Rad = false;
            }
        }
        private void cru2RadChecked(object sender, EventArgs e)
        {
            if (cru2Rad)
            {
                radioButtonCrucible2.Checked = false;
                cru2Rad = false;
            }
            else
            {
                radioButtonCrucible2.Checked = true;
                cru2Rad = true;
                cru1Rad = false;
                cru3Rad = false;
                cru4Rad = false;
            }
        }
        private void cru3RadChecked(object sender, EventArgs e)
        {
            if (cru3Rad)
            {
                radioButtonCrucible3.Checked = false;
                cru3Rad = false;

            }
            else
            {
                radioButtonCrucible3.Checked = true;
                cru3Rad = true;
                cru2Rad = false;
                cru1Rad = false;
                cru4Rad = false;
            }
        }
        private void cru4RadChecked(object sender, EventArgs e)
        {
            if (cru4Rad)
            {
                radioButtonCrucible4.Checked = false;
                cru4Rad = false;
            }
            else
            {
                radioButtonCrucible4.Checked = true;
                cru4Rad = true;
                cru3Rad = false;
                cru2Rad = false;
                cru1Rad = false;
            }
        }
    }
}
