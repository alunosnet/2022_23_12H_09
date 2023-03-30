using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                MostrarPerfil();
            }
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Session["id"].ToString());

                //validar os dados do form
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (nome.Length < 3 || !nome.Contains(" "))
                {
                    throw new Exception("O nome tem de ter pelo menos 3 letras e um apelido");
                }

                string nif = tb_nif.Text.Trim();
                if (nif.Length != 9)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }


                //TODO: validar os dados
                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.nif = nif;
                utilizador.id = id;
                utilizador.perfil = 1;
                utilizador.atualizarUtilizador();
            }
            catch (Exception erro)
            {

                lb_erro.Text = erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
        void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);

            tb_nome.Text = dados.Rows[0]["nome"].ToString();
            tb_nif.Text = dados.Rows[0]["nif"].ToString();
        
        }

        protected void bt_apagar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            Utilizador uti = new Utilizador();

            uti.removerUtilizador(id);
            Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
        }
    }
}