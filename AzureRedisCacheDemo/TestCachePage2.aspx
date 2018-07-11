<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCachePage2.aspx.cs" Inherits="AzureRedisCacheDemo.TestCachePage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
     var before_loadtime = new Date().getTime();
     window.onload = Pageloadtime;
     function Pageloadtime() {
         var aftr_loadtime = new Date().getTime();
         // Time calculating in seconds
         pgloadtime = (aftr_loadtime - before_loadtime) / 1000
         document.getElementById("loadtime").innerHTML = "Pgae load time is <font color='red'><b>" + pgloadtime + "</b></font> Seconds";
     }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <table style="align-content:center" border="0">
                <tr>
                    <td style="width:300px"></td>
                    <td>
                        <asp:Button ID="btn_cache" runat="server" Text="Get Data from Azure RadisCache" OnClick="btn_cache_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_db" runat="server" Text="Get Data from Azure SQL DB" OnClick="btn_db_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" style="width: 600px; align-content:center">
                       <span id="loadtime"></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" style="width: 600px; align-content:center">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
