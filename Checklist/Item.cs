using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist
{
    internal class Item
    {
        public string Challenge { get; set; }
        public string Response { get; set; }
        public string Description { get; set; }
        public bool CheckItem { get; set; }
        public Item SubItem { get; set; }
    }
}
