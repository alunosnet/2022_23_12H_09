<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarCarregador.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Admin.Carregadores.ApagarCarregador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Apagar utilizador</h1>
    <br />
    Localidade: <asp:Label ID="lbLocalidade" runat="server" Text=""></asp:Label><br />
    Empresa: <asp:Label ID="lbEmpresa" runat="server" Text=""></asp:Label><br />
    Preço por kWh: <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label><br />
    Latitude: <asp:Label ID="lbLatitude" runat="server" Text=""></asp:Label><br/>
    Longitude: <asp:Label ID="lbLongitude" runat="server" Text=""></asp:Label><br/>
    <asp:Button ID="btnRemover" 
        runat="server" 
        CssClass="btn btn-lg btn-danger" 
        Text="Remover" OnClick="btnRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Admin/Carregadores/Carregadores.aspx"/>
</asp:Content>
