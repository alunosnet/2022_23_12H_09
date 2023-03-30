using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Admin.Carregadores
{
    public partial class AdicionarCarregador : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            if (IsPostBack)
            {
                return;
            }

            dd_localidade.DataSource = Helper.localidades;
            dd_localidade.DataBind();

            dd_empresa.DataSource = listaEmpresas();
            dd_empresa.DataBind();
        }

        protected void bt_Click(object sender, EventArgs e)
        {

            try
            {

                string localidade = dd_localidade.SelectedValue;
                if (!Helper.localidades.Contains(localidade))
                {
                    throw new Exception("Erro na localidade.");
                }

                int empresa = int.Parse(dd_empresa.SelectedValue.Split('|')[0].Trim());
                string sql = @"SELECT id FROM Utilizadores WHERE perfil=2";
                DataTable dados = bd.devolveSQL(sql);
                gvEmpresas.DataSource = dados;
                gvEmpresas.DataBind();

                List<int> empresas = new List<int>();

                foreach(DataRow row in dados.Rows)
                {
                    empresas.Add(int.Parse(row[0].ToString()));
                }

                if(!empresas.Contains(empresa))
                {
                    throw new Exception("Erro na escolha da empresa");
                }

                Decimal preco = Decimal.Parse(tbPreco.Text.Replace(".", ","));
                if (preco < 0 || preco > (decimal)99.99)
                {
                    throw new Exception("O preço deve estar entre 0 e 99.99");
                }

                string latitude = tbLatitude.Text;
                latitude = latitude.Replace(";", ".");
                latitude = latitude.Replace(",", ".");

                if (!Regex.Match(latitude, @"^\d\d[.]\d{7}$").Success)
                {
                    throw new Exception("Erro na latitude");
                }

                string longitude = tbLongitude.Text;
                longitude = longitude.Replace(";", ".");
                longitude = longitude.Replace(",", ".");
                if (!Regex.Match(longitude, @"^\d\d[.]\d{7}$").Success)
                {
                    throw new Exception("Erro na longitude");
                }

                Carregador carregador = new Carregador();
                carregador.localidade = localidade;
                carregador.empresa = empresa;
                carregador.utilizacao = chk_utilizacao.Checked;
                carregador.preco_por_kWh = preco;
                carregador.latitude = latitude;
                carregador.longitude = longitude;
                int nCarregador = carregador.Adicionar();

                Response.Redirect("~/Admin/Carregadores/carregadores.aspx");
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }

        }

        protected List<string> listaEmpresas()
        {
            Utilizador empresas = new Utilizador();
            DataTable dados = empresas.ListaTodasEmpresas();
            List<string> listaEmpresas = new List<string>();

            foreach (DataRow row in dados.Rows)
            {
                listaEmpresas.Add(row[0] + " | " + row[1] + " | " + row[2]);
            }

            return listaEmpresas;
        }
    }
}