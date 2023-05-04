using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyMangement.View
{
    public interface ISearchView
    {
        DateTime SearchTime { get; set; }
        string DayNight { get; set; }

        event EventHandler SearchEvent;
        event EventHandler OutputExcelEvent;

        void SetSearchBindingSource(BindingSource stockList);
        void Show();
    }
}
