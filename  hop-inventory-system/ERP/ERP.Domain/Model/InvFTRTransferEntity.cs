using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
   public class InvFTRTransferEntity
    {
        public string TRID
        {
            set;
            get;
        }
        public string RIssueID
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
        public string ReceiveQty
        {
            set;
            get;
        }
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Issue Date")]
        public string IssueDate
        {
            set;
            get;
        }       
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Location")]
        public string LocID
        {
            set;
            get;
        }
        public string Location
        {
            set;
            get;
        }
        public string IssueQty
        {
            set;
            get;
        }
        public bool IsReceive
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
