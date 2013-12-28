<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EmployeeInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
   
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Employee Info</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
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
                title: 'The Employee Info List',
                defaultSorting: 'Name ASC',
                actions: {
                    listAction: '<%=Url.Content("~/Inventory/EmployeeInfoList") %>',
                    updateAction: '<%=Url.Content("~/Inventory/AddUpdateEmployeeInfo") %>',
                    createAction: '<%=Url.Content("~/Inventory/AddUpdateEmployeeInfo") %>'
                },
                fields: {
                    EmpID: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    EmpNo: {
                        title: 'Emp ID',
                        width: '10%'
                    },
                    EmpName: {
                        title: 'Employee Name',                        
                        width: '30%'                        
                    },
                    DeptID: {
                        title: 'Department Name',
                        width: '20%',
                        options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                    },
                    Location: {
                        title: 'Location',
                        width: '15%'
                    },
                    JoinDate: {
                        title: 'Joining Date',
                        width: '15%'
                    }
                },
                formCreated: function (event, data) {
                    data.form.find('input[name="EmpNo"]').addClass('validate[required]');
                    data.form.find('input[name="EmpName"]').addClass('validate[required]');
                    data.form.find('input[name="DeptID"]').addClass('validate[required]');
                    data.form.find('input[name="Location"]').addClass('validate[required]');
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
