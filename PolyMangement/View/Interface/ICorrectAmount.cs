using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.View.Interface
{
    public interface ICorrectAmount
    {
        string PCAText { get; set; }
        string XinhuaText { get; set; }
        string ASText { get; set; }
        string ARText { get; set; }
        string HemlockText { get; set; }
        string ASDopantText { get; set; }
        string PHDopantText { get; set; }
        string BDopantText { get; set; }

        string AqmText { get; set; }
        string YoxingText { get; set; }
        string AqmG3Text { get; set; }
        string MejingText { get; set; }


        bool IsEdit { get; set; }

        string RemainPCA { get; set; }
        string RemainXinhua { get; set; }
        string RemainAS { get; set; }
        string RemainAR { get; set; }
        string RemainHemLock { get; set; }
        string RemainASDopant { get; set; }
        string RemainPHDopant { get; set; }
        string RemainBDopant { get; set; }
        string RemainAQM { get; set; }
        string RemainYoXing { get; set; }
        string RemainAQMG3 { get; set; }
        string RemainMeJing { get; set; }

        event EventHandler CorrectEvent;
        event EventHandler CancelEvent;

    }
}
