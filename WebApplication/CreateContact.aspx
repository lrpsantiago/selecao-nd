<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateContact.aspx.cs" Inherits="WebApplication.CreateContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Cancelar" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Adicionar" />
        <br />
        <br />
        <asp:Label ID="lblType" runat="server" Text="Meio:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlType" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblContact" runat="server" Text="Contato:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbValue" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRequired" runat="server" ForeColor="Red" Text="*Este campo é obrigatório!" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
