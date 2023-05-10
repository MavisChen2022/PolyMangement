using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public class RedopantModel
    {
        DateTime year;
        DateTime monthDay;
        DateTime hourMins;
        string recipeName;
        int redopant;

        public DateTime Year { get => year; set => year = value; }
        public DateTime MonthDay { get => monthDay; set => monthDay = value; }
        public DateTime HourMins { get => hourMins; set => hourMins = value; }
        public string RecipeName { get => recipeName; set => recipeName = value; }
        public int Redopant { get => redopant; set => redopant = value; }
    }
}
