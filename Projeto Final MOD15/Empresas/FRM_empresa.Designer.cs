
namespace Projeto_Final_MOD15.Empresas
{
    partial class FRM_empresa
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
            this.TXT_pesquisar = new System.Windows.Forms.TextBox();
            this.LB_empresas = new System.Windows.Forms.ListBox();
            this.TXT_nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_nEmpresa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTN_cancelar
            // 
            this.BTN_cancelar.Location = new System.Drawing.Point(477, 384);
            this.BTN_cancelar.Name = "BTN_cancelar";
            this.BTN_cancelar.Size = new System.Drawing.Size(75, 23);
            this.BTN_cancelar.TabIndex = 51;
            this.BTN_cancelar.Text = "Cancelar";
            this.BTN_cancelar.UseVisualStyleBackColor = true;
            this.BTN_cancelar.Click += new System.EventHandler(this.BTN_cancelar_Click);
            // 
            // BTN_editar
            // 
            this.BTN_editar.Location = new System.Drawing.Point(396, 384);
            this.BTN_editar.Name = "BTN_editar";
            this.BTN_editar.Size = new System.Drawing.Size(75, 23);
            this.BTN_editar.TabIndex = 50;
            this.BTN_editar.Text = "Editar";
            this.BTN_editar.UseVisualStyleBackColor = true;
            this.BTN_editar.Click += new System.EventHandler(this.BTN_editar_Click);
            // 
            // BTN_apagar
            // 
            this.BTN_apagar.Location = new System.Drawing.Point(315, 384);
            this.BTN_apagar.Name = "BTN_apagar";
            this.BTN_apagar.Size = new System.Drawing.Size(75, 23);
            this.BTN_apagar.TabIndex = 49;
            this.BTN_apagar.Text = "Apagar";
            this.BTN_apagar.UseVisualStyleBackColor = true;
            this.BTN_apagar.Click += new System.EventHandler(this.BTN_apagar_Click);
            // 
            // BTN_guardar
            // 
            this.BTN_guardar.Location = new System.Drawing.Point(190, 336);
            this.BTN_guardar.Name = "BTN_guardar";
            this.BTN_guardar.Size = new System.Drawing.Size(75, 23);
            this.BTN_guardar.TabIndex = 47;
            this.BTN_guardar.Text = "Guardar";
            this.BTN_guardar.UseVisualStyleBackColor = true;
            this.BTN_guardar.Click += new System.EventHandler(this.BTN_guardar_Click);
            // 
            // TXT_pesquisar
            // 
            this.TXT_pesquisar.Location = new System.Drawing.Point(315, 43);
            this.TXT_pesquisar.Name = "TXT_pesquisar";
            this.TXT_pesquisar.Size = new System.Drawing.Size(237, 20);
            this.TXT_pesquisar.TabIndex = 48;
            // 
            // LB_empresas
            // 
            this.LB_empresas.FormattingEnabled = true;
            this.LB_empresas.Location = new System.Drawing.Point(315, 82);
            this.LB_empresas.Name = "LB_empresas";
            this.LB_empresas.Size = new System.Drawing.Size(237, 277);
            this.LB_empresas.TabIndex = 53;
            this.LB_empresas.SelectedIndexChanged += new System.EventHandler(this.LB_empresas_SelectedIndexChanged);
            // 
            // TXT_nome
            // 
            this.TXT_nome.Location = new System.Drawing.Point(144, 118);
            this.TXT_nome.Name = "TXT_nome";
            this.TXT_nome.Size = new System.Drawing.Size(121, 20);
            this.TXT_nome.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nome da empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "ID da empresa";
            // 
            // TXT_nEmpresa
            // 
            this.TXT_nEmpresa.Location = new System.Drawing.Point(144, 82);
            this.TXT_nEmpresa.Name = "TXT_nEmpresa";
            this.TXT_nEmpresa.ReadOnly = true;
            this.TXT_nEmpresa.Size = new System.Drawing.Size(121, 20);
            this.TXT_nEmpresa.TabIndex = 55;
            // 
            // FRM_empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.TXT_nEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_empresas);
            this.Controls.Add(this.BTN_cancelar);
            this.Controls.Add(this.BTN_editar);
            this.Controls.Add(this.BTN_apagar);
            this.Controls.Add(this.BTN_guardar);
            this.Controls.Add(this.TXT_pesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_empresa";
            this.ShowIcon = false;
            this.Text = "Empresas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_cancelar;
        private System.Windows.Forms.Button BTN_editar;
        private System.Windows.Forms.Button BTN_apagar;
        private System.Windows.Forms.Button BTN_guardar;
        private System.Windows.Forms.TextBox TXT_pesquisar;
        private System.Windows.Forms.ListBox LB_empresas;
        private System.Windows.Forms.TextBox TXT_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_nEmpresa;
    }
}