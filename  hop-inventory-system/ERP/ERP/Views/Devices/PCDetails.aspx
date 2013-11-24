<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PCDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!------------------------------ Validation engine script file and english localization ------------------------------------------->
 <!-- Validation engine style file -->
<%--<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>--%>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive-ajax.min.js") %>" type="text/javascript"></script>

<%---------------------------------------------------------------------------------------------------------------------------------%>
<%----------------------------------------------Popup Menu---------------------------------------------------------------------- --%>
<%--<link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script> --%>
<%----------------------------------------------Popup Menu---------------------------------------------------------------------- --%>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#PurchDate, #MPurchDate, #MDistDate, #UPurchDate, #UDistDate ").datepicker({ dateFormat: "dd-mm-yy" });
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

///////////////////////////////////-----------------------------------/////////////////////////////////////////////////
//    $(document).ready(function () {
//        // Dialog
//        $('#dialog').dialog({
//            autoOpen: false,
//            width: 900,
//            height: 250,
//            modal: true,
//            buttons: {
//                "Save": function () {
//                    $(this).dialog("close");
//                },
//                "Cancel": function () {
//                    $(this).dialog("close");
//                }
//            }
//        });
//        // Dialog Link
//        $('#dialog_link').click(function () {
//            $('#dialog').dialog('open');
//            return false;
//        });

//        //hover states on the static widgets
//        //        $('#dialog_link, ul#icons li').hover(
//        //				function () { $(this).addClass('ui-state-hover'); },
//        //				function () { $(this).removeClass('ui-state-hover'); }
//        //			);
//    });
    ////////////-----------------------------UPS--------------------------------/////////////////////
//    $(document).ready(function () {
//        // Dialog
//        $('#dialog01').dialog({
//            autoOpen: false,
//            width: 900,
//            height: 250,
//            modal: true,
//            buttons: {
//                "Save": function () {
//                    $(this).dialog("close");
//                },
//                "Cancel": function () {
//                    $(this).dialog("close");
//                }
//            }
//        });
//        // Dialog Link
//        $('#dialog_link01').click(function () {
//            $('#dialog01').dialog('open');
//            return false;
//        });

//        //hover states on the static widgets
//        //        $('#dialog_link, ul#icons li').hover(
//        //				function () { $(this).addClass('ui-state-hover'); },
//        //				function () { $(this).removeClass('ui-state-hover'); }
//        //			);
//    });



