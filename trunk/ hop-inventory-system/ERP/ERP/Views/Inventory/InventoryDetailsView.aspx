<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<ERP.Domain.Model.InvInventorydetailsEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    InventoryDetailsView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--Hasib; hasib_aziz@yahoo.com--%>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
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

<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">PC Details Views</div>
<%--<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HLNT </div>
<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HLAP </div>
<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HLBD </div>
<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HLWF </div>
<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HYBD </div>
<div> <%: Html.RadioButtonFor(m=>m.Location, "HLNT") %> - HLRC </div>--%>
</div>
<div class="mp_right_content">
        <div class="page_list_container">
            <div style="float: left; width: 100%">
                Location: <%: Html.DropDownListFor(m => m.Location, new SelectList(new[] { "HLNT", "HLAP", "HLBD", "HLRC", "HLWF", "HYBD" }), "Please Select...")%>                
                Department: <%: Html.DropDownListFor(m => m.DeptID, (List<SelectListItem>)ViewData["DeptName"], "Please Select...", new { @readonly = "true", @class = "Width=250" })%>
                Account Code : <%: Html.TextBoxFor(m => m.AccountCode, new { @class = "datefield Search_width_txt" })%>    
                Employee Name : <%: Html.TextBoxFor(m => m.EMPNAME, new { @class = "datefield Search_width_txt" })%>                         
            <input type="button" value="Search" title="Save" id="btnGetAccList" />
            </div>        
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>
        </div>
</div>

 <script type="text/javascript">
     $('input#AccountCode, #EMPNAME, #DeptID, #Location').change(function () {         
         $('#RecordsContainer').jtable({
             paging: true,
             pageSize: 10,
             sorting: false,
             title: 'The PC List',
             defaultSorting: 'Name ASC',
             actions: {
                 listAction: '/Inventory/InventoryDetailsListbyid?ACode=' + $("#AccountCode").val() + "&ENAME=" + $("#EMPNAME").val() + "&DNAME=" + $("#DeptID option:selected").text() + "&FLocation=" + $("#Location option:selected").text()
                 //listAction: '/Inventory/InventoryDetailsListbyDid?DNAME=' + $("#DeptID").val()
             },
            fields: {
                AccountID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
//                SL: {
//                    title: 'SL',
//                    width: '2%'
//                },
                ENumber:{
                    title: 'Equipment No',
                    width:'6%'
                },
                Location: {
                    title: 'Office',
                    width: '3%'
                },
                DeptID: {
                    title: 'Department',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                },
                Team: {
                    title: 'Team',
                    width: '3%'
                },
                Status: {
                    title: 'Status',
                    width: '2%'
                },
                Proposed: {
                    title: 'Proposed',
                    width: '2%'
                },
                HostName: {
                    title: 'Host Name',
                    width: '3%'
                },
                AccountCode: {
                    title: 'Account Code',
                    width: '5%',
                    display: function (data) {
                        return '<a href="/Inventory/InventoryDetailsbyID/' + data.record.AccountID + '">' + data.record.AccountCode + '</a>';
                    }
                },
                BrandModel: {
                    title: 'Brand & Model',
                    width: '8%'
                },
                ITemNo: {
                    title: 'ITE.No',
                    width: '3%'
                },
                Category: {
                    title: 'Category',
                    width: '5%'
                },
                Configuration: {
                    title: 'Configuration',
                    width: '12%'
                },
                SerialNo: {
                    title: 'Serial No',
                    width: '7%'
                },
                Office: {
                    title: 'Location',
                    width: '3%'
                },               
                EMPNAME: {
                    title: 'Employee Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameItem") %>'
                },    
                EMPID: {
                    title: 'Employee ID',
                    width: '7%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameListItem") %>'
                },                                  
                PurchDate: {
                    title: 'Purchase Date',
                    width: '7%'
                },
                MonitorID: {
                    title: 'Monitor SL NO',
                    width: '7%'
                },
                UPSID: {
                    title: 'Ups SL NO',
                    width: '7%'
                },                            
                Remark: {
                    title: 'Remark',
                    width: '3%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });         
               
</script>
<script type="text/javascript">

    $(document).ready(function () {

        $('#RecordsContainer').jtable({
            paging: true,
            scrollbar: true,
            pageSize: 10,
            sorting: false,
            title: 'The PC List',
            //defaultSorting: 'date ASC',
            defaultSorting: 'EMPNAME ASC',                    
            actions: {
                listAction: '<%=Url.Content("~/Inventory/InventoryDetailsList") %>', 
                deleteAction: '<%=Url.Content("~/Inventory/DeleteInventoryDetails") %>'
//                updateAction: '<%=Url.Content("~/Inventory/AddUpdateInventoryInfo") %>',
//                createAction: '<%=Url.Content("~/Inventory/AddUpdateInventoryInfo") %>'
            },                  
            fields: {
                AccountID: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                ENumber: {
                    title: 'Equipment No',
                    width: '6%'
                },
                Location: {
                    title: 'Office',
                    width: '3%'
                },
                DeptID: {
                    title: 'Department',
                    width: '5%',
                    options: '<%=Url.Content("~/Inventory/AllDepartmentNameListItem") %>'
                },
                Team: {
                    title: 'Team',
                    width: '3%'
                },
                Status: {
                    title: 'Status',
                    width: '2%'
                },
                Proposed: {
                    title: 'Proposed',
                    width: '2%'
                },
                HostName: {
                    title: 'Host Name',
                    width: '3%'
                },
                AccountCode: {
                    title: 'Account Code',
                    width: '5%',
                    display: function (data) {
                        return '<a href="/Inventory/InventoryDetailsbyID/' + data.record.AccountID + '">' + data.record.AccountCode + '</a>';
                    }
                },
                BrandModel: {
                    title: 'Brand & Model',
                    width: '8%'
                },
                ITemNo: {
                    title: 'ITE.No',
                    width: '3%'
                },
                Category: {
                    title: 'Category',
                    width: '5%'
                },
                Configuration: {
                    title: 'Configuration',
                    width: '12%'
                },
                SerialNo: {
                    title: 'Serial No',
                    width: '7%'
                },
                Office: {
                     title: 'Location',
                     width: '3%'
                },              
                EMPNAME: {
                    title: 'Employee Name',
                    width: '15%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameItem") %>'
                },
                EMPID: {
                    title: 'Employee ID',
                    width: '7%',
                    options: '<%=Url.Content("~/Inventory/AllEmployeeNameListItem") %>'
                },
                PurchDate: {
                    title: 'Purchase Date',
                    width: '7%'
                },
                MonitorID: {
                    title: 'Monitor SL NO',
                    width: '7%'
                },
                UPSID: {
                    title: 'Ups SL NO',
                    width: '7%'
                },
                Remark: {
                    title: 'Remark',
                    width: '3%'
                }
            }
        });
        $('#RecordsContainer').jtable('load');
    });
 
    </script>

</asp:Content>
