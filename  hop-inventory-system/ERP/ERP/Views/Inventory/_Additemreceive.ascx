<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ERP.Domain.Model.InvitemreceiveEntity>" %>

<link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery-1.5.1.js")  %>" type="text/javascript"></script> 
<script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script> 



<script type="text/javascript">
    $(document).ready(function () {
        // Dialog
        $('#dialog').dialog({
            autoOpen: false,
            resizable: false,    /// To make the Popup Window Customs resize (Big or Small)
            width: 300,
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
                "Send": function () {
                    //jQuery(this).dialog('close');
                    $.ajax({
                        //url: '@(Url.Action("AddRole", "Home"))',                                                       
                        url: '/Account/GetForgetmail',
                        type: 'POST',
                        //data: { className: cName }, // Your parameter
                        //data: "{ Umail: '" + $('.Usermail').val() + "' }",
                        data: { Umail: $('#Useremail').val() },
                        //data: { startDate: $('#startDate').val(), endDate: $('#endDate').val(), userName: $('#userName').val() },
                        dataType: "json",
                        success: function (Result) {
                            //var Mail = /^\w+@\w+\.\w{2,3}$/;   
                            //window.close(); 
                            $('#Useremail').val("");
                            $('#TextBox').hide();                         //window.close(); OR $('#popup_id').hide();   //$('#popup_wrapper_id').fadeOut();
                            $('#Message').html("Please Check Mail");     //$('#div_id').html("Write message or other response form your action").
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

<% using (Html.BeginForm("Additemreceive", "Inventory", FormMethod.Post, new { id = "target" }))
   { %>
   <div id="dialog" title="Receive Item">
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Invitemreceive</legend>
           <%: Html.HiddenFor(model => model.IRID)%>
        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ItemID) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ItemID) %>
            <%: Html.ValidationMessageFor(model => model.ItemID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ModelID) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ModelID) %>
            <%: Html.ValidationMessageFor(model => model.ModelID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RDate) %>
            <%: Html.ValidationMessageFor(model => model.RDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Chlanno) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Chlanno) %>
            <%: Html.ValidationMessageFor(model => model.Chlanno) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Location) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Location) %>
            <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>
            <%: Html.ValidationMessageFor(model => model.Location) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Quantity) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Quantity) %>
            <%: Html.ValidationMessageFor(model => model.Quantity) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>
  <div>
     <%: Html.ActionLink("Back to List", "Index") %>
  </div>
</div>


