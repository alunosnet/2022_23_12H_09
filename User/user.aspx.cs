using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.User
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            if (IsPostBack)
            {
                return;
            }

            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            tbNome.Text = dados.Rows[0]["nome"].ToString();
            tbNif.Text = dados.Rows[0]["nif"].ToString();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string nif = tbNif.Text;
            //TODO: validar os dados
            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.nif = nif;
            utilizador.id = id;
            utilizador.perfil = 0;
            utilizador.atualizarUtilizador();
        }
    }
}