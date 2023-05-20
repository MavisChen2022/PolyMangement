﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public interface IPolyView
    {
        string idText { get; set; }
        string machineNum { get; set; }
        string PCAText { get;set;}
        string XinhuaText { get; set; }
        string ASText { get; set; }
        string ARText { get; set; }
        string HemlockText { get; set; }
        string ASDopantText { get; set; }
        string PHDopantText { get; set; }
        string BDopantText { get; set; }

        bool AqmRadio { get; set; }
        bool YoxingRad { get; set; }
        bool AqmG3Rad { get; set; }
        bool MejingRad { get; set; }

        string chargeTime { get; set; }

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


        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetPolyBindingSource(BindingSource stockList);

        void Show();
    }
}