<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ERP.Models.LoginModel>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Login</title>
    <link rel="icon" href="<%= Url.Content("~/Content/images/favicon.ico") %>"/>
    <link href="<%: Url.Content("~/Content/Loginstyle.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Scripts/jquery-1.5.1.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.cycle.all.js")  %>" type="text/javascript"></script> 

                       <%--***************Forget Password*********************--%>
    <link href="<%: Url.Content("~/Content/themes/redmond/jquery-ui-1.8.16.custom.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Scripts/jquery-1.5.1.js")  %>" type="text/javascript"></script> 
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script> 
                                    <%--**********************--%>
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
                                 //$('#TextBox').hide();                         //window.close(); OR $('#popup_id').hide();   //$('#popup_wrapper_id').fadeOut();
                                 $('#Message').html("Please Check Mail");     //$('#div_id').html("Write message or other response form your action").
                                 $('#dialog').dialog("close");   //For Closing POPUP Window
                                 //window.parent.location.href = window.parent.location.href; //For Refresh the Parent Form
                                 //return false;
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

         function MailCheck(inputField, helpText)
          {
             var mail = /^\w+@\w+\.\w{2,3}$/;
             if (inputField.value == "") 
             {
                 helpText.innerHTML = "Email address is required";
                 return false;
             }
             else if (!mail.test(inputField.value)) {
                 helpText.innerHTML = "Please enter a valid email address";
                 return false;
             }
             else 
             {
                 if (helpText != null)
                     helpText.innerHTML = "";
                 return true;
             }
             return true;
         }
        
</script>


 
<script language="javascript" type="text/javascript">
    function SlideSwitch() {
        var $active = $('.home-page-slider img.active');
        if ($active.length == 0) $active = $('.home-page-slider img:last');
        var $next = $active.next().length ? $active.next() : $('.home-page-slider img:first');
        $active.addClass('last-active');
        $next.css({ opacity: 0.0 })
                .addClass('active')
                .animate({ opacity: 1.0 }, 2000, function () {
                    $active.removeClass('active last-active');
                });
    }
    var BASE_URI = "/UploadedImages/HomePageSliders/";
    function getImageUriPrefix() {
        var uriPrefix = BASE_URI;
        var screenWidth = screen.width;
        var screenHeight = screen.height;
        var aspectRatio = screenWidth / screenHeight;
        if (aspectRatio == (4 / 3)) {
            return uriPrefix + '4_3/';
        }
        else {
            if (screenWidth > 1920)
                return uriPrefix + '16_9/2880/';
            else if (screenWidth > 1600)
                return uriPrefix + '16_9/1920/';
            else if (screenWidth > 1440)
                return uriPrefix + '16_9/1600/';
            else
                return uriPrefix + '16_9/1440/';
        }
    }
    var LOADED_IMAGES = 0;
    $(document).ready(function () {
        var uriPrefix = getImageUriPrefix();
        var images = ['Computer.jpg', 'Computer01.jpg', 'Computer02.jpg', 'Laptop.jpg', 'Printer.jpg', 'Toner.jpg'];
        ///PreLoad and Wait for all image loading except the first one
        for (var i = 0; i < images.length; i++) {
            var src = uriPrefix + images[i];
            var imgClass = i == 0 ? 'active' : '';
            var img = $('<img />', { 'alt': '', 'class': imgClass }).appendTo('#divSliderContainer');
            $(img).one('load', function () {
                LOADED_IMAGES++;
                if (LOADED_IMAGES == images.length)
                    setInterval("SlideSwitch()", 5000);
            })
                .attr('src', src)
                .each(function () {
                    if (this.complete) $(this).trigger('load');
                });
        }
    });
