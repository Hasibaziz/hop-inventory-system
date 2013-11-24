<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
  <div> 
      <img id="imageSlide"></img>
      <div style="float:right; font-weight: normal; color:Black; padding-bottom: 2px;">
         <%-- Developed By: Hasib <br />  HopLun(BD) Ltd. IT Department--%>
          Developed By: HopLun(BD) Ltd. IT Department
            <div style="font-size: 11px; font-weight: bold; color:Black; padding-bottom: 2px;">
                Log in Time : 
                 <%if (Session["LoginDatetime"] != null)
                   { %>
                    <% Response.Write(Session["LoginDatetime"].ToString()); %>
                <%}%>
            </div>
            <div style="font-size: 11px; font-weight: bolder; color:Black;">
                Logged in as: 
                <%if (Session["UserName"] != null)
                  { %>
                    <% Response.Write(Session["Location"].ToString()); %> | 
                    <% Response.Write(Session["UserName"].ToString()); %> | [<a style="text-decoration:none;color:#009fff" href="<%: Url.Content("~/Account/Logout") %>">Logout</a>]
                <%} %>                  
             </div>
             <div><span id="connectedUsers"> Connected Users Info</span></div>

<%--<table border="1" width="500" style="border-collapse: collapse">
<%
   
foreach (item in Request.ServerVariables)
 { %>
<%   Response.Write("<tr><td>" & item & "</td><td>");  %>
<%   Response.Write(Request.ServerVariables(item));  %>
<%   Response.Write("</td></tr>" & vbCrLf);  %>
<% } %>
</table>--%>


          <div id="social" >  <!--Start Email Rss Icon--><!--End Email Rss Icon--> <!--Start Facebook Icon--> 
           <a rel="nofollow" title="Like Our Facebook Page" href="https://www.facebook.com" target="_blank">
              <img border="0" src="http://4.bp.blogspot.com/-dkmDM3RXcoE/UA6_d28wCyI/AAAAAAAAH8Y/9E3PI3lXueM/s1600/FACEBOOK-48x48.png" style="margin-right:1px;" alt="Icon"/>
           </a> <!--End Facebook Icon--> <!--Start Twitter Icon-->  
           <a rel="nofollow" title="Follow Our Updates On Twitter" href="https://twitter.com/" target="_blank">
              <img border="0" src="http://3.bp.blogspot.com/-TrNf8cdHE6w/UA6_iRAUK_I/AAAAAAAAH88/Jo7RAX207xo/s1600/TWITTER-48x48.png" style="margin-right:1px;" alt="Icon"/>
           </a> <!--End Twitter Icon--> <!--Start Google+ Icon--> <a title="Follow Us On Google+" rel="nofollow" href="https://plus.google.com" target="_blank">
              <img border="0" src="http://2.bp.blogspot.com/-VeOVFTKCvHw/UA6_em6-aOI/AAAAAAAAH8c/Uu4blSzFwLk/s1600/GOOGLE-PLUS-48x48.png" style="margin-right:1px;" alt="Icon"/>
           </a> <!--End Google+ Icon--><br/>
          </div>

      </div>
  </div>
 <%--<div class="logo">   
    <div style="font-size: 20px; font-weight: bold; color:#009fff">
        HOP LUN (BANGLADESH) LTD.
    </div>
    <div style="font-size: 13px; font-weight: bold; color: White">
       V 2012.0.0.1
    </div>    
 </div>--%>

 <%--<div class="logo" style="width:200px">
    <div style="font-size: 18px; font-weight: bold; color:#009fff">
        <%if (Session["ModuleName"] != null)
           { %>
            <% Response.Write(Session["ModuleName"].ToString()); %>
        <%}%>
    </div>
 </div>--%>


<%--<div class="current_user">
    <div style="font-size: 11px; font-weight: bold; color:Black; padding-bottom: 2px;">Developed By: Hasib, HopLun IT Department</div>
    <div style="font-size: 11px; font-weight: bold; color:Black; padding-bottom: 2px;">
        Log in Time : 
         <%if (Session["LoginDatetime"] != null)
           { %>
            <% Response.Write(Session["LoginDatetime"].ToString()); %>
        <%}%>
    </div>
    <div style="font-size: 11px; font-weight: bolder; color:Black;">
        Logged in as: 
        <%if (Session["UserName"] != null)
          { %>
            <% Response.Write(Session["Location"].ToString()); %> | 
            <% Response.Write(Session["UserName"].ToString()); %> | [<a style="text-decoration:none;color:#009fff" href="<%: Url.Content("~/Account/Logout") %>">Logout</a>]
        <%} %>
     </div>--%>

