<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ERP.Models.LoginModel>" %>
<%--This is Successfull form for POPUP Dialogue Boxes-- @Hasib --%>

<link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery-1.5.1.js")  %>" type="text/javascript"></script> 
<script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script> 


 <script type="text/javascript">
     $(document).ready(function () {
         // Dialog
         $('#dialog').dialog({
             autoOpen: false,
             width: 600,
             buttons: {
                 "Ok": function () {
                     $(this).dialog("close");
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

         //hover states on the static widgets
         $('#dialog_link, ul#icons li').hover(
				function () { $(this).addClass('ui-state-hover'); },
				function () { $(this).removeClass('ui-state-hover'); }
			);
     });   

</script>
 
   <% using (Html.BeginForm("Forgetpass", "Account", FormMethod.Post, new { id = "target" }))
       {%>
           <%--<div>
            <a href="#" id="dialog_link" ><span class="ui-icon ui-icon-newwin"></span>Open Dialog</a>            
           </div>--%>

        <!-- ui-dialog -->
		<div id="dialog" title="Dialog Title">
			<p>It is a Popup Menu</p>
             Enter Email Address:  <%: Html.TextBoxFor(model => model.Useremail)%>
		</div>                             
          
    <% } %>


