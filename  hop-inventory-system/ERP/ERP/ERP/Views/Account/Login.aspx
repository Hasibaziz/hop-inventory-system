<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ERP.Models.LoginModel>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="<%: Url.Content("~/Content/Common.css")%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <% using (Html.BeginForm())%> 
    <%{%>
    <div style="width: 380px; margin: 200px auto 200px auto; border: 1px solid gray;">
        <div style="background-color: #c5c5c5; padding: 10px">
            Login</div>
        <div class="page_single_column">
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName )%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.UserName)%>
                <%: Html.ValidationMessageFor(model => model.UserName)%>
            </div>
        </div>
        <div class="page_single_column">
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password )%>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.Password)%>
                <%: Html.ValidationMessageFor(model => model.Password)%>
            </div>
        </div>
        <div class="page_single_column">
            <input type="submit" value="Submit" title="Submit" />
        </div>
    </div>
    <%} %>
</body>
</html>
