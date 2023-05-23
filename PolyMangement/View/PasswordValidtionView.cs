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
        public static PasswordValidtionView instance;
        public static PasswordValidtionView GetInstance(Form parenterContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PasswordValidtionView();
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
