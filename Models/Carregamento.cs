using M17AB_TrabalhoModelo_202223.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Models
{
    public class Carregamento
    {
        BaseDados bd;

        public Carregamento()
        {
            this.bd = new BaseDados();
        }

        public void adicionarCarregamento(int nCarregador, int nCliente, float kWh)
        {
            string sql = "SELECT * FROM Carregadores WHERE nCarregador=@nCarregador";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nCarregador }
            };
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                string a = dados.Rows[0]["utilizacao"].ToString();
                if (dados.Rows[0]["utilizacao"].ToString() != "False")
                    throw new Exception("Carregador não está disponível");

                sql = "UPDATE Carregadores SET utilizacao=@utilizacao WHERE nCarregador=@nCarregador";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nCarregador },
                    new SqlParameter() {ParameterName="@utilizacao",SqlDbType=SqlDbType.Int,Value=1 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);

                sql = @"INSERT INTO Carregamento(nCarregador,cliente,data_carregamento, kWh) 
                            VALUES (@nCarregador, @cliente, @data_carregamento, @kWh)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nCarregador },
                    new SqlParameter() {ParameterName="@cliente",SqlDbType=SqlDbType.Int,Value=nCliente },
                    new SqlParameter() {ParameterName="@data_carregamento",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                    new SqlParameter() {ParameterName="@kWh",SqlDbType=SqlDbType.Decimal,Value=kWh },
                };
                bd.executaSQL(sql, parametrosInsert, transacao);

                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }
        public DataTable listaTodosCarregamentosComNomes(int nCliente)
        {
            string sql = @"SELECT nCarregamento,Carregadores.nCarregador as [Nº Carregador],Utilizadores.nome as [Nome cliente],data_carregamento,kWh,precoTotal
                        FROM Carregamento 
                        inner join Carregadores on Carregamento.nCarregador=Carregadores.nCarregador
                        inner join Utilizadores on Carregamento.Cliente=Utilizadores.id Where Cliente=@Cliente";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@Cliente",SqlDbType=SqlDbType.Int,Value=nCliente }
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}
