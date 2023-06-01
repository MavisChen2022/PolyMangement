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
        public string poly1Text 
        {
            get => txtPoly1.Text;
            set => txtPoly1.Text = value; 
        }
        public string poly2Text 
        {
            get => txtPoly2.Text; 
            set => txtPoly2.Text=value;
        }
        public string poly3Text 
        {
            get => txtPoly3.Text; 
            set => txtPoly3.Text=value;
        }
        public string poly4Text 
        {
            get => txtPoly4.Text;
            set => txtPoly4.Text=value;
        }
        public string poly5Text 
        { 
            get => txtPoly5.Text;
            set => txtPoly5.Text=value;
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
        public string crucible1Text 
        {
            get => txtCrucible1.Text;
            set => txtCrucible1.Text = value;
        }
        public string crucible2Text 
        {
            get => txtCrucible2.Text;
            set => txtCrucible2.Text=value;
        }
        public string crucible3Text 
        {
            get => txtCrucible3.Text; 
            set => txtCrucible3.Text=value;
        }
        public string crucible4Text 
        { 
            get => txtCrucible4.Text;
            set => txtCrucible4.Text=value;
        }
        public string RemainPoly1 
        {
            get => lbPoly1.Text;
            set => lbPoly1.Text=value;
        }
        public string RemainPoly2 
        { 
            get => lbPoly2.Text;
            set => lbPoly2.Text=value;
        }
        public string RemainPoly3 
        { 
            get => lbPoly3.Text;
            set => lbPoly3.Text=value;
        }
        public string RemainPoly4 
        { 
            get => lbPoly4.Text;
            set => lbPoly4.Text=value;
        }
        public string RemainPoly5 
        { 
            get => lbPoly5.Text;
            set => lbPoly5.Text=value;
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
