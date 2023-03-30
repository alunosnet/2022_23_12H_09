<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carregadores.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.User.Carregadores.Carregadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Carregadores</h1>
    <asp:Button Text="Adicionar carregador" runat="server" CssClass="btn btn-success" PostBackUrl="AdicionarCarregador.aspx"/> <br /> <br />
    <asp:GridView CssClass="table" ID="gvCarregadores" runat="server"></asp:GridView>
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
