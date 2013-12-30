<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvEquipmentEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Newequipment
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
  <link href="<%: Url.Content("~/Content/themes/redmond/jquery-ui-1.8.16.custom.css") %>" rel="stylesheet" type="text/css" />
  <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script> 
<%----------------------------------------------Popup Menu---------------------------------------------------------------------- --%>
<script type="text/javascript">
    $(document).ready(function () {
        $("input#Remarks, #PurchDate").datepicker({ dateFormat: "dd-mm-yy" });
    });
</script> 


<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Equipment Entry</div></div>
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
          <div style="color:#B0171F; font-size: x-large; text-align: center">Equipment Entry</div>
           <fieldset> <%--<fieldset width="10" hight="100">--%>
            <legend class="LegendColor">Select Location </legend>
            <%: Html.HiddenFor(m => m.EID)%>
            <%: Html.HiddenFor(m => m.ENumber)%>  
             <div class="editor-label01">
                <label for="Remark">Country</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.CID, (List<SelectListItem>)ViewData["Name"], "Country", new { @readonly = "true", @class = "Width=250" })%>
               <%-- <a href="#" id="addDevice">Add New</a>--%>
                <%: Html.ValidationMessageFor(m => m.CID)%>
              </div>                      
            <div class="editor-label01">
                <label for="Location">Location: </label>
              </div>
            <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m=>m.Location) %>--%>
                <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @readonly = "true", @class = "Width=250" })%>
                <%: Html.ValidationMessageFor(m => m.LocID)%>                               
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
                 <label for="AccountCode">Asset Code: *</label>
               </div>
               <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.AssetCode)%>
                <%: Html.ValidationMessageFor(m => m.AssetCode)%> 
              </div>   
               <div class="editor-label01">
                <label for="BrandModel">Brand: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Brand) %>
              </div>
               <div class="editor-label01">
                <label for="BrandModel">Model: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Model) %>
              </div>
               <div class="editor-label01">
                <label for="BrandModel">Serial No: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Serialno) %>
              </div>
               <div class="editor-label01">
                <label for="BrandModel">Sub-Serial No: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.Subserialno) %>
              </div>
               <div class="editor-label01">
                <label for="BrandModel">Purchase Date: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m=>m.PurchDate) %>
              </div>
               <div class="editor-label01">
                <label for="BrandModel">Machine Short Code: </label>
              </div>
              <div class="editor-field01">
                 <%: Html.DropDownListFor(m => m.MNID, (List<SelectListItem>)ViewData["MachineName"], "Machine Name", new { @readonly = "true", @class = "Width=250" })%>               
              </div>
              <div class="editor-label01">
                <label for="BrandModel">- </label>
              </div>
              <%--<div style="margin: 0em 0cm 0 0.3cm; padding: 0 0 0 5cm;">--%>
              <div class="editor-field01" style="color: Green;">
                <%--<%: Html.TextBoxFor(m => m.Description, new {@readonly="true" })%>--%>
                <p id="Results" ></p>
              </div>
  <div style="margin: -25.6em 50cm 0 0.5cm;  padding: 0 0 0 15cm;" > 
              <div class="editor-label01">
                <label for="Remark">Machine ID: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Machineid)%>
              </div>  
              <div class="editor-label01">
                <label for="Remark">Machine Life Time: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Lifetime)%>
              </div>  
              <div class="editor-label01">
                <label for="DeptNo">Unit Name:</label>
              </div>
              <div class="editor-field01">
               <%-- <%: Html.TextBoxFor(m => m.DeptNo)%>--%>
               <%: Html.DropDownListFor(m => m.UnitID, (List<SelectListItem>)ViewData["UnitName"], "Select Unit", new { @readonly = "true", @class = "Width=250" })%>
               <%--<a href="#" id="addDept">Add New</a>--%>
               <%: Html.ValidationMessageFor(m => m.UnitID)%> 
              </div> 
              <div class="editor-label01">
                <label for="Remark">Building Name/No:</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.BNID, (List<SelectListItem>)ViewData["BuildingName"], "Building", new { @readonly = "true", @class = "Width=250" })%>                              
              </div>  
              <div class="editor-label01">
                <label for="Remark">Level/Floor No:</label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.FID, (List<SelectListItem>)ViewData["FloorName"], "Floor", new { @readonly = "true", @class = "Width=250" })%>                              
               <%-- <%: Html.TextBoxFor(m => m.Floorno)%>--%>
              </div>  
              <div class="editor-label01">
                <label for="Remark">Line No: </label>
              </div>
              <div class="editor-field01">
                <%: Html.DropDownListFor(m => m.LID, (List<SelectListItem>)ViewData["LineName"], "Line No", new { @readonly = "true", @class = "Width=250" })%>                              
               <%-- <%: Html.TextBoxFor(m => m.LID)%>--%>
              </div>                                    
              <div class="editor-label01">
                <label for="Remark">Status: </label>
              </div>
              <div class="editor-field01">
                <%--<%: Html.TextBoxFor(m => m.Status)%>--%>
                <%: Html.DropDownListFor(m => m.Status, new SelectList(new[] {"Active","Idle" }), "Select Status")%>
              </div>  
              <div class="editor-label01">
                <label for="Remark">Idle Date: </label>
              </div>
              <div class="editor-field01">
                <%: Html.TextBoxFor(m => m.Remarks)%>
              </div>  
              <%--<div class="editor-field01">
                <%: Html.TextAreaFor(m => m.Remarks)%>
              </div>  --%>           
            </div>         
 </fieldset>   
  <p style="padding-left:400px"><input type="submit" class="Submit"  value="Save"   /></p>  
           <%--<input type="button" value="Clean Boxes" title="Clean" id="msg"   onclick="TXTBOX()" />   --%> 
                <div style="float: left; width: 100%;">        
 
  <% } %>  
  </div>
 </div>   
