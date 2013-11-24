<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Models.BarcodeDemoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    BarCodeGen
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="<%: Url.Content("~/Content/Site.css")%>" rel="stylesheet" type="text/css" />

<div class="mp_left_menu">
    <% Html.RenderPartial("HomeLeftMenu"); %>
</div>
<div class="mp_right_content">
        <div class="page_list_container">
            <div style="float: left; width: 100%">
                Enter the text for the Barcode: <%: Html.TextBoxFor(model => model.BarcodeText)%>
                Barcode Thickness: <%: Html.DropDownListFor(model => model.BarcodeThickness, Model.ThicknessOptions)%>
                Show Barcode text: <%: Html.CheckBoxFor(model => model.ShowBarcodeText)%>
            <input type="submit" value="Generate Barcode" />
            </div>
            <% if (!string.IsNullOrEmpty(Model.BarcodeImageUrl))
               { %>
                 <img src="<%: Model.BarcodeImageUrl %>" />
                 <% } %>
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
