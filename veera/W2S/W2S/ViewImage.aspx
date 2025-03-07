<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewImage.aspx.cs" Inherits="W2S.ViewImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>View Uploaded Image</title>
    <style>
        body { font-family: Arial, sans-serif; text-align: center; padding: 50px; }
        form { display: inline-block; text-align: left; padding: 20px; border: 1px solid #ccc; }
        img { width: 240px;
    height: 180px;
    border: 5px solid #000;
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden; 
    position: relative;
} 

    </style>
</head>
<body>
     <h2>Uploaded Image</h2>
    <form id="form1" runat="server">
          <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br /><br />
        
        <asp:Image ID="imgUser" runat="server" /><br /><br />
        <label>Name :</label>  <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
       <label>Email :</label>  <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox><br />
      
        <br /><br />
        <a href="Login.aspx">Logout</a>
        <div>
        </div>
    </form>
</body>
</html>
