<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="W2S.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            padding: 50px;
        }

        form {
            display: inline-block;
            text-align: left;
            padding: 20px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <h2>User Registration</h2>
    <form id="form1" runat="server">

        <label>Username:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        <br />

        <label>Email:</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <br />


        <label>Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />

         <label>Education:</label>
        <asp:DropDownList ID="DDlEdu" runat="server">
            <asp:ListItem>UG</asp:ListItem>
            <asp:ListItem>PG</asp:ListItem>
            <asp:ListItem>SSLC</asp:ListItem>
            <asp:ListItem>HSC</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
             <br />      

        <label>Select Image:</label>
        <asp:FileUpload ID="fileUpload" runat="server" /><br />
        <br />

        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /><br />
        <br />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <a href="Login.aspx">Already registered? Login here</a>
    </form>
</body>
</html>
