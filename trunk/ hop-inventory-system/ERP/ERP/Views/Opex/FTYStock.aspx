<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OPEX.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FTYStock
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
                    $(".scroll-text").css("left", 10);
                    $(".scroll-text").css("opacity", 1);
                    marqueePlay();
                }
            );
        }
        marqueePlay();
    }); 
</script>  
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Factory wise Stock</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
           </div>                   
         </fieldset>
        </div>
</div>

<script type="text/javascript">

    $(document).ready(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 15,
            sorting: false,
            title: 'The Factory wise Stock Info List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Opex/FTYStockinfoList") %>',
                //updateAction: '<%=Url.Content("~/Inventory/Additemreceive") %>'
            },
            fields: {
                FSID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                ItemID: {
                    title: 'Item Name',
                    width: '10%',
                    options: '<%=Url.Content("~/Opex/AllListItems") %>'
                },
                ModelID: {
                    title: 'Model Name',
                    width: '25%',
                    options: '<%=Url.Content("~/Opex/AllListModels") %>'
                },               
                FSDate: {
                    title: 'Stock Date',
                    width: '10%',
                    displayFormat: 'dd-mm-yy'
                },
                TFSRQty: {
                    title: 'Receiver Qty',
                    width: '10%'
                },                
                TFSIQty: {
                    title: 'Issue Qty',
                    width: '10%'
                }, 
                LocID: {
                     title: 'Location',
                     width: '10%',
                     options: '<%=Url.Content("~/Opex/AllLocation") %>'
                     //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
                 },              
                FSBalanceQty: {
                    title: 'Balance Qty',
                    width: '10%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
</script>

</asp:Content>
