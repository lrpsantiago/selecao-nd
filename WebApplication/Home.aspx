<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblName" runat="server" Text="Nome:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    
        <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreate" runat="server" Text="Criar Novo" OnClick="btnCreate_Click" />
        <br />
        <br />
        <asp:Label ID="lblOrderBy" runat="server" Text="Ordenar Por:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlOrderBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrderBy_SelectedIndexChanged">
            <asp:ListItem Value="Name">Nome</asp:ListItem>
            <asp:ListItem Value="MarkerId">Marcador</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvPersons" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvPersons_RowDataBound" OnRowCommand="gvPersons_RowCommand" Width="366px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" Visible="False" />
                <asp:HyperLinkField HeaderText="Nome" DataTextField="Name" NavigateUrl="~/DetailsPage.aspx" DataNavigateUrlFields="id" DataNavigateUrlFormatString="DetailsPage.aspx?id={0}" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="Marcador" ReadOnly="True" DataField="Marker">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:ButtonField CommandName="DeletePerson" Text="Apagar" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ButtonField>
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
    
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>
