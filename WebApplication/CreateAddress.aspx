<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAddress.aspx.cs" Inherits="WebApplication.CreateAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Cancelar" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="Adicionar" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblType" runat="server" Text="Tipo:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlType" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblContact" runat="server" Text="Logradouro:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbStreetName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRequired" runat="server" ForeColor="Red" Text="*Este campo é obrigatório!" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblNumber" runat="server" Text="Número:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNumber" runat="server" TextMode="Number"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRequiredNum" runat="server" ForeColor="Red" Text="*Este campo é obrigatório!" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Complemento:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbComplement" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Bairro:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDistrict" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Cidade:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbState" runat="server"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
