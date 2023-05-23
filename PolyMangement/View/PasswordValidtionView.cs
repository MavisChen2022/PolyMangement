using PolyMangement.View.Interface;
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
    public partial class PasswordValidtionView : Form,IPasswordValidtionView
    {

        public PasswordValidtionView()
        {
            InitializeComponent();
            btnLogin.Click += delegate
            {
                PasswordValidationEvent?.Invoke(this, EventArgs.Empty);
            };
            btnCancel.Click += delegate
            {
                this.Close();
            };
        }

        public string PasswordText 
        { 
            get => txtPassword.Text;
        }

        public event EventHandler PasswordValidationEvent;
        public void CloseValidation()
        {
            this.Close();
        }
    }
}
