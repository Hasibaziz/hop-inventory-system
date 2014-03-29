<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvEquipmentEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Equipmentinfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Equipment Info </div></div>
<% using (Html.BeginForm("EquipmentDetailsbyloc", "Inventory", FormMethod.Post, new { id = "target" }))
    {%> 
   <!-- ui-dialog -->
	<div id="dialog" title="Search">
        <div class="editor-label01">
            <label for="Location">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @onClick = "javascript:LocCheck(this)" })%>
            <%--<%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>--%>
            <%: Html.ValidationMessageFor(model => model.LocID)%>
            <span style="color:Red;" id="Locmsg" ></span>
        </div>       
        <div class="editor-label01">
            <label for="Location"> Equipment No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.ENumber)%>
            <%: Html.ValidationMessageFor(model => model.ENumber)%>
            <span style="color:Red;" id="Span1" ></span>
        </div>        
        <div style="color:Red;"><span id="Message" ></span></div>
	</div>         
<% } %>

<script type="text/javascript">
    $(document).ready(function () {
        // Dialog
        $('#dialog').dialog({
            autoOpen: false,
            resizable: false,    /// To make the Popup Window Customs resize (Big or Small)
            width: 500,
            modal: true,    // For Background Disable... 
            show: {
                effect: "blind",
                duration: 1000
                },
            hide: {
                effect: "blind",       //effect: "explode",
                duration: 1000
                },
            buttons: {
                "Search": function () {                   
////                    $.ajax({
////                        //url: '@(Url.Action("AddRole", "Home"))',                                                       
////                        //*url: '/Inventory/EquipmentDetailsbyloc'+ $('#LocID').val(),
////                        url: '/Inventory/EquipmentDetailsbyloc',                                               
////                        type: 'POST',
////                        //data: { className: cName }, // Your parameter
////                        //data: "{ Umail: '" + $('.Usermail').val() + "' }",
////                        data: { location: $('#LocID').val() },
////                        //data: { startDate: $('#startDate').val(), endDate: $('#endDate').val(), userName: $('#userName').val() },
////                        dataType: "json",
////                        success: function (Result) {
////                            $('#LocID').val("");                           
////                            $('#dialog').dialog("close");   //For Closing POPUP Window                                                            
////                        },
////                        error: function (Result) {
////                            alert("Error " + Result.Success);
////                        }
//                    });
//                    return false;
                 },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $('#dialog_link').click(function () {
            $('#dialog').dialog('open');
            return false;
        });
    });

</script>
<div style=" margin: 1em .5cm -85px .8cm;">
  <%-- <a href="#" id="dialog_link" onclick="SendValue();"><span class="ui-icon ui-icon-newwin"></span>Search</a>--%>
   <a href="#" id="dialog_link" ><img src="../../Content/images/Search.png", alt="Search" /></a>         
</div>
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
                AccountCode: {
                    title: 'Account Code',
                    width: '5%'
                },
                LocID: {
                     title: 'Location',
                     width: '5%',
                     options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                },                              
                AssetCode: {
                    title: 'Asset Code',
                    width: '5%'
                },
                Brand: {
                    title: 'Brand',
                    width: '5%'
                },
                Model:{
                    title: 'Model',
                    width:'5%'
                },
                Serialno: {
                    title: 'Serial No',
                    width: '7%'
                },
                Subserialno: {
                    title: 'Subserial No',
                    width: '7%'
                },                
                MNID: {
                    title: 'Machine Name',
                    width: '7%',
                    options: '<%=Url.Content("~/Inventory/AllMachineinfo") %>'
                },  
                UnitID: {
                    title: 'Unit Name',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllUnits") %>'
                },                                                        
                BNID: {
                    title: 'Building No',
                    width: '6%',
                    options: '<%=Url.Content("~/Inventory/AllBuildinginfo") %>'
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
                Remarks: {
                    title: 'Idle Date',
                    width: '7%'
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
 <script type="text/javascript">
     function LocCheck(Locvalue) {
         $(Locvalue).change(function () {
             //$('input#LocID').change(function () {    
             //alert("Got Location ID");
             $('#RecordsContainer').jtable({
                 paging: true,
                 pageSize: 10,
                 sorting: false,
                 title: 'Equipment Info List',
                 defaultSorting: 'Name ASC',
                 actions: {
                     listAction: '/Inventory/EquipmentDetailsbyloc?location=' + $(Locvalue).val()
                     //listAction: '/Inventory/InventoryDetailsListbyDid?DNAME=' + $("#DeptID").val()
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
                     ENumber: {
                         title: 'Equipment No',
                         width: '6%'
                     },
                     AccountCode: {
                         title: 'Account Code',
                         width: '5%'
                     },
                     LocID: {
                         title: 'Location',
                         width: '5%',
                         options: '<%=Url.Content("~/Inventory/AllLocation") %>'
                     },
                     AssetCode: {
                         title: 'Asset Code',
                         width: '5%'
                     },
                     Brand: {
                         title: 'Brand',
                         width: '5%'
                     },
                     Model: {
                         title: 'Model',
                         width: '5%'
                     },
                     Serialno: {
                         title: 'Serial No',
                         width: '7%'
                     },
                     Subserialno: {
                         title: 'Subserial No',
                         width: '7%'
                     },
                     MNID: {
                         title: 'Machine Name',
                         width: '7%',
                         options: '<%=Url.Content("~/Inventory/AllMachineinfo") %>'
                     },
                     UnitID: {
                         title: 'Unit Name',
                         width: '5%',
                         options: '<%=Url.Content("~/Inventory/AllUnits") %>'
                     },
                     BNID: {
                         title: 'Building No',
                         width: '6%',
                         options: '<%=Url.Content("~/Inventory/AllBuildinginfo") %>'
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
                     Remarks: {
                         title: 'Idle Date',
                         width: '7%'
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
     }
</script>

</asp:Content>
