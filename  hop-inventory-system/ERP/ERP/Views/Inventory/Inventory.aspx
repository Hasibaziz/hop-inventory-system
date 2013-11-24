<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InventoryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Inventory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>
<div class="mp_right_content">
        <div class="page_list_container">
            <div style="float: left; width: 100%">
                Account Code: <%: Html.TextBoxFor(m => m.AccCode, new { @class = "datefield Search_width_txt" })%>
            <input type="button" value="Search" title="Save" id="btnGetCarList" />
            </div>
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer">
                </div>
            </div>
        </div>
</div>

<script type="text/javascript">

        $(document).ready(function () {

            $('#RecordsContainer').jtable({
                paging: true,
                pageSize: 10,
                sorting: false,
                defaultSorting: 'Name ASC',
                actions: {
                    listAction: '<%=Url.Content("~/Inventory/InventoryInfoList") %>',
                    deleteAction: '<%=Url.Content("~/Inventory/DeleteInventoryInfo") %>',
                    updateAction: '<%=Url.Content("~/Inventory/AddUpdateInventoryInfo") %>',
                    createAction: '<%=Url.Content("~/Inventory/AddUpdateInventoryInfo") %>'
                },
                fields: {
                    AccID: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    AccCode: {
                        title: 'Account Code',
                        width: '3%'
                    },
                    BrandModel: {
                        title: 'Brand & Model',
                        width: '2%'
                    },
                    Category: {
                        title: 'Category',
                        width: '2%'
                    },
                    Configuration: {
                        title: 'Configuration',
                        width: '3%'
                    },
                    SerialNo: {
                        title: 'Serial No',
                        width: '3%'
                    },
                    Location: {
                        title: 'Location',
                        width: '3%'
                    },
                    UserName: {
                        title: 'User Name',
                        width: '5%'
                    },
                    PurchDate: {
                        title: 'Purchage Date',
                        width: '5%'
                    },                   
                    MonitorSLNO: {
                        title: 'Monitor SL NO',
                        width: '5%'
                    },
                    UpsSLNO: {
                        title: 'Ups SL NO',
                        width: '3%'
                    },
                    DeptNo: {
                        title: 'Dept.No',
                        width: '3%'
                    },
                    Team: {
                        title: 'Team',
                        width: '3%'
                    },
                    Status: {
                        title: 'Status',
                        width: '2%'
                    },
                    HostName: {
                        title: 'Host Name',
                        width: '3%'
                    },
                    ITemNo: {
                        title: 'ITem No',
                        width: '3%'
                    },
                     Remark: {
                        title: 'Remark',
                        width: '3%'
                    }
                    
                }
            });
            $('#RecordsContainer').jtable('load');
        });
 
    </script>

</asp:Content>
