<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PrinterView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script type="text/javascript" >
    $(document).ready(function () {
        $("input#PurchDate").datepicker({ dateFormat: "dd-mm-yy" });
        $("input#PPurchDate").datepicker({ dateFormat: "dd-mm-yy" });
        $("input#PDistDate").datepicker({ dateFormat: "dd-mm-yy" });
    });
 </script>   

<div class="mp_left_menu">
  <div class="scroll-text" style="background-color: #DB7093; font: Arial;">Printer Details</div>
  <%--Hasib; hasib_aziz@yahoo.com--%>
   <%-- <% Html.RenderPartial("DeviceLeftMenu"); %>--%>
    <% using (Html.BeginForm())
         { %>
</div>
<div class="mp_right_content_form">
        <div class="page_list_container">
        <div style="background-color: #680000; color:#FFFFFF; font-size: large; padding:2px 1px 1px 533px; font: Bookman Old Style;"><strong>Printer Information</strong></div>
            <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Enter Asset ID </legend>
            <div style="float: left; width: 100%">
                Account Code: <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt"})%>
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
              </div>      
              <div class="editor-label01">
                <label for="UserName">Employee ID</label>
              </div>
              <div class="editor-field01">
              <%--<%: Html.TextBoxFor(m=>m.UserName) %>  --%>   
              <%: Html.DropDownListFor(m => m.EMPID, (List<SelectListItem>)ViewData["EmpNo"], "Employee ID", new { @readonly = "true", @class = "Width=250" })%>           
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
                <%: Html.TextAreaFor(m => m.Remark)%>
              </div>  
             <div class="editor-label01">
                <label for="Remark">Device</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.DeviceID, (List<SelectListItem>)ViewData["DeviceName"], "Select Device", new { @readonly = "true", @class = "Width=250" })%>
              </div> 
            </div>   
 </fieldset>
 <fieldset> <%--<fieldset width="10" hight="100">--%>  
            <legend class="LegendColor">Print Information </legend>
              <div class="Monitor-label">
                <label for="Monitorname">Printer Name</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.PrinterName, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Modelno">IP/MAC Address</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.IPMAC, new { @class = " Control_Moni_Width_100" })%>
              </div>
        <div class="New_Right_Monitor">
             <div class="Monitor-label">
                <label for="Modelno">Type</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.Type, new { @class = " Control_Moni_Width_100" })%>
              </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Purchase Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.PPurchDate, new { @class = " Control_Moni_Width_100" })%>
              </div>
         </div>
           <div class="New_Right_Monitor01">
               <div class="Monitor-label">
                <label for="Purchagedate">Distribution Date</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.PDistDate, new { @class = " Control_Moni_Width_100" })%>
             </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Total User</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.Totaluser, new { @class = " Control_Moni_Width_100" })%>
             </div>
              <div class="Monitor-label">
                <label for="Purchagedate">Daily Print Pages</label>
              </div>
              <div class="Monitor-field">
                <%: Html.TextBoxFor(m => m.Dailyppage, new { @class = " Control_Moni_Width_100" })%>
             </div>
        </div>
</fieldset>
            <p style="padding-left:400px"><input type="submit" value="Save"/></p>          
                <div style="float: left; width: 100%;">
          <% } %>
   <div id="RecordsContainer"></div>
  </div>
 </div> 
 </div>
 <script type="text/javascript">

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
                 //                $("#EMPID").removeAttr('disabled');
             });
         }
     });
                   
</script>

</asp:Content>
