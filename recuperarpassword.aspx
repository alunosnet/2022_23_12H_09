﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="recuperarpassword.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.recuperarpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Recuperação da palavra passe</h1>
    Nova palavra passe:<asp:TextBox runat="server" ID="tb_password" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="bt_recuperar" Text="Definir nova password" OnClick="bt_recuperar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
