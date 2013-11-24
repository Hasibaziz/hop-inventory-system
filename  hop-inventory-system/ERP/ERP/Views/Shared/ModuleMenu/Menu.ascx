<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="menu-bg" style="border-bottom:solid 1px gray;">
    <div id="top-menu" style="float: left; width: 100%">
        <ul class="menu">
            <%--<li><a href="<%=Url.Content("~/Settings/Index") %>" class="last"><span>Settings</span></a></li>--%>
            <li><a href="<%=Url.Content("~/Inventory/Index") %>"><span>Inventory</span></a></li>
             <li><a href="<%=Url.Content("~/Devices/Index") %>"><span>New Inventory</span></a></li>
           <%-- <li><a href="<%=Url.Content("~/Configuration/ServiceName") %>"><span>Utility</span></a></li>
            <li><a href="<%=Url.Content("~/Category/Index") %>"><span>Category Information</span></a></li>
            <li><a href="<%=Url.Content("~/Sales/Index") %>"><span>Inventory</span></a></li>
            <li><a href="<%=Url.Content("~/HRM/Index") %>"><span>HRM</span></a></li>
            <li><a href="<%=Url.Content("~/Home/Index") %>"><span>Bar Code</span></a></li>--%>
            <li><a href="<%=Url.Content("~/Report/Index") %>"><span>Report</span></a></li>
        </ul>
    </div>
    <div class="clear">
            </div>
</div>