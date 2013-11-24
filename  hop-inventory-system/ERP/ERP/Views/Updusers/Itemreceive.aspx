<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvitemreceiveEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Itemreceive
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
                    $(".scroll-text").css("left", 15);
                    $(".scroll-text").css("opacity", 1);
                    marqueePlay();
                }
            );
        }
        marqueePlay();
    }); 
</script>  
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Item Receive</div></div>
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
            <div> 
               <%: Html.ActionLink("Add Receive Item", "Additemreceive", new { @href="#", @id = "dialog_link", title = "Receive Item" })%>
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
            title: 'The Items Receive List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Updusers/ItemreceiveList") %>',
                updateAction: '<%=Url.Content("~/Updusers/Additemreceive") %>'
            },
            fields: {
                IRID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                ItemID: {
                    title: 'Item Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Updusers/AllListItems") %>'
                },
                ModelID: {
                    title: 'Model Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Updusers/AllListModels") %>'
                },
                RDate: {
                    title: 'Receive Date',
                    width: '15%'
                },
                Chlanno: {
                    title: 'Ref.(Challan No.)',
                    width: '20%'
                },
                Suppliername: {
                    title: 'Supplier Name',
                    width: '20%'
                },
                LocID: {
                    title: 'Location',
                    width: '10%',
                    options: '<%=Url.Content("~/Updusers/AllLocation") %>'
                    //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
                },
                Quantity: {
                    title: 'Quantity',
                    width: '5%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
</script>

</asp:Content>
