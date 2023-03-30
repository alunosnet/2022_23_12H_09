using M17AB_TrabalhoModelo_202223.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.User.Carregadores
{
    public partial class Carregador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvCarregadores.Columns.Clear();
            gvCarregadores.DataSource = null;
            gvCarregadores.DataBind();

            Models.Carregador carregador = new Models.Carregador();
            gvCarregadores.DataSource = carregador.listarCarregadoresDisponiveis();

            //botão reservar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Utilizar";
            bt.Text = "Utilizar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "utilizar";
            bt.ControlStyle.CssClass = "btn btn-info";
            gvCarregadores.Columns.Add(bt);

            gvCarregadores.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvCarregadores.RowCommand += gvCarregadores_RowCommand;
        }

        private void gvCarregadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                int linha = int.Parse(e.CommandArgument.ToString());
                int idCarregador = int.Parse(gvCarregadores.Rows[linha].Cells[1].Text);
                int idUtilizador = int.Parse(Session["id"].ToString());
                if (e.CommandName == "utilizar")
                {
                    Models.Carregamento carregamento = new Models.Carregamento();
                    carregamento.adicionarCarregamento(idCarregador, idUtilizador, 1);
                    AtualizarGrid();
                }

                Response.Redirect("~/User/Carregadores/Carregador.aspx");
        }
    }
}