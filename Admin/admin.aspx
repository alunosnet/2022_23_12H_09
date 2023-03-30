<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Admin.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área de administrador</h1>
    <hr />
    <h3>Mudar info</h3>
    Nome e apelido:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nome"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control"  runat="server" ID="tb_nif"></asp:TextBox><br /><br />
    <asp:Button CssClass="btn btn-info" runat="server" ID="bt_guardar" Text="Guardar" OnClick="bt_guardar_Click"/>
    <asp:Button CssClass="btn btn-danger" runat="server" ID="bt_apagar" Text="Apagar conta" style="float: right" OnClick="bt_apagar_Click"/><br /><br />
    <asp:Label  runat="server" ID="lb_erro" CssClass="alert alert-danger"></asp:Label>
</asp:Content>
