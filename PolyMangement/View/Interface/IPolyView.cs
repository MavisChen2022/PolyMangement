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
        string idText { get; set; }
        string machineNum { get; set; }
        string poly1Text { get;set;}
        string poly2Text { get; set; }
        string poly3Text { get; set; }
        string poly4Text { get; set; }
        string poly5Text { get; set; }
        string dopant1Text { get; set; }
        string dopant2Text { get; set; }
        string dopant3Text { get; set; }

        bool crucible1Rad { get; set; }
        bool crucible2Rad { get; set; }
        bool crucible3Rad { get; set; }
        bool crucible4Rad { get; set; }

        string chargeTime { get; set; }

        bool IsEdit { get; set; }

        string RemainPoly1 { get; set; }
        string RemainPoly2 { get; set; }
        string RemainPoly3 { get; set; }
        string RemainPoly4 { get; set; }
        string RemainPoly5 { get; set; }
        string RemainDopant1 { get; set; }
        string RemainDopant2 { get; set; }
        string RemainDopant3 { get; set; }
        string RemainCrucible1 { get; set; }
        string RemainCrucible2 { get; set; }
        string RemainCrucible3 { get; set; }
        string RemainCrucible4 { get; set; }

        string poly11Text { get; set; }
        string poly22Text { get; set; }
        string poly33Text { get; set; }
        string poly44Text { get; set; }
        string poly55Text { get; set; }
        string dopant11Text { get; set; }
        string dopant22Text { get; set; }
        string dopant33Text { get; set; }

        string crucible11Text { get; set; }
        string crucible22Text { get; set; }
        string crucible33Text { get; set; }
        string crucible44Text { get; set; }
        bool IsChargeIN { get; set; }


        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;

        void SetPolyBindingSource(BindingSource stockList);

        void Show();
    }
}
