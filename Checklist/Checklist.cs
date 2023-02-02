﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist
{
    internal class Checklist
    {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
    }

    internal class Section
    {
        public string Name { get; set; }
        public bool Information { get; set; }
        public List<Item> Items { get; set; }
    }
}
