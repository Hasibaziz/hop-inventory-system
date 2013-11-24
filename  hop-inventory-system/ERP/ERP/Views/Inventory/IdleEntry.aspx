<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvLeaveinfoEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IdleEntry
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<style>
.ui-datepicker-calendar {
    display: none;
    }
</style>


<script type="text/javascript">
    $(function () {
        $("input#Years").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy',
            onClose: function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
            }
        });
    });
</script>
 <script type="text/javascript" >
     $(function () {
         $("input#Months").datepicker({
             changeMonth: true,
             changeYear: true,
             showButtonPanel: true,
             dateFormat: 'm-MM',
             onClose: function (dateText, inst) {
                 var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                 var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                 $(this).datepicker('setDate', new Date(year, month, 1));
             }
         });
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Idle Entry</div></div>
<div class="mp_right_content_form">
        <div class="page_list_container">             
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>        
        </div>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Idle Days Entry</legend>
           <%: Html.HiddenFor(model => model.IID)%>
        <div class="editor-label01">
          <label for="ItemID">Unit Name:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.UnitID, (List<SelectListItem>)ViewData["UnitName"], "Unit Name", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.UnitID)%>
        </div>
        <div class="editor-label01">
            <label for="RDate">Year:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Years) %>
            <%: Html.ValidationMessageFor(model => model.Years)%>
        </div>

        <div class="editor-label01">
            <label for="Chlanno">Month:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Months) %>
            <%: Html.ValidationMessageFor(model => model.Months)%>
        </div>
         <div class="editor-label01">
            <label for="Suppliername">Idle Days:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Idledays)%>
            <%: Html.ValidationMessageFor(model => model.Idledays)%>
        </div>       
        <p>
            <input type="submit" value="Add" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Leaveinfo")%>
</div>
</div>

</asp:Content>
