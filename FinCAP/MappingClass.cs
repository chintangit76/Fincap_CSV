using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCAP
{
    public class MappingClass
    {
        public string ScriptName { get; set; }
        public string TallyName { get; set; }
        
    }

    public class FixedMappingClass
    {
        public string Member { get; set; }
        public string Broker { get; set; }
        public string BrokLedg { get; set; }
        public string FutTradingLedg { get; set; }
        public string OptTradingLedg { get; set; }
        public string FutLedg { get; set; }
        public string OptLedg { get; set; }
        public string EqLedg { get; set; }

    }

    public class BankDefaultMappingClass
    {
        public string SearchValue { get; set; }
        public string DrLedgerName { get; set; }
        public string DrNarration { get; set; }
        public string CrLedgerName { get; set; }
        public string CrNarration { get; set; }

    }


}
