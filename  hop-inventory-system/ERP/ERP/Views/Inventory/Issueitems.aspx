<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvreceivenissueEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Issueitems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%----------------------**********For Popup Window********************--------------------------------------%>
<%--    <link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
--%>    <link href="<%: Url.Content("~/Content/themes/redmond/jquery-ui-1.8.16.custom.css") %>" rel="stylesheet" type="text/css" />
<%--    <script src="<%: Url.Content("~/Scripts/jquery-1.5.1.js")  %>" type="text/javascript"></script> --%>
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script>     
 <%----------------------******************End***************************--------------------------------------%>


<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#IssueDate").datepicker({ dateFormat: "dd-mm-yy" });       
    });
 </script>

<style>
    .ui-state-error { padding: .3em; }
</style>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Issue Items</div></div>
<div id="ajaxResult" ></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
          <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>
            <div>                
            </div>                
        </div>

<% using (Html.BeginForm("Issueitems", "Inventory", new { id = "target" }))
   { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Receive Item Info</legend>
         <%: Html.HiddenFor(model => model.RIssueID)%>
         <div class="editor-label01">
           <label for="ModelID">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @readonly = "true", @class = "Width=250" })%>
            <%--<%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>--%>
            <%: Html.ValidationMessageFor(model => model.LocID)%>
        </div> 
         <div class="editor-label01">
           <label for="ItemID">Item Name:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.ItemID, (List<SelectListItem>)ViewData["ItemName"], "Select Item", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.ItemID) %>
        </div>
 
        <div class="editor-label01">
           <label for="ModelID">Model Name:</label>
        </div>
        <div class="editor-field01">
            <%--<%: Html.DropDownListFor(model => model.ModelID, (List<SelectListItem>)ViewData["ModelName"], "Select Model", new { @readonly = "true", @class = "Width=250" }) %>--%>
            <%: Html.DropDownListFor(model => model.ModelID, new SelectList(new[] { " " }),"Select Model") %>
            <%: Html.ValidationMessageFor(model => model.ModelID) %>
        </div>
<div style="margin: -9em 20cm 0 8cm; padding: 0 0 0 7cm;">
 
        <div class="editor-label01">
            <label for="ReceiveQty">Receive Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.ReceiveQty, new {@class = " Control_Moni_Width_100", @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.ReceiveQty) %>
        </div>


         <div class="editor-label01">
            <label for="TotalissueQty">Total Issue Quantity:</label>
        </div>
        <div class="editor-field01">
           <%-- <%: Html.TextBoxFor(model => model.TotalissueQty, new { placeholder = "0" })%>--%>
            <%: Html.TextBoxFor(model => model.TotalissueQty, new {@class = " Control_Moni_Width_100", @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.TotalissueQty)%>
        </div>
         <div class="editor-label01">
            <label for="BalanceQty">Balance Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.BalanceQty, new {@class = " Control_Moni_Width_100", @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.BalanceQty)%>
        </div>
</div>
 
</fieldset>
<% } %>

<%--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>

        <!-- ui-dialog -->
<% using (Html.BeginForm("Issueitems", "Inventory", FormMethod.Post, new { id = "Ajaxform" }))
 {%>   
  <div id="dialog" title="Issue for Factory">
    <div id="Div1" title="Factory Issue">
    <%: Html.ValidationSummary(true,"Please Correct the Form") %> 
   <%-- <%: Html.EnableClientValidation(); %>  --%> 
     <%-- <div><span id="Asset" >Hello</span></div>--%>
    <%-- <legend>Item Distrubution Info</legend>--%>
         <div class="editor-label01">
            <label for="ITRFNo">Receiver Name :</label>
        </div>
        <div class="editor-field01">
            <%--<%: Html.EditorFor(model => model.ReceiverName)%>--%>
            <%: Html.DropDownListFor(m => m.ReceiverName, new SelectList(new[] { "Mahidul", "Nayan", "Rezwan", "Sakahawat", "Safiul", "Shaikat", "Wares" }), "Select Name", new { @onblur = "javascript:UserCheck(this, document.getElementById('Usermsg'))" })%>
            <%: Html.ValidationMessageFor(model => model.ReceiverName)%>
            <span style="color:Red;" id="Usermsg" ></span>
        </div> 
        <div class="editor-label01">
            <label for="ITRFNo">Receiver Email:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.ReceiverEmail, new SelectList(new[] { "mahidul@hoplunbd.com", "nayan@hoplunbd.com", "rezwan@hoplunbd.com", "sakahawat@hoplunbd.com", "safiul@hoplunbd.com", "shaikat@hoplunbd.com", "wares@hoplunbd.com" }), "Select Mail Address", new { @onblur = "javascript:MailCheck(this, document.getElementById('Mailmsg'))" })%>
            <%--<%: Html.EditorFor(model => model.ReceiverEmail)%>--%>
            <%: Html.ValidationMessageFor(model => model.ReceiverEmail)%>
            <span style="color:Red;" id="Mailmsg" ></span>
        </div> 
         <div class="editor-label01">
            <label for="ITRFNo">Transport No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.Transportno, new { @onblur = "javascript:TransCheck(this, document.getElementById('Tranmsg'))" })%>
            <%: Html.ValidationMessageFor(model => model.Transportno)%>
            <span style="color:Red;" id="Tranmsg" ></span>
        </div>         
        <div class="editor-label01">
            <label for="IssueDate">Issue Date:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.IssueDate, new { @onblur = "javascript:IdateCheck(this, document.getElementById('Issuedatemsg'))" })%>
            <%: Html.ValidationMessageFor(model => model.IssueDate) %>
            <span style="color:Red;" id="Issuedatemsg" ></span>
        </div>
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
            <label for="IssueQty">New Issue Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.IssueQty)%>
            <%: Html.ValidationMessageFor(model => model.IssueQty) %>
        </div>

        <div class="editor-label01">
            <label for="NewbalanceQty">New Balance Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.NewbalanceQty, new { @readonly = "readonly" })%>
           <%-- <%: Html.TextBoxFor(model => model.NewbalanceQty, new { @readonly = "readonly", onfocus = "this.blur()" })%>  --%>          
            <%: Html.ValidationMessageFor(model => model.NewbalanceQty)%>
        </div>
  

   <div style="color:Red;"><span id="Message" ></span></div>
  <%-- <p style="padding-left:400px"><input type="submit" class="Submit"  value="Save"   /></p>  --%>

           <%--<input type="button" value="Clean Boxes" title="Clean" id="msg"   onclick="TXTBOX()" />   --%> 
                <%--<div style="float: left; width: 100%;">    </div>--%>
 </div>
