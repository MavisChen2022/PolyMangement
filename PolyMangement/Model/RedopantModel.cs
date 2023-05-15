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
        private int hour;
        private string recipeA;
        private string recipeB;

        public int Hour { get => hour; set => hour = value; }
        public string RecipeA { get => recipeA; set => recipeA = value; }
        public string RecipeB { get => recipeB; set => recipeB = value; }
    }
}
