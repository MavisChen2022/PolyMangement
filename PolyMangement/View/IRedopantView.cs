using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public interface IRedopantView
    {
        string StartYearText { get; set; }
        string StartMonthDayText { get; set; }
        string StartHourMinsText { get; set; }
        string EndYearText { get; set; }
        string EndMonthDayText { get; set; }
        string EndHourMinsText { get; set; }
        string NeckTimes { get; set; }
        string RealText { get; set; }
        string RemeltText { get; set; }

        event EventHandler ShowCorrespondRecipeEvent;
        event EventHandler CalculateTimeIntervalEvent;
        event EventHandler CalRedopantEvent;
        void SetRedopantBindingSource(BindingSource stockList);

        void Show();
    }
}
