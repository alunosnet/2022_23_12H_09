using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Admin.Utilizadores
{
    public partial class AdicionarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (true)
                {

                }
                if (nome.Length < 3)
                {
                    throw new Exception("O nome tem de ter pelo menos 3 letras");
                }
                else if (!nome.Trim().Contains(" "))
                {
                    throw new Exception("O nome tem de ter pelo menos 2 palavras");
                }
                string email = tb_email.Text.Trim();
                if (email == String.Empty || email.Contains("@") == false ||
                   email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido");
                }
                string nif = tb_nif.Text.Trim();
                if (nif.Length != 9)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }
                string password = tb_password.Text.Trim();
                if (password.Length < 5)
                {
                    throw new Exception("A password tem de ter pelo menos 5 letras");
                }
                int perfil = int.Parse(dd_perfil.SelectedValue);
                Random rnd = new Random();
                int sal = rnd.Next(1000);

                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.sal = sal;
                utilizador.nif = nif;
                utilizador.password = password;
                utilizador.perfil = perfil;

                utilizador.Adicionar();

                Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
    }
}