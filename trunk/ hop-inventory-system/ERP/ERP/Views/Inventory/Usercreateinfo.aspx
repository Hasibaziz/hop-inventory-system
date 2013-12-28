<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usercreate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
  
<div class="mp_left_menu"><div class="scroll-text"style="background-color: #DB7093; font: Arial;">User Create</div></div>
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
                pageSize: 20,
                sorting: false,
                 title: 'The User Information List',
                defaultSorting: 'Name ASC',
                actions: {
                    listAction: '<%=Url.Content("~/Inventory/UsercreateinfoList") %>',
                    updateAction: '<%=Url.Content("~/Inventory/AddUpdateUsercreateInfo") %>',
                    createAction: '<%=Url.Content("~/Inventory/AddUpdateUsercreateInfo") %>',
                    //deleteAction: '<%=Url.Content("~/Inventory/DeleteEmployeeInfo") %>'
                },
                fields: {
                    UserID: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    UserName: {
                        title: 'UserName',
                        width: '25%'
                    },
                    Usermail: {
                        title: 'User Email',
                        list: false
                    },
                    Password: {
                        title: 'Password',
                        type: 'password',
                        list: false
                    },                    
                    LocID: {
                        title: 'Location',
                        width: '25%',
                        //options: { 'HLNT': 'HLNT', 'HLBD': 'HLBD','HLAP': 'HLAP' }
                        options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                    },
                    UsersStatus: {
                        title: 'User Status',
                        width: '20%',
                        options: { 'Admin':  'Admin',
                                   'Normal': 'Normal',
                                   'Common': 'Common',
                                   'OPEX':'OPEX'
                                  }
                    },
                    Createdate: {
                        title: 'Create Date',
                        width: '20%'
                    }
                },
                formCreated: function (event, data) {
                    data.form.find('input[name="UserName"]').addClass('validate[required]');
                    data.form.find('input[name="Password"]').addClass('validate[required]');
                    data.form.find('input[name="Usermail"]').addClass('validate[required]');
                    data.form.find('input[name="Location"]').addClass('validate[required]');                   
                    data.form.find('input[name="Createdate"]').addClass('validate[required]');                   
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
