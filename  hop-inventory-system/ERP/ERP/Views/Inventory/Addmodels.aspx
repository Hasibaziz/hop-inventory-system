<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Addmodels
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        function marqueePlay() {
            $(".scroll-text").animate(
                {
                    top: $(window).height(),
                    opacity: 0
                }, 10000, function () {
                    $(".scroll-text").css("left", 15);
                    $(".scroll-text").css("opacity", 1);
                    marqueePlay();
                }
            );
        }
        marqueePlay();
    }); 
</script>  
<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Add Models</div></div>
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
             title: 'The Models Info List',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '<%=Url.Content("~/Inventory/ModelsList") %>',
                 deleteAction: '<%=Url.Content("~/Inventory/DeleteModelsRecord") %>',
                 updateAction: '<%=Url.Content("~/Inventory/AddUpdateModels") %>',
                 createAction: '<%=Url.Content("~/Inventory/AddUpdateModels") %>'

             },
             fields: {
                 ModelID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 ItemID: {
                     title: 'Item',
                     width: '10%',
                     options: '<%=Url.Content("~/Inventory/AllListItems") %>'
                 },
                 ModelName: {
                     title: 'Model',
                     width: '25%'
                 },
                 ModelDate: {
                     title: 'Date of Entry',
                     type: 'date',
                     displayFormat: 'dd-mm-yy',
                     width: '15%'
                 },
                 EXDate: {
                     title: 'Date/Expair',
                     type: 'date',
                     displayFormat: 'dd-mm-yy',
                     width: '15%'
                 },
                 TPage: {
                     title: 'To/Page',                    
                     width: '5%'
                 },
                 Description: {
                     title: 'Description',
                     type: 'textarea',
                     width: '20%'
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="ItemID"]').addClass('validate[required]');
                 data.form.find('input[name="ModelName"]').addClass('validate[required]');
                 data.form.find('input[name="ModelDate"]').addClass('validate[required]');
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


</asp:Content>
