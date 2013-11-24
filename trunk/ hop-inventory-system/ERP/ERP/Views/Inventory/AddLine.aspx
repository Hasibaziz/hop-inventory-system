<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvLineinfoEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddLine
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>

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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Line Entry</div></div>
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
           <%: Html.HiddenFor(model => model.LID)%>
            <div class="editor-label01">
          <label for="ItemID">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.LocID)%>
        </div>
        <div class="editor-label01">
          <label for="ItemID">Building Name/No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.BNID, (List<SelectListItem>)ViewData["BuildingName"], "Building", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.BNID)%>
        </div>
         <div class="editor-label01">
          <label for="ItemID">Floor/Level No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.FID, (List<SelectListItem>)ViewData["FloorName"], "Floor", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.FID)%>
        </div>
        <div class="editor-label01">
            <label for="RDate">Line No:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.LineName) %>
            <%: Html.ValidationMessageFor(model => model.LineName)%>
        </div>            
        <p>
            <input type="submit" value="Add" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Lineinfo")%>
</div>
</div>
<script type="text/javascript">

    $('#LocID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Inventory/GetBuildingBylocID?locid=")%>' + $("#LocID > option:selected").attr("value"), function (data) {
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
            $.post('<%: ResolveUrl("~/Inventory/GetFloorByBNID?flrid=")%>' + $("#BNID > option:selected").attr("value"), function (data) {
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

</asp:Content>
