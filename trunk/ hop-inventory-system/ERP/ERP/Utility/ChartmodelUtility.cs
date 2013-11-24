using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Utility
{
    public class ChartmodelUtility
    {
            public DateTime XServicedate;
            public int YMlifetime;

            public ChartmodelUtility()
            {
            }
            public DateTime Servicedate
            {
                get { return XServicedate; }
                set { XServicedate = value; }
            }
            public int Mlifetime
            {
                get { return YMlifetime; }
                set { YMlifetime = value; }
            }

      
    }
}