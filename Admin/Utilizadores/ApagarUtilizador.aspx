<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarUtilizador.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Admin.Utilizadores.ApagarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Apagar utilizador</h1>
    <br />
    Nome: <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    Email: <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label><br />
    Nif: <asp:Label ID="lbNif" runat="server" Text=""></asp:Label><br />
    ID do utilizador: <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br/>
    <asp:Button ID="btnRemover" 
        runat="server" 
        CssClass="btn btn-lg btn-danger" 
        Text="Remover" OnClick="btnRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Admin/Utilizadores/utilizadores.aspx"/>
</asp:Content>
