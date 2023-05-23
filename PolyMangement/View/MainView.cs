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
    public partial class MainView : Form,IMainView
    {
        public MainView()
        {
            InitializeComponent();
            ButtonFunctionCollection();
        }

        private void ButtonFunctionCollection()
        {
            btnCharge.Click += delegate 
            {
                CloseOtherForms();
                ShowStockListEvent?.Invoke(this, EventArgs.Empty);
            };
            btnSearch.Click+=delegate 
            {
                CloseOtherForms();
                SearchStockListEvent?.Invoke(this, EventArgs.Empty); 
            };
            btnRedopant.Click+=delegate 
            {
                CloseOtherForms();
                CalculateRedopantEvent?.Invoke(this, EventArgs.Empty); 
            };
            btnCorrectAndValid.Click += delegate
            {
                CloseOtherForms();
                PasswordValidEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        
        public event EventHandler ShowStockListEvent;
        public event EventHandler SearchStockListEvent;
        public event EventHandler CalculateRedopantEvent;
        public event EventHandler CorrectAmountEvent;
        public event EventHandler PasswordValidEvent;

        public void CloseOtherForms()
        {
            foreach (Form form in MdiChildren)
            {
                form.Close();
                form.Dispose();
            }
        }
    }
}
