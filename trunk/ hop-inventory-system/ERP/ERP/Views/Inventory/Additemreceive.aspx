<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvitemreceiveEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Additemreceive
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#RDate").datepicker({ dateFormat: "dd-mm-yy" });
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Add Receive Item</div></div>
<div class="mp_right_content_form">
        <div class="page_list_container">             
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>        
        </div>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Receiver Item</legend>
           <%: Html.HiddenFor(model => model.IRID)%>
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

        <div class="editor-label01">
            <label for="RDate">Receive Date:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.RDate) %>
            <%: Html.ValidationMessageFor(model => model.RDate) %>
        </div>

        <div class="editor-label01">
            <label for="Chlanno">Ref.(Challan No.):</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Chlanno) %>
            <%: Html.ValidationMessageFor(model => model.Chlanno) %>
        </div>
         <div class="editor-label01">
            <label for="Suppliername">Supplier Name:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Suppliername)%>
            <%: Html.ValidationMessageFor(model => model.Suppliername)%>
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
            <label for="Quantity">Quantity:</label>
        </div>
        <div class="editor-field01">
            <%: Html.EditorFor(model => model.Quantity) %>
            <%: Html.ValidationMessageFor(model => model.Quantity) %>
        </div>

        <p>
            <input type="submit" value="Add" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Itemreceive")%>
</div>
</div>

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
