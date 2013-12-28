<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvServiceinfoEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Serviceinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>


<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Service Info</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content">
 <div class="page_list_container"></div>
    <div style="float: left; width: 100%;"></div>
        <div id="RecordsContainer">
      </div>
  </div>
 <script type="text/javascript">

     $(document).ready(function () {

         $('#RecordsContainer').jtable({
             paging: true,
             pageSize: 15,
             sorting: false,             
             title: 'Servicing Information',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '<%=Url.Content("~/Inventory/Serviceinfolist") %>',
//                 deleteAction: '<%=Url.Content("~/Inventory/DeleteModelsRecord") %>',
                 updateAction: '<%=Url.Content("~/Inventory/AddUpdateServiceinfo") %>',
                 createAction: '<%=Url.Content("~/Inventory/AddUpdateServiceinfo") %>'

             },
             fields: {
                 ServiceID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 LocID: {
                     title: 'Location',
                     width: '7%',
                     options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                 }, 
                 AccountID: {
                     title: 'Equipment No',
                     width: '20%',
                     options: '<%=Url.Content("~/Inventory/AllEquipmentno") %>'
                 },                                
                 Servicedate: {
                     title: 'Last Servicing Date',
                     //type: 'date',
                     displayFormat: 'dd-mm-yy',
                     width: '20%'
                 },                                
                 Mlifetime: {
                     title: 'Life Time',
                     width: '15%'
                 },                
                 Description: {
                     title: 'Description',
                     type: 'textarea',
                     width: '25%'
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="LocID"]').addClass('validate[required]');
                 data.form.find('input[name="AccountID"]').addClass('validate[required]');
                 data.form.find('input[name="Servicedate"]').addClass('validate[required]');
                 data.form.validationEngine();
             },
             //Validate form when it is being submitted
             formSubmitting: function (event, data) {
                 return data.form.validationEngine('validate');
             },
             //Dispose validation logic when form is closed
//             formClosed: function (event, data) {
//                 data.form.validationEngine('hide');
//                 data.form.validationEngine('detach');
//             }
         });
         $('#RecordsContainer').jtable('load');
     });
 
    </script>
<script type="text/javascript">
    $(function () {
        $(".Servicedate").datepicker({
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '-100y:c+nn',
            maxDate: '1d'
        });
    });

</script>
</asp:Content>
