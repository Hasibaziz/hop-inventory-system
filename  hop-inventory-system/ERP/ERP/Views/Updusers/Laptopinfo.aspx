﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Upd  Laptopinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Laptop Info</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content">
        <div class="page_list_container">
            <div style="float: left; width: 100%">
                Account Code: <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt" })%>
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
                listAction: '<%=Url.Content("~/Updusers/LaptopinfoList") %>'
            },
            fields: {
                AccountID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                AccountCode: {
                    title: 'Account Code',
                    width: '5%',
                    display: function (data) {
                        return '<a href="/Updusers/LaptopDetailsbyID/' + data.record.AccountID + '">' + data.record.AccountCode + '</a>';
                    }
                },
                EMPID: {
                    title: 'Employee ID',
                    width: '6%',
                    options: '<%=Url.Content("~/Updusers/AllEmployeeNameListItem") %>'
                },
                EMPNAME: {
                    title: 'Employee Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Updusers/AllEmployeeNameItem") %>'
                },
                Location: {
                    title: 'Location',
                    width: '3%'
                },
                DeptID: {
                    title: 'Department',
                    width: '5%',
                    options: '<%=Url.Content("~/Updusers/AllDepartmentNameListItem") %>'
                },
                BrandModel: {
                    title: 'Brand & Model',
                    width: '8%'
                },
                Category: {
                    title: 'Category',
                    width: '5%'
                },
                Configuration: {
                    title: 'Configuration',
                    width: '12%'
                },
                SerialNo: {
                    title: 'Serial No',
                    width: '7%'
                },
                PurchDate: {
                    title: 'Purchase Date',
                    width: '5%'
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
                    title: 'ITE No',
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
