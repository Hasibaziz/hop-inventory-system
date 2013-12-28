<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvitemreceiveEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Itemreceive
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>


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
                listAction: '<%=Url.Content("~/Inventory/ItemreceiveList") %>',
                updateAction: '<%=Url.Content("~/Inventory/Additemreceive") %>'
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
                    options: '<%=Url.Content("~/Inventory/AllListItems") %>'
                },
                ModelID: {
                    title: 'Model Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Inventory/AllListModels") %>'
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
                    options: '<%=Url.Content("~/Inventory/AllLocation") %>'
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
