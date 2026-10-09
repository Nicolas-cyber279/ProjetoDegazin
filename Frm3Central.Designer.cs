namespace ProjetoDegazin
{
    partial class pagCentral
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pagCentral));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadRevendedora = new System.Windows.Forms.Button();
            this.btnAtendimento = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnAcerto = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seja Bem-Vindo(a) ao sistema Degazin!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCadRevendedora
            // 
            this.btnCadRevendedora.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnCadRevendedora.ForeColor = System.Drawing.Color.White;
            this.btnCadRevendedora.Location = new System.Drawing.Point(12, 120);
            this.btnCadRevendedora.Name = "btnCadRevendedora";
            this.btnCadRevendedora.Size = new System.Drawing.Size(135, 59);
            this.btnCadRevendedora.TabIndex = 0;
            this.btnCadRevendedora.Text = "Cadastrar revendedora";
            this.btnCadRevendedora.UseVisualStyleBackColor = false;
            this.btnCadRevendedora.Click += new System.EventHandler(this.btnCadRevendedora_Click);
            // 
            // btnAtendimento
            // 
            this.btnAtendimento.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAtendimento.ForeColor = System.Drawing.Color.White;
            this.btnAtendimento.Location = new System.Drawing.Point(12, 211);
            this.btnAtendimento.Name = "btnAtendimento";
            this.btnAtendimento.Size = new System.Drawing.Size(436, 50);
            this.btnAtendimento.TabIndex = 3;
            this.btnAtendimento.Text = "Realizar atendimento";
            this.btnAtendimento.UseVisualStyleBackColor = false;
            this.btnAtendimento.Click += new System.EventHandler(this.btnAtendimento_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnEstoque.ForeColor = System.Drawing.Color.White;
            this.btnEstoque.Location = new System.Drawing.Point(162, 120);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(135, 59);
            this.btnEstoque.TabIndex = 1;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnAcerto
            // 
            this.btnAcerto.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAcerto.ForeColor = System.Drawing.Color.White;
            this.btnAcerto.Location = new System.Drawing.Point(313, 120);
            this.btnAcerto.Name = "btnAcerto";
            this.btnAcerto.Size = new System.Drawing.Size(135, 59);
            this.btnAcerto.TabIndex = 2;
            this.btnAcerto.Text = "Registrar Acerto";
            this.btnAcerto.UseVisualStyleBackColor = false;
            this.btnAcerto.Click += new System.EventHandler(this.btnAcerto_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(162, 336);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(135, 54);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pagCentral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(460, 477);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAcerto);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnAtendimento);
            this.Controls.Add(this.btnCadRevendedora);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "pagCentral";
            this.Text = "Degazin - Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadRevendedora;
        private System.Windows.Forms.Button btnAtendimento;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnAcerto;
        private System.Windows.Forms.Button btnSair;
    }
}

