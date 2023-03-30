
namespace Projeto_Final_MOD15.Carregadores
{
    partial class FRM_coordenadas
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
            this.WBB_maps = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_latitude = new System.Windows.Forms.Label();
            this.TXT_latAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_latitude = new System.Windows.Forms.TextBox();
            this.TXT_longAtual = new System.Windows.Forms.TextBox();
            this.LBL_longitude = new System.Windows.Forms.Label();
            this.TXT_longitude = new System.Windows.Forms.TextBox();
            this.BTN_cancelar = new System.Windows.Forms.Button();
            this.BTN_substituir = new System.Windows.Forms.Button();
            this.BTN_guardar = new System.Windows.Forms.Button();
            this.BTN_pesquisar = new System.Windows.Forms.Button();
            this.PNL_pesquisar = new System.Windows.Forms.Panel();
            this.LBL_pesquisar = new System.Windows.Forms.Label();
            this.PB_pesquisar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PNL_pesquisar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // WBB_maps
            // 
            this.WBB_maps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBB_maps.Location = new System.Drawing.Point(0, 0);
            this.WBB_maps.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBB_maps.Name = "WBB_maps";
            this.WBB_maps.Size = new System.Drawing.Size(530, 450);
            this.WBB_maps.TabIndex = 0;
            this.WBB_maps.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WBB_maps_Navigated);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.LBL_latitude);
            this.splitContainer1.Panel1.Controls.Add(this.TXT_latAtual);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TXT_latitude);
            this.splitContainer1.Panel1.Controls.Add(this.TXT_longAtual);
            this.splitContainer1.Panel1.Controls.Add(this.LBL_longitude);
            this.splitContainer1.Panel1.Controls.Add(this.TXT_longitude);
            this.splitContainer1.Panel1.Controls.Add(this.BTN_cancelar);
            this.splitContainer1.Panel1.Controls.Add(this.BTN_substituir);
            this.splitContainer1.Panel1.Controls.Add(this.BTN_guardar);
            this.splitContainer1.Panel1.Controls.Add(this.BTN_pesquisar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PNL_pesquisar);
            this.splitContainer1.Panel2.Controls.Add(this.WBB_maps);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitude atual";
            // 
            // LBL_latitude
            // 
            this.LBL_latitude.AutoSize = true;
            this.LBL_latitude.Location = new System.Drawing.Point(39, 239);
            this.LBL_latitude.Name = "LBL_latitude";
            this.LBL_latitude.Size = new System.Drawing.Size(45, 13);
            this.LBL_latitude.TabIndex = 4;
            this.LBL_latitude.Text = "Latitude";
            // 
            // TXT_latAtual
            // 
            this.TXT_latAtual.Location = new System.Drawing.Point(163, 25);
            this.TXT_latAtual.Name = "TXT_latAtual";
            this.TXT_latAtual.ReadOnly = true;
            this.TXT_latAtual.Size = new System.Drawing.Size(100, 20);
            this.TXT_latAtual.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Longitude atual";
            // 
            // TXT_latitude
            // 
            this.TXT_latitude.Location = new System.Drawing.Point(42, 255);
            this.TXT_latitude.Name = "TXT_latitude";
            this.TXT_latitude.Size = new System.Drawing.Size(100, 20);
            this.TXT_latitude.TabIndex = 0;
            this.toolTip1.SetToolTip(this.TXT_latitude, "entre -9.92114 e -6.25616");
            // 
            // TXT_longAtual
            // 
            this.TXT_longAtual.Location = new System.Drawing.Point(163, 75);
            this.TXT_longAtual.Name = "TXT_longAtual";
            this.TXT_longAtual.ReadOnly = true;
            this.TXT_longAtual.Size = new System.Drawing.Size(100, 20);
            this.TXT_longAtual.TabIndex = 4;
            // 
            // LBL_longitude
            // 
            this.LBL_longitude.AutoSize = true;
            this.LBL_longitude.Location = new System.Drawing.Point(39, 289);
            this.LBL_longitude.Name = "LBL_longitude";
            this.LBL_longitude.Size = new System.Drawing.Size(54, 13);
            this.LBL_longitude.TabIndex = 2;
            this.LBL_longitude.Text = "Longitude";
            // 
            // TXT_longitude
            // 
            this.TXT_longitude.Location = new System.Drawing.Point(42, 305);
            this.TXT_longitude.Name = "TXT_longitude";
            this.TXT_longitude.Size = new System.Drawing.Size(100, 20);
            this.TXT_longitude.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TXT_longitude, "entre 36.58804 e 42.21245");
            // 
            // BTN_cancelar
            // 
            this.BTN_cancelar.Location = new System.Drawing.Point(151, 415);
            this.BTN_cancelar.Name = "BTN_cancelar";
            this.BTN_cancelar.Size = new System.Drawing.Size(75, 23);
            this.BTN_cancelar.TabIndex = 5;
            this.BTN_cancelar.Text = "Cancelar";
            this.BTN_cancelar.UseVisualStyleBackColor = true;
            this.BTN_cancelar.Click += new System.EventHandler(this.BTN_cancelar_Click);
            // 
            // BTN_substituir
            // 
            this.BTN_substituir.Location = new System.Drawing.Point(163, 126);
            this.BTN_substituir.Name = "BTN_substituir";
            this.BTN_substituir.Size = new System.Drawing.Size(75, 23);
            this.BTN_substituir.TabIndex = 3;
            this.BTN_substituir.Text = "Substituir";
            this.BTN_substituir.UseVisualStyleBackColor = true;
            this.BTN_substituir.Click += new System.EventHandler(this.BTN_substituir_Click);
            // 
            // BTN_guardar
            // 
            this.BTN_guardar.Location = new System.Drawing.Point(42, 415);
            this.BTN_guardar.Name = "BTN_guardar";
            this.BTN_guardar.Size = new System.Drawing.Size(75, 23);
            this.BTN_guardar.TabIndex = 4;
            this.BTN_guardar.Text = "Guardar";
            this.BTN_guardar.UseVisualStyleBackColor = true;
            this.BTN_guardar.Click += new System.EventHandler(this.BTN_guardar_Click);
            // 
            // BTN_pesquisar
            // 
            this.BTN_pesquisar.Location = new System.Drawing.Point(42, 348);
            this.BTN_pesquisar.Name = "BTN_pesquisar";
            this.BTN_pesquisar.Size = new System.Drawing.Size(75, 23);
            this.BTN_pesquisar.TabIndex = 2;
            this.BTN_pesquisar.Text = "GO!";
            this.BTN_pesquisar.UseVisualStyleBackColor = true;
            this.BTN_pesquisar.Click += new System.EventHandler(this.BTN_pesquisar_Click);
            // 
            // PNL_pesquisar
            // 
            this.PNL_pesquisar.Controls.Add(this.LBL_pesquisar);
            this.PNL_pesquisar.Controls.Add(this.PB_pesquisar);
            this.PNL_pesquisar.Location = new System.Drawing.Point(67, 59);
            this.PNL_pesquisar.Name = "PNL_pesquisar";
            this.PNL_pesquisar.Size = new System.Drawing.Size(269, 262);
            this.PNL_pesquisar.TabIndex = 1;
            // 
            // LBL_pesquisar
            // 
            this.LBL_pesquisar.AutoSize = true;
            this.LBL_pesquisar.BackColor = System.Drawing.Color.Transparent;
            this.LBL_pesquisar.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_pesquisar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LBL_pesquisar.Location = new System.Drawing.Point(36, 13);
            this.LBL_pesquisar.Name = "LBL_pesquisar";
            this.LBL_pesquisar.Size = new System.Drawing.Size(197, 42);
            this.LBL_pesquisar.TabIndex = 1;
            this.LBL_pesquisar.Text = "Carregue no botão \"GO!\" \r\npara pesquisar";
            // 
            // PB_pesquisar
            // 
            this.PB_pesquisar.Image = global::Projeto_Final_MOD15.Properties.Resources.cat_2;
            this.PB_pesquisar.Location = new System.Drawing.Point(39, 67);
            this.PB_pesquisar.Name = "PB_pesquisar";
            this.PB_pesquisar.Size = new System.Drawing.Size(194, 192);
            this.PB_pesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_pesquisar.TabIndex = 0;
            this.PB_pesquisar.TabStop = false;
            this.PB_pesquisar.MouseEnter += new System.EventHandler(this.PB_pesquisar_MouseEnter);
            // 
            // FRM_coordenadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FRM_coordenadas";
            this.ShowIcon = false;
            this.Text = "Coordenadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_coordenadas_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PNL_pesquisar.ResumeLayout(false);
            this.PNL_pesquisar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_pesquisar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WBB_maps;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBL_latitude;
        private System.Windows.Forms.TextBox TXT_latAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_latitude;
        private System.Windows.Forms.TextBox TXT_longAtual;
        private System.Windows.Forms.Label LBL_longitude;
        private System.Windows.Forms.TextBox TXT_longitude;
        private System.Windows.Forms.Button BTN_pesquisar;
        private System.Windows.Forms.Panel PNL_pesquisar;
        private System.Windows.Forms.PictureBox PB_pesquisar;
        private System.Windows.Forms.Label LBL_pesquisar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BTN_guardar;
        private System.Windows.Forms.Button BTN_cancelar;
        private System.Windows.Forms.Button BTN_substituir;
    }
}