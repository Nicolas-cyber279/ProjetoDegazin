namespace ProjetoDegazin
{
    partial class pagAtendimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pagAtendimento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            this.btnDarBaixa = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atendimento Degazin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id do vendedor atendido: ";
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.ForeColor = System.Drawing.Color.Green;
            this.txtIdVendedor.Location = new System.Drawing.Point(299, 67);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(100, 31);
            this.txtIdVendedor.TabIndex = 0;
            // 
            // btnDarBaixa
            // 
            this.btnDarBaixa.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDarBaixa.ForeColor = System.Drawing.Color.White;
            this.btnDarBaixa.Location = new System.Drawing.Point(12, 121);
            this.btnDarBaixa.Name = "btnDarBaixa";
            this.btnDarBaixa.Size = new System.Drawing.Size(204, 50);
            this.btnDarBaixa.TabIndex = 1;
            this.btnDarBaixa.Text = "Dar Baixa";
            this.btnDarBaixa.UseVisualStyleBackColor = false;
            this.btnDarBaixa.Click += new System.EventHandler(this.btnDarBaixa_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnRegistro.ForeColor = System.Drawing.Color.White;
            this.btnRegistro.Location = new System.Drawing.Point(12, 177);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(204, 50);
            this.btnRegistro.TabIndex = 2;
            this.btnRegistro.Text = "Registrar peças";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(17, 329);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(204, 50);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // pagAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(411, 400);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnDarBaixa);
            this.Controls.Add(this.txtIdVendedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "pagAtendimento";
            this.Text = "Degazin - Atendimento";
            this.Load += new System.EventHandler(this.pagAtendimento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdVendedor;
        private System.Windows.Forms.Button btnDarBaixa;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnFinalizar;
    }
}