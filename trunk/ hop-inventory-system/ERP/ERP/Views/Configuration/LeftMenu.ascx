<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="page_header" style="float:left;width:99%">Utility</div>
<div class="clear nav_sub_menu">
    <a href="<%=Url.Content("~/Configuration/ServiceName") %>">Access Permission</a>
    <a href="<%=Url.Content("~/Configuration/ServiceDetails") %>">Create User</a>
</div>
