<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PCDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--Hasib; hasib_aziz@yahoo.com--%>
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
</script>  
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">PC Info</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("DeviceLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container">
         <% using (Html.BeginForm(new { ID="MyID"}))
            { %>
        <div style="text-align: center; color:#B0171F; font-size: x-large"><strong>PC Information</strong></div>
           <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Enter Asset ID </legend>
            <%: Html.HiddenFor(m => m.AccountID)%>
            <%: Html.HiddenFor(m => m.MonitorID)%>
            <%: Html.HiddenFor(m => m.UPSID)%>
            <div style="float: left; width: 100%">
                Account Code:  * <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "validate[required,custom[AccountCode]]" })%>
                <%: Html.ValidationMessageFor(m => m.AccountCode)%> 
            <%--<input type="button" value="Search" title="Save" id="btnGetCarList" />--%>
            </div>
            </fieldset>           
            <fieldset> <%--<fieldset width="30" hight="100">--%>
            <legend class="LegendColor">Details Information</legend>
              <div class="editor-label01">
                <label for="BrandModel">Brand & Model</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.BrandModel)%>
              </div>
              <div class="editor-label01">
                <label for="Configuration">Configuration</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Configuration)%>
              </div>
              <div class="editor-label01">
                <label for="Category">Category</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Category)%>
              </div>
               <div class="editor-label01">
                <label for="SerialNo">Serial No</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.SerialNo)%>
              </div>
              <div class="editor-label01">
                <label for="Location">Location</label>
              </div>
              <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m => m.Location)%>--%>
                <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>
                <%: Html.ValidationMessageFor(m => m.Location)%> 
              </div>
              <div class="editor-label01">
                <label for="DeptNo">Department Name * </label>
              </div>
              <div class="editor-field01">
               <%-- <%: Html.TextBoxFor(m => m.DeptNo)%>--%>
               <%: Html.DropDownListFor(m => m.DeptID, (List<SelectListItem>)ViewData["DeptName"], "Select Department", new { @readonly = "true", @class = "Width=250" })%>
               <%: Html.ValidationMessageFor(m => m.DeptID)%> 
              </div>      
              <div class="editor-label01">
                <label for="UserName">Employee ID * </label>
              </div>
              <div class="editor-field01">
              <%--<%: Html.TextBoxFor(m=>m.UserName) %>  --%>   
              <%: Html.DropDownListFor(m => m.EMPID, (List<SelectListItem>)ViewData["EmpNo"], "Employee ID", new { @readonly = "true", @class = "Width=250" })%>           
              <%: Html.ValidationMessageFor(m => m.EMPID)%> 
              </div> 
          <div class="New_Right_Begin">                      
              <div class="editor-label01">
                <label for="PurchDate">Purchase Date</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.PurchDate)%>
              </div>
              <div class="editor-label01">
                <label for="Status">Status</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Status)%>
              </div>
               <div class="editor-label01">
                <label for="Team">Team</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Team)%>
              </div>
              <div class="editor-label01">
                <label for="HostName">Host Name</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.HostName)%>
              </div>
              <div class="editor-label01">
                <label for="ITemNo">ITE. No</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.ITemNo)%>
              </div>
               <div class="editor-label01">
                <label for="Remark">Remark</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextAreaFor(m => m.Remark)%>
              </div>  
             <div class="editor-label01">
                <label for="Remark">Device * </label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.DeviceID, (List<SelectListItem>)ViewData["DeviceName"], "Select Device", new { @readonly = "true", @class = "Width=250" })%>
                <%: Html.ValidationMessageFor(m => m.DeviceID)%> 
              </div> 
            </div>         
 </fieldset>           
       </div>  
 <fieldset> <%--<fieldset width="10" hight="100">--%>  
            <legend class="LegendColor">Monitor Information </legend>
              <div class="Monitor-label">
                <label for="Monitorname">Monitor Name</label>
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
                <label for="Purchagedate">Purchase Date</label>
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
                <label for="UPSname">UPS Name</label>
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
           <p style="padding-left:400px"><input type="submit" id="Submit"  value="Save"   /></p>  
           <%--<input type="button" value="Clean Boxes" title="Clean" id="msg"   onclick="TXTBOX()" />  --%>     
                <div style="float: left; width: 100%;">
                  
 <% } %>
   <div id="RecordsContainer"></div>
  </div>
 </div>  
 <script type="text/javascript">

     $('#AccountCode').change(function () {
         var Result = $.post('<%: ResolveUrl("~/Inventory/Depvaluecheck?UserID=")%>' + $("#AccountCode").attr("value"), function (data) {
             //alert("********* WORKING *************");
             if (data.EMPID != null)
                 alert("Value Already Exist");
         });

     });

</script>

</asp:Content>
