using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using M15_TrabalhoModelo_2022_23;

namespace Projeto_Final_MOD15.Carregadores
{
    public class Carregador
    {
        public int nCarregador { get; set; }
        public string localidade  { get; set; }
        public int nEmpresa { get; set; }
        public bool estado { get; set; } = false;
        public float preco_por_kWh  { get; set; }
        public string latitude  { get; set; }
        public string longitude  { get; set; }

        public Carregador()
        {

        }


        public void Guardar(BaseDados bd)
        {
            string sql = @"insert into Carregadores(localidade,nEmpresa,estado,preco_por_kWh,latitude,longitude) Values
                            (@localidade,@nEmpresa,@estado,@preco_por_kWh,@latitude,@longitude)";

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
                    ParameterName="@nEmpresa",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nEmpresa
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.estado
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

            bd.ExecutaSQL(sql, parametros);
        }

        internal static DataTable ListarDisponiveis(BaseDados bd)
        {
            string sql = "select * from Carregadores where estado = 0";
            return bd.DevolveSQL(sql);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "select nCarregador, localidade, Empresas.nome, estado, preco_por_kWh as [Preço por kWh] from Carregadores " +
                "inner join Empresas on Carregadores.nEmpresa = Empresas.nEmpresa";
            return bd.DevolveSQL(sql);
        }

        public DataTable Procurar(int nCarregador_, BaseDados bd)
        {
            string sql = "select * from Carregadores where nCarregador=" + nCarregador_;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.nCarregador = int.Parse(temp.Rows[0]["nCarregador"].ToString());
                this.localidade = temp.Rows[0]["localidade"].ToString();
                this.nEmpresa = int.Parse(temp.Rows[0]["nEmpresa"].ToString());
                this.estado = bool.Parse(temp.Rows[0]["estado"].ToString());
                this.preco_por_kWh = float.Parse(temp.Rows[0]["preco_por_kWh"].ToString());
                this.latitude = temp.Rows[0]["latitude"].ToString();
                this.longitude = temp.Rows[0]["longitude"].ToString();
            }

            return temp;
        }

        public static void ApagarCarregador(int nCarregador_, BaseDados bd)
        {
            string sql = "delete from Carregadores where nCarregador =" + nCarregador_;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"update Carregadores set localidade=@localidade,nEmpresa=@nEmpresa,estado=@estado,preco_por_kWh=@preco_por_kWh,latitude=@latitude,longitude=@longitude
                            where nCarregador=@nCarregador";

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
                    ParameterName="@localidade",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.localidade
                },
                new SqlParameter()
                {
                    ParameterName="@nEmpresa",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nEmpresa
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Bit,
                    Value=this.estado
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

            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable PesquisaPorLocalidade(BaseDados bd, string localidade)
        {
            string sql = @"select * from Carregadores where localidade like @localidade";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@localidade",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+localidade+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }

        public static int NrRegistos(BaseDados bd)
        {
            string sql = "select count(*) as NrRegistos from Carregadores";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public static DataTable ListarTodos(BaseDados bd, int primeiroRegisto, int ultimoRegisto)
        {
            string sql = $@"select nCarregador,localidade,Empresas.nome, estado, preco_por_kWh, latitude, longitude from
                        (select row_number() over (order by nCarregador) as Num,* from Carregadores) as T
                        inner join Empresas on T.nEmpresa = Empresas.nEmpresa
                        where Num>={primeiroRegisto} and Num<={ultimoRegisto}";
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.nCarregador.ToString();
        }


    }
}
