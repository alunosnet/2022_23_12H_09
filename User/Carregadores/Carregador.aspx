<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carregador.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.User.Carregadores.Carregador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table" EmptyDataText="Não existem carregadores disponíveis" runat="server" ID="gvCarregadores"></asp:GridView>
</asp:Content>
