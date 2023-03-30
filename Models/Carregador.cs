using M17AB_TrabalhoModelo_202223.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nº9_12ºH___M17AB_Trabalho_Final.Models
{
    public class Carregador
    {
        public int nCarregador;
        public string localidade;
        public int empresa;
        public bool utilizacao;
        public Decimal preco_por_kWh;
        public string latitude;
        public string longitude;

        BaseDados bd;
        public Carregador()
        {
            this.bd = new BaseDados();
        }


        public int Adicionar()
        {
            string sql = @"INSERT INTO Carregadores(localidade,empresa,utilizacao,preco_por_kWh,latitude,longitude)
                    VALUES (@localidade,@empresa,@utilizacao,@preco_por_kWh,@latitude,@longitude);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@localidade",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.localidade
                },
                new SqlParameter()
                {
                    ParameterName="@empresa",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.empresa
                },
                new SqlParameter()
                {
                    ParameterName="@utilizacao",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.utilizacao
                },
                new SqlParameter()
                {
                    ParameterName="@preco_por_kWh",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco_por_kWh
                },
                new SqlParameter()
                {
                    ParameterName="@latitude",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.latitude
                },
                new SqlParameter()
                {
                    ParameterName="@longitude",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.longitude
                }
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosCarregadores()
        {
            string sql = @"SELECT Carregadores.nCarregador, Carregadores.localidade, utilizadores.nome, Carregadores.preco_por_kWh, Carregadores.latitude, Carregadores.longitude,
                            CASE
                                WHEN Carregadores.utilizacao = 0 THEN 'Disponível'
                                WHEN Carregadores.utilizacao = 1 THEN 'Em utilização'
                            END AS utilizacao
                            FROM Carregadores
                            INNER JOIN utilizadores ON utilizadores.id = Carregadores.empresa";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosCarregadores(int nCarregador)
        {
            string sql = "SELECT * FROM Carregadores WHERE nCarregador=@nCarregador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nCarregador }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public void removerCarregador(int nlivro)
        {
            string sql = "DELETE FROM Carregadores WHERE nCarregador=@nCarregador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nlivro }
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizaCarregador()
        {
            string sql = "UPDATE Carregadores SET localidade=@localidade,empresa=@empresa,utilizacao=@utilizacao,";
            sql += "preco_por_kWh=@preco_por_kWh,latitude=@latitude, longitude=@longitude ";
            sql += " WHERE nCarregador=@nCarregador;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@localidade",SqlDbType=SqlDbType.VarChar,Value= localidade},
                new SqlParameter() {ParameterName="@empresa",SqlDbType=SqlDbType.Int,Value= empresa},
                new SqlParameter() {ParameterName="@utilizacao",SqlDbType=SqlDbType.Bit,Value= utilizacao},
                new SqlParameter() {ParameterName="@preco_por_kWh",SqlDbType=SqlDbType.Decimal,Value= preco_por_kWh},
                new SqlParameter() {ParameterName="@latitude",SqlDbType=SqlDbType.VarChar,Value=latitude},
                new SqlParameter() {ParameterName="@longitude",SqlDbType=SqlDbType.VarChar,Value=longitude},
                new SqlParameter() {ParameterName="@nCarregador",SqlDbType=SqlDbType.Int,Value=nCarregador}
            };
            bd.executaSQL(sql, parametros);
        }

        public DataTable listarCarregadoresDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Carregadores WHERE utilizacao=0";
            if (ordena != null && ordena == 1)
            {
                sql += " order by localidade";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by empresa";
            }
            return bd.devolveSQL(sql);
        }

        internal DataTable listarCarregadoresPorLocalidade(string pesquisa)
        {
            string sql = "SELECT * FROM Carregadores WHERE localidade like @localidade";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@localidade",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal DataTable listarCarregadoresDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Carregadores WHERE utilizacao=0 and localidade like @localidade";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco_por_kWh";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by empresa";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@localidade",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal DataTable listarCarregadorMaisUsado()
        {
            string sql = "SELECT top 1 nCarregador, COUNT(*) AS NumUses FROM Carregamento GROUP BY nCarregador ORDER BY NumUses DESC;";
            return bd.devolveSQL(sql);
        }

        internal DataTable ListaTodosCarregadoresDaEmpresa(int nEmpresa)
        {
            string sql = @"SELECT Carregadores.nCarregador, Carregadores.localidade, Carregadores.preco_por_kWh, Carregadores.latitude, Carregadores.longitude,
                            CASE
                                WHEN Carregadores.utilizacao = 0 THEN 'Disponível'
                                WHEN Carregadores.utilizacao = 1 THEN 'Em utilização'
                            END AS utilizacao
                            FROM Carregadores
                            WHERE empresa = @Empresa";


            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@Empresa",SqlDbType=SqlDbType.Int,Value=nEmpresa }
            };
            return bd.devolveSQL(sql, parametros);
        }

    }

}