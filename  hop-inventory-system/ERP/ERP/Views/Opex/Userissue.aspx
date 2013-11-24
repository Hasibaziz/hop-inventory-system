<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OPEX.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvuserissueEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Userissue
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<link href="~/Scripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/validationEngine/jquery.validationEngine-en.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript" >
    $(document).ready(function () {
        $("input#UIssueDate").datepicker({ dateFormat: "dd-mm-yy" });
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
<%--Hasib; hasib_aziz@yahoo.com--%>
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">User Issue Items</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content_form">
    <div class="page_list_container"></div>
       <div style="float: left; width: 100%;"> 
           <div id="RecordsContainer">  
        
<% using (Html.BeginForm("Userissue", "OPEX"))
   { %>
    <%: Html.ValidationSummary(true)%>
    <fieldset>
        <legend>User Issue Items</legend>
         <%: Html.HiddenFor(model => model.UIssueID)%>
         <div class="editor-label01">
           <label for="ModelID">Location:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.LocID, (List<SelectListItem>)ViewData["Location"], "Location", new { @readonly = "true", @class = "Width=250" })%>
            <%--<%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Select")%>--%>
            <%: Html.ValidationMessageFor(model => model.LocID)%>
        </div>    
         <div class="editor-label01">
           <label for="ModelID">Department Name:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(m => m.DeptID, (List<SelectListItem>)ViewData["DeptName"], "Select Department", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.DeptID)%>
        </div>
        <div class="editor-label01">
           <label for="ModelID">Employee ID:</label>
        </div>
        <div class="editor-field01">
            <%: Html.DropDownListFor(model => model.EmpID, new SelectList(new[] { " " }), "Select Emp ID")%>
            <%: Html.ValidationMessageFor(model => model.EmpID)%>
        </div>         
<div style="margin: -9em 20cm 0 3cm; padding: 0 0 0 7cm;">
         <div class="editor-label01">
           <label for="ItemID">Item Name:</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.DropDownListFor(model => model.ItemID, (List<SelectListItem>)ViewData["ItemName"], "Select Item", new { @readonly = "true", @class = "Width=250" })%>
            <%: Html.ValidationMessageFor(model => model.ItemID)%>
        </div>
 
        <div class="editor-label01">
           <label for="ModelID">Model Name:</label>
        </div>
        <div style="margin: -1.3em 1px 3px 122px;">
            <%--<%: Html.DropDownListFor(model => model.ModelID, (List<SelectListItem>)ViewData["ModelName"], "Select Model", new { @readonly = "true", @class = "Width=250" }) %>--%>
            <%: Html.DropDownListFor(model => model.ModelID, new SelectList(new[] { " " }), "Select Model")%>
            <%: Html.ValidationMessageFor(model => model.ModelID)%>
        </div>  
         <div class="editor-label01">
           <label for="ModelID">OnHand Qty:</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.TextBoxFor(model => model.UBalanceQty, new { @class = " Control_Moni_Width_100", @readonly = "readonly" })%>           
        </div> 
</div>
<div style="margin: -9em 20cm 0 13cm; padding: 0 0 0 7cm;"> 

        <div class="editor-label01">
           <label for="ModelID">Total Issue:</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.TextBoxFor(model => model.UIssueTotal, new { @class = " Control_Moni_Width_100", @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.UIssueTotal)%>
        </div>        
        <div class="editor-label01">
           <label for="ModelID">Issue Date:</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.TextBoxFor(model => model.UIssueDate, new { @class = " Control_Moni_Width_100" })%>
            <%: Html.ValidationMessageFor(model => model.UIssueDate )%>
        </div>   
        <div class="editor-label01">
           <label for="ModelID">Ref.(ITRF No.):</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.TextBoxFor(model => model.UITRFNo, new { @class = " Control_Moni_Width_100", @readonly = "readonly" })%>           
        </div>       
        <div class="editor-label01">
           <label for="ModelID">Issue Quantity:</label>
        </div>
        <div style="margin: -1.3em 1px 5px 122px;">
            <%: Html.TextBoxFor(model => model.UIssueQty, new { @class = " Control_Moni_Width_100" })%>            
        </div>
  </div>
   <p>
     <input type="submit" value="Save" />
   </p>
<%} %>
</fieldset>
   </div> 
  </div>
</div>
 <script type="text/javascript">

     $(document).ready(function () {

         $('#RecordsContainer').jtable({
             paging: true,
             pageSize: 5,
             sorting: false,
             title: 'The User Issue Item',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '<%=Url.Content("~/OPEX/UserissueitemList") %>',
                 //deleteAction: '<%=Url.Content("~/Inventory/DeleteItemsRecord") %>',
                 updateAction: '<%=Url.Content("~/Inventory/Userissue") %>',
                 //createAction: '<%=Url.Content("~/Inventory/AddUpdateUserissue") %>'

             },
             fields: {
                 UIssueID: {
                     key: true,
                     create: false,
                     edit: false,
                     list: false
                 },
                 EmpID: {
                     title: 'Employee ID',
                     width: '15%',
                     options: '<%=Url.Content("~/OPEX/AllEmployeeNameListItem") %>'
                 },
                 DeptID: {
                     title: 'Department Name',
                     width: '20%',
                     options: '<%=Url.Content("~/OPEX/AllDepartmentNameListItem") %>'
                 },
                 ItemID: {
                     title: 'Item Name',
                     width: '10%',
                     options: '<%=Url.Content("~/OPEX/AllListItems") %>'
                 },
                 ModelID: {
                     title: 'Model Name',
                     width: '15%',
                     options: '<%=Url.Content("~/OPEX/AllListModels") %>'
                 },                 
                 LocID: {
                     title: 'Location',
                     width: '10%',
                     options: '<%=Url.Content("~/OPEX/AllLocation") %>'                    
                 },
                 UIssueDate: {
                     title: 'Date Of Entry',                    
                     width: '10%'
                 },
                 UITRFNo: {
                     title: 'Ref.(ITRF No.)',                    
                     width: '15%'
                 },
                 UIssueQty: {
                     title: 'Qty',
                     width: '5%'                    
                 }
             },
             formCreated: function (event, data) {
                 data.form.find('input[name="EMPID"]').addClass('validate[required]');
                 data.form.find('input[name="DeptID"]').addClass('validate[required]');
                 data.form.find('input[name="ItemID"]').addClass('validate[required]');
                 data.form.find('input[name="ModelID"]').addClass('validate[required]');
                 data.form.validationEngine();
             },
             //Validate form when it is being submitted
             formSubmitting: function (event, data) {
                 return data.form.validationEngine('validate');
             },
             //Dispose validation logic when form is closed
             formClosed: function (event, data) {
                 data.form.validationEngine('hide');
                 data.form.validationEngine('detach');
             }
         });
         $('#RecordsContainer').jtable('load');
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

    $('#DeptID').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            var items = "<option value=''></option>";
        } else {
            $.post('<%: ResolveUrl("~/Inventory/EmployeeList?ClassID=")%>' + $("#DeptID > option:selected").attr("value"), function (data) {
                var items = "";
                var items1 = "";
                var isSeleted = '';
                if (data.Selected) {
                    isSeleted = " selected='selected'";
                }
                $.each(data, function (i, data) {
                    items += "<option value='" + data.Value + isSeleted + "'>" + data.Text + "</option>";
                });
                $("#EmpID").html(items);
                $("#EmpID").removeAttr('disabled');
            });
        }
    });
                   
