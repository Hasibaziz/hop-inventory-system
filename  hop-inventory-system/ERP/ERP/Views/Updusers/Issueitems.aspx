<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Upduser.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvreceivenissueEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Issueitems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%----------------------**********For Popup Window********************--------------------------------------%>
    <link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script>     
 <%----------------------******************End***************************--------------------------------------%>


<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#IssueDate").datepicker({ dateFormat: "dd-mm-yy" });
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
<style>
    .ui-state-error { padding: .3em; }
</style>

<div id="ajaxResult" ></div>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Issue Items</div></div>
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
<div style="margin: -6em 20cm 0 4cm; padding: 0 0 0 7cm;">
 
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
</div>
<div style="margin: -6em 20cm 0 12cm; padding: 0 0 0 7cm;">
        <div class="editor-label01">
            <label for="BalanceQty">Balance Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.TextBoxFor(model => model.BalanceQty, new {@class = " Control_Moni_Width_100", @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.BalanceQty)%>
        </div>
</div>
 
</fieldset>

<%--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>

        <!-- ui-dialog -->

<div id="dialog" title="Issue for Factory">
   <div id="Div1" title="Receive Item">
    <%: Html.ValidationSummary(true) %>             
         <div class="editor-label01">
            <label for="ITRFNo">Receiver Name :</label>
        </div>
        <div class="editor-field01">
            <%--<%: Html.EditorFor(model => model.ReceiverName)%>--%>
            <%: Html.DropDownListFor(m => m.ReceiverName, new SelectList(new[] { "Mahidul", "Nayan", "Rezwan", "Sakahawat", "Safiul", "Shaikat", "Wares" }), "Select Name")%>
            <%: Html.ValidationMessageFor(model => model.ReceiverName)%>
        </div> 
        <div class="editor-label01">
            <label for="ITRFNo">Receiver Email:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.ReceiverEmail)%>
            <%: Html.ValidationMessageFor(model => model.ReceiverEmail)%>
        </div> 
         <div class="editor-label01">
            <label for="ITRFNo">Transport No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Transportno)%>
            <%: Html.ValidationMessageFor(model => model.Transportno)%>
        </div>         
        <div class="editor-label01">
            <label for="IssueDate">Issue Date:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.IssueDate) %>
            <%: Html.ValidationMessageFor(model => model.IssueDate) %>
        </div>
        <div class="editor-label01">
            <label for="Location">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @readonly = "true", @class = "Width=250" })%>
            <%--<%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>--%>
            <%: Html.ValidationMessageFor(model => model.LocID)%>
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
   </div>
   <div style="color:Red;"><span id="Message" ></span></div>
 </div>

<% } %>
    
<fieldset>
 <legend>Issue Entry</legend>

        <div style=" margin: 1em .5cm 0px .5cm;">
            <a href="#" id="dialog_link" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>For Factory</a>                        
        </div>
        <%--<div style="margin: -3.6em 1px 5px 125px;">
           <a href="#" id="dialoglink_users" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>For Users'</a>               
        </div>--%>
</fieldset>

<div style="margin: 4.6em 1px 5px 18px;">
    <%: Html.ActionLink("Back to List", "Receiveissue")%>
</div> 

</div>  
   
 <script type="text/javascript" language="javascript">
     $(document).ready(function () {
         var name = $("#name"),
             email = $("#email");

         function checkLength(o, n, min, max) {
             if (o.val().length > max || o.val().length < min) {
                 o.addClass("ui-state-error");
                 updateTips("Length of " + n + " must be between " + min + " and " + max + ".");
                 return false;
             } else {
                 return true;
             }
         }
         function checkRegexp(o, regexp, n) {
             if (!(regexp.test(o.val()))) {
                 o.addClass("ui-state-error");
                 updateTips(n);
                 return false;
             } else {
                 return true;
             }
         }

         // Dialog
         $('#dialog').dialog({
             autoOpen: false,
             width: 600,
             modal: true,
             buttons: {
                 "Save": function () {
                     $.ajax({
                         type: 'POST',
                         //url: '@(Url.Action("Issueitems", "Inventory"))',  
                         url: '/Inventory/Issueitems',
                         // dataType: "json",
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
                         success: function (Result) {
                             $('#Message').html("Save Successful");
                             $('#dialog').dialog("close");   //For Closing POPUP Window
                             window.parent.location.href = window.parent.location.href; //For Refresh the Parent Form
                             return false;
                             //$(target).html(response);
                             //                             $("#Message").hide().html('Record saved').fadeIn(300, function () {
                             //                                 var e = this;
                             //                                 setTimeout(function () { $(e).fadeOut(400); }, 2500);
                             //                             });                            
                             //////////////////////////////////////////////////////////////////////////////

                             var bValid = true;
                             allFields.removeClass("ui-state-error");

                             bValid = bValid && checkLength(name, "username", 3, 16);
                             bValid = bValid && checkLength(email, "email", 6, 80);
                             bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
                             // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/
                             bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");

                             if (bValid) {
                                 $(this).dialog("close");
                             }
                             //////////////////////////////////////////////////////////////////////////////////
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


</script>

<%--////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>


<script type="text/javascript">
    $('#ModelID').change(function () {
        $.post('<%: ResolveUrl("~/Inventory/Getsumvalue?XModelid=")%>' + $("#ModelID > option:selected").attr("value"), function (data) {
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
        //$("#TotalissueQty").val(sum);
        //$("#BalanceQty").val(DIFF);       
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
</asp:Content>
