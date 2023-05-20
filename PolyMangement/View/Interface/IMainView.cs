using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.View
{
    public interface IMainView
    {
        event EventHandler ShowStockListEvent;
        event EventHandler SearchStockListEvent;
        event EventHandler CalculateRedopantEvent;
        event EventHandler CorrectAmountEvent;
    }
}
