using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public interface IPolyView
    {
        string PCAText { get;set;}
        string XinhuaText { get; set; }
        string ASText { get; set; }
        string ARText { get; set; }
        string HemlockText { get; set; }

        string RemainPCA { get; set; }
        string RemainXinhua { get; set; }
        string RemainAS { get; set; }
        string RemainAR { get; set; }
        string RemainHemLock { get; set; }

        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateRemainPolyEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetPolyBindingSource(BindingSource stockList);

        void Show();
    }
}