</script>  
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">PC Details</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("DeviceLeftMenu"); %>
</div>--%>

 
<div class="mp_right_content_form">
   <div class="page_list_container">
         <div style="float:Left; width: 10%;">
           <div id="RecordsContainer"></div>
  </div> 

        <%-- <% using (Html.BeginForm(new { ID="MyID"}))--%>
         <% using (Html.BeginForm())
            { %>
          <div style="color:#B0171F; font-size: x-large; text-align: center">PC Information</div>
           <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Select Location </legend>
            <%: Html.HiddenFor(m => m.AccountID)%>
            <%: Html.HiddenFor(m => m.ENumber)%>
            <%: Html.HiddenFor(m => m.MonitorID)%>
            <%: Html.HiddenFor(m => m.UPSID)%>
            <div class="editor-label01">
                <label for="Location">Office: </label>
              </div>
            <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m=>m.Location) %>--%>
                <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD", "HLST" }), "Select Office")%>
                <%: Html.ValidationMessageFor(m => m.Location)%>                               
            <%--<input type="button" value="Search" title="Save" id="btnGetCarList" />--%>
            </div>
            <%--<div class="editor-label01">
                <label for="Location">Equipment Number: </label>
            </div>
            <div class="editor-field01">--%>
                <%--<%: Html.TextBoxFor(m=>m.Location) %>--%>
              <%--  <%: Html.TextBoxFor(m => m.ENumber, new { @readonly = true, @class = " Control_Moni_Width_100" })%>
                <%: Html.ValidationMessageFor(m => m.ENumber)%>                               --%>
            <%--<input type="button" value="Search" title="Save" id="btnGetCarList" />--%>
           <%-- </div>--%>
            </fieldset>           
            <fieldset> <%--<fieldset width="30" hight="100">--%>
            <legend class="LegendColor">Details Information</legend>
               <div class="editor-label01">
                 <label for="AccountCode">Account Code: *</label>
               </div>
               <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.AccountCode)%>
                <%: Html.ValidationMessageFor(m => m.AccountCode)%> 
              </div>
              <div class="editor-label01">
                <label for="DeptNo">Department Name</label>
              </div>
              <div class="editor-field01">
               <%-- <%: Html.TextBoxFor(m => m.DeptNo)%>--%>
               <%: Html.DropDownListFor(m => m.DeptID, (List<SelectListItem>)ViewData["DeptName"], "Select Department", new { @readonly = "true", @class = "Width=250" })%>
               <%: Html.ActionLink("Add New", "DepartmentInfo")%>
               <%: Html.ValidationMessageFor(m => m.DeptID)%> 
              </div>  
              <div class="editor-label01">
                <label for="Team">Team</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Team)%>
              </div>
              <div class="editor-label01">
                <label for="Status">Status</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Status)%>
              </div>
              <div class="editor-label01">
                <label for="Status">Proposed</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Proposed)%>
              </div>
               <div class="editor-label01">
                <label for="HostName">Host Name</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.HostName)%>
              </div>
              <div class="editor-label01">
                <label for="BrandModel">Brand & Model</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.BrandModel) %>
              </div>
               <div class="editor-label01">
                <label for="ITemNo">ITE. No</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.ITemNo)%>
              </div>
  <div class="New_Right_Begin">   
              <div class="editor-label01">
                <label for="Category">Category</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Category) %>
              </div>
              <div class="editor-label01">
                <label for="Configuration">Configuration</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Configuration) %>
              </div>              
               <div class="editor-label01">
                <label for="SerialNo">S/L Number</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.SerialNo) %>
              </div>              
             <div class="editor-label01">
                <label for="Category">Location</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Office) %>
              </div>                
              <div class="editor-label01">
                <label for="UserName">User ID</label>
              </div>
              <div class="editor-field01">
              <%--<%: Html.TextBoxFor(m=>m.UserName) %>  --%>  
              <%: Html.DropDownListFor(model => model.EMPID, new SelectList(new[] { " " }), "Select Emp ID")%> 
              <%--<%: Html.DropDownListFor(m => m.EMPID, (List<SelectListItem>)ViewData["EmpNo"], "Employee ID", new { @readonly = "true", @class = "Width=250" })%>           --%>
              <%: Html.ActionLink("Add New", "EmployeeInfo", new { @href = "#", @id = "dialog_link", title = "Receive Item" })%>
              <%: Html.ValidationMessageFor(m => m.EMPID)%>              
              </div>                    
              <div class="editor-label01">
                <label for="PurchDate">Purchase Date</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.PurchDate) %>
              </div>            
              <div class="editor-label01">
                <label for="Remark">Remarks</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextAreaFor(m => m.Remark)%>
              </div>  
             <div class="editor-label01">
                <label for="Remark">Device</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.DeviceID, (List<SelectListItem>)ViewData["DeviceName"], "Select Device", new { @readonly = "true", @class = "Width=250" })%>
                <%: Html.ValidationMessageFor(m => m.DeviceID)%>
              </div> 
            </div>         
 </fieldset>           
       </div>  
 <fieldset> <%--<fieldset width="10" hight="100">--%>  
 <legend class="LegendColor">ADD Monitor OR UPS Information </legend>
