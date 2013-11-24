<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="page_header" style="float:left;width:99%">Inventory</div>
<div class="clear nav_sub_menu">
    <a href="<%=Url.Content("~/Users/AllDeviceinfo") %>">All Device Information</a>
    <a href="<%=Url.Content("~/Users/InventoryDetails") %>">PC Details Information</a>
    <a href="<%=Url.Content("~/Users/Laptopinfo") %>">Laptop Details Information</a>
    <%--<a href="<%=Url.Content("~/Users/Serverinfo") %>">Server Details Information</a>
    <a href="<%=Url.Content("~/Users/PrinterView") %>">Printer Details Information</a>  --%>
</div>