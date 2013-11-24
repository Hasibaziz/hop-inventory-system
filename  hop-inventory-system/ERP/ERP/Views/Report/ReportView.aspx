<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ReportView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 

    <form id="form1" runat="server">
 

<%--<div class="mp_left_menu">
    <% Html.RenderPartial("RLeftMenu"); %>
</div>--%>
<div>
   

    <CR:CrystalReportViewer ID="CRViewer" runat="server" 
        AutoDataBind="true" />
   

</div>
  </form>
   
</asp:Content>
