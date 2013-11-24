<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PrinterInfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Printer Details</div></div>
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
            pageSize: 30,
            sorting: false,
            defaultSorting: 'Name ASC',
            toolbar: {
                hoverAnimation: true, //Enable/disable small animation on mouse hover to a toolbar item.
                hoverAnimationDuration: 60, //Duration of the hover animation.
                hoverAnimationEasing: undefined, //Easing of the hover animation. Uses jQuery's default animation ('swing') if set to undefined.
                items: [] //Array of your custom toolbar items.
            }, 
            actions: {
                listAction: '<%=Url.Content("~/Devices/PrinterInfoList") %>',
                createAction: '<%=Url.Content("~/Devices/AddUpdatePrinterInfo") %>',
//                updateAction: '<%=Url.Content("~/Devices/AddUpdatePrinterInfo") %>',
                deleteAction: '<%=Url.Content("~/Devices/DeletePrinterInfo") %>'

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
                PrinterID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                AccountCode: {
                    title: 'Account Code',
                    width: '12%'
                },             
                PrinterName: {
                    title: 'Printer Name',
                    width: '15%'
                },               
                IPMAC: {
                    title: 'IP/MAC Address ',
                    width: '10%'
                },
                PurchDate: {
                    title: 'Purchase Date',
                    width: '15%'
                },
                DeptID: {
                    title: 'Department Name',
                    width: '13%',
                    options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                },
                DistDate: {
                    title: 'Distribution Date',
                    width: '10%'
                },
                Type: {
                    title: 'Type',
                    width: '5%'
                },
                Totaluser: {
                    title: 'Total User',
                    width: '10%'
                },
                Dailyppage: {
                    title: 'Daily Print Page',
                    width: '17%'
                },
                DeviceID: {
                    title: 'Device',
                    width: '10%',
                    options: '<%=Url.Content("~/Inventory/AllDeviceNameListItem") %>'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
 </script>

</asp:Content>
