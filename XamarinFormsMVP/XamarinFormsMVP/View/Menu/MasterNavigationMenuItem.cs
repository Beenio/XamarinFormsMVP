﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsMVP.View.Menu
{

    public class MasterNavigationMenuItem
    {
        public MasterNavigationMenuItem()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}