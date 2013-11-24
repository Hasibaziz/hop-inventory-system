<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    LaptopDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!-- Validation engine script file and english localization -->
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<!-- ******************************************************************************************************************** -->

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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Laptop Details</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("DeviceLeftMenu"); %>        
</div>--%>

<div class="mp_right_content_form">
   <div class="page_list_container">
         <div style="float:Left; width: 10%;">
           <div id="RecordsContainer"></div>
         </div>
     </div>
<%--</div>--%>
  <% using (Html.BeginForm())    { %>
        <div style="text-align: center; color: #B0171F; font-size: x-large"><strong>Laptop Information</strong></div>
            <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Enter Asset ID </legend>           
                Account Code: <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt"})%>
                <%: Html.ValidationMessageFor(m => m.AccountCode)%>
            <%--<input type="button" value="Search" title="Save" id="btnGetCarList" />--%>
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
               <%-- <%: Html.TextBoxFor(m=>m.Location) %>--%>
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
                <%: Html.TextBoxFor(m => m.Remark)%>
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
            <p style="padding-left:400px"><input  type="submit" value="Save" /></p>       
            <%--<input type="image" src="img.png" onclick="javascript:if(!func()){return false;}"/>   --%>
                <%--01<div style="float: left; width: 100%;">--%>
          <% } %>
  <%--01</div> --%>
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
                //                var items1 = "";
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
</asp:Content>