<% } %>
</div>

<%--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>

<fieldset>
 <legend>Issue Entry</legend>
        <div style=" margin: 1em .5cm 0px .5cm;">
            <a href="#" id="dialog_link" class="ui-state-default ui-corner-all" onclick="SendValue();"><span class="ui-icon ui-icon-newwin"></span>For Factory</a>                        
        </div>
       <%-- <div style="margin: -3.6em 1px 5px 125px;">
           <a href="#" id="dialoglink_users" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>For Users'</a>               
        </div>--%>
</fieldset>

<div style="margin: 4.6em 1px 5px 18px;">
    <%: Html.ActionLink("Back to List", "Receiveissue")%>
</div>

</div>
   
 <script type="text/javascript" language="javascript">
     $(document).ready(function () {
         // Dialog       
         $('#dialog').dialog({
             autoOpen: false,
             width: 600,
             modal: true,
             hide: 'fade',
             buttons: {
                 "Save": function () {
                     $.ajax({
                         type: 'POST',
                         //url: '@(Url.Action("Issueitems", "Inventory"))',  
                         url: '/Inventory/Issueitems',
                         data: {
                             ItemID: $("#ItemID").val(),
                             ModelID: $("#ModelID").val(),
                             ReceiveQty: $("#ReceiveQty").val(),
                             IssueDate: $("#IssueDate").val(),
                             ReceiverName: $("#ReceiverName").val(),
                             ReceiverEmail: $("#ReceiverEmail").val(),
                             Transportno: $("#Transportno").val(),
                             Location: $("#Location").val(),
                             IssueQty: $("#IssueQty").val(),
                             NewbalanceQty: $("#NewbalanceQty").val(),

                             IDate: $("#IDate").val(),
                             ITRFNo: $("#ITRFNo").val(),
                             LocID: $("#LocID").val(),
                             IssueQty: $("#IssueQty").val()
                         },
                         //dataType: "json",
                         //dataType: "html",
                         success: function (Result) {
                             // alert("Data: " + Result.ReceiverName);
                             //$('#Message').val(Result.ReceiverName);
                             // if (!Result.success) {
                             //                             if (Result.ItemID == null) {
                             //                                 alert("Null Value");
                             //                                 $('#Message').html("Please Fill up the Form");
                             //                             }
                             //                             else {                            
                            $('#Message').html("Save Successful");
                            $("#Message").hide().html('Record saved').fadeIn(300, function () {
                                var e = this;
                                setTimeout(function () { $(e).fadeOut(400); }, 2500);
                            });
                            $('#dialog').dialog("close");   //For Closing POPUP Window    
                            window.parent.location.href = window.parent.location.href; //For Refresh the Parent Form                   
                         
                             // }
                         },
                         error: function (data) {
                             alert("Error " + data.Success);
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
     });
     function UserCheck(inputField, helpText) {
         var USR = /^\w{2,15}$/;
         if (inputField.value == "Select Name") {
                 helpText.innerHTML = "Select User Name";
                 return false;
             }
             else if (!USR.test(inputField.value)) {
                 helpText.innerHTML = "Select User Name";
                 return false;
             }
             else {
                 if (helpText != null)
                     helpText.innerHTML = "";
                 return true;
             }
             return true;
         }
     function MailCheck(inputField, helpText) {
         var mail = /^\w+@\w+\.\w{2,3}$/;
         if (inputField.value == "Select Mail Address") {
             helpText.innerHTML = "Email address is required";
             return false;
         }
         else if (!mail.test(inputField.value)) {
             helpText.innerHTML = "Please Select a valid email address";
             return false;
         }
         else {
             if (helpText != null)
                 helpText.innerHTML = "";
             return true;
         }
         return true;
     }

     function TransCheck(inputField, helpText) {         
         if (inputField.value == "") {
             helpText.innerHTML = "Enter Transport No";
             return false;
         }         
         else {
             if (helpText != null)
                 helpText.innerHTML = "";
             return true;
         }
         return true;
     }
     function IdateCheck(inputField, helpText) {
         if (inputField.value == "") {
             helpText.innerHTML = "Select Issue Date";
             return false;
         }
         else {
             if (helpText != null)
                 helpText.innerHTML = "";
             return true;
         }
         return true;
     }
     function LocCheck(inputField, helpText) {
         var LOC = /^\w{2,15}$/;
         if (inputField.value == "Location") {
             helpText.innerHTML = "Select Location";
             return false;
         }
         else if (!LOC.test(inputField.value)) {
             helpText.innerHTML = "Select Location";
             return false;
         }
         else {
             if (helpText != null)
                 helpText.innerHTML = "";
             return true;
         }
         return true;
     }
</script>

<%--////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>


<script type="text/javascript">
    $('#ModelID').change(function () {
        $.post('<%: ResolveUrl("~/Inventory/Getsumvalue?XModelid=")%>' + $("#ModelID > option:selected").attr("value") + "&LOC=" + $("#LocID").val(), function (data) {
            $('input:text[id$=ReceiveQty]').val(data.ReceiveQty);
            //$('input:text[id$=ReceiveQty]').attr("disabled", true);
            $('input:text[id$=ReceiveQty]').attr('disabled', false)
            //alert(data.TotalissueQty);
            if (data.TotalissueQty == "") {
                $('input:text[id$=TotalissueQty]').val("0");
                $('input:text[id$=BalanceQty]').val("0");                
            }
            else {
                $('input:text[id$=TotalissueQty]').val(data.TotalissueQty);
                $('input:text[id$=BalanceQty]').val(data.BalanceQty);               
                //$('input:text[id$=TotalissueQty]').attr("disabled", true);
                //$('input:text[id$=BalanceQty]').attr("disabled", true);
                $('input:text[id$=TotalissueQty]').attr("disabled", false);
                $('input:text[id$=BalanceQty]').attr("disabled", false);
            }
        });

    });
</script>
<script type="text/javascript">
    $('#IssueQty').change(function () {
        var Newiss = $(this).val();
        var RValue = $("#ReceiveQty").val();
        var Newbala = $("#NewbalanceQty").val();
        var Oldiss = $("#TotalissueQty").val();
        var Oldbala = $("#BalanceQty").val();
        if (parseInt(Oldbala) == null || parseInt(Newiss) == null) {
            //alert('Balance Quantity  Zero');           
            Oldbala = 0;
            return;
        }
        var x = 0, y = 0, z = 0; var sum = 0; var DIFF = 0;
        x = parseInt(RValue);
        y = parseInt(Newiss);
        z = parseInt(Oldiss);
        sum = y + z;
        DIFF = x - (y + z);
        //alert(z);
        if (DIFF < 0) {
            alert('Balance cannot be Negative! Please check');
        }
        else
        $("#NewbalanceQty").val(DIFF);             
        $('input:text[id$=NewbalanceQty]').attr("disabled", false);
        $('input:text[id$=NewbalanceQty]').focus();
    });
</script>
<script type="text/javascript">
    $('#ItemID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Inventory/ItemmodelList?IID=")%>' + $("#ItemID> option:selected").attr("value"), function (data) {
                //var items = "";
                //var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#ModelID").html(items);
                $("#ModelID").removeAttr('disabled');
            });
        }
    });
</script>
<script type="text/javascript">
//    window.onload = function () {
//        //var pw = parent.window;
//        var pw = window.opener;
//        if (pw) {
//            var inputFrm = pw.document.forms["target"];
//            var outputFrm = document.forms["dialog"];

//            outputFrm.elements["IssueQty"].value = inputFrm.elements["ModelID"].text;           
//            //            outputFrm.elements['txtremarks'].value = inputFrm.elements['txtremarks'].value;
//            //            outputFrm.elements['txtsperson'].value = inputFrm.elements['txtsperson'].value;
//        }
//    }


    function SendValue() {
        //var val = document.getElementById("#ModelID").text;
        opener.document.dialog.IssueQty.value = document.target.ModelID.text;
        alert("Test");
               $("#IssueQty").value() = val;      
    }

</script>

</asp:Content>
