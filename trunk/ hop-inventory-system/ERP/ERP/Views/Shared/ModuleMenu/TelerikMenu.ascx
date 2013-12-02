<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
 <%= Html.Telerik().StyleSheetRegistrar()
         .DefaultGroup(group => group.Add("telerik.common.css")                                                                           
                                     .Add("telerik." + Html.GetCurrentTheme() + ".css")        
                       )
  %>

   
 <% Html.Telerik().Menu().HtmlAttributes(new { style = "color: Black !important" })
            .Name("Menu")
            .Items(menu =>
            {
                menu.Add()
                    .Text("CAPEX Items")
                    .ImageUrl("~/Content/Common/Icons/Suites/mvc.png")
                    .Items(item =>
                    {
                        item.Add().Text("Equipment Information").ImageUrl("~/Content/Common/Icons/Suites/win.png").Url("~/Inventory/Equipmentinfo");
                        item.Add().Text("All Device Information").ImageUrl("~/Content/Common/Icons/Mvc/pc.png").Url("~/Inventory/AllDeviceinfo");
                        item.Add().Text("PC Details Information").ImageUrl("~/Content/Common/Icons/Computer/monitor.png").Url("~/Inventory/InventoryDetailsView");
                        item.Add().Text("Laptop Details Information").ImageUrl("~/Content/Common/Icons/Computer/laptop.png").Url("~/Inventory/Laptopinfo");
                        item.Add().Text("Server Details Information").ImageUrl("~/Content/Common/Icons/Computer/server.png").Url("~/Inventory/Serverinfo");
                        item.Add().Text("Printer Details Information").ImageUrl("~/Content/Common/Icons/Computer/print.png").Url("~/Inventory/PrinterView");
                        item.Add().Text("Switch Details Information").ImageUrl("~/Content/Common/Icons/Suites/Switch.png");
                        item.Add().Text("Other Devices Information").ImageUrl("~/Content/Common/Icons/Suites/Multi.png");
                        item.Add().Text("Online UPS Information").ImageUrl("~/Content/Common/Icons/Suites/Onlineups.png");
                        
                    });
                menu.Add()
                    .Text("CAPEX Insert")
                    .ImageUrl("~/Content/Common/Icons/Suites/orm.png")
                    .Items(item =>
                    {
                        item.Add().Text("New Equipment Entry").ImageUrl("~/Content/Common/Icons/Suites/win.png").Url("~/Devices/Newequipment");
                        item.Add().Text("PC Details").ImageUrl("~/Content/Common/Icons/Computer/monitor.png").Url("~/Devices/PCDetails");
                        item.Add().Text("Laptop Details").ImageUrl("~/Content/Common/Icons/Computer/laptop.png").Url("~/Devices/LaptopDetails");
                        item.Add().Text("Server Details").ImageUrl("~/Content/Common/Icons/Computer/server.png").Url("~/Devices/ServerDetails");
                        item.Add().Text("Printer Details").ImageUrl("~/Content/Common/Icons/Computer/print.png").Url("~/Devices/PrinterView");
                        item.Add().Text("Monitor Details").ImageUrl("~/Content/Common/Icons/Computer/monitor24.png").Url("~/Devices/MonitorInfo");
                        item.Add().Text("Printer Details").ImageUrl("~/Content/Common/Icons/Computer/print24.png").Url("~/Devices/PrinterInfo");
                        item.Add().Text("UPS Details").ImageUrl("~/Content/Common/Icons/Computer/UPS.png").Url("~/Devices/UPSInfo");
                        item.Add().Text("... and more!").Url("http://10.3.12.156:802");
                    });
                menu.Add()
                   .HtmlAttributes(new { style = "border-right: 0;" })
                   .Text("OPEX Items")
                   .ImageUrl("~/Content/Common/Icons/Suites/rep.png")
                   .Items(item =>
                   {
                       item.Add().Text("Add Items").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Inventory/Additems");
                       item.Add().Text("Add Models").ImageUrl("~/Content/Common/Icons/Suites/win.png").Url("~/Inventory/Addmodels");
                       item.Add().Text("Items Receive").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/Itemreceive");
                       item.Add().Text("Issue To Factory").ImageUrl("~/Content/Common/Icons/Mvc/Grid.png").Url("~/Inventory/Receiveissue");
                       item.Add().Text("User Issue Item").ImageUrl("~/Content/Common/Icons/Suites/orm.png").Url("~/Inventory/Userissue");
                       item.Add().Text("FTY Transfer").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Assetdist");
                   });
                menu.Add()
                  .HtmlAttributes(new { style = "border-right: 0;" })
                  .Text("Tools")
                  .ImageUrl("~/Content/Common/Icons/Suites/wpf.png")
                  .Items(item =>
                  {
                      item.Add().Text("Add Country").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Country");
                      item.Add().Text("Building Entry").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Buildinginfo");
                      item.Add().Text("Level/Floor Entry").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Floorinfo");
                      item.Add().Text("Line Entry").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Lineinfo");
                      item.Add().Text("Machine Name Entry").ImageUrl("~/Content/Common/Icons/Suites/mvc.png").Url("~/Inventory/Machineinfo");
                      item.Add().Text("Add Unit").ImageUrl("~/Content/Common/Icons/Suites/rep.png").Url("~/Inventory/Unitentry");
                      item.Add().Text("Department Information").ImageUrl("~/Content/Common/Icons/Mvc/Grid.png").Url("~/Inventory/DepartmentInfo");
                      item.Add().Text("Employee Information").ImageUrl("~/Content/Common/Icons/Mvc/Menu.png").Url("~/Inventory/EmployeeInfo");
                      item.Add().Text("Add Devices").ImageUrl("~/Content/Common/Icons/Suites/orm.png").Url("~/Inventory/DeviceName");
                      item.Add().Text("Idle days Entry").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/Leaveinfo");
                      item.Add().Text("Servicing Information").ImageUrl("~/Content/Common/Icons/Suites/win.png").Url("~/Inventory/Serviceinfo");
                      item.Add().Text("User Create Information").ImageUrl("~/Content/Common/Icons/Suites/UserCreate.png").Url("~/Inventory/Usercreateinfo");
                      item.Add().Text("User Update Information").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Inventory/Updateuserinfo");                      
                  });             
                menu.Add()
                    .HtmlAttributes(new { style = "border-right: 0;" })
                    .Text("Reporting")
                    .ImageUrl("~/Content/Common/Icons/Suites/test.png")
                    .Items(item =>
                    {
                        item.Add().Text("Equipment Chart Report").ImageUrl("~/Content/Common/Icons/Suites/orm.png").Url("~/Report/Reportchart");
                        item.Add().Text("Overall Receive Report").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/Receiverpt");
                        item.Add().Text("OPEX Overall Stock Info").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Inventory/Stockinfo");
                        item.Add().Text("OPEX Factory Wise Stock").ImageUrl("~/Content/Common/Icons/Suites/win.png").Url("~/Inventory/FTYStock");
                        item.Add().Text("Factory Wise Issue Report").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/Getpassissue");
                        //item.Add().Text("Report Viewer").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Report/ReportView");
                        item.Add().Text("Factory Wise Issue Report Viewer").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/ReportView");
                        //item.Add().Text("Report Viewer").ImageUrl("~/Content/Common/Icons/Suites/wpf.png").Url("~/Inventory/ReportViewer");
                    });
                menu.Add()
                  .HtmlAttributes(new { style = "border-right: 0;" })
                  .Text("Helps Tips")
                  .ImageUrl("~/Content/Common/Icons/Suites/win.png")
                  .Items(item =>
                  {
                      item.Add().Text("About").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Helps/Locationinfo");                      
                  });
                menu.Add()
                   .HtmlAttributes(new { style = "border-right: 0;" })
                   .Text("Log Out")
                   .ImageUrl("~/Content/Common/Icons/Suites/win.png")
                   .Items(item =>
                   {                      
                       item.Add().Text("Log Out").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Account/Logout");
                       item.Add().Text("... and more!").ImageUrl("~/Content/Common/Icons/Suites/win.png");                       
                   });
            })
            .Render();
    %>
 <% Html.Telerik().ScriptRegistrar()
                  .jQuery(false)            //Important for Running JSON and JQuery 
                  .jQueryValidation(false)  //Important for Running JSON and JQuery 
                  .DefaultGroup(group => group
                  .Add("telerik.examples.js")
                  .Compress(true))
                  .OnDocumentReady(() => { %>prettyPrint();<% })
                  .Render(); 
 %> 
 
