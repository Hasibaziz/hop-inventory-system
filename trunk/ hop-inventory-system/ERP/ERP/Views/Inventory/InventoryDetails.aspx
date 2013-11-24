<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    InventoryDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<link href="../../Content/NewUserStyle.css" rel="stylesheet" type="text/css" />--%>
<%--<script src="<%: Url.Content("~/Scripts/jquery-1.5.1.min.js") %>" type="text/javascript"></script>--%>
<%--<script src="<%: Url.Content("~/Scripts/jquery-1.6.4.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validationEngine-en.js") %>" type="text/javascript" charset="utf-8">	</script>
<script src="<%: Url.Content("~/Scripts/jquery.validationEngine.js") %>" type="text/javascript" charset="utf-8">	</script>--%>


<%--<script type="text/javascript">
    jQuery(document).ready(function () {
        // binds form submission and fields to the validation engine
        jQuery("#formID").validationEngine();
    });
</script>--%>
<%--Hasib; hasib_aziz@yahoo.com--%>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#PurchDate, #MPurchDate, #MDistDate, #UPurchDate, #UDistDate").datepicker({ dateFormat: "dd-mm-yy" });
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">PC Info</div></div>
<div class="mp_right_content_form">
        <div class="page_list_container">
         <% using (Html.BeginForm())
         { %>
            <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Enter Asset ID </legend>
            <%: Html.HiddenFor(m => m.AccountID) %>
            <%: Html.HiddenFor(m => m.MonitorID) %>
            <%: Html.HiddenFor(m => m.UPSID) %>
             <div class="editor-label01">
                <label for="Location">Office: </label>
              </div>
            <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m=>m.Location) %>--%>
                <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD", "HLST" }), "Select")%>
                <%: Html.ValidationMessageFor(m => m.Location)%>                               
            <%--<input type="button" value="Search" title="Save" id="btnGetCarList" />--%>
            </div>
           <%-- <div class="editor-label01">
                <label for="Location">Equipment Number: </label>
              </div>
            <div style="float: left; width: 100%">              
                <%: Html.TextBoxFor(m => m.ENumber)%>
                <%: Html.ValidationMessageFor(m => m.ENumber)%>                                          
            </div>--%>
            </fieldset>
            <fieldset> <%--<fieldset width="30" hight="100">--%>
            <legend class="LegendColor">Details Information</legend>
              <div class="editor-label01">
                 <label for="AccountCode">Account Code: *</label>
              </div>
              <div class="editor-field01">
               <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt"})%>
               <%: Html.ValidationMessageFor(m => m.AccountCode)%> 
              </div>
              <div class="editor-label01">
                <label for="DeptNo">Department Name</label>
              </div>
              <div class="editor-field01">
               <%-- <%: Html.TextBoxFor(m => m.DeptNo)%>--%>
               <%: Html.DropDownListFor(m => m.DeptID, (List<SelectListItem>)ViewData["DeptName"], "Select Department", new { @readonly = "true", @class = "Width=250" })%>
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
                <label for="SerialNo">Serial No</label>
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
              <%: Html.DropDownListFor(m => m.EMPID, (List<SelectListItem>)ViewData["EmpNo"], "Employee ID", new { @readonly = "true", @class = "Width=250" })%>           
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
                <%: Html.DropDownListFor(m => m.DeviceID, (List<SelectListItem>)ViewData["DeviceName"], "Select Device", new { @readonly = "true", @class = "Width=250", @color = "#ffffff" })%>
                <%: Html.ValidationMessageFor(m => m.DeviceID)%>
              </div> 
            </div>         
 </fieldset>           
       </div>  
 <fieldset> <%--<fieldset width="10" hight="100">--%>  
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
  </fieldset>
  <fieldset> <%--<fieldset width="10" hight="100">--%>  
            <legend class="LegendColor">UPS Information </legend>
              <div class="Monitor-label">
                <label for="UPSname">UPSAcc Code </label>
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
           <p style="padding-left:400px"><input type="submit" id="Submit" value="Update"/></p>          
                <div style="float: left; width: 100%;">

 <% } %>
   <div id="RecordsContainer"></div>
   </div>
  </div>

  
<%--<script type="text/javascript">

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
                   
</script>--%>
<%--<script type="text/javascript">

    $('#EMPID').change(function () {
        //         var EmployeeID = document.getElementById("EMPID");
        //        var selectedID = $(this).val();
        //        $.get('<%: ResolveUrl("~/Inventory/GetEmployeeInfo?UserID=")%>' + selectedID, function (data) {
        $.post('<%: ResolveUrl("~/Inventory/GetEmployeeInfo?UserID=")%>' + $("#EMPID > option:selected").attr("value"), function (data) {
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
<%-- -----------------******************      Example:  Passing Value from Drop Down list to the Text Box  **********************--------------------------%>
<%--<script type="text/javascript">
$(function() {
    $('#EMPID').change(function () {
        var selectedValue = $(this).val();
//        $.post('<%: ResolveUrl("~/Inventory/GetEmployeeInfo?UserID=")%>' + $("#EMPID").val(selectedValue);
          $('#Remark').val(selectedValue);
      
    });
});
</script>--%>
<%---------------------------------------***************************************************************-----------------------------------------------------%>


<%--<script type="text/javascript">
$(function(){
  $("#EMPID").change(function(){
    var val=$(this).val();  
    console.debug(val);    
    $.get("@Url.Action("GetEmployeeInfo","Inventory")",  { itemId : val },function(data){
      $("#MonitorID").val(data.MonitorID);
      $("#UPSID").val(data.UPSID);
//      $("#divItemPrice").html(data);
    });     
  });
});
</script>--%>
<%--<script type="text/javascript">

    function OpenPopup() {

        popup("PopupPage.aspx");

    }

    // copied from http://www.dotnetfunda.com/codes/code419-code-to-open-popup-window-in-center-position-.aspx

    function popup(url) {

        var width = 300;

        var height = 200;

        var left = (screen.width - width) / 2;

        var top = (screen.height - height) / 2;

        var params = 'width=' + width + ', height=' + height;

        params += ', top=' + top + ', left=' + left;

        params += ', directories=no';

        params += ', location=no';

        params += ', menubar=no';

        params += ', resizable=no';

        params += ', scrollbars=no';

        params += ', status=no';

        params += ', toolbar=no';

        newwin = window.open(url, 'windowname5', params);

        if (window.focus) { newwin.focus() }

        return false;

    }

</script>--%>

</asp:Content>