<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Users.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Locationinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%----------------------**********For Popup Window********************--------------------------------------%>
    <link href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js")  %>" type="text/javascript"></script>     
 <%----------------------******************End***************************--------------------------------------%>

 <script type="text/javascript">
         $(document).ready(function () {
             // Dialog
             $('#dialog').dialog({
                 autoOpen: false,
                 resizable: false,    /// To make the Popup Window Customs resize (Big or Small)
                 width: 400,
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
                     "OK": function () {
                        $('#dialog').dialog("close");
                     },
//                     "Cancel": function () {
//                         $(this).dialog("close");
//                     }
                 }
             });
             // Dialog Link
             $('#dialog_link').click(function () {
                 $('#dialog').dialog('open');
                 return false;
             });
         });
             
</script>

 <% using (Html.BeginForm("Locationinfo", "Helps", FormMethod.Post, new { id = "target" }))
       {%>         

        <!-- ui-dialog -->
		<div id="dialog" title="Location Information">           
             <div><label for="HLNT">Hop Lun BD         (HLBD)-110</label></div>
             <div><label for="HLNT">Hop Yick           (HYBD)-120</label></div>
             <div><label for="HLNT">HopLun Welform     (HLWF)-130</label></div>
             <div><label for="HLNT">HopLun Apparel     (HLAP)-210</label></div>
             <div><label for="HLNT">HopLun Rana Centre (HLRC)-220</label></div>
             <div><label for="HLNT">HopLun S.T Tower   (HLST)-230</label></div>
             <div><label for="HLNT">HopLun North Tower (HLNT)-240</label></div>          
         <div style="color:Red;"><span id="Message" ></span></div>
		</div>         
    <% } %>

  <div class="mp_right_content">
        <div class="page_list_container">               
              <div style=" margin: 1em .5cm 0px .5cm;">
               <a href="#" id="dialog_link" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>1. Location Information</a>                        
              </div>           
              <div style="float: left; width: 100%;">
                <div id="RecordsContainer">
                </div>
            </div>
        </div>
</div>

</asp:Content>
