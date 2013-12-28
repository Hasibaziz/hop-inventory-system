<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DepartmentInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>


<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Department Info</div></div>
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
            title: 'The Department List',
            //defaultSorting: 'Name ASC',
            sorting: true,
            toolbar: {
                hoverAnimation: true, //Enable/disable small animation on mouse hover to a toolbar item.
                hoverAnimationDuration: 60, //Duration of the hover animation.
                hoverAnimationEasing: undefined, //Easing of the hover animation. Uses jQuery's default animation ('swing') if set to undefined.
                items: [] //Array of your custom toolbar items.
            }, 
            actions: {
                listAction: '<%=Url.Content("~/Inventory/DepartmentInfoList") %>',
                //deleteAction: '<%=Url.Content("~/Inventory/DeleteDepartmentInfo") %>',
                updateAction: '<%=Url.Content("~/Inventory/AddUpdateDepartmentInfo") %>',
                createAction: '<%=Url.Content("~/Inventory/AddUpdateDepartmentInfo") %>'
            },
            toolbar: {
                items: [{
                    tooltip: 'Click here to export this table to excel',
                    icon: '/Content/images/excel.jpg',
                    text: 'Export to Excel',
                    click: function () {
                        alert('This item is just a demonstration for new toolbar feature.');
                        //perform your custom job...
                    }
                }, {
                    icon: '/Content/images/excel.jpg',
                    text: 'Export to Pdf',
                    click: function () {
                        //perform your custom job...
                    }
                }]
            },  
            fields: {
                DeptID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                DeptNo: {
                    title: 'Department No',
                    width: '20%'
                },
                DeptName: {
                    title: 'Department Name',
                    width: '25%'
                },
                Description: {
                    title: 'Description',
                    width: '25%'
                }
            },
                formCreated: function (event, data) {
                    data.form.find('input[name="DeptNo"]').addClass('validate[required]');
                    data.form.find('input[name="DeptName"]').addClass('validate[required]');
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
