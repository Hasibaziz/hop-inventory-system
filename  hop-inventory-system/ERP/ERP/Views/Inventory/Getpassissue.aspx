<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvgetpassissuereportEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Getpassissue
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#IssueDate").datepicker({ dateFormat: "dd-mm-yy" });
    });
</script>
 
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Issue Report</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
                Date: <%: Html.TextBoxFor(m => m.IssueDate, new { @class = "Width=250" })%>  
                <input type="button" value="Print Report" title="Print"   onclick="printItem()" />
                <div id="RecordsContainer"></div>
            </div>
            <div> 
               <%--<%: Html.ActionLink("Add Issue Item", "Issueitems", new { @href = "#", @id = "dialog_link", title = "Receive Item" })%>--%>
               <%--<%: Html.ActionLink("Add Issue Item", "Issueitems", new { @href = "#", @id = "dialog_link", title = "Receive Item" })%>--%>
            </div>          
         </fieldset>
        </div>
</div>
<script type="text/javascript">
    function printItem() {
//        alert("Report");
        window.open("/Inventory/Getpassissuerpt");
    }
</script>
<script type="text/javascript">

    $('input#IssueDate').change(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 15,
            sorting: false,
            title: 'Issue Report',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '/Inventory/GetpassissueByDate?issuedate=' + $("#IssueDate ").val()                
            },
            fields: {
                //                RIssueID: {
                //                    key: true,
                //                    create: false,
                //                    edit: false,
                //                    list: false
                //                },
                ItemName: {
                    title: 'Item Name',
                    width: '10%'
                },
                ModelName: {
                    title: 'Model Name',
                    width: '20%'
                },
                IssueDate: {
                    title: 'Issue Date',
                    width: '10%'
                },
                IssueName: {
                    title: 'Issue Name',
                    width: '10%'
                },
                ILocation: {
                    title: 'Issue Location',
                    width: '5%'
                },
                ReceiverName: {
                    title: 'Receiver Name',
                    width: '10%'
                },
                Location: {
                    title: 'Location',
                    width: '5%'
                },
                IssueQty: {
                    title: 'Issue Qty',
                    width: '10%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
</script>

<script type="text/javascript">

    $(document).ready(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 15,
            sorting: false,
            title: 'Issue Report',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Inventory/GetpassissueList") %>'
                //updateAction: '<%=Url.Content("~/Inventory/Additemreceive") %>'
            },
            fields: {
//                RIssueID: {
//                    key: true,
//                    create: false,
//                    edit: false,
//                    list: false
//                },
                ItemName: {
                    title: 'Item Name',
                    width: '10%'
                },
                ModelName: {
                    title: 'Model Name',
                    width: '20%'
                },
                IssueDate: {
                    title: 'Issue Date',
                    width: '10%'
                },
                IssueName: {
                    title: 'Issue Name',
                    width: '10%'
                },
                ILocation: {
                    title: 'Issue Location',
                    width: '5%'
                },
                ReceiverName: {
                    title: 'Receiver Name',
                    width: '10%'
                },
                Location: {
                    title: 'Location',
                    width: '5%'
                },
                IssueQty: {
                    title: 'Issue Qty',
                    width: '10%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    }); 
</script>
</asp:Content>
