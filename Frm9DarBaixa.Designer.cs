namespace ProjetoDegazin
{
    partial class pagDarBaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pagDarBaixa));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoDG = new System.Windows.Forms.TextBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtUltimoAtendimento = new System.Windows.Forms.DateTimePicker();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(13, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(426, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dar Baixa nas peças de Revendedor(a)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código DG:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCodigoDG
            // 
            this.txtCodigoDG.Location = new System.Drawing.Point(210, 174);
            this.txtCodigoDG.Name = "txtCodigoDG";
            this.txtCodigoDG.Size = new System.Drawing.Size(134, 31);
            this.txtCodigoDG.TabIndex = 1;
            this.txtCodigoDG.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtCodigoDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDevolver.ForeColor = System.Drawing.Color.White;
            this.btnDevolver.Location = new System.Drawing.Point(18, 257);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(133, 50);
            this.btnDevolver.TabIndex = 2;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            this.btnDevolver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnDevolver_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 50);
            this.label3.TabIndex = 16;
            this.label3.Text = "Data do último\r\nAtendimento:";
            // 
            // dtUltimoAtendimento
            // 
            this.dtUltimoAtendimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtUltimoAtendimento.Location = new System.Drawing.Point(210, 91);
            this.dtUltimoAtendimento.Name = "dtUltimoAtendimento";
            this.dtUltimoAtendimento.Size = new System.Drawing.Size(265, 20);
            this.dtUltimoAtendimento.TabIndex = 0;
            this.dtUltimoAtendimento.Value = new System.DateTime(1753, 1, 1, 23, 59, 0, 0);
            this.dtUltimoAtendimento.ValueChanged += new System.EventHandler(this.dtUltimoAtendimento_ValueChanged);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(18, 353);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(133, 50);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(350, 177);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(183, 25);
            this.lblResultado.TabIndex = 17;
            this.lblResultado.Text = "Peça Devolvida!";
            // 
            // pagDarBaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(587, 437);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dtUltimoAtendimento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtCodigoDG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "pagDarBaixa";
            this.Text = "Degazin - Devolução";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pagDarBaixa_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoDG;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtUltimoAtendimento;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblResultado;
    }
}