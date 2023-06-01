using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.View.Interface
{
    public interface ICorrectAmountView
    {
        string poly1Text { get; set; }
        string poly2Text { get; set; }
        string poly3Text { get; set; }
        string poly4Text { get; set; }
        string poly5Text { get; set; }
        string dopant1Text { get; set; }
        string dopant2Text { get; set; }
        string dopant3Text { get; set; }

        string crucible1Text { get; set; }
        string crucible2Text { get; set; }
        string crucible3Text { get; set; }
        string crucible4Text { get; set; }


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

        event EventHandler CorrectEvent;
        void Show();
    }
}
