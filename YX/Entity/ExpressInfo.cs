using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YX.Entity
{
    public  class ExpressInfo
    {
        public string status { get; set; }
        public string nu { get; set; }
        public string com { get; set; }
        public List<ExpressDetail> data { get; set; }
    }
    public class ExpressDetail
    {
        public string time { get; set; }
        public string context { get; set; }
    }
}
