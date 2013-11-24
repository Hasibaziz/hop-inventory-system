<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Floorinfo
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Floor List</div></div>
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>

<div class="mp_right_content_form">
        <div class="page_list_container"> 
        <fieldset>          
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>
            <div> 
               <%--<%: Html.ActionLink("Add Issue Item", "Issueitems", new { @href = "#", @id = "dialog_link", title = "Receive Item" })%>--%>
               <%: Html.ActionLink("Add Level/Floor", "AddFloor", new { @href = "#", @id = "dialog_link", title = "Receive Item" })%>
            </div>          
         </fieldset>
        </div>
</div>

<script type="text/javascript">

    $(document).ready(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            pageSize: 15,
            sorting: false,
            title: 'The Level/Floor List',
            defaultSorting: 'Name ASC',
            actions: {
                listAction: '<%=Url.Content("~/Inventory/FloorinfoList") %>',
                updateAction: '<%=Url.Content("~/Inventory/AddFloor") %>'
            },
            fields: {
                FID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
//                LocID: {
//                    title: 'Location',
//                    width: '15%',
//                    options: '<%=Url.Content("~/Inventory/AllLocation") %>'
//                },
                BNID: {
                    title: 'Building Name/No',
                    width: '25%',
                    options: '<%=Url.Content("~/Inventory/AllBuildinginfo") %>'                  
                },
                FloorName: {
                    title: 'Level/Floor Name',
                    width: '25%'
                }
              },
                   formCreated: function (event, data) {
                   data.form.find('input[name="BNID"]').addClass('validate[required]');
                   data.form.find('input[name="FloorName"]').addClass('validate[required]');
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


</asp:Content>
