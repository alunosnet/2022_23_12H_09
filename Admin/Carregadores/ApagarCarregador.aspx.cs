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
    public partial class ApagarCarregador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;

            try
            {
                int nCarregador = int.Parse(Request["nCarregador"].ToString());
                Carregador carregador = new Carregador();

                DataTable dados = carregador.devolveDadosCarregadores(nCarregador);

                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("O carregador não existe");
                }

                lbEmpresa.Text = dados.Rows[0]["empresa"].ToString();
                lbLatitude.Text = dados.Rows[0]["latitude"].ToString();
                lbLongitude.Text = dados.Rows[0]["longitude"].ToString();
                lbLocalidade.Text = dados.Rows[0]["localidade"].ToString();
                lbPreco.Text = dados.Rows[0]["preco_por_kWh"].ToString();
            }

            catch
            {
                Response.Redirect("~/Admin/Carregadores/carregadores.aspx");
            }
        }
        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int nCarregador = int.Parse(Request["nCarregador"].ToString());
            Carregador carregador = new Carregador();

            carregador.removerCarregador(nCarregador);
            Response.Redirect("~/Admin/Carregadores/carregadores.aspx");
        }
    }
}