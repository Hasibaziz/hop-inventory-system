﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvEquipmentEntity>" %>

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
<% using (Html.BeginForm("Forgetpass", "Account", FormMethod.Post, new { id = "target" }))
    {%> 
   <!-- ui-dialog -->
	<div id="dialog" title="Search">
        <div class="editor-label01">
            <label for="Location">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @onblur = "javascript:LocCheck(this, document.getElementById('Locmsg'))" })%>
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
                effect: "explode",
                duration: 1000
                },
            buttons: {
                "Search": function () {
                    //jQuery(this).dialog('close');
                    $.ajax({
                        //url: '@(Url.Action("AddRole", "Home"))',                                                       
                        //*url: '/Account/GetForgetmail',
                        type: 'POST',
                        //data: { className: cName }, // Your parameter
                        //data: "{ Umail: '" + $('.Usermail').val() + "' }",
                        //*data: { Umail: $('#Useremail').val() },
                        //data: { startDate: $('#startDate').val(), endDate: $('#endDate').val(), userName: $('#userName').val() },
                        dataType: "json",
                        success: function (Result) {
                            //var Mail = /^\w+@\w+\.\w{2,3}$/;   
                            //window.close(); 
                            $('#Useremail').val("");
                            //$('#TextBox').hide();                         //window.close(); OR $('#popup_id').hide();   //$('#popup_wrapper_id').fadeOut();
                            $('#Message').html("Please Check");     //$('#div_id').html("Write message or other response form your action").
                            $('#dialog').dialog("close");   //For Closing POPUP Window
                            //window.parent.location.href = window.parent.location.href; //For Refresh the Parent Form
                            //return false;
                            //alert(Result.Success);
                            //alert("Please Check Mail ");
                                 
                        },
                        error: function (Result) {
                            alert("Error " + Result.Success);
                        }
                    });
                    return false;
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

        //             hover states on the static widgets
        //             $('#dialog_link, ul#icons li').hover(
        //				function () { $(this).addClass('ui-state-hover'); },
        //				function () { $(this).removeClass('ui-state-hover'); }
        //			);

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
