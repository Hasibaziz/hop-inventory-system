<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ERP.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reportchart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
<div class="mp_left_menu"><div class="scroll-text" style="background-color: #DB7093; font: Arial;">Chart Report</div></div>
<%--<div class="mp_left_menu">
    <% Html.RenderPartial("INVLeftMenu"); %>
</div>--%>
<div class="mp_right_content_form">
  <div class="page_list_container"></div>
    <div style="float: left; width: 100%;"> 
       <div id="RecordsContainer">  </div>
       <%--<img src="<%: Url.Action("EquipmentChart")%>" alt="SimpleChart" /> --%>
       <img src="<%: Url.Action("MyChart")%>" alt="SimpleChart" /> 
      <%-- <img src="<%: Url.Action("Chart")%>" alt="SimpleChart" /> --%>
  </div>
</div>

</asp:Content>
