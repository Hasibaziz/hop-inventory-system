<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvLeaveinfoEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Leaveinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<style>
.ui-datepicker-calendar {
    display: none;
    }
</style>


<script type="text/javascript">
    $(function () {
        $("input#Years").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy',
            onClose: function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
            }
        });
    });
</script>

<script type="text/javascript">
    $(function () {
        $("input#Months").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'mm-MM',
            onClose: function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
            }
        });
    });
</script>


<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Holiday Entry</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
               Unit Name: <%: Html.DropDownListFor(model => model.UnitID, (List<SelectListItem>)ViewData["UnitName"], "Unit Name", new { @readonly = "true", @class = "Width=250" })%>
               Year: <%: Html.EditorFor(model => model.Years) %>
               Month: <%: Html.EditorFor(model => model.Months) %>
                <div id="RecordsContainer"></div>
            </div>
            <div> 
               <%: Html.ActionLink("Add Idle Months", "IdleEntry")%>
            </div>          
         </fieldset>
        </div>
</div>

 <script type="text/javascript">

     $(document).ready(function () {

         $('#RecordsContainer').jtable({
             paging: true,
             pageSize: 15,
             sorting: false,
             title: 'Idle Entry List',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '<%=Url.Content("~/Inventory/Leaveinfolist") %>',
//                 deleteAction: '<%=Url.Content("~/Inventory/DeleteModelsRecord") %>',
                 updateAction: '<%=Url.Content("~/Inventory/AddUpdateLeaveinfo") %>',
                // createAction: '<%=Url.Content("~/Inventory/AddUpdateLeaveinfo") %>'

             },
             fields: {
                 IID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 EID: {
                     title: 'Equipment No',
                     width: '25%',
                     options: '<%=Url.Content("~/Inventory/AllEQPList") %>'
                 },
                 UnitID: {
                     title: 'Unit Name',
                     width: '20%',
                     options: '<%=Url.Content("~/Inventory/AllUnits") %>'
                 },                 
                 Years: {
                     title: 'Year',
                     displayFormat: 'yy',
                     width: '10%'
                 },                                
                 Months: {
                     title: 'Month',
                     displayFormat: 'mm-MM',
                     width: '15%'
                 },                
                 Idledays: {
                     title: 'Idle Days',                    
                     width: '10%'
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="Years"]').addClass('validate[required]');
                 data.form.find('input[name="Months"]').addClass('validate[required]');
                 //data.form.find('input[name="LeaveDays"]').addClass('validate[required]');
                 data.form.validationEngine();
             },
             //Validate form when it is being submitted
             formSubmitting: function (event, data) {
                 return data.form.validationEngine('validate');
             }
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
    $('input#Months, #Years, #UnitID').change(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 15,
            sorting: false,
            title: 'Idle Entry List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '/Inventory/IdlesearchByuym?Unitid=' + $("#UnitID ").val() + "&years=" + $("#Years").val() + "&months=" + $("#Months").val(),
                updateAction: '<%=Url.Content("~/Inventory/AddUpdateLeaveinfo") %>'              

            },
             fields: {
                 IID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 EID: {
                     title: 'Equipment No',
                     width: '25%',
                     options: '<%=Url.Content("~/Inventory/AllEQPList") %>'
                 },
                 UnitID: {
                     title: 'Unit Name',
                     width: '20%',
                     options: '<%=Url.Content("~/Inventory/AllUnits") %>'
                 },                 
                 Years: {
                     title: 'Year',
                     displayFormat: 'yy',
                     width: '10%'
                 },                                
                 Months: {
                     title: 'Month',
                     displayFormat: 'mm-MM',
                     width: '15%'
                 },                
                 Idledays: {
                     title: 'Idle Days',                    
                     width: '10%'
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="Years"]').addClass('validate[required]');
                 data.form.find('input[name="Months"]').addClass('validate[required]');
                 //data.form.find('input[name="LeaveDays"]').addClass('validate[required]');
                 data.form.validationEngine();
             },
             //Validate form when it is being submitted
             formSubmitting: function (event, data) {
                 return data.form.validationEngine('validate');
             }
             //Dispose validation logic when form is closed
             //             formClosed: function (event, data) {
             //                 data.form.validationEngine('hide');
             //                 data.form.validationEngine('detach');
             //             }
         });  
         $('#RecordsContainer').jtable('load');
     });
 
</script>
</asp:Content>
