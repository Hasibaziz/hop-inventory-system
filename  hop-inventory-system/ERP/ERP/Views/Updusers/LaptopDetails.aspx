<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    LaptopDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script type="text/javascript" >
    $(document).ready(function () {
        $("input#PurchDate").datepicker({ dateFormat: "dd-mm-yy" });
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Laptop Entry</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>   
</div>
--%>
<div class="mp_right_content_form">
    <div class="page_list_container">
         <% using (Html.BeginForm())
         { %>
            <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Enter Asset ID </legend>
             <%: Html.HiddenFor(m => m.AccountID) %>
            <div style="float: left; width: 100%">
                Account Code: <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt"})%>
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
                <%: Html.TextBoxFor(m=>m.BrandModel) %>
              </div>
              <div class="editor-label01">
                <label for="Configuration">Configuration</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Configuration) %>
              </div>
              <div class="editor-label01">
                <label for="Category">Category</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Category) %>
              </div>
               <div class="editor-label01">
                <label for="SerialNo">Serial No</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.SerialNo) %>
              </div>
              <div class="editor-label01">
                <label for="Location">Location</label>
              </div>
              <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m=>m.Location) %>--%>
                <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>
                <%: Html.ValidationMessageFor(m => m.Location)%> 
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
                <label for="UserName">Employee ID</label>
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
                <%: Html.TextBoxFor(m=>m.PurchDate) %>
              </div>
              <%--<div class="editor-label01">
                <label for="MonitorSLNO">Monitor SL NO</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.MonitorID)%>
              </div>
              <div class="editor-label01">
                <label for="UpsSLNO">Ups SL NO</label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.UPSID)%>
              </div>--%>
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
                <label for="Remark">Device</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.DeviceID, (List<SelectListItem>)ViewData["DeviceName"], "Select Device", new { @readonly = "true", @class = "Width=250" })%>
                <%: Html.ValidationMessageFor(m => m.DeviceID)%>
              </div> 
            </div>   
 </fieldset>
            <p style="padding-left:400px"><input type="submit" value="Update"/></p>          
                <div style="float: left; width: 100%;">
          <% } %>
   <div id="RecordsContainer"></div>
  </div>
 </div> 
 </div>


</asp:Content>
