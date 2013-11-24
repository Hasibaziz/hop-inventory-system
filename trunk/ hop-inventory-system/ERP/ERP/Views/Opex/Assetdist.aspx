<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OPEX.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvFTRTransferEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Assetdist
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#IssueDate").datepicker({ dateFormat: "dd-mm-yy" });
    });
</script>
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">FTY Transfer</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
                   Item Name: <%: Html.DropDownListFor(m => m.ItemID, (List<SelectListItem>)ViewData["ItemName"], "Items", new { @readonly = "true", @class = "Width=250" })%>
                   Date: <%: Html.TextBoxFor(m => m.IssueDate, new { @class = "Width=250" })%>                         
                <%--<input type="button" value="Search" title="Save" id="btnGetAccList" />--%>
                <div id="RecordsContainer"></div>
            </div>                   
         </fieldset>
        </div>
</div>



<script type="text/javascript">

    $('input#IssueDate, #ItemID').change(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 10,
            sorting: false,
            title: 'The Items Receive List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '/Opex/AssettransferBylocdate?itemname=' + $("#ItemID ").val() + "&issuedate=" + $("#IssueDate").val(),
                updateAction: '<%=Url.Content("~/Inventory/AddUpdateFTRTransfer") %>'

            },
            fields: {
                TRID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                Models: {
                    title: 'Models',
                    width: '1%',
                    sorting: false,
                    edit: false,
                    create: false,
                    listClass: 'child-opener-image-column',
                    display: function (modelData) {
                        //Create an image that will be used to open child table
                        var $img = $('<img class="child-opener-image" src="/Content/images/Misc/note.png" title="Model Quantity" />');
                        //Open child table when user clicks the image
                        $img.click(function () {
                            $('#RecordsContainer').jtable('openChildTable',
                                    $img.closest('tr'),
                                    {
                                        //title: modelData.record.IssueDate + modelData.record.ItemID + ' - Issue Asset',
                                        title: modelData.record.IssueDate + ' - Issue Asset',
                                        actions: {
                                            listAction: '/Opex/AssetdistbyMDate?MDate=' + modelData.record.IssueDate + "&itemid=" + modelData.record.ItemID
                                            //deleteAction: '@Url.Action("DeletePhone")',
                                            //updateAction: '@Url.Action("UpdatePhone")',
                                            //createAction: '@Url.Action("CreatePhone")'
                                        },
                                        fields: {
                                            //                                            IssueDate: {
                                            //                                                type: 'hidden',
                                            //                                                defaultValue: modelData.record.IssueDate
                                            //                                            },
                                            RIssueID: {
                                                key: true,
                                                create: false,
                                                edit: false,
                                                list: false
                                            },
                                            ModelID: {
                                                title: 'Model Name',
                                                width: '15%',
                                                options: '<%=Url.Content("~/Opex/AllListModels") %>'
                                            },
                                            IssueQty: {
                                                title: 'Issue Qty',
                                                width: '10%'
                                            }
                                        }
                                    }, function (data) { //opened handler
                                        data.childTable.jtable('load');
                                    });
                        });
                        //Return image to show on the person row
                        return $img;
                    }
                },
                ItemID: {
                    title: 'Item Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Opex/AllListItems") %>'
                },
                IssueDate: {
                    title: 'Issue Date',
                    width: '25%'
                },
                LocID: {
                    title: 'Location',
                    width: '10%',
                    options: '<%=Url.Content("~/Opex/AllLocation") %>'
                    //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
                },
                IsReceive: {
                    title: 'Status',
                    width: '10%',
                    type: 'checkbox',
                    values: { 'false': 'Not Receive', 'true': 'Receive' },
                    defaultValue: 'false'
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
            pageSize: 10,
            sorting: false,
            title: 'The Items Receive List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Opex/FTRTransferList") %>',
                updateAction: '<%=Url.Content("~/Opex/AddUpdateFTRTransfer") %>'
            },
            fields: {
                TRID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                Models: {
                    title: 'Models',
                    width: '1%',
                    sorting: false,
                    edit: false,
                    create: false,
                    listClass: 'child-opener-image-column',
                    display: function (modelData) {
                        //Create an image that will be used to open child table
                        var $img = $('<img class="child-opener-image" src="/Content/images/Misc/note.png" title="Model Quantity" />');
                        //Open child table when user clicks the image
                        $img.click(function () {
                            $('#RecordsContainer').jtable('openChildTable',
                                    $img.closest('tr'),
                                    {
                                        //title: modelData.record.IssueDate + modelData.record.ItemID + ' - Issue Asset',
                                        title: modelData.record.IssueDate + ' - Issue Asset',
                                        actions: {
                                            listAction: '/Opex/AssetdistbyMDate?MDate=' + modelData.record.IssueDate + "&itemid=" + modelData.record.ItemID
                                            //deleteAction: '@Url.Action("DeletePhone")',
                                            //updateAction: '@Url.Action("UpdatePhone")',
                                            //createAction: '@Url.Action("CreatePhone")'
                                        },
                                        fields: {
                                            //                                            IssueDate: {
                                            //                                                type: 'hidden',
                                            //                                                defaultValue: modelData.record.IssueDate
                                            //                                            },
                                            RIssueID: {
                                                key: true,
                                                create: false,
                                                edit: false,
                                                list: false
                                            },
                                            ModelID: {
                                                title: 'Model Name',
                                                width: '15%',
                                                options: '<%=Url.Content("~/Opex/AllListModels") %>'
                                            },
                                            IssueQty: {
                                                title: 'Issue Qty',
                                                width: '10%'
                                            }
                                        }
                                    }, function (data) { //opened handler
                                        data.childTable.jtable('load');
                                    });
                        });
                        //Return image to show on the person row
                        return $img;
                    }
                },
                ItemID: {
                    title: 'Item Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Opex/AllListItems") %>'
                },
                IssueDate: {
                    title: 'Issue Date',
                    width: '25%'
                },
                LocID: {
                    title: 'Location',
                    width: '10%',
                    options: '<%=Url.Content("~/Opex/AllLocation") %>'
                    //options: { 'HLNT': 'HLNT', 'HLAP': 'HLAP', 'HLBD': 'HLBD', 'HLRC': 'HLRC', 'HLWF': 'HLWF', 'HYBD': 'HYBD', 'HLST': 'HLST' }
                },
                IsReceive: {
                    title: 'Status',
                    width: '10%',
                    type: 'checkbox',
                    values: { 'false': ' Not Receive', 'true': ' Receive' },
                    defaultValue: 'false'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
</script>

</asp:Content>
