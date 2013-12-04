using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ERP.Domain.Model
{
   public class InvallstockEntity
    {
       public string SID
       {
           get;
           set;
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
       public string LocID
       {
           set;
           get;
       }
       public string IDate
       {
           set;
           get;
       }
       public string SDate
       {
           get;
           set;
       }
       public string IssueQty
       {
           get;
           set;
       }
       public string TOTALRQty
       {
           get;
           set;
       }
       public string TOTALIQty
       {
           get;
           set;
       }
       public string BalanceQty
       {
           get;
           set;
       }
       public string Location
       {
           get;
           set;
       }
       public string Userstatus
       {
           get;
           set;
       }
       public string StartDate
       {
           get;
           set;
       }
       public string EndDate
       {
           get;
           set;
       }
    }
}
