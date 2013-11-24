<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Equipmentinfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Equipment Info </div></div>
<div class="mp_right_content">
        <div class="page_list_container">
             <%-- <input type="button" value="Excel" title="Excel Report"   onclick="impexcel()" />--%>
             <%-- <input type="button" value="Save As Excel" title="Save As Excel"   onclick="impexcel01()" />--%>
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
            title: 'Equipment Info List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Inventory/EquipmentinfoList") %>',               
            },
            fields: {
                EID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                SL: {
                    title: 'SL',
                    width: '2%'
                },
                ENumber:{
                    title: 'Equipment No',
                    width:'6%'
                },
                Machineid: {
                    title: 'Machine ID',
                    width: '5%'
                },
                LocID: {
                     title: 'Location',
                     width: '5%',
                     options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                },                              
                AccountCode: {
                    title: 'Asset Code',
                    width: '5%'
                },
                BrandModel: {
                    title: 'Brand & Model',
                    width: '8%'
                },
                Machineno:{
                    title: 'Machine No',
                    width:'5%'
                },
                Type: {
                    title: 'Type OF M/C',
                    width: '7%'
                },
                PurchDate: {
                    title: 'Purchase Date',
                    width: '7%'
                },                
                Lifetime: {
                    title: 'Life Time',
                    width: '3%'
                },  
                UnitID: {
                    title: 'Unit Name',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllUnits") %>'
                },                                                        
                Buildingno: {
                    title: 'Building No',
                    width: '4%'
                },
                FID: {
                    title: 'Level/Floor No',
                    width: '7%',
                    options: '<%=Url.Content("~/Inventory/AllFloorinfo") %>'
                }, 
                LID: {
                    title: 'Line No',
                    width: '3%',
                    options: '<%=Url.Content("~/Inventory/AllLineinfo") %>'
                },                                                       
                Status: {
                    title: 'Status',
                    width: '3%'
                },              
                CID: {
                    title: 'Country',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllCountry") %>'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
    </script>

</asp:Content>
