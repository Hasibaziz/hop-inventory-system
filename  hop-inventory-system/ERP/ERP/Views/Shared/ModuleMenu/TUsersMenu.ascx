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
                        item.Add().Text("All Device Information").ImageUrl("~/Content/Common/Icons/Mvc/pc.png").Url("~/Users/AllDeviceinfo");
                        item.Add().Text("PC Details Information").ImageUrl("~/Content/Common/Icons/Computer/monitor.png").Url("~/Users/InventoryDetailsView");
                        item.Add().Text("Laptop Details Information").ImageUrl("~/Content/Common/Icons/Computer/laptop.png").Url("~/Users/Laptopinfo");
                        //item.Add().Text("Server Details Information").ImageUrl("~/Content/Common/Icons/Computer/server.png").Url("~/Inventory/Serverinfo");
                        //item.Add().Text("Printer Details Information").ImageUrl("~/Content/Common/Icons/Computer/print.png").Url("~/Inventory/PrinterView");
                        //item.Add().Text("Switch Details Information").ImageUrl("~/Content/Common/Icons/Suites/Switch.png");
                        //item.Add().Text("Other Devices Information").ImageUrl("~/Content/Common/Icons/Suites/Multi.png");
                        //item.Add().Text("Online UPS Information").ImageUrl("~/Content/Common/Icons/Suites/Onlineups.png");
                        
                    });
                menu.Add()
                   .Text("CAPEX Insert")
                    .ImageUrl("~/Content/Common/Icons/Suites/orm.png")
                    .Items(item =>
                    {
                        //item.Add().Text("PC Details").ImageUrl("~/Content/Common/Icons/Computer/monitor.png").Url("~/Devices/PCDetails");
                        //item.Add().Text("Laptop Details").ImageUrl("~/Content/Common/Icons/Computer/laptop.png").Url("~/Devices/LaptopDetails");
                        //item.Add().Text("Server Details").ImageUrl("~/Content/Common/Icons/Computer/server.png").Url("~/Devices/ServerDetails");
                        //item.Add().Text("Printer Details").ImageUrl("~/Content/Common/Icons/Computer/print.png").Url("~/Devices/PrinterView");
                        //item.Add().Text("Monitor Details").ImageUrl("~/Content/Common/Icons/Computer/monitor24.png").Url("~/Devices/MonitorInfo");
                        //item.Add().Text("Printer Details").ImageUrl("~/Content/Common/Icons/Computer/print24.png").Url("~/Devices/PrinterInfo");
                        //item.Add().Text("UPS Details").ImageUrl("~/Content/Common/Icons/Computer/UPS.png").Url("~/Devices/UPSInfo");
                        item.Add().Text("... and more!").Url("http://10.3.12.156:802");
                    });
                menu.Add()
                  .HtmlAttributes(new { style = "border-right: 0;" })
                  .Text("OPEX Items")
                  .ImageUrl("~/Content/Common/Icons/Suites/rep.png")
                  .Items(item =>
                  {
                      item.Add().Text("PC Details Reports").ImageUrl("~/Content/Common/Icons/Suites/test.png");
                      item.Add().Text("Labtop Details Reports").ImageUrl("~/Content/Common/Icons/Suites/win.png");
                      item.Add().Text("Printer Details Reports").ImageUrl("~/Content/Common/Icons/Suites/wpf.png");
                  });             
                menu.Add()
                    .HtmlAttributes(new { style = "border-right: 0;" })
                    .Text("Reporting")
                    .ImageUrl("~/Content/Common/Icons/Suites/test.png")
                    .Items(item =>
                    {
                        item.Add().Text("PC Details Reports").ImageUrl("~/Content/Common/Icons/Suites/test.png");
                        item.Add().Text("Labtop Details Reports").ImageUrl("~/Content/Common/Icons/Suites/win.png");
                        item.Add().Text("Printer Details Reports").ImageUrl("~/Content/Common/Icons/Suites/wpf.png");
                    });
                menu.Add()
                 .HtmlAttributes(new { style = "border-right: 0;" })
                 .Text("Helps Tips")
                 .ImageUrl("~/Content/Common/Icons/Suites/win.png")
                 .Items(item =>
                 {
                     item.Add().Text("About").ImageUrl("~/Content/Common/Icons/Suites/test.png").Url("~/Users/Locationinfo");
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
 