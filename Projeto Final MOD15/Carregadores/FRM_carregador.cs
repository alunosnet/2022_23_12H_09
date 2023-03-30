using M15_TrabalhoModelo_2022_23;
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

namespace Projeto_Final_MOD15.Carregadores
{
    public partial class FRM_carregador : Form
    {
        BaseDados bd;
        int nCarregador_escolhido;
        int NrRegistosPorPagina = 5;
        int nrlinhas, nrpagina;
        public FRM_carregador(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            CMB_localidade.DataSource = BaseDados.Localidades;

            AtualizaCMBempresa();
            AtualizarGrelha();
            AtualizarNrPaginas();
        }

        private void AtualizaCMBempresa()
        {
            CMB_empresa.Items.Clear();
            DataTable dados = Empresa.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Empresa empresa = new Empresa();
                empresa.nEmpresa = int.Parse(dr["nEmpresa"].ToString());
                empresa.nome = dr["nome"].ToString();
                CMB_empresa.Items.Add(empresa);
            }

            if (!(CMB_empresa.Items.Count == 0))
            {
                CMB_empresa.SelectedIndex = 0;
            }
        }

        private void BTN_mapa_Click(object sender, EventArgs e)
        {
            FRM_coordenadas F_Coordenadas = new FRM_coordenadas();
            F_Coordenadas.pesquisa(TXT_latitude.Text, TXT_longitude.Text);
            var resultado = F_Coordenadas.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                TXT_latitude.Text = F_Coordenadas.Latitude;
                TXT_longitude.Text = F_Coordenadas.Longitude;
            }
            
        }

        private void BTN_guardar_Click(object sender, EventArgs e)
        {

            //Validar os dados
            if (CMB_localidade.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma localidade.");
                CMB_localidade.Focus();
                return;
            }
            if (CMB_empresa.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma empresa.");
                CMB_empresa.Focus();
                return;
            }

            float preco;
            if (float.TryParse(TXT_preco.Text.Replace(".", ","), out preco) == false)
            {
                MessageBox.Show("O preço por kWh tem de ser superior a 0 e inferior a 100.");
                TXT_preco.Focus();
                return;
            }
            if (preco <= 0 || preco > (float)99.99)
            {
                MessageBox.Show("O preço por kWh tem de ser superior a 0 e inferior a 100.");
                TXT_preco.Focus();
                return;
            }

            string latitude, longitude;
            latitude = TXT_latitude.Text;
            if (!float.TryParse(latitude.Replace(".", ","), out float temp_lat))
            {
                MessageBox.Show("A latitude só pode conter números.");
                TXT_preco.Focus();
                return;
            }
            if (-9.92114 > temp_lat || temp_lat > -6.25616)
            {
                MessageBox.Show("A latitude tem de ser entre -9.92114 e -6.25616.");
                TXT_preco.Focus();
                return;
            }

            longitude = TXT_longitude.Text;
            if (!float.TryParse(longitude.Replace(".", ","), out float temp_long))
            {
                MessageBox.Show("A longitude só pode conter números.");
                TXT_preco.Focus();
                return;
            }
            if (36.58804 > temp_long || temp_long > 42.21245)
            {
                MessageBox.Show("A longitude tem de ser entre 36.58804 e 42.21245.");
                TXT_preco.Focus();
                return;
            }

            Carregador carregador = new Carregador();

            Empresa empresa = CMB_empresa.SelectedItem as Empresa;

            carregador.localidade = CMB_localidade.Text;
            carregador.nEmpresa = empresa.nEmpresa;
            carregador.estado = CB_estado.Checked;
            carregador.preco_por_kWh = preco;
            carregador.latitude = TXT_latitude.Text.Trim();
            carregador.longitude = TXT_longitude.Text.Trim();
            //TODO:ACABAR O GUARDAR

            //Guardar na BD
            carregador.Guardar(bd);

            //Limar o form
            LimparForm();
            AtualizarGrelha();
            AtualizarNrPaginas();
        }

        void AtualizarNrPaginas()
        {
            CMB_pagina.Items.Clear();
            int nrlivros = Carregador.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nrlivros / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                CMB_pagina.Items.Add(i);

            if (CMB_pagina.Items.Count == 0)
            {
                CMB_pagina.Items.Add(1);
            }
            CMB_pagina.SelectedIndex = 0;
        }

        private void LimparForm()
        {
            TXT_nCarregador.Text = "";
            TXT_preco.Text = "";
            TXT_latitude.Text = "";
            TXT_longitude.Text = "";
            CMB_localidade.SelectedIndex = 0;
            CB_estado.Checked = false;
            AtualizarGrelha();
        }

        void AtualizarGrelha()
        {
            DGV_carregadores.AllowUserToAddRows = false;
            DGV_carregadores.AllowUserToDeleteRows = false;
            DGV_carregadores.ReadOnly = true;
            DGV_carregadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_carregadores.MultiSelect = false;

            if (CMB_pagina.SelectedIndex == -1)
                DGV_carregadores.DataSource = Carregador.ListarTodos(bd);
            else
            {
                //paginação
                int nrpagina = CMB_pagina.SelectedIndex + 1;
                int primeiroRegisto = (nrpagina - 1) * NrRegistosPorPagina + 1; //1
                int ultimoRegisto = primeiroRegisto + NrRegistosPorPagina - 1;
                DGV_carregadores.DataSource = Carregador.ListarTodos(bd, primeiroRegisto, ultimoRegisto);
            }

        }

        private void CMB_pagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelha();
        }

        private void TXT_pesquisar_TextChanged(object sender, EventArgs e)
        {
            DGV_carregadores.DataSource = Carregador.PesquisaPorLocalidade(bd, TXT_pesquisar.Text);
        }

        private void BTN_cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
        }

        private void BTN_editar_Click(object sender, EventArgs e)
        {
            if (CMB_localidade.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma localidade.");
                CMB_localidade.Focus();
                return;
            }
            if (CMB_empresa.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma empresa.");
                CMB_empresa.Focus();
                return;
            }

            float preco;
            if (float.TryParse(TXT_preco.Text.Replace(".", ","), out preco) == false)
            {
                MessageBox.Show("O preço por kWh tem de ser superior a 0 e inferior a 100.");
                TXT_preco.Focus();
                return;
            }
            if (preco <= 0 || preco > (float)99.99)
            {
                MessageBox.Show("O preço por kWh tem de ser superior a 0 e inferior a 100.");
                TXT_preco.Focus();
                return;
            }

            string latitude, longitude;
            latitude = TXT_latitude.Text;
            if (!float.TryParse(latitude.Replace(".", ","), out float temp_lat))
            {
                MessageBox.Show("A latitude só pode conter números.");
                TXT_preco.Focus();
                return;
            }
            if (-9.92114 > temp_lat || temp_lat > -6.25616)
            {
                MessageBox.Show("A latitude tem de ser entre -9.92114 e -6.25616.");
                TXT_preco.Focus();
                return;
            }

            longitude = TXT_longitude.Text;
            if (!float.TryParse(longitude.Replace(".", ","), out float temp_long))
            {
                MessageBox.Show("A longitude só pode conter números.");
                TXT_preco.Focus();
                return;
            }
            if (36.58804 > temp_long || temp_long > 42.21245)
            {
                MessageBox.Show("A longitude tem de ser entre 36.58804 e 42.21245.");
                TXT_preco.Focus();
                return;
            }

            Carregador carregador = new Carregador();

            Empresa empresa = CMB_empresa.SelectedItem as Empresa;

            carregador.nCarregador = nCarregador_escolhido;
            carregador.localidade = CMB_localidade.Text;
            carregador.nEmpresa = empresa.nEmpresa;
            carregador.estado = CB_estado.Checked;
            carregador.preco_por_kWh = preco;
            carregador.latitude = TXT_latitude.Text.Trim();
            carregador.longitude = TXT_longitude.Text.Trim();

            carregador.Atualizar(bd);
            LimparForm();
            AtualizarGrelha();
        }

        private void BTN_apagar_Click(object sender, EventArgs e)
        {
            if (nCarregador_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um carregador primeiro. Clique com o botão esquerdo.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende eliminar o carregador selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Carregador.ApagarCarregador(nCarregador_escolhido, bd);
            }

            LimparForm();

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;

            AtualizarGrelha();

            AtualizarNrPaginas();
        }

        private void DGV_carregadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BTN_apagar.Visible = true;
            BTN_editar.Visible = true;
            BTN_guardar.Visible = false;
            BTN_cancelar.Visible = true;

            int linha = DGV_carregadores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }

            int nCarregador = int.Parse(DGV_carregadores.Rows[linha].Cells[0].Value.ToString());
            Carregador escolhido = new Carregador();
            escolhido.Procurar(nCarregador, bd);

            foreach (Empresa empresa in CMB_empresa.Items)
            {
                if (empresa.nEmpresa == escolhido.nEmpresa)
                {
                    CMB_empresa.SelectedItem = empresa;
                }
            }

         
            CB_estado.Checked = escolhido.estado;
            TXT_preco.Text = escolhido.preco_por_kWh.ToString();
            TXT_latitude.Text = escolhido.latitude;
            TXT_longitude.Text = escolhido.longitude;

            nCarregador_escolhido = escolhido.nCarregador;
        }

        
    }
}
