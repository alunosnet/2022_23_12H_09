using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_MOD15.Clientes
{
    public partial class FRM_cliente : Form
    {
        BaseDados bd;
        string Nif_escolhido = "";
        int NrRegistosPorPagina = 5;
        int nrlinhas, nrpagina;
        public FRM_cliente(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;

            AtualizarGrelha();
            AtualizarNrPaginas();
        }

        private void BTN_guardar_Click(object sender, EventArgs e)
        {

            //Validar os dados
            string nome = TXT_nome.Text.Trim();
            if (nome.Length<3 || (!nome.Contains(" ") || nome.Length > 40))
            {
                MessageBox.Show("O nome tem de ter entre 3 e 40 letras e 1 espaço.");
                TXT_nome.Focus();
                return;
            }


            string nif = TXT_Nif.Text.Trim();
            if (nif.Length != 9 || nif.Contains(" "))
            {
                MessageBox.Show("O nif tem de ter 9 charateres e nenhum espaço.");
                TXT_nome.Focus();
                return;
            }

            int pesquiasNif = int.Parse(Cliente.procurarNif(bd, nif).Rows[0][0].ToString());

            if (pesquiasNif > 0)
            {
                MessageBox.Show("O nif tem de ser único.");
                TXT_nome.Focus();
                return;
            }

            Cliente cliente = new Cliente();

            cliente.nome = nome;
            cliente.nif = TXT_Nif.Text.Trim();

            cliente.Guardar(bd);

            LimparForm();
            AtualizarGrelha();
            AtualizarNrPaginas();
        }

        private void AtualizarNrPaginas()
        {
            CMB_pagina.Items.Clear();
            int nrlivros = Cliente.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nrlivros / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                CMB_pagina.Items.Add(i);

            if (CMB_pagina.Items.Count == 0)
            {
                CMB_pagina.Items.Add(1);
            }
            CMB_pagina.SelectedIndex = 0;
        }

        private void AtualizarGrelha()
        {
            DGV_clientes.AllowUserToAddRows = false;
            DGV_clientes.AllowUserToDeleteRows = false;
            DGV_clientes.ReadOnly = true;
            DGV_clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_clientes.MultiSelect = false;

            if (CMB_pagina.SelectedIndex == -1)
                DGV_clientes.DataSource = Cliente.ListarTodos(bd);
            else
            {
                //paginação
                int nrpagina = CMB_pagina.SelectedIndex + 1;
                int primeiroRegisto = (nrpagina - 1) * NrRegistosPorPagina + 1; //1
                int ultimoRegisto = primeiroRegisto + NrRegistosPorPagina - 1;
                DGV_clientes.DataSource = Cliente.ListarTodos(bd, primeiroRegisto, ultimoRegisto);
            }
        }

        private void LimparForm()
        {
            TXT_Nif.Text = "";
            TXT_nome.Text = "";
            TXT_Nif.ReadOnly = false;
            AtualizarGrelha();
        }

        private void BTN_editar_Click(object sender, EventArgs e)
        {
            string nome = TXT_nome.Text.Trim();
            if (nome.Length < 3 || (!nome.Contains(" ") || nome.Length > 40))
            {
                MessageBox.Show("O nome tem de ter entre 3 e 40 letras e 1 espaço.");
                TXT_nome.Focus();
                return;
            }

            Cliente carregador = new Cliente();

            carregador.nome = nome;
            carregador.nif = TXT_Nif.Text;

            carregador.Atualizar(bd);
            LimparForm();
            AtualizarGrelha();

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
            TXT_Nif.ReadOnly = false;
        }

        private void BTN_cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
            TXT_Nif.ReadOnly = false;
        }

        private void BTN_apagar_Click(object sender, EventArgs e)
        {
            if (Nif_escolhido == "")
            {
                MessageBox.Show("Tem de selecionar um carregador primeiro. Clique com o botão esquerdo.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende eliminar o carregador selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cliente.ApagarCliente(Nif_escolhido, bd);
            }

            LimparForm();

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;

            AtualizarGrelha();

            AtualizarNrPaginas();
        }

        private void TXT_pesquisar_TextChanged(object sender, EventArgs e)
        {
            DGV_clientes.DataSource = Cliente.PesquisaPorNif(bd, TXT_pesquisar.Text);
        }

        private void DGV_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TXT_Nif.ReadOnly = true;


            BTN_apagar.Visible = true;
            BTN_editar.Visible = true;
            BTN_guardar.Visible = false;
            BTN_cancelar.Visible = true;

            int linha = DGV_clientes.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }

            int nCarregador = int.Parse(DGV_clientes.Rows[linha].Cells[0].Value.ToString());
            Cliente escolhido = new Cliente();
            escolhido.Procurar(nCarregador, bd);

            TXT_nome.Text = escolhido.nome;
            TXT_Nif.Text = escolhido.nif;

            Nif_escolhido = escolhido.nif;
        }
    }
}
