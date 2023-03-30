using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_MOD15.Empresas
{
    public class Empresa
    {
        public int nEmpresa { get; set; }
        public string nome { get; set; }


        public Empresa(int nEmpresa_, string nome_)
        {
            this.nEmpresa = nEmpresa_;
            this.nome = nome_;
        }

        public Empresa()
        {
        }

        public void Adicionar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into Empresas(nEmpresa, nome)
                            values(@nEmpresa, @nome)";

            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nEmpresa",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nEmpresa
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                }
            };
            //executar
            bd.ExecutaSQL(sql, parametros);
        }

        internal void Guardar(BaseDados bd)
        {
            string sql = @"insert into Empresas(nome) Values
                            (@nome)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                }
            };

            bd.ExecutaSQL(sql, parametros);
        }

        internal static void ApagarEmpresa(int nEmpresa_, BaseDados bd)
        {
            string sql = "delete from Empresas where nempresa =" + nEmpresa_;
            bd.ExecutaSQL(sql);
        }

        internal static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "select * from Empresas";
            return bd.DevolveSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"update Empresas set nome=@nome
                            where nEmpresa=@nEmpresa";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },

                new SqlParameter()
                {
                    ParameterName="@nEmpresa",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nEmpresa
                }
            };

            bd.ExecutaSQL(sql, parametros);
        }

        public void Apagar(BaseDados bd, int nEmpresa_)
        {
            string sql = "delete from Empresas where nEmpresa =" + nEmpresa_;
            bd.ExecutaSQL(sql);
        }

        public override string ToString()
        {
            return nEmpresa + " - " + nome;
        }
    }
}
