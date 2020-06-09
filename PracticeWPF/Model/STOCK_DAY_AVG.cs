using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPF.Model
{
   public class STOCK_DAY_AVG
    {
        public string stat { get; set; }
        public string date { get; set; }
        public string title { get; set; }
        public string[] fields { get; set; }
        public string[][] data { get; set; }
        public string[] notes { get; set; }
    }
}
