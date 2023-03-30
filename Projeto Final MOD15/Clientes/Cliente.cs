using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_MOD15.Clientes
{
    public class Cliente
    {
        public string nif { get; set; }
        public string nome { get; set; }

        public Cliente(string nif_, string nome_)
        {
            this.nif = nif_;
            this.nome = nome_;
        }

        public Cliente()
        {

        }

        public static DataTable procurarNif(BaseDados bd, string nif_)
        {
            string sql = @"select count(*) from clientes where nif like @nif";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nif_+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }

        internal void Guardar(BaseDados bd)
        {
            string sql = @"insert into Clientes(nif, nome) Values
                            (@nif, @nome)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                }
            };

            bd.ExecutaSQL(sql, parametros);
        }

        internal static int NrRegistos(BaseDados bd)
        {
            string sql = "select count(*) as NrRegistos from Clientes";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        internal static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "select * from Clientes ";
            return bd.DevolveSQL(sql);
        }

        internal static DataTable ListarTodos(BaseDados bd, int primeiroRegisto, int ultimoRegisto)
        {
            string sql = $@"select nif,nome from
                        (select row_number() over (order by nif) as Num,* from clientes) as T
                        where Num>={primeiroRegisto} and Num<={ultimoRegisto}";
            return bd.DevolveSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"update Clientes set nome=@nome
                            where nif=@nif";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                }
            };

            bd.ExecutaSQL(sql, parametros);
        }

        internal DataTable Procurar(int nif_, BaseDados bd)
        {
            string sql = "select * from Clientes where nif=" + nif_;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.nif = temp.Rows[0]["nif"].ToString();
                this.nome = temp.Rows[0]["nome"].ToString();
            }

            return temp;
        }

        internal static void ApagarCliente(string nif_escolhido_, BaseDados bd)
        {
            string sql = "delete from Clientes where nif =" + nif_escolhido_;
            bd.ExecutaSQL(sql);
        }

        internal static DataTable PesquisaPorNif(BaseDados bd, string nif_)
        {
            string sql = @"select * from Clientes where nif like @nif";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nif_+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }

        public override string ToString()
        {
            return this.nif;
        }
    }
}
