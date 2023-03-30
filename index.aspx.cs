using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (UserLogin.ValidarSessaoSemLogout(Session, Request, "0"))
                {
                    Response.Redirect("/user/Carregadores/Carregador.aspx");
                }

                if (UserLogin.ValidarSessaoSemLogout(Session, Request, "1"))
                {
                    Response.Redirect("/admin/Carregadores/Carregadores.aspx");
                }

                if (UserLogin.ValidarSessaoSemLogout(Session, Request, "2"))
                {
                    Response.Redirect("~/Company/Carregadores/Carregadores.aspx");
                }
            }
            atualizaListaCarregadores(null);
        }
        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaListaCarregadores(tbPesquisa.Text);
        }
        private void atualizaListaCarregadores(string pesquisa = null)
        {
            Carregador carregador = new Carregador();
            DataTable dados;
            if (pesquisa == null)
            {
                dados = carregador.listarCarregadoresPorLocalidade("");
            }
            else
            {
                dados = carregador.listarCarregadoresPorLocalidade(pesquisa);
            }
            gerarIndex(dados);
        }
        private void gerarIndex(DataTable dados)
        {
            string estado = "null";
            if (dados == null || dados.Rows.Count == 0)
            {
                divCarregadores.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow carregador in dados.Rows)
            {

                if (carregador[3].ToString() == "True")
                {
                    estado = "Em utilização";
                }
                else
                {
                    estado = "Disponivel";
                }

                grelha += "<div>";
                grelha += "<span class='stat-title'>" + carregador[0].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'> | " + carregador[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'> | " + carregador[2].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'> | " + estado
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(carregador["preco_por_kWh"].ToString()))
                    + "</span>";
                grelha += "</div>";
                grelha += "</br>";
                grelha += "</hr>";
                grelha += "</br>";
            }
            grelha += "</div></div>";
            divCarregadores.InnerHtml = grelha;
        }
    }
}