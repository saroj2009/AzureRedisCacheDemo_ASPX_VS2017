<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCachePage.aspx.cs" Inherits="AzureRedisCacheDemo.TestCachePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <br />
        Delete Cache<br />
        <asp:Button ID="ButDelete" runat="server" Text="Delete Cache" OnClick="ButDelete_Click" />
    </div>
    </form>
</body>
</html>
