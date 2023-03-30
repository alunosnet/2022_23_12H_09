using M15_TrabalhoModelo_2022_23;
using Projeto_Final_MOD15.Carregadores;
using Projeto_Final_MOD15.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_MOD15.Carregamentos
{
    public partial class FRM_carregamento : Form
    {
        BaseDados bd;
        int nCarregamento_escolhido;
        int NrRegistosPorPagina = 5;
        int nrlinhas, nrpagina;
        public FRM_carregamento(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarGrelha();
            AtualizarNrPaginas();

            AtualizarCMB_carregador();
            AtualizarCMB_nif();
        }

        private void AtualizarCMB_nif()
        {
            CMB_nif.Items.Clear();
            DataTable dados = Cliente.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.nif = dr["nif"].ToString();
                cliente.nome = dr["nome"].ToString();
                CMB_nif.Items.Add(cliente);
            }

            if (!(CMB_nif.Items.Count == 0))
            {
                CMB_nif.SelectedIndex = 0;
            }
        }

        private void AtualizarCMB_carregador()
        {
            CMB_carregador.Items.Clear();
            DataTable dados = Carregador.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Carregador carregador = new Carregador();
                carregador.nCarregador = int.Parse(dr["nCarregador"].ToString());
                carregador.localidade = dr["localidade"].ToString();
                carregador.preco_por_kWh = float.Parse(dr[4].ToString());
                CMB_carregador.Items.Add(carregador);
            }

            if (!(CMB_carregador.Items.Count == 0))
            {
                CMB_carregador.SelectedIndex = 0;
            }
        }

        private void BTN_guardar_Click(object sender, EventArgs e)
        {

            //Validar os dados
            if (CMB_carregador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um carregador.");
                CMB_carregador.Focus();
                return;
            }
            if (CMB_nif.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um nif.");
                CMB_nif.Focus();
                return;
            }

            DateTime data_carregamento = DTP_carregamento.Value;
            if (data_carregamento > DateTime.Now)
            {
                MessageBox.Show("A data do carregamento tem de ser inferior ou igual à data atual");
                DTP_carregamento.Focus();
                return;
            }

            float kWh;
            if (float.TryParse(TXT_kWh.Text.Replace(".", ","), out kWh) == false)
            {
                MessageBox.Show("Os kWh carregados têm de ser entre 0 e 100.");
                TXT_preco.Focus();
                return;
            }
            if (kWh <= 0 || kWh > (float)100)
            {
                MessageBox.Show("Os kWh carregados têm de ser entre 0 e 100.");
                TXT_preco.Focus();
                return;
            }

            Carregamento carregamento = new Carregamento();

            Carregador carregador = CMB_carregador.SelectedItem as Carregador;
            Cliente cliente = CMB_nif.SelectedItem as Cliente;

            carregamento.nCarregador = carregador.nCarregador;
            carregamento.nif = cliente.nif;
            carregamento.data_carregamento = data_carregamento;
            carregamento.kWh = kWh;
            carregamento.precoTotal = float.Parse(TXT_preco.Text);

            //Guardar na BD
            carregamento.Guardar(bd);

            //Limar o form
            LimparForm();
            AtualizarGrelha();
            AtualizarNrPaginas();
        }

        private void LimparForm()
        {
            TXT_nCarregamento.Text = "";
            CMB_carregador.Text = "";
            CMB_nif.Text = "";
            DTP_carregamento.Value = DateTime.Now;
            TXT_kWh.Text = "";
            TXT_preco.Text = "";
            AtualizarGrelha();
        }

        private void AtualizarGrelha()
        {
            DGV_carregamento.AllowUserToAddRows = false;
            DGV_carregamento.AllowUserToDeleteRows = false;
            DGV_carregamento.ReadOnly = true;
            DGV_carregamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_carregamento.MultiSelect = false;

            if (CMB_pagina.SelectedIndex == -1)
                DGV_carregamento.DataSource = Carregamento.ListarTodos(bd);
            else
            {
                //paginação
                int nrpagina = CMB_pagina.SelectedIndex + 1;
                int primeiroRegisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoRegisto = primeiroRegisto + NrRegistosPorPagina - 1;
                DGV_carregamento.DataSource = Carregamento.ListarTodos(bd, primeiroRegisto, ultimoRegisto);
            }
        }

        private void DGV_carregamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            BTN_apagar.Visible = true;
            BTN_editar.Visible = true;
            BTN_guardar.Visible = false;
            BTN_cancelar.Visible = true;

            int linha = DGV_carregamento.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }

            int nCarregamento = int.Parse(DGV_carregamento.Rows[linha].Cells[0].Value.ToString());
            Carregamento escolhido = new Carregamento();
            escolhido.Procurar(nCarregamento, bd);

            foreach (Carregador carregador in CMB_carregador.Items)
            {
                if (carregador.nCarregador == escolhido.nCarregador)
                {
                    CMB_carregador.SelectedItem = carregador;
                }
            }

            foreach (Cliente cliente in CMB_nif.Items)
            {
                if (cliente.nif == escolhido.nif)
                {
                    CMB_nif.SelectedItem = cliente;
                }
            }

            nCarregamento_escolhido = escolhido.nCarregamento;
        }

        private void CMB_carregador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carregador carregador = CMB_carregador.SelectedItem as Carregador;
            string preco = String.Format("{0:0.00}", carregador.preco_por_kWh);
            LBL_carregador_kWh.Text = "("+ preco +"/kWh)";

            AtualizarPreco(float.Parse(preco));
        }

        private void TXT_kWh_TextChanged(object sender, EventArgs e)
        {
            Carregador carregador = CMB_carregador.SelectedItem as Carregador;
            AtualizarPreco(carregador.preco_por_kWh);
        }

        private void AtualizarPreco(float precokWh)
        {
            if (TXT_kWh.Text != "" && CMB_carregador.SelectedIndex !=-1)
            {
                TXT_preco.Text = (float.Parse(TXT_kWh.Text) * precokWh).ToString();
            }
        }

        private void BTN_editar_Click(object sender, EventArgs e)
        {

            //Validar os dados
            if (CMB_carregador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um carregador.");
                CMB_carregador.Focus();
                return;
            }
            if (CMB_nif.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um nif.");
                CMB_nif.Focus();
                return;
            }

            DateTime data_carregamento = DTP_carregamento.Value;
            if (data_carregamento > DateTime.Now)
            {
                MessageBox.Show("A data do carregamento tem de ser inferior ou igual à data atual");
                DTP_carregamento.Focus();
                return;
            }

            float kWh;
            if (float.TryParse(TXT_kWh.Text.Replace(".", ","), out kWh) == false)
            {
                MessageBox.Show("Os kWh carregados têm de ser entre 0 e 100.");
                TXT_preco.Focus();
                return;
            }
            if (kWh <= 0 || kWh > (float)100)
            {
                MessageBox.Show("Os kWh carregados têm de ser entre 0 e 100.");
                TXT_preco.Focus();
                return;
            }

            Carregamento carregamento = new Carregamento();

            Carregador carregador = CMB_carregador.SelectedItem as Carregador;
            Cliente cliente = CMB_nif.SelectedItem as Cliente;

            carregamento.nCarregador = carregador.nCarregador;
            carregamento.nif = cliente.nif;
            carregamento.data_carregamento = data_carregamento;
            carregamento.kWh = kWh;
            carregamento.precoTotal = float.Parse(TXT_preco.Text);

            carregamento.Atualizar(bd);
            LimparForm();
            AtualizarGrelha();

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
        }

        private void BTN_apagar_Click(object sender, EventArgs e)
        {
            if (nCarregamento_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um carregador primeiro. Clique com o botão esquerdo.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende eliminar o carregador selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Carregamento.ApagarCarregamento(nCarregamento_escolhido, bd);
            }

            LimparForm();

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;

            AtualizarGrelha();

            AtualizarNrPaginas();
        }

        void AtualizarNrPaginas()
        {
            CMB_pagina.Items.Clear();
            int nrlivros = Carregamento.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nrlivros / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                CMB_pagina.Items.Add(i);

            if (CMB_pagina.Items.Count == 0)
            {
                CMB_pagina.Items.Add(1);
            }
            CMB_pagina.SelectedIndex = 0;
        }
    }
}
