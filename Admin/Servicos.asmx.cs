using M17AB_TrabalhoModelo_202223.Classes;
using Nº9_12ºH___M17AB_Trabalho_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace M17AB_TrabalhoModelo_2022_23.Admin
{
    /// <summary>
    /// Summary description for Servicos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Servicos : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListaCarregador()
        {
            Carregador carregador = new Carregador();
            DataTable dados = carregador.ListaTodosCarregadores();
            List<Carregador> Carregadores = new List<Carregador>(); 
            for(int i=0;i<dados.Rows.Count;i++)
            {
                Carregador novo = new Carregador();
                novo.nCarregador = int.Parse(dados.Rows[i]["nCarregador"].ToString());
                novo.localidade = dados.Rows[i]["localidade"].ToString();
                novo.empresa = int.Parse(dados.Rows[i]["empresa"].ToString());
                novo.preco_por_kWh = Decimal.Parse(dados.Rows[i]["preco_por_kWh"].ToString());
                novo.latitude = dados.Rows[i]["latitude"].ToString();
                novo.longitude = dados.Rows[i]["longitude"].ToString();
                Carregadores.Add(novo);
            }
            return new JavaScriptSerializer().Serialize(Carregadores);
        }
        public class Dados
        {
            public string perfil;
            public int contagem;
        }
        [WebMethod(EnableSession = true)]
        public List<Dados> DadosUtilizadores()
        {
            if (Session["perfil"] == null || Session["perfil"].ToString() != "0")
                return null;
            List<Dados> devolver = new List<Dados>();
            BaseDados bd = new BaseDados();
            DataTable dados = bd.devolveSQL(@"SELECT count(*), case 
                                                   when perfil=0 then 'User'
                                                   when perfil=1 then 'Admin'
                                                   when perfil=2 then 'Company'
                                                end as [perfil]
                                                FROM Utilizadores GROUP BY perfil");
            for (int i = 0; i < dados.Rows.Count; i++)
            {
                Dados novo = new Dados();
                novo.perfil = dados.Rows[i][1].ToString();
                novo.contagem = int.Parse(dados.Rows[i][0].ToString());
                devolver.Add(novo);
            }
            return devolver;
        }
    }
}
