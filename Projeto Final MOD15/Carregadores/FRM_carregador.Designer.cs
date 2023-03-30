
namespace Projeto_Final_MOD15.Carregadores
{
    partial class FRM_carregador
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
            this.components = new System.ComponentModel.Container();
            this.LBL_nCarregador = new System.Windows.Forms.Label();
            this.TXT_nCarregador = new System.Windows.Forms.TextBox();
            this.DGV_carregadores = new System.Windows.Forms.DataGridView();
            this.BTN_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CMB_localidade = new System.Windows.Forms.ComboBox();
            this.CMB_empresa = new System.Windows.Forms.ComboBox();
            this.CB_estado = new System.Windows.Forms.CheckBox();
            this.TXT_preco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_latitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXT_longitude = new System.Windows.Forms.TextBox();
            this.BTN_apagar = new System.Windows.Forms.Button();
            this.BTN_editar = new System.Windows.Forms.Button();
            this.TXT_pesquisar = new System.Windows.Forms.TextBox();
            this.BTN_cancelar = new System.Windows.Forms.Button();
            this.BTN_mapa = new System.Windows.Forms.Button();
            this.CMB_pagina = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_carregadores)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_nCarregador
            // 
            this.LBL_nCarregador.AutoSize = true;
            this.LBL_nCarregador.Location = new System.Drawing.Point(12, 41);
            this.LBL_nCarregador.Name = "LBL_nCarregador";
            this.LBL_nCarregador.Size = new System.Drawing.Size(113, 13);
            this.LBL_nCarregador.TabIndex = 0;
            this.LBL_nCarregador.Text = "Número do carregador";
            // 
            // TXT_nCarregador
            // 
            this.TXT_nCarregador.Location = new System.Drawing.Point(131, 38);
            this.TXT_nCarregador.Name = "TXT_nCarregador";
            this.TXT_nCarregador.ReadOnly = true;
            this.TXT_nCarregador.Size = new System.Drawing.Size(121, 20);
            this.TXT_nCarregador.TabIndex = 0;
            // 
            // DGV_carregadores
            // 
            this.DGV_carregadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_carregadores.Location = new System.Drawing.Point(308, 71);
            this.DGV_carregadores.Name = "DGV_carregadores";
            this.DGV_carregadores.Size = new System.Drawing.Size(425, 296);
            this.DGV_carregadores.TabIndex = 13;
            this.DGV_carregadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_carregadores_CellClick);
            // 
            // BTN_guardar
            // 
            this.BTN_guardar.Location = new System.Drawing.Point(131, 344);
            this.BTN_guardar.Name = "BTN_guardar";
            this.BTN_guardar.Size = new System.Drawing.Size(75, 23);
            this.BTN_guardar.TabIndex = 8;
            this.BTN_guardar.Text = "Guardar";
            this.BTN_guardar.UseVisualStyleBackColor = true;
            this.BTN_guardar.Click += new System.EventHandler(this.BTN_guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Localidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Empresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Em utilização?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Preço por kWh";
            // 
            // CMB_localidade
            // 
            this.CMB_localidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_localidade.FormattingEnabled = true;
            this.CMB_localidade.Location = new System.Drawing.Point(131, 71);
            this.CMB_localidade.Name = "CMB_localidade";
            this.CMB_localidade.Size = new System.Drawing.Size(121, 21);
            this.CMB_localidade.TabIndex = 1;
            // 
            // CMB_empresa
            // 
            this.CMB_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_empresa.FormattingEnabled = true;
            this.CMB_empresa.Location = new System.Drawing.Point(131, 104);
            this.CMB_empresa.Name = "CMB_empresa";
            this.CMB_empresa.Size = new System.Drawing.Size(121, 21);
            this.CMB_empresa.TabIndex = 2;
            // 
            // CB_estado
            // 
            this.CB_estado.AutoSize = true;
            this.CB_estado.Location = new System.Drawing.Point(131, 140);
            this.CB_estado.Name = "CB_estado";
            this.CB_estado.Size = new System.Drawing.Size(15, 14);
            this.CB_estado.TabIndex = 3;
            this.CB_estado.UseVisualStyleBackColor = true;
            // 
            // TXT_preco
            // 
            this.TXT_preco.Location = new System.Drawing.Point(131, 170);
            this.TXT_preco.Name = "TXT_preco";
            this.TXT_preco.Size = new System.Drawing.Size(121, 20);
            this.TXT_preco.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude";
            // 
            // TXT_latitude
            // 
            this.TXT_latitude.Location = new System.Drawing.Point(131, 203);
            this.TXT_latitude.Name = "TXT_latitude";
            this.TXT_latitude.Size = new System.Drawing.Size(121, 20);
            this.TXT_latitude.TabIndex = 5;
            this.toolTip1.SetToolTip(this.TXT_latitude, "entre -9.92114 e -6.25616");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Longitude";
            // 
            // TXT_longitude
            // 
            this.TXT_longitude.Location = new System.Drawing.Point(131, 236);
            this.TXT_longitude.Name = "TXT_longitude";
            this.TXT_longitude.Size = new System.Drawing.Size(121, 20);
            this.TXT_longitude.TabIndex = 6;
            this.toolTip1.SetToolTip(this.TXT_longitude, "entre 36.58804 e 42.21245");
            // 
            // BTN_apagar
            // 
            this.BTN_apagar.Location = new System.Drawing.Point(308, 373);
            this.BTN_apagar.Name = "BTN_apagar";
            this.BTN_apagar.Size = new System.Drawing.Size(75, 23);
            this.BTN_apagar.TabIndex = 10;
            this.BTN_apagar.Text = "Apagar";
            this.BTN_apagar.UseVisualStyleBackColor = true;
            this.BTN_apagar.Click += new System.EventHandler(this.BTN_apagar_Click);
            // 
            // BTN_editar
            // 
            this.BTN_editar.Location = new System.Drawing.Point(389, 373);
            this.BTN_editar.Name = "BTN_editar";
            this.BTN_editar.Size = new System.Drawing.Size(75, 23);
            this.BTN_editar.TabIndex = 11;
            this.BTN_editar.Text = "Editar";
            this.BTN_editar.UseVisualStyleBackColor = true;
            this.BTN_editar.Click += new System.EventHandler(this.BTN_editar_Click);
            // 
            // TXT_pesquisar
            // 
            this.TXT_pesquisar.Location = new System.Drawing.Point(308, 38);
            this.TXT_pesquisar.Name = "TXT_pesquisar";
            this.TXT_pesquisar.Size = new System.Drawing.Size(425, 20);
            this.TXT_pesquisar.TabIndex = 9;
            this.TXT_pesquisar.TextChanged += new System.EventHandler(this.TXT_pesquisar_TextChanged);
            // 
            // BTN_cancelar
            // 
            this.BTN_cancelar.Location = new System.Drawing.Point(470, 373);
            this.BTN_cancelar.Name = "BTN_cancelar";
            this.BTN_cancelar.Size = new System.Drawing.Size(75, 23);
            this.BTN_cancelar.TabIndex = 12;
            this.BTN_cancelar.Text = "Cancelar";
            this.BTN_cancelar.UseVisualStyleBackColor = true;
            this.BTN_cancelar.Click += new System.EventHandler(this.BTN_cancelar_Click);
            // 
            // BTN_mapa
            // 
            this.BTN_mapa.Location = new System.Drawing.Point(131, 274);
            this.BTN_mapa.Name = "BTN_mapa";
            this.BTN_mapa.Size = new System.Drawing.Size(75, 23);
            this.BTN_mapa.TabIndex = 7;
            this.BTN_mapa.Text = "Mapa";
            this.BTN_mapa.UseVisualStyleBackColor = true;
            this.BTN_mapa.Click += new System.EventHandler(this.BTN_mapa_Click);
            // 
            // CMB_pagina
            // 
            this.CMB_pagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_pagina.FormattingEnabled = true;
            this.CMB_pagina.Location = new System.Drawing.Point(551, 375);
            this.CMB_pagina.Name = "CMB_pagina";
            this.CMB_pagina.Size = new System.Drawing.Size(143, 21);
            this.CMB_pagina.TabIndex = 14;
            this.CMB_pagina.SelectedIndexChanged += new System.EventHandler(this.CMB_pagina_SelectedIndexChanged);
            // 
            // FRM_carregador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.CMB_pagina);
            this.Controls.Add(this.BTN_cancelar);
            this.Controls.Add(this.BTN_editar);
            this.Controls.Add(this.BTN_apagar);
            this.Controls.Add(this.CB_estado);
            this.Controls.Add(this.CMB_empresa);
            this.Controls.Add(this.CMB_localidade);
            this.Controls.Add(this.BTN_mapa);
            this.Controls.Add(this.BTN_guardar);
            this.Controls.Add(this.DGV_carregadores);
            this.Controls.Add(this.TXT_longitude);
            this.Controls.Add(this.TXT_latitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXT_pesquisar);
            this.Controls.Add(this.TXT_preco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_nCarregador);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBL_nCarregador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_carregador";
            this.ShowIcon = false;
            this.Text = "Carregadores";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_carregadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_nCarregador;
        private System.Windows.Forms.TextBox TXT_nCarregador;
        private System.Windows.Forms.DataGridView DGV_carregadores;
        private System.Windows.Forms.Button BTN_guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMB_localidade;
        private System.Windows.Forms.ComboBox CMB_empresa;
        private System.Windows.Forms.CheckBox CB_estado;
        private System.Windows.Forms.TextBox TXT_preco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTN_apagar;
        private System.Windows.Forms.Button BTN_editar;
        private System.Windows.Forms.TextBox TXT_pesquisar;
        private System.Windows.Forms.Button BTN_cancelar;
        private System.Windows.Forms.Button BTN_mapa;
        private System.Windows.Forms.ComboBox CMB_pagina;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox TXT_latitude;
        internal System.Windows.Forms.TextBox TXT_longitude;
    }
}