<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AllDeviceinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
<script type="text/javascript">
    function impexcel() {
        alert("Report");
        window.open("/Inventory/ExcelReport");
      }
</script>

<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">All Devices </div></div>
<div class="mp_right_content">
        <div class="page_list_container">
              <input type="button" value="Excel" title="Excel Report"   onclick="impexcel()" />
              <input type="button" value="Save As Excel" title="Save As Excel"   onclick="impexcel01()" />
              <div style="float: left; width: 100%;">
                <div id="RecordsContainer">
                </div>
            </div>
        </div>
</div>
<script type="text/javascript">
    function impexcel01() {
        alert("Report");
        window.open("/Inventory/AllInvReport");
    }
</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#RecordsContainer').jtable({
            paging: true,
            scrollbar: true,
            pageSize: 10,
            sorting: false,
            title: 'The All Devices List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Inventory/AllDeviceinfoList") %>',               
            },
            fields: {
                AccountID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
//                SL: {
//                    title: 'SL',
//                    width: '2%'
//                },
               ENumber:{
                    title: 'Equipment No',
                    width:'6%'
                },
                Location: {
                    title: 'Office',
                    width: '3%'
                },
                DeptID: {
                    title: 'Department',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                },
                Team: {
                    title: 'Team',
                    width: '3%'
                },
                Status: {
                    title: 'Status',
                    width: '2%'
                },
                Proposed:{
                    title: 'Proposed',
                    width:'2%'
                },
                HostName: {
                    title: 'Host Name',
                    width: '3%'
                },  
                AccountCode: {
                    title: 'Account Code',
                    width: '5%'
                },
                BrandModel: {
                    title: 'Brand & Model',
                    width: '8%'
                },
                ITemNo: {
                    title: 'ITE No',
                    width: '3%'
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
                Office: {
                     title: 'Location',
                     width: '3%'
                },
                EMPNAME: {
                    title: 'Employee Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameItem") %>'
                }, 
                EMPID: {
                    title: 'Employee ID',
                    width: '7%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameListItem") %>'
                },                               
                PurchDate: {
                    title: 'Purchase Date',
                    width: '7%'
                },
                MonitorID: {
                    title: 'Monitor SL NO',
                    width: '7%'
                },
                UPSID: {
                    title: 'Ups SL NO',
                    width: '7%'
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
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('.mp_left_menu').bind('marquee', function () {
            var boxWidth = $(this).width;
            var textWidth = $('.scroll-text', $(this)).width();
            if (textWidth > boxWidth) {
                var animSpeed = textWidth - boxWidth * 20; // 50 pix per sec
                $(this)
        .animate({ scrollLeft: textWidth - scrollWidth }, animSpeed)
        .animate({ scrollLeft: 0 }, animSpeed, function () {
            $(this).trigger(marquee);
        });
            }
        }).trigger('marquee');
    });
</script>--%>
</asp:Content>