<%--<style> 
    #social a:hover {background-color: transparent; opacity: 0.7;} 
    #social img { -moz-transition: all 0.8s ease-in-out; -webkit-transition: all 0.8s ease-in-out; -o-transition: all 0.8s ease-in-out; -ms-transition: all 0.8s ease-in-out; transition: all 0.8s ease-in-out; } 
    #social img:hover { -moz-transform: rotate(360deg); -webkit-transform: rotate(360deg); -o-transform: rotate(360deg); -ms-transform: rotate(360deg); transform: rotate(360deg); } 
</style>
 <div id="social">  <!--Start Email Rss Icon--><!--End Email Rss Icon--> <!--Start Facebook Icon--> 
   <a rel="nofollow" title="Like Our Facebook Page" href="https://www.facebook.com" target="_blank">
      <img border="0" src="http://4.bp.blogspot.com/-dkmDM3RXcoE/UA6_d28wCyI/AAAAAAAAH8Y/9E3PI3lXueM/s1600/FACEBOOK-48x48.png" style="margin-right:1px;" alt="Icon"/>
   </a> <!--End Facebook Icon--> <!--Start Twitter Icon-->  
   <a rel="nofollow" title="Follow Our Updates On Twitter" href="https://twitter.com/" target="_blank">
      <img border="0" src="http://3.bp.blogspot.com/-TrNf8cdHE6w/UA6_iRAUK_I/AAAAAAAAH88/Jo7RAX207xo/s1600/TWITTER-48x48.png" style="margin-right:1px;" alt="Icon"/>
   </a> <!--End Twitter Icon--> <!--Start Google+ Icon--> <a title="Follow Us On Google+" rel="nofollow" href="https://plus.google.com" target="_blank">
      <img border="0" src="http://2.bp.blogspot.com/-VeOVFTKCvHw/UA6_em6-aOI/AAAAAAAAH8c/Uu4blSzFwLk/s1600/GOOGLE-PLUS-48x48.png" style="margin-right:1px;" alt="Icon"/>
   </a> <!--End Google+ Icon--><br/>
 </div>
</div>--%>
<style> 
    #social a:hover {background-color: transparent; opacity: 0.7;} 
    #social img { -moz-transition: all 0.8s ease-in-out; -webkit-transition: all 0.8s ease-in-out; -o-transition: all 0.8s ease-in-out; -ms-transition: all 0.8s ease-in-out; transition: all 0.8s ease-in-out; } 
    #social img:hover { -moz-transform: rotate(360deg); -webkit-transform: rotate(360deg); -o-transform: rotate(360deg); -ms-transform: rotate(360deg); transform: rotate(360deg); } 
</style>

<script type="text/javascript">
    function PollUsers() {
        $(function () {
//            $.getJSON("/Base/UserConnected", function (json) { $('#connectedUsers').text(json.count + " user(s) connected") });
            $.getJSON("/Base/UserConnected", function (json) { $('#connectedUsers').text(json.count + json.result + " user(s) connected") });
        });
    }

    setInterval(PollUsers, 10000);
</script>

<script type="text/javascript">
    $(function () {

        var imgs = [
                '../../Content/Images/Slideimg/Img01.jpg',                
                '../../Content/Images/Slideimg/Img03.jpg',
                '../../Content/Images/Slideimg/Img04.jpg',
                '../../Content/Images/Slideimg/Img05.jpg',
                '../../Content/Images/Slideimg/Img06.jpg'
                ];
        var cnt = imgs.length;

        var $imageSlide = $('img[id$=imageSlide]');
        // set the image control to the last image
        $imageSlide.attr('src', imgs[cnt - 1]);

        setInterval(Slider, 4000);

        function Slider() {
            $imageSlide.fadeOut(4000, function () {      //$imageSlide.fadeOut("slow", function () {
                $(this).attr('src', imgs[(imgs.length++) % cnt])
                    .fadeIn(4000);    //.fadeIn("slow");
            });
        }
    });
</script>