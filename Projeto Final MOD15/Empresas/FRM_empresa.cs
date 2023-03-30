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

namespace Projeto_Final_MOD15.Empresas
{
    public partial class FRM_empresa : Form
    {
        BaseDados bd;
        public FRM_empresa(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarLBEmpresas();


            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
        }

        private void AtualizarLBEmpresas()
        {
            LB_empresas.Items.Clear();
            DataTable dados = Empresa.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Empresa empresa = new Empresa();
                empresa.nEmpresa = int.Parse(dr["nempresa"].ToString());
                empresa.nome = dr["nome"].ToString();
                LB_empresas.Items.Add(empresa);
            }
        }

        private void BTN_guardar_Click(object sender, EventArgs e)
        {
            if (TXT_nome.Text.Trim() == "")
            {
                MessageBox.Show("O nome não pode ser vazio.");
                TXT_nome.Focus();
                return;
            }

            Empresa empresa = new Empresa();

            empresa.nome = TXT_nome.Text.Trim();

            empresa.Guardar(bd);

            LimparForm();
            AtualizarLBEmpresas();
        }

        private void BTN_apagar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende eliminar a empresa selecionada?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Empresa.ApagarEmpresa(int.Parse(TXT_nEmpresa.Text),bd);
            }

            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;

            LimparForm();
            AtualizarLBEmpresas();
        }

        private void BTN_editar_Click(object sender, EventArgs e)
        {
            if (TXT_nome.Text.Trim() == "")
            {
                MessageBox.Show("O nome não pode ser vazio.");
                TXT_nome.Focus();
                return;
            }

            Empresa empresa = new Empresa();

            empresa.nome = TXT_nome.Text.Trim();
            empresa.nEmpresa = int.Parse(TXT_nEmpresa.Text);

            empresa.Atualizar(bd);

            LimparForm();
            AtualizarLBEmpresas();
            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
        }

        private void LimparForm()
        {
            TXT_nome.Text = "";
            TXT_nEmpresa.Text = "";
        }

        private void BTN_cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            BTN_apagar.Visible = false;
            BTN_editar.Visible = false;
            BTN_guardar.Visible = true;
            BTN_cancelar.Visible = false;
        }

        private void LB_empresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_empresas.SelectedItem != null)
            {
                BTN_apagar.Visible = true;
                BTN_editar.Visible = true;
                BTN_guardar.Visible = false;
                BTN_cancelar.Visible = true;

                Empresa linha = (Empresa)LB_empresas.SelectedItem;

                TXT_nome.Text = linha.nome;
                TXT_nEmpresa.Text = linha.nEmpresa.ToString();
            }
        }
    }
}
