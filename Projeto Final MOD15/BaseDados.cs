﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
namespace M15_TrabalhoModelo_2022_23
{
    public class BaseDados
    {
        string ligaBD;
        SqlConnection sqlConnection;
        string NomeBD;
        string caminhoBD;

        public static string[] Localidades = { "Açores", "Aveiro", "Beja", "Braga", "Bragança", "Castelo Branco", "Coimbra", "Évora", "Faro", "Guarda", "Leiria", "Lisboa", "Madeira", "Portalegre", "Porto", "Santarém", "Setúbal", "Viana do Castelo", "Vila Real", "Viseu" };

        /*construtor*/
        public BaseDados(string NomeBD)
        {
            ligaBD = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.NomeBD = NomeBD;
            string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            caminhoBD += "\\M15_TrabalhoFinal\\";
            this.caminhoBD = caminhoBD + NomeBD + ".mdf";
            if (System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }
            if (System.IO.File.Exists(this.caminhoBD) == false)
            {
                CriarBD();
            }
            //ligação BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(NomeBD);

        }
        /*destrutor*/
        ~BaseDados()
        {
            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch
            {
                //Pode ocorrer erros 
            }
        }
        private void CriarBD()
        {
            //ligar ao servidor BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            //criar a BD
            string sql = $"CREATE DATABASE {NomeBD} ON PRIMARY (NAME={NomeBD},FILENAME='{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(NomeBD);
            //criar as tabelas
            sql = @"create table Empresas(
                        nEmpresa int identity primary key,
	                    nome varchar(40) not null,

	                    check ((RTRIM(LTRIM(nome)) != '') and (nome is not null))
                    );

                    create table Carregadores(
	                    nCarregador int identity primary key,
	                    localidade varchar(20),
	                    nEmpresa int foreign key references Empresas(nEmpresa),
	                    estado bit default 0, --em utilização,
	                    preco_por_kWh decimal(4,2),
	                    latitude varchar(10),
	                    longitude varchar(10),

	                    check (preco_por_kWh > 0)	
                    );

                    create table Clientes(
	                    nif varchar(9) primary key,
	                    nome varchar(40),

	                    check ((RTRIM(LTRIM(nome)) like '% %') and (len(RTRIM(LTRIM(nome)))>4))
                    );

                    create table Carregamentos(
	                    nCarregamento int identity primary key,
	                    nCarregador int foreign key references Carregadores(nCarregador),
	                    cliente varchar(9) foreign key references Clientes(nif),
	                    data_carregamento date,
	                    kWh decimal(5,2),
	                    precoTotal decimal(7,2),

	                    check (kWh > 0),
	                    check (precoTotal > 0)
                    );";

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //fechar a ligação ao servidor BD
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        /// <summary>
        /// Vai executar um SQL que altera os dados (p.e:insert, delete ou update)
        /// </summary>
        public void ExecutaSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }
        /// <summary>
        /// Executa uma consulta e devolve os dados da bd
        /// </summary>
        /// <returns>Um datatable com o resultado da consulta</returns>
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            DataTable dados = new DataTable();

            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);

            registos.Close();
            comando.Dispose();
            registos = null;
            comando = null;

            return dados;
        }

    }
}
