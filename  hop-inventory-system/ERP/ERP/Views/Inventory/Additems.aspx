<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Additems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Add Items</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content">
        <div class="page_list_container"></div>
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>
</div>

 <script type="text/javascript">

     $(document).ready(function () {

         $('#RecordsContainer').jtable({
             paging: true,
             pageSize: 15,
             sorting: false,
             title: 'The Items Info List',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '<%=Url.Content("~/Inventory/ItemsList") %>',
                 deleteAction: '<%=Url.Content("~/Inventory/DeleteItemsRecord") %>',
                 updateAction: '<%=Url.Content("~/Inventory/AddUpdateItems") %>',
                 createAction: '<%=Url.Content("~/Inventory/AddUpdateItems") %>'

             },
             fields: {
                 ItemID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 ItemName: {
                     title: 'Item Name',
                     width: '20%'
                 },
                 ItemDate: {
                     title: 'Date Of Entry',
                     type: 'date',
                     displayFormat: 'dd-mm-yy',
                     width: '25%'
                 },
                 Description: {
                     title: 'Description',
                     type: 'textarea',
                     width: '20%'                     
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="ItemName"]').addClass('validate[required]');
                 data.form.find('input[name="ItemDate"]').addClass('validate[required]');                
                 data.form.validationEngine();
             },
             //Validate form when it is being submitted
             formSubmitting: function (event, data) {
                 return data.form.validationEngine('validate');
             },
             //Dispose validation logic when form is closed
             formClosed: function (event, data) {
                 data.form.validationEngine('hide');
                 data.form.validationEngine('detach');
             }
         });
         $('#RecordsContainer').jtable('load');
     });
 
    </script>






<%--
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Invitems</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ItemID) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ItemID) %>
            <%: Html.ValidationMessageFor(model => model.ItemID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ItemName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ItemName) %>
            <%: Html.ValidationMessageFor(model => model.ItemName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ItemDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ItemDate) %>
            <%: Html.ValidationMessageFor(model => model.ItemDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
  <% } %>

  <div>
     <%: Html.ActionLink("Back to List", "Index") %>
  </div>
</div>
--%>
</asp:Content>
