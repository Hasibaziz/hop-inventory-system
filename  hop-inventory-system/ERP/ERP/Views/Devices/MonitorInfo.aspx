﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MonirotInfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Monitor Details</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("DeviceLeftMenu"); %>
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
            pageSize: 10,
            sorting: false,
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Devices/MonitorInfoList") %>',
                deleteAction: '<%=Url.Content("~/Devices/DeleteMonitorInfo") %>',
                updateAction: '<%=Url.Content("~/Devices/AddUpdateMonitorInfo") %>',
                createAction: '<%=Url.Content("~/Devices/AddUpdateMonitorInfo") %>'
            },
            fields: {
                MonitorID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                MonitorName: {
                    title: 'Monitor Name',
                    width: '15%'
                },
                ModelNo: {
                    title: 'Model No',
                    width: '15%'
                },
                SerialNo: {
                    title: 'Serial No',
                    width: '15%'
                },
                PurchDate: {
                    title: 'Purchase Date',
                    width: '15%'
                    
                },
                DeptID: {
                    title: 'Department Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                },
                EmpID: {
                    title: 'Employee ID',
                    width: '10%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameListItem") %>'
                }, 
                DistDate: {
                    title: 'Distribution Date',
                    width: '15%'
                },
                Description: {
                    title: 'Description',
                    width: '10%'
                }

            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
    </script>

</asp:Content>
