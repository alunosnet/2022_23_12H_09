<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Utilizadores</h1>
    <asp:Button Text="Criar novo utilizador" runat="server" CssClass="btn btn-success" PostBackUrl="AdicionarUtilizador.aspx"/> <br /> <br />
    <asp:GridView CssClass="table" ID="gvUtilizadores" runat="server"></asp:GridView>
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