</script>
</head>
<body >
    <div class="Backimg">       
    <% using (Html.BeginForm())%> 
    <%{%>   
     <%--<div style="width: 303px; margin: 100px auto 200px auto; background-color:transparent; border: 1px solid gray; box-shadow:2px 2px gray; background: -moz-linear-gradient(center top , #FFFFFF 0px, #DDDDDD 100%) repeat scroll 0 0 transparent;">--%>
      <div style="width: 303px; margin: 100px auto 200px auto; background-color:transparent; border: 1px solid gray; box-shadow:2px 2px gray; border-radius: 4px 4px 4px 4px;">
        <div style="background-color: #DB7093; height: 28px;">
            Sign up</div>
         <%: Html.HiddenFor(model=>model.UserID)%>
         <div class="page_single_column">                
            <div class="editor-field">           
              UserName<%: Html.EditorFor(model => model.UserName, new { @class = "water text-box", title = "User Name" })%>
                      <%--<%: Html.TextBoxFor(model => model.Location, new { @class = "text-box-Location" })%>--%>                                                        
                      <div> <%: Html.ValidationMessageFor(model => model.UserName)%> </div>
            </div>           
        </div>
        <div style="margin: 2.-1em 50cm 0cm 1.2cm;  padding: 0 0 0 6cm;color: Green;"> <div><p  id="Location" ></p></div></div>
        <div class="page_single_column">            
            <div class="editor-field">
              Password   <%: Html.PasswordFor(model => model.Password, new { @class = "text-box" })%>
                         <div><%: Html.ValidationMessageFor(model => model.Password)%></div>
            </div>
        </div> 
        <div class="page_single_column">   
           <div  class="editor-field"> 
               <%: Html.ActionLink("Forget Password", "Forgetpass", new { LoginModel = Model.UserID }, new { @id="dialog_link"})%>              
           </div>     
        </div>
        <div class="Button_single">
            <input type="image" src="../../Content/images/Icon48.png" value="Submit" title="Submit" />
            <%--<input type="image"  class="Button_imp" src="../../Content/images/Icon48.png" value="Submit" title="Submit" />--%>
            <%--<input type="submit"  class="Button_imp"  value="Submit" title="Submit" />--%>
      <%-- <div class="Logo"> For Down in Login Box --%>
        </div>
</div>      
    <%} %>     
 </div>  
<%--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
  <% using (Html.BeginForm("Forgetpass", "Account", FormMethod.Post, new { id = "target" }))
       {%>         

        <!-- ui-dialog -->
		<div id="dialog" title="Forget Password">
           <div id="TextBox">
             <label for="Useremail">Enter Email Address:</label>	           
             <%: Html.TextBoxFor(model => model.Useremail, new { @onblur = "javascript:MailCheck(this, document.getElementById('Message'))" })%>
             <%-- <%: Html.ValidationMessageFor(m => m.Useremail)%>--%>
           </div>
           <div style="color:Red;"><span id="Message" ></span></div>
		</div>         
    <% } %>
<%--////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
  <div id="divSliderContainer" class="home-page-slider"></div> 

</body>
 <script type="text/javascript">
//  $(document).ready(function () {

//            // Define what happens when the textbox comes under focus
//            // Remove the watermark class and clear the box
//            $("input#UserName").focus(function () {

//                $(this).filter(function () {

//                    // We only want this to apply if there's not
//                    // something actually entered
//                    return $(this).val() == "" || $(this).val() == "Enter your name"

//                }).removeClass("watermarkOn").val("");

//            });
 
      
    $('#UserName').change(function () {
         //var SeleName = $(this).val();
         $.post('<%: ResolveUrl("~/Account/UserNameLOC?UName=")%>' + $("#UserName").attr("value"), function (data) {
             //alert("********* WORKING *************");
             //$('input:text[id$=Location]').val(data.Location);
             //$("#Location").val(SeleName);        
             //$('input:text[id$=Location]').attr("disabled", true);
             $("#Location").html(data.Location);   
         });

     });
         
</script>
<%--<script type="text/javascript">
    $('#dropdown').change(function () {
        if ($(this).val() == 'Admin') {
            $('#Select1').hide();
        }
        else {
            $('#Select1').show();
        }

    });
</script>--%>

</html>
