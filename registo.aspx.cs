using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (nome.Length < 3 || !nome.Contains(" "))
                {
                    throw new Exception("O nome tem de ter pelo menos 3 letras e um apelido");
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
                int perfil = 0;

                //inserir o utilizador na bd
                Utilizador utilizador = new Utilizador();
                utilizador.nif = nif;
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.password = password;
                utilizador.perfil = perfil;
                Random rnd = new Random();
                utilizador.sal = rnd.Next(9999);    //Isto devia estar na função adicionar
                utilizador.Adicionar();

                tb_nome.Visible = false;
                tb_email.Visible = false;
                tb_nif.Visible = false;
                tb_password.Visible = false;
                bt_guardar.Visible = false;

                lb_erro.Text = "Registado com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch (Exception erro)
            {
                if (erro.Message.Contains("UQ_Utilizadores_email"))
                {
                    lb_erro.Text = "Já existe uma conta com esse email!";
                    lb_erro.CssClass = "alert alert-danger";
                    return;
                }

                lb_erro.Text = erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
    }
}