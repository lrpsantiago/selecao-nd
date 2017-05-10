﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsPage.aspx.cs" Inherits="WebApplication.DetailsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Voltar" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Editar" />
        <br />
        <br />
        <asp:Label ID="lblName" runat="server" Text="Nome:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbName" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblMarker" runat="server" Text="Marcador:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlMarker" runat="server" Enabled="False">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblAddresses" runat="server" Text="Endereço:"></asp:Label>
        <asp:GridView ID="gvAddresses" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Tipo" />
                <asp:BoundField DataField="StreetName" HeaderText="Logadouro" />
                <asp:BoundField DataField="Number" HeaderText="Número" />
                <asp:BoundField DataField="Complement" HeaderText="Complemento" />
                <asp:BoundField DataField="District" HeaderText="Bairro" />
                <asp:BoundField DataField="City" HeaderText="Cidade" />
                <asp:BoundField DataField="State" HeaderText="Estado" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contatos:"></asp:Label>
        <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Meio" />
                <asp:BoundField DataField="Value" HeaderText="Contato" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
