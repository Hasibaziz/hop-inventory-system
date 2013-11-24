<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="page_header" style="float:left;width:99%">Inventory</div>
<div class="clear nav_sub_menu">
    <a href="<%=Url.Content("~/Inventory/DepartmentInfo") %>">Department Information</a>
    <a href="<%=Url.Content("~/Inventory/EmployeeInfo") %>">Employee Information</a>
    <a href="<%=Url.Content("~/Inventory/AllDeviceinfo") %>">All Device Information</a>
    <a href="<%=Url.Content("~/Inventory/InventoryDetailsView") %>">PC Details Information</a>
    <a href="<%=Url.Content("~/Inventory/Laptopinfo") %>">Laptop Details Information</a>
    <a href="<%=Url.Content("~/Inventory/Serverinfo") %>">Server Details Information</a>
   <%-- <a href="<%=Url.Content("~/Inventory/InventoryDetails") %>">PC Details Info</a>--%>
    <a href="<%=Url.Content("~/Inventory/PrinterView") %>">Printer Details Information</a>
   <%-- <a href="<%=Url.Content("~/Home/BarCodeGen") %>">BarCode Generate Info</a>--%>
</div>