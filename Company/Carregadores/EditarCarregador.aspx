<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarCarregador.aspx.cs" Inherits="Nº9_12ºH___M17AB_Trabalho_Final.Company.Carregadores.EditarCarregador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Editar Carregador</h1>
    <div class="from-group">
        <label for="ContentPlaceHolder1_dd_localidade">Localidade:</label>
        <asp:DropDownList CssClass="form-control" runat="server" ID="dd_localidade"/><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_chk_utilizacao">Em utilização?</label> <br />
        <asp:CheckBox runat="server" ID="chk_utilizacao" /> Sim <br /> <br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço por kWh:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" TextMode="Number"  step="any" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbLatitude">Latitude:</label>
        <asp:TextBox CssClass="form-control" ID="tbLatitude" runat="server" MaxLength="100" placeholder="00.0000000" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbLongitude">Longitude:</label>
        <asp:TextBox CssClass="form-control" ID="tbLongitude" runat="server" MaxLength="100" placeholder="00.0000000" /><br />
    </div>
    <br />
    <br /><asp:Button CssClass="btn btn-lg btn-success" OnClick="btEditar_Click" runat="server" ID="btEditar" Text="Editar" />
    <asp:Button CssClass="btn btn-lg btn-info" 
        runat="server" 
        ID="btVoltar" 
        Text="Voltar" 
        PostBackUrl="~/Company/Carregadores/carregadores.aspx"/>

    <br />
    <br />  

    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
