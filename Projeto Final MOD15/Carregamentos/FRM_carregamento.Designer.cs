
namespace Projeto_Final_MOD15.Carregamentos
{
    partial class FRM_carregamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_cancelar = new System.Windows.Forms.Button();
            this.BTN_editar = new System.Windows.Forms.Button();
            this.BTN_apagar = new System.Windows.Forms.Button();
            this.BTN_guardar = new System.Windows.Forms.Button();
            this.DGV_carregamento = new System.Windows.Forms.DataGridView();
            this.TXT_pesquisar = new System.Windows.Forms.TextBox();
            this.TXT_nCarregamento = new System.Windows.Forms.TextBox();
            this.LBL_nCarregamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTP_carregamento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_kWh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXT_preco = new System.Windows.Forms.TextBox();
            this.LBL_carregador_kWh = new System.Windows.Forms.Label();
            this.CMB_pagina = new System.Windows.Forms.ComboBox();
            this.CMB_carregador = new System.Windows.Forms.ComboBox();
            this.CMB_nif = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_carregamento)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_cancelar
            // 
            this.BTN_cancelar.Location = new System.Drawing.Point(508, 387);
            this.BTN_cancelar.Name = "BTN_cancelar";
            this.BTN_cancelar.Size = new System.Drawing.Size(75, 23);
            this.BTN_cancelar.TabIndex = 33;
            this.BTN_cancelar.Text = "Cancelar";
            this.BTN_cancelar.UseVisualStyleBackColor = true;
            // 
            // BTN_editar
            // 
            this.BTN_editar.Location = new System.Drawing.Point(427, 387);
            this.BTN_editar.Name = "BTN_editar";
            this.BTN_editar.Size = new System.Drawing.Size(75, 23);
            this.BTN_editar.TabIndex = 32;
            this.BTN_editar.Text = "Editar";
            this.BTN_editar.UseVisualStyleBackColor = true;
            this.BTN_editar.Click += new System.EventHandler(this.BTN_editar_Click);
            // 
            // BTN_apagar
            // 
            this.BTN_apagar.Location = new System.Drawing.Point(346, 387);
            this.BTN_apagar.Name = "BTN_apagar";
            this.BTN_apagar.Size = new System.Drawing.Size(75, 23);
            this.BTN_apagar.TabIndex = 31;
            this.BTN_apagar.Text = "Apagar";
            this.BTN_apagar.UseVisualStyleBackColor = true;
            this.BTN_apagar.Click += new System.EventHandler(this.BTN_apagar_Click);
            // 
            // BTN_guardar
            // 
            this.BTN_guardar.Location = new System.Drawing.Point(164, 349);
            this.BTN_guardar.Name = "BTN_guardar";
            this.BTN_guardar.Size = new System.Drawing.Size(75, 23);
            this.BTN_guardar.TabIndex = 29;
            this.BTN_guardar.Text = "Guardar";
            this.BTN_guardar.UseVisualStyleBackColor = true;
            this.BTN_guardar.Click += new System.EventHandler(this.BTN_guardar_Click);
            // 
            // DGV_carregamento
            // 
            this.DGV_carregamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_carregamento.Location = new System.Drawing.Point(346, 76);
            this.DGV_carregamento.Name = "DGV_carregamento";
            this.DGV_carregamento.Size = new System.Drawing.Size(415, 296);
            this.DGV_carregamento.TabIndex = 34;
            this.DGV_carregamento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_carregamento_CellClick);
            // 
            // TXT_pesquisar
            // 
            this.TXT_pesquisar.Location = new System.Drawing.Point(346, 43);
            this.TXT_pesquisar.Name = "TXT_pesquisar";
            this.TXT_pesquisar.Size = new System.Drawing.Size(415, 20);
            this.TXT_pesquisar.TabIndex = 30;
            // 
            // TXT_nCarregamento
            // 
            this.TXT_nCarregamento.Location = new System.Drawing.Point(146, 43);
            this.TXT_nCarregamento.Name = "TXT_nCarregamento";
            this.TXT_nCarregamento.ReadOnly = true;
            this.TXT_nCarregamento.Size = new System.Drawing.Size(121, 20);
            this.TXT_nCarregamento.TabIndex = 18;
            // 
            // LBL_nCarregamento
            // 
            this.LBL_nCarregamento.AutoSize = true;
            this.LBL_nCarregamento.Location = new System.Drawing.Point(12, 46);
            this.LBL_nCarregamento.Name = "LBL_nCarregamento";
            this.LBL_nCarregamento.Size = new System.Drawing.Size(127, 13);
            this.LBL_nCarregamento.TabIndex = 14;
            this.LBL_nCarregamento.Text = "Número do carregamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Número do carregador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nif cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Data do carregamento";
            // 
            // DTP_carregamento
            // 
            this.DTP_carregamento.Location = new System.Drawing.Point(146, 133);
            this.DTP_carregamento.Name = "DTP_carregamento";
            this.DTP_carregamento.Size = new System.Drawing.Size(121, 20);
            this.DTP_carregamento.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "KWh carregados";
            // 
            // TXT_kWh
            // 
            this.TXT_kWh.Location = new System.Drawing.Point(146, 167);
            this.TXT_kWh.Name = "TXT_kWh";
            this.TXT_kWh.Size = new System.Drawing.Size(121, 20);
            this.TXT_kWh.TabIndex = 18;
            this.TXT_kWh.TextChanged += new System.EventHandler(this.TXT_kWh_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Preço total";
            // 
            // TXT_preco
            // 
            this.TXT_preco.Location = new System.Drawing.Point(146, 198);
            this.TXT_preco.Name = "TXT_preco";
            this.TXT_preco.ReadOnly = true;
            this.TXT_preco.Size = new System.Drawing.Size(121, 20);
            this.TXT_preco.TabIndex = 18;
            // 
            // LBL_carregador_kWh
            // 
            this.LBL_carregador_kWh.AutoSize = true;
            this.LBL_carregador_kWh.Location = new System.Drawing.Point(273, 77);
            this.LBL_carregador_kWh.Name = "LBL_carregador_kWh";
            this.LBL_carregador_kWh.Size = new System.Drawing.Size(47, 13);
            this.LBL_carregador_kWh.TabIndex = 14;
            this.LBL_carregador_kWh.Text = "($/kWh)";
            // 
            // CMB_pagina
            // 
            this.CMB_pagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_pagina.FormattingEnabled = true;
            this.CMB_pagina.Location = new System.Drawing.Point(589, 389);
            this.CMB_pagina.Name = "CMB_pagina";
            this.CMB_pagina.Size = new System.Drawing.Size(143, 21);
            this.CMB_pagina.TabIndex = 36;
            // 
            // CMB_carregador
            // 
            this.CMB_carregador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_carregador.FormattingEnabled = true;
            this.CMB_carregador.Location = new System.Drawing.Point(146, 74);
            this.CMB_carregador.Name = "CMB_carregador";
            this.CMB_carregador.Size = new System.Drawing.Size(121, 21);
            this.CMB_carregador.TabIndex = 37;
            this.CMB_carregador.SelectedIndexChanged += new System.EventHandler(this.CMB_carregador_SelectedIndexChanged);
            // 
            // CMB_nif
            // 
            this.CMB_nif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_nif.FormattingEnabled = true;
            this.CMB_nif.Location = new System.Drawing.Point(146, 105);
            this.CMB_nif.Name = "CMB_nif";
            this.CMB_nif.Size = new System.Drawing.Size(121, 21);
            this.CMB_nif.TabIndex = 37;
            // 
            // FRM_carregamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CMB_nif);
            this.Controls.Add(this.CMB_carregador);
            this.Controls.Add(this.CMB_pagina);
            this.Controls.Add(this.DTP_carregamento);
            this.Controls.Add(this.BTN_cancelar);
            this.Controls.Add(this.BTN_editar);
            this.Controls.Add(this.BTN_apagar);
            this.Controls.Add(this.BTN_guardar);
            this.Controls.Add(this.DGV_carregamento);
            this.Controls.Add(this.TXT_pesquisar);
            this.Controls.Add(this.TXT_preco);
            this.Controls.Add(this.TXT_kWh);
            this.Controls.Add(this.LBL_carregador_kWh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_nCarregamento);
            this.Controls.Add(this.LBL_nCarregamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_carregamento";
            this.ShowIcon = false;
            this.Text = "Carregamentos";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_carregamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_cancelar;
        private System.Windows.Forms.Button BTN_editar;
        private System.Windows.Forms.Button BTN_apagar;
        private System.Windows.Forms.Button BTN_guardar;
        private System.Windows.Forms.DataGridView DGV_carregamento;
        private System.Windows.Forms.TextBox TXT_pesquisar;
        private System.Windows.Forms.TextBox TXT_nCarregamento;
        private System.Windows.Forms.Label LBL_nCarregamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTP_carregamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_kWh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXT_preco;
        private System.Windows.Forms.Label LBL_carregador_kWh;
        private System.Windows.Forms.ComboBox CMB_pagina;
        private System.Windows.Forms.ComboBox CMB_carregador;
        private System.Windows.Forms.ComboBox CMB_nif;
    }
}