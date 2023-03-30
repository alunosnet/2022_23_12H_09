<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registo</h1>
    Nome e apelido:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_email"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    <asp:Button CssClass="btn btn-info" runat="server" ID="bt_guardar" Text="Registar" OnClick="bt_guardar_Click" /><br /><br />
    <asp:Label  runat="server" ID="lb_erro" CssClass="alert alert-danger"></asp:Label>
</asp:Content>