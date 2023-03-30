
namespace Projeto_Final_MOD15.Clientes
{
    partial class FRM_cliente
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
            this.DGV_clientes = new System.Windows.Forms.DataGridView();
            this.TXT_pesquisar = new System.Windows.Forms.TextBox();
            this.TXT_Nif = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_nif = new System.Windows.Forms.Label();
            this.TXT_nome = new System.Windows.Forms.TextBox();
            this.CMB_pagina = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_cancelar
            // 
            this.BTN_cancelar.Location = new System.Drawing.Point(498, 408);
            this.BTN_cancelar.Name = "BTN_cancelar";
            this.BTN_cancelar.Size = new System.Drawing.Size(75, 23);
            this.BTN_cancelar.TabIndex = 33;
            this.BTN_cancelar.Text = "Cancelar";
            this.BTN_cancelar.UseVisualStyleBackColor = true;
            this.BTN_cancelar.Click += new System.EventHandler(this.BTN_cancelar_Click);
            // 
            // BTN_editar
            // 
            this.BTN_editar.Location = new System.Drawing.Point(417, 408);
            this.BTN_editar.Name = "BTN_editar";
            this.BTN_editar.Size = new System.Drawing.Size(75, 23);
            this.BTN_editar.TabIndex = 32;
            this.BTN_editar.Text = "Editar";
            this.BTN_editar.UseVisualStyleBackColor = true;
            this.BTN_editar.Click += new System.EventHandler(this.BTN_editar_Click);
            // 
            // BTN_apagar
            // 
            this.BTN_apagar.Location = new System.Drawing.Point(336, 408);
            this.BTN_apagar.Name = "BTN_apagar";
            this.BTN_apagar.Size = new System.Drawing.Size(75, 23);
            this.BTN_apagar.TabIndex = 31;
            this.BTN_apagar.Text = "Apagar";
            this.BTN_apagar.UseVisualStyleBackColor = true;
            this.BTN_apagar.Click += new System.EventHandler(this.BTN_apagar_Click);
            // 
            // BTN_guardar
            // 
            this.BTN_guardar.Location = new System.Drawing.Point(205, 352);
            this.BTN_guardar.Name = "BTN_guardar";
            this.BTN_guardar.Size = new System.Drawing.Size(75, 23);
            this.BTN_guardar.TabIndex = 29;
            this.BTN_guardar.Text = "Guardar";
            this.BTN_guardar.UseVisualStyleBackColor = true;
            this.BTN_guardar.Click += new System.EventHandler(this.BTN_guardar_Click);
            // 
            // DGV_clientes
            // 
            this.DGV_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_clientes.Location = new System.Drawing.Point(336, 79);
            this.DGV_clientes.Name = "DGV_clientes";
            this.DGV_clientes.Size = new System.Drawing.Size(283, 296);
            this.DGV_clientes.TabIndex = 34;
            this.DGV_clientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_clientes_CellClick);
            // 
            // TXT_pesquisar
            // 
            this.TXT_pesquisar.Location = new System.Drawing.Point(336, 46);
            this.TXT_pesquisar.Name = "TXT_pesquisar";
            this.TXT_pesquisar.Size = new System.Drawing.Size(283, 20);
            this.TXT_pesquisar.TabIndex = 30;
            this.TXT_pesquisar.TextChanged += new System.EventHandler(this.TXT_pesquisar_TextChanged);
            // 
            // TXT_Nif
            // 
            this.TXT_Nif.Location = new System.Drawing.Point(53, 46);
            this.TXT_Nif.Name = "TXT_Nif";
            this.TXT_Nif.Size = new System.Drawing.Size(227, 20);
            this.TXT_Nif.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nome";
            // 
            // LBL_nif
            // 
            this.LBL_nif.AutoSize = true;
            this.LBL_nif.Location = new System.Drawing.Point(27, 49);
            this.LBL_nif.Name = "LBL_nif";
            this.LBL_nif.Size = new System.Drawing.Size(20, 13);
            this.LBL_nif.TabIndex = 14;
            this.LBL_nif.Text = "Nif";
            // 
            // TXT_nome
            // 
            this.TXT_nome.Location = new System.Drawing.Point(53, 79);
            this.TXT_nome.Name = "TXT_nome";
            this.TXT_nome.Size = new System.Drawing.Size(227, 20);
            this.TXT_nome.TabIndex = 25;
            // 
            // CMB_pagina
            // 
            this.CMB_pagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_pagina.FormattingEnabled = true;
            this.CMB_pagina.Location = new System.Drawing.Point(336, 381);
            this.CMB_pagina.Name = "CMB_pagina";
            this.CMB_pagina.Size = new System.Drawing.Size(143, 21);
            this.CMB_pagina.TabIndex = 35;
            // 
            // FRM_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 450);
            this.Controls.Add(this.CMB_pagina);
            this.Controls.Add(this.BTN_cancelar);
            this.Controls.Add(this.BTN_editar);
            this.Controls.Add(this.BTN_apagar);
            this.Controls.Add(this.BTN_guardar);
            this.Controls.Add(this.DGV_clientes);
            this.Controls.Add(this.TXT_pesquisar);
            this.Controls.Add(this.TXT_nome);
            this.Controls.Add(this.TXT_Nif);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBL_nif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_cliente";
            this.ShowIcon = false;
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_cancelar;
        private System.Windows.Forms.Button BTN_editar;
        private System.Windows.Forms.Button BTN_apagar;
        private System.Windows.Forms.Button BTN_guardar;
        private System.Windows.Forms.DataGridView DGV_clientes;
        private System.Windows.Forms.TextBox TXT_pesquisar;
        private System.Windows.Forms.TextBox TXT_Nif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBL_nif;
        private System.Windows.Forms.TextBox TXT_nome;
        private System.Windows.Forms.ComboBox CMB_pagina;
    }
}