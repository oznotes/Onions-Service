using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
