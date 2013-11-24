using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ERP.Domain.Model
{
    public class InvftystockinfoEntity
    {
        public string FSID
        {
            set;
            get;
        }
        public string ItemID
        {
            set;
            get;
        }
        public string ModelID
        {
            set;
            get;
        }
        public string FSDate
        {
            set;
            get;
        }
        public string TFSRQty
        {
            set;
            get;
        }
        public string TFSIQty
        {
            set;
            get;
        }
        public string LocID
        {
            set;
            get;
        }
        public string FSBalanceQty
        {
            set;
            get;
        }
        public string Location
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
