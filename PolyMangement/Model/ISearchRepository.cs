﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public interface ISearchRepository
    {
        IEnumerable<SearchModel> GetNow();
        IEnumerable<SearchModel> GetByValue(DateTime start,DateTime end);   //分出日夜班
    }
}
