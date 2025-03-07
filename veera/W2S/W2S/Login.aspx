<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="W2S.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body { font-family: Arial, sans-serif; text-align: center; padding: 50px; }
        form { display: inline-block; text-align: left; padding: 20px; border: 1px solid #ccc; }
    </style>
</head>
<body>
    <h2>User Login</h2>
    <form id="form1" runat="server">
          <label>Username:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
        
        <label>Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  /><br /><br />
        
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br /><br />
        <a href="Registration.aspx">New user? Register here</a>
   
        <div>
        </div>
    </form>
</body>
</html>
