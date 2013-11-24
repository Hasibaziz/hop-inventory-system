using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace ERP.Reports
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            //ReportClass report = new ReportClass();
            report.Load(Server.MapPath("~/Reports/GetpassissueReport.rpt"));
            report.SetDataSource(Session["ReportSource"]);
            CRViewer1.ReportSource = report;
            //MemoryStream stream = (MemoryStream)report.ExportToStream(ExportFormatType.PortableDocFormat);
            //CRViewer1.ReportSource = stream; 
        }
    }
}