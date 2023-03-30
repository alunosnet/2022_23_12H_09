using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Admin.Carregadores
{
    public partial class MaisUtilizado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (UserLogin.ValidarSessaoSemLogout(Session, Request, "0"))
                {
                    Response.Redirect("/user/Carregadores/Carregador.aspx");
                }

                if (UserLogin.ValidarSessaoSemLogout(Session, Request, "2"))
                {
                    Response.Redirect("~/Company/Carregadores/Carregadores.aspx");
                }
            }
            melhor();
        }

        private void melhor()
        {
            Carregador carregador = new Carregador();
            DataTable carregador_data;
            carregador_data = carregador.listarCarregadorMaisUsado();

            string grelha = "O carregador mais utilizado é <b>id: " + carregador_data.Rows[0][0];
            grelha += ".</b><br>";
            grelha += "O carregador foi utilizado <b>" + carregador_data.Rows[0][1];
            grelha += " vezes.</b>";
            grelha += "</br><hr>";

            Utilizador utilizador = new Utilizador();
            DataTable utilizador_data;
            utilizador_data = utilizador.listarUtilizadorRegular();

            grelha += "O utilizador mais regular é: <b>" + utilizador_data.Rows[0][2] + " ( id:"+ utilizador_data.Rows[0][0] + ")";
            grelha += ".</b><br>";
            grelha += "Já carregou <b>" + utilizador_data.Rows[0][1];
            grelha += " vezes.</b>";
            divMelhor.InnerHtml = grelha;
        }
    }
}