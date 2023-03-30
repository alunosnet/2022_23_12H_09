using M15_TrabalhoModelo_2022_23;
using Projeto_Final_MOD15.Carregadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_MOD15.Carregamentos
{
    public class Carregamento
    {

        public int nCarregamento { get; set; }
        public int nCarregador { get; set; }
        public string nif { get; set; }
        public DateTime data_carregamento { get; set; }
        public float kWh { get; set; }
        public float precoTotal { get; set; }

        public Carregamento()
        {

        }
        public Carregamento(int nCarregamento_, int nCarregador_, string nif_, DateTime data_carregamento_, float kWh_, float precoTotal_)
        {
            this.nCarregamento = nCarregamento_;
            this.nCarregador = nCarregador_;
            this.nif = nif_;
            this.data_carregamento = data_carregamento_;
            this.kWh = kWh_;
            this.precoTotal = precoTotal_;
        }



        public void Guardar(BaseDados bd)
        {
            string sql = @"insert into Carregamentos(nCarregador,cliente,data_carregamento,kWh,precoTotal) Values
                                (@nCarregador,@nif,@data_carregamento,@kWh,@precoTotal)";

            List<System.Data.SqlClient.SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName="@nCarregador",
                        SqlDbType=System.Data.SqlDbType.Int,
                        Value=this.nCarregador
                    },
                    new SqlParameter()
                    {
                        ParameterName="@nif",
                        SqlDbType=System.Data.SqlDbType.VarChar,
                        Value=this.nif
                    },
                    new SqlParameter()
                    {
                        ParameterName="@data_carregamento",
                        SqlDbType=System.Data.SqlDbType.Date,
                        Value=this.data_carregamento.Date
                    },
                    new SqlParameter()
                    {
                        ParameterName="@kWh",
                        SqlDbType=System.Data.SqlDbType.Decimal,
                        Value=this.kWh
                    },
                    new SqlParameter()
                    {
                        ParameterName="@precoTotal",
                        SqlDbType=System.Data.SqlDbType.Decimal,
                        Value=this.precoTotal
                    }
                };

            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "select * from Carregamentos";
            return bd.DevolveSQL(sql);
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroRegisto, int ultimoRegisto)
        {
            string sql = $@"select nCarregamento,nCarregador,cliente,data_carregamento,kWh,precoTotal from
                        (select row_number() over (order by nCarregamento) as Num,* from Carregamentos) as T
                        where Num>={primeiroRegisto} and Num<={ultimoRegisto}";
            return bd.DevolveSQL(sql);
        }

        public DataTable Procurar(int nCarregamento_, BaseDados bd)
        {
            string sql = "select * from Carregamentos where nCarregamento=" + nCarregamento_;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.nCarregamento = int.Parse(temp.Rows[0]["nCarregamento"].ToString());
                this.nCarregador = int.Parse(temp.Rows[0]["nCarregador"].ToString());
                this.nif = temp.Rows[0]["cliente"].ToString();
                this.data_carregamento = DateTime.Parse(temp.Rows[0]["data_carregamento"].ToString());
                this.kWh = float.Parse(temp.Rows[0]["kWh"].ToString());
                this.precoTotal = float.Parse(temp.Rows[0]["precoTotal"].ToString());
            }

            return temp;
        }

        public void ProcurarPorNrLeitor(BaseDados bd, int nCarregamento_)
        {
            string sql = "Select * from Carregamentos where nCarregamento=" + nCarregamento_;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.nCarregamento = int.Parse(dados.Rows[0]["nCarregamento"].ToString());
                this.nCarregador = int.Parse(dados.Rows[0]["nCarregador"].ToString());
                this.nif = dados.Rows[0]["cliente"].ToString();
                this.data_carregamento = DateTime.Parse(dados.Rows[0]["data_carregamento"].ToString());
                this.kWh = float.Parse(dados.Rows[0]["kWh"].ToString());
                this.precoTotal = float.Parse(dados.Rows[0]["precoTotal"].ToString());
            }
        }

        internal static int NrRegistos(BaseDados bd)
        {
            string sql = "select count(*) as NrRegistos from Carregamentos";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public static void ApagarCarregamento(int nCarregamento_, BaseDados bd)
        {
            string sql = "delete from Carregamentos where nCarregamento =" + nCarregamento_;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"update Carregamentos set nCarregador=@nCarregador, cliente=@nif, data_carregamento=@data_carregamento, kWh=@kWh, precoTotal=@precoTotal
                            where nCarregamento=@nCarregamento";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nCarregador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nCarregador
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@data_carregamento",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_carregamento
                },
                new SqlParameter()
                {
                    ParameterName="@kWh",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.kWh
                },
                new SqlParameter()
                {
                    ParameterName="@precoTotal",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.precoTotal
                }
            };

            bd.ExecutaSQL(sql, parametros);
        }

        public override string ToString()
        {
            return this.nCarregamento.ToString();
        }
    }
}
