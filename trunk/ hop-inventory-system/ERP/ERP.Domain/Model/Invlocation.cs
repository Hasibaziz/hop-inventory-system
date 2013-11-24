using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
    public class Invlocation
    {
        public string LocID
        {
            set;
            get;
        }
        public string CID
        {
            set;
            get;
        }
        public string Location
        {
            set;
            get;
        }
        public string Description
        {
            set;
            get;
        }
        public string Userstatus 
        { 
            get; 
            set; 
        }
    }
}
