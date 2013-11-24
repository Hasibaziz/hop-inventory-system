using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.Server.DAL
{
    public partial class InvreportingDAL
    {
        public DataTable GetAllDeviceinfoReport(InvInventorydetailsEntity obj, object param)
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) 'Line#', A.Location AS Office, D.DeptName AS Department, A.Team, A.Status, A.Proposed, A.HostName, A.AccountCode, A.BrandModel AS 'Brand&Model', A.ITemNo AS 'ITE.NO', A.Category, A.Configuration, A.SerialNo, A.Office AS Location, E.EmpNo AS UserID, E.EmpName AS Users, convert(date, A.PurchDate,103) as PurchDate, A.Remark AS Remarks, B.SerialNo AS MonitorSL, B.MonitorName AS 'Monitor Acc Code', C.SerialNo AS UPSSL, C.UPSName AS 'UPS Acc Code'";
            sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
            sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
            sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
            sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID";
            sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID";
            //sql = sql + " WHERE A.Location=LEFT(A.Location,4)";
            sql = sql + " WHERE A.Location=@Location";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
    }
}
