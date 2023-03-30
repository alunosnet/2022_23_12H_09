using M15_TrabalhoModelo_2022_23;
using Projeto_Final_MOD15.Carregadores;
using Projeto_Final_MOD15.Carregamentos;
using Projeto_Final_MOD15.Clientes;
using Projeto_Final_MOD15.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_MOD15
{
    public partial class FRM_principal : Form
    {
        BaseDados BD = new BaseDados("M15_BD_final");
        public FRM_principal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Abre o form dos carregadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carregamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_carregamento F_Carregamentos = new FRM_carregamento(BD);
            F_Carregamentos.ShowDialog(); //Não quero que o utilizador possa mexer em mais que 1 janela ao mesmo tempo, por isso uso showdialog
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_empresa F_Empresas = new FRM_empresa(BD);
            F_Empresas.ShowDialog(); 
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_cliente F_Clientes = new FRM_cliente(BD);
            F_Clientes.ShowDialog();
        }

        private void carregadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_carregador F_Carregadores = new FRM_carregador(BD);
            F_Carregadores.ShowDialog();
        }
    }
}
