using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.User.Carregadores
{
    public partial class Carregadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        private void ConfigurarGrid()
        {
            gvCarregadores.AllowPaging = true;
            gvCarregadores.PageSize = 5;
            gvCarregadores.PageIndexChanging += GvCarregador_PageIndexChanging;
        }

        private void GvCarregador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCarregadores.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvCarregadores.Columns.Clear();
            Models.Carregador carregador = new Models.Carregador();
            DataTable dados = carregador.ListaTodosCarregadores();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvCarregadores.DataSource = dados;
            gvCarregadores.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarCarregador.aspx?nCarregador={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "nCarregador" };
            hlEditar.ControlStyle.CssClass = "btn btn-info";
            gvCarregadores.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarCarregador.aspx?nCarregador={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "nCarregador" };
            hlApagar.ControlStyle.CssClass = "btn btn-danger";
            gvCarregadores.Columns.Add(hlApagar);

            BoundField bfncarregador = new BoundField();
            bfncarregador.HeaderText = "Nº Carregador";
            bfncarregador.DataField = "nCarregador";
            gvCarregadores.Columns.Add(bfncarregador);

            BoundField bfempresa = new BoundField();
            bfempresa.HeaderText = "Empresa";
            bfempresa.DataField = "nome";
            gvCarregadores.Columns.Add(bfempresa);

            BoundField bflocalidade = new BoundField();
            bflocalidade.HeaderText = "Localidade";
            bflocalidade.DataField = "localidade";
            gvCarregadores.Columns.Add(bflocalidade);

            BoundField bfutilizacao = new BoundField();
            bfutilizacao.HeaderText = "Em utilização";
            bfutilizacao.DataField = "utilizacao"; ;
            gvCarregadores.Columns.Add(bfutilizacao);

            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço por kWh";
            bfpreco.DataField = "preco_por_kWH";
            bfpreco.DataFormatString = "{0:C}";
            gvCarregadores.Columns.Add(bfpreco);

            BoundField bflatitude = new BoundField();
            bflatitude.HeaderText = "Latitude";
            bflatitude.DataField = "latitude";
            gvCarregadores.Columns.Add(bflatitude);

            BoundField bflongitude = new BoundField();
            bflongitude.HeaderText = "Longitude";
            bflongitude.DataField = "longitude";
            gvCarregadores.Columns.Add(bflongitude);

            gvCarregadores.DataBind();
        }
    }
}