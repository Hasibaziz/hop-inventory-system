using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Model
{
    public class InvreceivenissueEntity
    {
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
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Issue Date")]
        public string IssueDate
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Receiver Name ")]
        public string ReceiverName
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Email Address")]
        public string ReceiverEmail
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Transport No")]
        public string Transportno
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Location")]
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
        public string TotalissueQty
        {
            set;
            get;
        }
        public string IssueQty
        {
            set;
            get;
        }
        public string BalanceQty
        {
            set;
            get;
        }
        public string NewbalanceQty
        {
            set;
            get;
        }
        public string Userstatus
        {
            get;
            set;
        }
        public string UIssueTotal
        {
            set;
            get;
        }
        
    }
}
