﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myblog1.Models
{
    public class CheckListModel
    {
        public CheckListModel()
        {
            Isset = new List<bool>();
        }
        public IList<bool> Isset { get; set; }
    }
}