<%-- <div style=" margin: 1em .5cm 0px .5cm;">
   <a href="#" id="dialog_link" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>Add Monitor</a>                        
 </div>
 <div style="margin: -3.6em 1px 5px 125px;">
   <a href="#" id="dialog_link01" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>Add uPs</a>               
 </div>--%>
         <legend class="LegendColor">Monitor Information </legend>
              <div class="Monitor-label">
                <label for="Monitorname">MonitorAcc Code</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MonitorName, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Modelno">Model No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MModelNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
        <div class="New_Right_Monitor">
             <div class="Monitor-label">
                <label for="Modelno">Serial No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MSerialNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Purchage Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MPurchDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
         </div>
           <div class="New_Right_Monitor01">
               <div class="Monitor-label">
                <label for="Purchagedate">Distribution Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MDistDate, new { @class = " Control_Moni_Width_100" })%>
             </div>
        </div>
  </fieldset>
 <fieldset><%--<fieldset width="10" hight="100">--%>
           <legend class="LegendColor">UPS Information </legend>
              <div class="Monitor-label">
                <label for="UPSname">UPSAcc Code</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UPSName, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="UPSno">UPS No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UModelNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
        <div class="New_Right_Monitor">
             <div class="Monitor-label">
                <label for="Modelno">Serial No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.USerialNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Purchage Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UPurchDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
         </div>
        <div class="New_Right_Monitor01">
               <div class="Monitor-label">
                <label for="Purchagedate">Distribution Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UDistDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
        </div>
  </fieldset>
           <p style="padding-left:400px"><input type="submit" class="Submit"  value="Save"   /></p>  
           <%--<input type="button" value="Clean Boxes" title="Clean" id="msg"   onclick="TXTBOX()" />   --%> 
                <div style="float: left; width: 100%;">
                  
    <% } %>  
   </div>  
  </div>  


        <!-- ui-dialog -->
<%--<div id="dialog" title="Monitor Details">
  <legend class="LegendColor">Monitor Information </legend>
              <div class="Monitor-label">
                <label for="Monitorname">MonitorAcc Code </label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MonitorName, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Modelno">Model No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MModelNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
     <div class="New_Right_Monitor">
             <div class="Monitor-label">
                <label for="Modelno">Serial No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MSerialNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Purchage Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MPurchDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
      </div>
           <div class="New_Right_Monitor01">
               <div class="Monitor-label">
                <label for="Purchagedate">Distribution Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.MDistDate, new { @class = " Control_Moni_Width_100" })%>
             </div>
        </div>       
        
</div>        --%>
<%--<div id="dialog01" title="uPs Details">
 <legend class="LegendColor">UPS Information </legend>
              <div class="Monitor-label">
                <label for="UPSname">UPSAcc Code</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UPSName, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="UPSno">UPS No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UModelNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
        <div class="New_Right_Monitor">
             <div class="Monitor-label">
                <label for="Modelno">Serial No</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.USerialNo, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Purchage Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UPurchDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
         </div>
        <div class="New_Right_Monitor01">
               <div class="Monitor-label">
                <label for="Purchagedate">Distribution Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.UDistDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
        </div>

</div>--%>
  
          
<%--<script type="text/javascript">
    $(function () {
        $('#Submit').click(function () {
            $.post(this.href, function (json) {
                $("#Submit").dialog({
                    resizable: false,
                    height: 140,
                    modal: true,
                    buttons: {
                        "Yes": function () {
                            $("#Configuration").val(''); // clear textbox
                            $('#BrandModel').val(''); //clear textbox
                            $(this).dialog("close");
                            Confirm = true; obj.click();
                        },
                        "No": function () {
                            $(this).dialog("close");
                        }
                    }
                });
                // TODO: Do something with the JSON object 
                // returned the your controller action
                $.post('<%: ResolveUrl("~/Devices/PCDetails")%>');
                alert(json.Script);
            });
            return false;
        });
    });

</script>--%>

 <%--<script type="text/javascript">
$(function () {
     var Confirm = false;
      if (!Confirm) {
            $("#Submit").dialog({
                resizable: false,
                height: 140,
                modal: true,
                buttons: {
                    "Yes": function () {
                        $("#Configuration").val(''); // clear textbox
                        $('#BrandModel').val(''); //clear textbox
                        $(this).dialog("close");
                        Confirm = true; obj.click();
                    },
                    "No": function () {
                        $(this).dialog("close");
                    }
                }
            });
        return Confirm;
    }
 });
</script>--%>


