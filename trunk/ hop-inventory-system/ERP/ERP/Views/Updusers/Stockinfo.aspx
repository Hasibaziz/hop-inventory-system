<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvallstockEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Stockinfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Overall Sock Info</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
                Start Date : <%: Html.TextBoxFor(m => m.StartDate, new { @class = "Control_Moni_Width_100" })%>    
                End Date : <%: Html.TextBoxFor(m => m.EndDate, new { @class = "Control_Moni_Width_100" })%> 
                Item Name: <%: Html.DropDownListFor(model => model.ItemID, (List<SelectListItem>)ViewData["ItemName"], "Select Item", new { @readonly = "true", @class = "Width=250" })%>
                Model No: <%: Html.DropDownListFor(model => model.ModelID, new SelectList(new[] { " " }), "Select Model")%>
                <%--<input type="button" value="Show" title="Save"  id="Getvalue" /> &nbsp; &nbsp;&nbsp;--%>
                <input type="button" value="Save As Excel" title="Save As Excel"   onclick="impexcel()" />
                <div id="RecordsContainer"></div>
           </div>                   
         </fieldset>
        </div>
</div>

<script type="text/javascript">
    function impexcel() {
        //alert("Report");
        window.open("/Updusers/StockinfoByDateExcel?StartDate=" + $("#StartDate").val() + "&EndDate=" + $("#EndDate").val() + "&ItemID=" + $("#ItemID").val() + "&ModelID=" + $("#ModelID").val());
    }
</script>

<script type="text/javascript">

    $('input#StartDate, #EndDate, #ItemID, #ModelID').change(function () {
        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 20,
            sorting: false,
            title: 'The PC List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '/Inventory/StockinfoByDate?StartDate=' + $("#StartDate").val() + "&EndDate=" + $("#EndDate").val() + "&ItemID=" + $("#ItemID").val() + "&ModelID=" + $("#ModelID").val()
                //listAction: '/Inventory/InventoryDetailsListbyDid?DNAME=' + $("#DeptID").val()
            },
            fields: {
                SID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                ItemID: {
                    title: 'Item Name',
                    width: '10%',
                    options: '<%=Url.Content("~/Inventory/AllListItems") %>'
                },
                ModelID: {
                    title: 'Model Name',
                    width: '25%',
                    options: '<%=Url.Content("~/Inventory/AllListModels") %>'
                },
                SDate: {
                    title: 'Stock Date',
                    width: '10%',
                    displayFormat: 'dd-mm-yy'
                },
                TOTALRQty: {
                    title: 'Receiver Qty',
                    width: '10%'
                },
                //                LocID: {
                //                     title: 'Location',
                //                     width: '10%',
                //                     options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                //                     //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
                //                 },
                TOTALIQty: {
                    title: 'Issue Qty',
                    width: '10%'
                },
                BalanceQty: {
                    title: 'Balance Qty',
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
            pageSize: 20,
            sorting: false,
            title: 'The Overall Stock Info List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Updusers/StockinfoList") %>',
                //updateAction: '<%=Url.Content("~/Inventory/Additemreceive") %>'
            },
            fields: {
                SID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                ItemID: {
                    title: 'Item Name',
                    width: '10%',
                    options: '<%=Url.Content("~/Updusers/AllListItems") %>'
                },
                ModelID: {
                    title: 'Model Name',
                    width: '25%',
                    options: '<%=Url.Content("~/Updusers/AllListModels") %>'
                },               
                SDate: {
                    title: 'Stock Date',
                    width: '10%',
                    displayFormat: 'dd-mm-yy'
                },
                TOTALRQty: {
                    title: 'Receiver Qty',
                    width: '10%'
                },
                TOTALIQty: {
                    title: 'Issue Qty',
                    width: '10%'
                },               
                BalanceQty: {
                    title: 'Balance Qty',
                    width: '10%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
</script>
<script type="text/javascript">

//    $(document).ready(function () {

//        $('#RecordsContainer').jtable({
//            paging: true,
//            pageSize: 15,
//            sorting: false,
//            title: 'The Overall Stock Info List',
//            defaultSorting: 'Name ASC',
//            actions: {
//                listAction: '<%=Url.Content("~/Updusers/StockinfoByDate") %>',
//                //updateAction: '<%=Url.Content("~/Inventory/Additemreceive") %>'
//            },
//            fields: {
//                SID: {
//                    key: true,
//                    create: false,
//                    edit: false,
//                    list: false
//                },
//                ItemID: {
//                    title: 'Item Name',
//                    width: '10%',
//                    options: '<%=Url.Content("~/Updusers/AllListItems") %>'
//                },
//                ModelID: {
//                    title: 'Model Name',
//                    width: '25%',
//                    options: '<%=Url.Content("~/Updusers/AllListModels") %>'
//                },               
//                SDate: {
//                    title: 'Stock Date',
//                    width: '10%',
//                    displayFormat: 'dd-mm-yy'
//                },
//                TOTALRQty: {
//                    title: 'Receiver Qty',
//                    width: '10%'
//                },
////                LocID: {
////                     title: 'Location',
////                     width: '10%',
////                     options: '<%=Url.Content("~/Inventory/AllLocation") %>'
////                     //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
////                 },
//                TOTALIQty: {
//                    title: 'Issue Qty',
//                    width: '10%'
//                },               
//                BalanceQty: {
//                    title: 'Balance Qty',
//                    width: '10%'
//                }
//            }
//        });
////        $('#RecordsContainer').jtable('load');
////    });

//     $('#Getvalue').click(function (e) {
//            e.preventDefault();
//            $('#RecordsContainer').jtable('load', {
//                StartDate: $('#StartDate').val(),
//                EndDate: $('#EndDate').val(),
//                ItemID: $('#ItemID').val(),
//                ModelID: $('#ModelID').val()
//            });
//        });
//    });

</script>
<script type="text/javascript">
    $('#ItemID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Inventory/ItemmodelList?IID=")%>' + $("#ItemID> option:selected").attr("value"), function (data) {
                //var items = "";
                //var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#ModelID").html(items);
                $("#ModelID").removeAttr('disabled');
            });
        }
    });
</script>
<script type="text/javascript">
    $(function () {
        $("input#StartDate, #EndDate").datepicker({
            dateFormat: 'dd-mm-yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '-100y:c+nn',
            maxDate: '1d'
        });
    });

</script>

</asp:Content>
