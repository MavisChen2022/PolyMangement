using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public class BaseView:Form, IBaseView
    {
        private BaseView instance;

        public BaseView Instance 
        {
            get => instance; 
            set => instance=value;
        }

        public BaseView GetInstance(Form parenterContainer)
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new BaseView();
                Instance.MdiParent = parenterContainer;
                Instance.FormBorderStyle = FormBorderStyle.None;
                Instance.Dock = DockStyle.Fill;
                Instance.AutoSize = true;
                Instance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            else
            {
                if (Instance.WindowState == FormWindowState.Minimized)
                {
                    Instance.WindowState = FormWindowState.Normal;
                }
                Instance.BringToFront();

            }
            return Instance;
        }
    }
}