</div>

 

<script type="text/javascript">

     $('#CID').change(function () {
         $.ajaxSetup({ cache: false });
         var selectedItem = $(this).val();
         if (selectedItem == "" || selectedItem == 0) {
             var items = "<option value=''></option>";
         } else {
             $.post('<%: ResolveUrl("~/Devices/GetlocationBycID?cid=")%>' + $("#CID > option:selected").attr("value"), function (data) {
                 var items = "";
                 var items1 = "";
                 var isSeleted = '';
                 if (data.Selected) {
                     isSeleted = " selected='selected'";
                 }
                 $.each(data, function (i, data) {
                     items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                 });
                 $("#LocID").html(items);
                 $("#LocID").removeAttr('disabled');
             });
         }
     });
                   
</script>

<script type="text/javascript">

    $('#LocID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Devices/GetBuildingBylocID?locid=")%>' + $("#LocID > option:selected").attr("value"), function (data) {
                var items = "";
                var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#BNID").html(items);
                $("#BNID").removeAttr('disabled');
            });
        }
    });
                   
</script>

<script type="text/javascript">

    $('#BNID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Devices/GetFloorByBNID?bnid=")%>' + $("#BNID > option:selected").attr("value"), function (data) {
                var items = "";
                var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#FID").html(items);
                $("#FID").removeAttr('disabled');
            });
        }
    });
                   
</script>

<script type="text/javascript">

    $('#MNID').change(function () {
        var Result = $.post('<%: ResolveUrl("~/Devices/GetmachinenameByID?mnid=")%>' + $("#MNID  > option:selected").attr("value"), function (data) {
            //alert("********* WORKING *************");
            if (data.MNID != null)
            //$('input:text[id$=Description]').val(data.Description);
                //$("#Description").val(data.Description);
                $("#Results").html(data.Description);            
        });

    });
</script>

<script type="text/javascript">
    $('#Status').change(function () {
        var Status = $(this).val();
        if (Status == 'Active') {
            $('input:text[id$=Remarks]').val(' ');
            $('input:text[id$=Remarks]').attr("disabled", true);
            return;
        }
        else
            $('input:text[id$=Remarks]').focus();
        $('input:text[id$=Remarks]').attr("disabled", false);
    });
</script>
  
</asp:Content>
