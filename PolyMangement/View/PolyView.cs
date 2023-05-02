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

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateRemainPoly;

        public void SetPolyBindingSource(BindingSource polyList)
        {
            throw new NotImplementedException();
        }
    }
}
