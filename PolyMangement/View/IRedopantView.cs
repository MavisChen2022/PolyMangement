using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.View
{
    public interface IRedopantView
    {
        string YearText { get; set; }
        string MonthDayText { get; set; }
        string HourMinsText { get; set; }
        string NeckTimes { get; set; }
        string RealText { get; set; }
        string Remelt { get; set; }

        event EventHandler ShowCorrespondRecipeEvent;
        event EventHandler CalTimeIntervalEvent;
        event EventHandler CalRedopantEvent;
    }
}
