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
        private bool isChargeIN = false;
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
            tabControl1.TabPages.Remove(ChargeIn);
        }

        private void Default()
        {
            comboBoxMachine.Text = "K01";
        }

        private void ButtonCollections()
        {
            btnOut.Click += delegate 
            {
                isChargeIN = false;
                tabControl1.TabPages.Remove(ChargeList);
                tabControl1.TabPages.Add(ChargeDetail);
            };
            btnEdit.Click+=delegate 
            {
                isChargeIN = false;
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeList);
                tabControl1.TabPages.Add(ChargeDetail);
            };
            btnDel.Click+=delegate 
            { 
                DeleteEvent?.Invoke(this, EventArgs.Empty);

            };
            btnIn.Click += delegate
            {
                isChargeIN = true;
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Remove(ChargeList);
                tabControl1.TabPages.Add(ChargeIn);
            };


            btnOutSave.Click += delegate 
            {
                isChargeIN = false;
                SaveEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Remove(ChargeIn);
                tabControl1.TabPages.Add(ChargeList);
            };
            btnOutCancel.Click += delegate 
            {
                isChargeIN = false;
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Remove(ChargeIn);
                tabControl1.TabPages.Add(ChargeList);
            };
            btnInSave.Click += delegate
            {
                isChargeIN=true;
                SaveEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Remove(ChargeIn);
                tabControl1.TabPages.Add(ChargeList);
            };
            btnInCancel.Click += delegate
            {
                isChargeIN = false;
                tabControl1.TabPages.Remove(ChargeDetail);
                tabControl1.TabPages.Remove(ChargeIn);
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
        public string poly11Text 
        {
            get => txtPoly11.Text; 
            set => txtPoly11.Text=value;
        }
        public string poly22Text 
        { 
            get => txtPoly22.Text;
            set => txtPoly22.Text=value;
        }
        public string poly33Text 
        { 
            get => txtPoly33.Text;
            set => txtPoly33.Text=value;
        }
        public string poly44Text 
        { 
            get => txtPoly44.Text;
            set => txtPoly44.Text=value;
        }
        public string poly55Text 
        { 
            get => txtPoly55.Text;
            set => txtPoly55.Text=value;
        }
        public string dopant11Text 
        {
            get => txtdopant11.Text;
            set => txtdopant11.Text=value;
        }
        public string dopant22Text 
        { 
            get => txtdopant22.Text;
            set => txtdopant22.Text=value;
        }
        public string dopant33Text 
        { 
            get => txtdopant33.Text;
            set => txtdopant33.Text=value;
        }
        public string crucible11Text 
        {
            get => txtCrocible11.Text;
            set => txtCrocible11.Text=value;
        }
        public string crucible22Text 
        { 
            get => txtCrocible22.Text;
            set => txtCrocible22.Text=value;
        }
        public string crucible33Text 
        { 
            get => txtCrocible33.Text;
            set => txtCrocible33.Text=value;
        }
        public string crucible44Text 
        { 
            get => txtCrocible44.Text;
            set => txtCrocible44.Text=value;
        }
        public bool IsChargeIN 
        { 
            get => isChargeIN; 
            set => isChargeIN=value;
        }
        public Color RemainPoly1Color { set => lbPoly1.ForeColor = value; }
        public Color RemainPoly2Color { set => lbPoly2.ForeColor = value; }
        public Color RemainPoly3Color { set => lbPoly3.ForeColor = value; }
        public Color RemainPoly4Color { set => lbPoly4.ForeColor = value; }
        public Color RemainPoly5Color { set => lbPoly5.ForeColor = value; }
        public Color RemainDopant1Color { set => lbDopant1.ForeColor = value; }
        public Color RemainDopant2Color { set => lbDopant2.ForeColor = value; }
        public Color RemainDopant3Color { set => lbDopant3.ForeColor = value; }
        public Color RemainCrucible1Color { set => lbCrucible1.ForeColor = value; }
        public Color RemainCrucible2Color { set => lbCrucible2.ForeColor = value; }
        public Color RemainCrucible3Color { set => lbCrucible3.ForeColor = value; }
        public Color RemainCrucible4Color { set => lbCrucible4.ForeColor = value; }

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
