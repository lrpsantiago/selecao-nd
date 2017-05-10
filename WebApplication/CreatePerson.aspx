<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePerson.aspx.cs" Inherits="WebApplication.CreatePerson" %>

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
        <asp:Button ID="btnSave" runat="server" Height="26px" OnClick="btnSave_Click" Text="Salvar" />
        <br />
        <br />
        <asp:Label ID="lblName" runat="server" Text="Nome:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRequired" runat="server" ForeColor="Red" Text="*Este campo é obrigatório!" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblMarker" runat="server" Text="Marcador:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlMarker" runat="server">
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
