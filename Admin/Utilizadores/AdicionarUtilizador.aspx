<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdicionarUtilizador.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Admin.Utilizadores.AdicionarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Adicionar Utilizador</h1>
    Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tb_email"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    Perfil:<asp:DropDownList CssClass="form-control" runat="server" ID="dd_perfil">
                <asp:ListItem Value="0">Cliente</asp:ListItem>
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Empresa</asp:ListItem>
           </asp:DropDownList>
    <br />
    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt_guardar" Text="Adicionar" OnClick="bt_guardar_Click" /><br /><br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