</script>
<script type="text/javascript">
    $('#ModelID').change(function () {
        $.post('<%: ResolveUrl("~/Inventory/Usersumvalue?XModelid=")%>' + $("#ModelID > option:selected").attr("value"), function (data) {
            //alert(data.TotalissueQty);
            if (data.BalanceQty == "") {
                $('input:text[id$=UBalanceQty]').val("0");
            }
            else {
                $('input:text[id$=UBalanceQty]').val(data.BalanceQty);
                $('input:text[id$=UIssueTotal]').val(data.UIssueTotal);
                $('input:text[id$=UBalanceQty]').attr("disabled", false);
            }
        });

    });
</script>
<script type="text/javascript">
    $('#UIssueQty').change(function () {
        var Newiss = $(this).val();
        var RValue = $("#UBalanceQty").val();

        var x = 0, y = 0, z = 0; var sum = 0; var DIFF = 0;
        x = parseInt(RValue);
        y = parseInt(Newiss);

        DIFF = x - y;
        //alert(z);
        if (DIFF < 0) {
            alert('Balance cannot be Negative! Please check');
            $('input:text[id$=UIssueQty]').val("0");
            $('input:text[id$=UIssueQty]').focus();
        }
    });
</script>

<script type="text/javascript">
    $('#LocID').change(function () {
        $.post('<%: ResolveUrl("~/Opex/AutoITRF?Locname=")%>' + $("#LocID option:selected").text(), function (data) {
            //alert(data.TotalissueQty);
            $('input:text[id$=UITRFNo]').val(data);
        });

    });
</script>

</asp:Content>