<%--<script type="text/javascript">
    var Confirm = false;
    function TXTBOX() {
//        alert("Text Clean");
        if (!Confirm) {
            $("#msg").dialog({
                resizable: false,
                height: 140,
                modal: true,
                buttons: {
                    "Yes": function () {
                        $("#Configuration").val(''); // clear textbox
                        $('#BrandModel').val(''); //clear textbox
                        $(this).dialog("close");
                        Confirm = true; obj.click();
                    },
                    "No": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }

        return Confirm;
    }
</script>--%>

<%-- Clean Text Boxes
$.msgBox({
    title: "Are You Sure",
    content: "Would you like a cup of coffee?",
    type: "confirm",
    buttons: [{ value: "Yes" }, { value: "No" }, { value: "Cancel"}],
    success: function (result) {
        if (result == "Yes") {
            alert("One cup of coffee coming right up!");

        }
    }
});
-----------------------------------------------------------------------------------------------------------
 $(document).ready(function () {
$('#equipment_warrantyLength').change(ResetDates); //fires when drop down changed

function ResetDates() {
    alert("hello");

    $("#equipment_purchaseDate").val(''); // clear textbox
    $('#equipment_warrentyExpires').val(''); //clear textbox
}
});--%>
<script type="text/javascript">

    $('#DeptID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Devices/EmployeeList?ClassID=")%>' + $("#DeptID > option:selected").attr("value"), function (data) {
                var items = "";
                var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#EMPID").html(items);
                $("#EMPID").removeAttr('disabled');
            });
        }
    });
                   
</script>
<%--<script type="text/javascript">

    $('#EMPID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Devices/GetEmployeeInfo?UserID=")%>' + $("#EMPID > option:selected").attr("value"), function (data) {
                var items = "";
                //                var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $('input:text[id$=MonitorName]').val(data.MonitorName);
                $('input:text[id$=MModelNo]').val(data.MModelNo);
                $('input:text[id$=MSerialNo]').val(data.MSerialNo);
                $('input:text[id$=MPurchDate]').val(data.MPurchDate);
                $('input:text[id$=MDistDate]').val(data.MDistDate);
            });
        }
    });
                   
</script>--%>
<%--<script type="text/javascript">

    $('#EMPID').change(function () {
        //         var EmployeeID = document.getElementById("EMPID");
        //        var selectedID = $(this).val();
        //        $.get('<%: ResolveUrl("~/Inventory/GetEmployeeInfo?UserID=")%>' + selectedID, function (data) {
        $.post('<%: ResolveUrl("~/Devices/GetEmployeeInfo?UserID=")%>' + $("#EMPID > option:selected").attr("value"), function (data) {
            //         $("#EMPID").change(function () {$.get("~/Inventory/GetEmployeeInfo", { UserID : $(this).val() }, function (data) {
            //         $.post('<%: ResolveUrl("~/Inventory/GetEmployeeInfo?UserID=")%>' + $("#EMPID").val(EmployeeID), function (data) {
            $('input:text[id$=MonitorName]').val(data.MonitorName);
            $('input:text[id$=MModelNo]').val(data.MModelNo);
            $('input:text[id$=MSerialNo]').val(data.MSerialNo);
            $('input:text[id$=MPurchDate]').val(data.MPurchDate);
            $('input:text[id$=MDistDate]').val(data.MDistDate);

            $('input:text[id$=UPSName]').val(data.UPSName);
            $('input:text[id$=UModelNo]').val(data.UModelNo);
            $('input:text[id$=USerialNo]').val(data.USerialNo);
            $('input:text[id$=UPurchDate]').val(data.UPurchDate);
            $('input:text[id$=UDistDate]').val(data.UDistDate);

        });

    }); 
</script>--%>
<script type="text/javascript">

    $('#AccountCode').change(function () {
      var Result = $.post('<%: ResolveUrl("~/Inventory/Depvaluecheck?UserID=")%>' + $("#AccountCode").attr("value"), function (data) {
        //alert("********* WORKING *************");
      if (data.EMPID != null)
         alert("Value Already Exist");
        });

    });

</script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.Submit').click(function () {
            $.ajax({
                type: "POST",
                url: '/Devices/PCDetails',
                dataType: "json",
                data: JSON.stringify(InvInventorydetailsEntity),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.Success) {
                        alert("Asset Code Already Exists");
                        //alert(result.Message);
                    }
                },
                error: function (data) { alert("Asset Code Already Exists!!!"); }
                //                                onSuccess: function (result) {
                //                                    result = $.parseJSON(result);
                //                                    if (result.success) {
                //                                        alert(result.Message);
                //                                    }
                //                                    else {
                //                                        alert("...");
                //                                    }
                //                                }
            });
            return false;
        });
    });
</script>



</asp:Content>
