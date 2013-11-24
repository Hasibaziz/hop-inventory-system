<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Updateuserinfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--Hasib; hasib_aziz@yahoo.com--%>
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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Update User Info</div></div>
<div class="mp_right_content">
        <div class="page_list_container"></div>
            <div style="float: left; width: 100%;">
                <div id="RecordsContainer"></div>
            </div>
</div>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#RecordsContainer').jtable({
                paging: true,
                pageSize: 20,
                sorting: false,
                title: 'The Users Update List Info',
                defaultSorting: 'Name ASC',
                actions: {
                    listAction: '<%=Url.Content("~/Inventory/UpdateuserinfoList") %>'
                },
                fields: {
                    UserinfoID: {
                        key: true,
                        create: false,
                        edit: false,
                        list: false
                    },
                    AccountCode: {
                        title: 'Account Code',
                        width: '20%'
                    },
                    UserID: {
                        title: 'User Name',
                        width: '15%',
                        options: '<%=Url.Content("~/Inventory/AllUpdateuserListItem") %>'
                    },                    
                    Modifydate: {
                        title: 'Modified Date',
                        width: '15%'
                    }
                }
            });
            $('#RecordsContainer').jtable('load');
        });
 
    </script>

</asp:Content>
