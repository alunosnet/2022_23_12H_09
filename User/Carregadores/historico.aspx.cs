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
    public partial class carregamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                atualizarGrid();
            }
            catch
            {
                lbErro.Text = "Não existem carregamentos";
                lbErro.CssClass = "alert alert-danger";
            }
        }
        private void atualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Session["id"].ToString());
            Carregamento carregamento = new Carregamento();
            gvHistorico.DataSource = carregamento.listaTodosCarregamentosComNomes(id);
            gvHistorico.DataBind();
            //TODO: esconder o nome do utilizador
        }
    }
}