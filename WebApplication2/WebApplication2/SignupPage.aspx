<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="WebApplication2.SignupPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            사용자 명 :
            <asp:TextBox ID="TextBox1" runat="server" Width="158px"></asp:TextBox>
            <br />
            사용&nbsp; ID&nbsp; :
            <asp:TextBox ID="TextBox2" runat="server" Width="163px"></asp:TextBox>
            <br />
            Password :
            <asp:TextBox ID="TextBox3" runat="server" Width="163px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="가입 신청" OnClick="Button1_Click" />


            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>


        </div>
    </form>
</body>
</html>
