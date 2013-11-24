using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CrystalDecisions.CrystalReports.Engine;
using System.Web.Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using ERP.Structure;
using ERP.Domain.Model;
using System.Collections;
using ERP.Utility;


namespace ERP.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            ViewData["PageHeader"] = ".";
            return View();
        }
        public ActionResult ReportView()
        {
            ViewData["PageHeader"] = ".";            
            return View();
        }

        public ActionResult Reportchart()
        {
            return View();
        }
        public ActionResult EquipmentChart()
        {
            //string myTheme = @"<Chart BackColor=""Transparent"" ForeColor=""Navy""><ChartAreas><ChartArea Name=""Default"" BackColor=""Aqua"" ></ChartArea></ChartAreas></Chart>";
            //var bytes = new Chart(width: 400, height: 200, theme: ChartTheme.Yellow)
            //var bytes = new Chart(width: 600, height: 400, theme: myTheme)
            var bytes = new Chart(width: 700, height: 500, theme: ChartTheme.Green)
             .AddTitle("Equipment Efficiency ")
             .AddSeries(
                 chartType: "column",     //Make Chart Horizontal 
                //chartType: "bar",
                 axisLabel: "Name",
                 xValue: new[] { "2008", "2009", "2010", "2011", "2012" },
                 yValues: new[] { "60.18", "70.35", "68.70", "88.5", "89.30" })
                 .AddSeries(chartType: "line", yValues: new[] { "30", "40", "50", "60", "70" })
             .GetBytes("png");
            return File(bytes, "image/png");
        }
        public ActionResult MyChart()
        {
            var XVal = GetXVal();
            //var XVal = GetYVal();

            new Chart(width: 700, height: 500, theme: ChartTheme.Green)
             .AddTitle("Price enquiries")             
             //.DataBindTable(XVal, xField: "Servicedate")            
             .AddSeries("Default",
                 xValue: XVal, xField: "Servicedate",
                 yValues: XVal, yFields: "Mlifetime")
             .Write("png");      
           return null;

        }

        private IList GetXVal()
        {
            //Dictionary<DateTime, List<string>> Alist = new Dictionary<DateTime, List<string>>();
            //ServiceinfoEntity _Model = new ServiceinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetXValRecord, null);
            //var records = new[] { new { Servicedate="" , Mlifetime ="" } }.ToList();
            //ArrayList AList = new ArrayList();
            //List<int> Ltime = new List<int>();
            //foreach (DataRow row in dt.Rows)
            //    foreach (DataColumn col in dt.Columns)
            //        records.Add(new {Servicedate =row["Servicedate"].ToString(), Mlifetime =row["Mlifetime"].ToString() });
            //        //AList.Add(new AList { XY = Convert.ToDateTime(row["Servicedate"].ToString(), YX = Convert.ToInt32(row["Mlifetime"].ToString())) });
            ////Skip the blank record
            //records = records.Skip(1).ToList();
            ////var Record = ItemList;           
            ////Alist.AddRange(Record);         
            //AList.AddRange(records);
            //return new ArrayList {records};
            //foreach (DataRow row in dt.Rows)
            //{
            //    List<string> Ltime = new List<string>();
            //    foreach (DataColumn col in dt.Columns)
            //        Ltime.Add(row[col].ToString());
            //    Alist.Add(Convert.ToDateTime(row["Servicedate"].ToString()), Ltime);
            //}
            //return new ArrayList { Alist };         
           List<ChartmodelUtility> BarchartModelList = new List<ChartmodelUtility>();
            foreach (DataRow row in dt.Rows)
                foreach (DataColumn col in dt.Columns)
                    BarchartModelList.Add(new ChartmodelUtility()
                    {
                        Servicedate = Convert.ToDateTime(row["Servicedate"].ToString()),
                        Mlifetime = Convert.ToInt32(row["Mlifetime"].ToString())
                    });
            return BarchartModelList;
        }
        private IList GetYVal()
        {
            ServiceinfoEntity _Model = new ServiceinfoEntity();
            //DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetYValRecord, null);
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetXValRecord, null);
            //var records = new[] { new { SDate = "", LTime = "" } }.ToList(); 
            foreach (DataRow dr in dt.Rows)
            {
               _Model.Servicedate =Convert.ToDateTime( dr["Servicedate"].ToString());
               _Model.Mlifetime  =Convert.ToInt32( dr["Mlifetime"].ToString());
              
            }
            return new ArrayList {_Model };            
        }


        public class ChartModel
        {
            public IList GetChartData()
            {
              return new ArrayList
              {
                  new { X = DateTime.Now.AddMonths(-4), Y = 10 },
                  new { X = DateTime.Now.AddMonths(-3), Y = 20 },
                  new { X = DateTime.Now.AddMonths(-2), Y = 35 },
                  new { X = DateTime.Now.AddMonths(-1), Y = 40 },
                  new { X = DateTime.Now, Y = 55 }
               };
             }
           }
        public ActionResult Chart()
        {
            var model = new ChartModel();
            var data = model.GetChartData();
            new Chart(width: 700, height: 500, theme: ChartTheme.Green)
                .AddTitle("Equipment Efficincies")
                .DataBindTable(data, "X")
                .Write("png");
            return null;
           }

    }
}
