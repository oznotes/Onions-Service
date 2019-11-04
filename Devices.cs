using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onions
{
    public class MODELIST
    {
        public string MODEL { get; set; }
        public string URLIMAGE { get; set; }
    }
    public class BRANDLIST
    {
        public string BRAND { get; set; }      
        public List<MODELIST> MODELIST { get; set; }
    }
}
