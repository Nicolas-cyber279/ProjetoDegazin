namespace ProjetoDegazin
{
    partial class pagListaEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pagListaEstoque));
            this.dtGridTabela = new System.Windows.Forms.DataGridView();
            this.ColDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxPesquisa = new System.Windows.Forms.GroupBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTabela)).BeginInit();
            this.gBoxPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGridTabela
            // 
            this.dtGridTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDG,
            this.ColCodigo,
            this.ColDescricao,
            this.ColPreco,
            this.ColVendida});
            this.dtGridTabela.Location = new System.Drawing.Point(12, 88);
            this.dtGridTabela.Name = "dtGridTabela";
            this.dtGridTabela.Size = new System.Drawing.Size(639, 424);
            this.dtGridTabela.TabIndex = 0;
            this.dtGridTabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridTabela_CellContentClick);
            // 
            // ColDG
            // 
            this.ColDG.HeaderText = "DG";
            this.ColDG.Name = "ColDG";
            // 
            // ColCodigo
            // 
            this.ColCodigo.HeaderText = "Código Original";
            this.ColCodigo.Name = "ColCodigo";
            // 
            // ColDescricao
            // 
            this.ColDescricao.HeaderText = "Descrição";
            this.ColDescricao.Name = "ColDescricao";
            // 
            // ColPreco
            // 
            this.ColPreco.HeaderText = "Preço";
            this.ColPreco.Name = "ColPreco";
            // 
            // ColVendida
            // 
            this.ColVendida.HeaderText = "Vendida";
            this.ColVendida.Name = "ColVendida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estoque de peças";
            // 
            // gBoxPesquisa
            // 
            this.gBoxPesquisa.Controls.Add(this.txtPesquisa);
            this.gBoxPesquisa.Controls.Add(this.btnPesquisa);
            this.gBoxPesquisa.Location = new System.Drawing.Point(330, 13);
            this.gBoxPesquisa.Name = "gBoxPesquisa";
            this.gBoxPesquisa.Size = new System.Drawing.Size(321, 42);
            this.gBoxPesquisa.TabIndex = 2;
            this.gBoxPesquisa.TabStop = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(0, 15);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(223, 20);
            this.txtPesquisa.TabIndex = 5;
            this.txtPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisa_KeyPress);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPesquisa.ForeColor = System.Drawing.Color.White;
            this.btnPesquisa.Location = new System.Drawing.Point(229, 7);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(92, 35);
            this.btnPesquisa.TabIndex = 4;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.UseVisualStyleBackColor = false;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(12, 47);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(92, 35);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pagListaEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(663, 540);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.gBoxPesquisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridTabela);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pagListaEstoque";
            this.Text = "Degazin - Estoque";
            this.Load += new System.EventHandler(this.pagListaEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTabela)).EndInit();
            this.gBoxPesquisa.ResumeLayout(false);
            this.gBoxPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVendida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
    }
}