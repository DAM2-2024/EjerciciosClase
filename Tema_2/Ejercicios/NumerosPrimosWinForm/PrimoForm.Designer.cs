namespace NumerosPrimosWinForm
{
    partial class PrimoForm
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
            this.txtBox_Numero = new System.Windows.Forms.TextBox();
            this.lb_TextBoxNumero = new System.Windows.Forms.Label();
            this.lb_Result = new System.Windows.Forms.Label();
            this.btn_Comprobar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox_Numero
            // 
            this.txtBox_Numero.Location = new System.Drawing.Point(263, 82);
            this.txtBox_Numero.Name = "txtBox_Numero";
            this.txtBox_Numero.Size = new System.Drawing.Size(282, 23);
            this.txtBox_Numero.TabIndex = 0;
            // 
            // lb_TextBoxNumero
            // 
            this.lb_TextBoxNumero.AutoSize = true;
            this.lb_TextBoxNumero.Location = new System.Drawing.Point(151, 85);
            this.lb_TextBoxNumero.Name = "lb_TextBoxNumero";
            this.lb_TextBoxNumero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_TextBoxNumero.Size = new System.Drawing.Size(106, 15);
            this.lb_TextBoxNumero.TabIndex = 1;
            this.lb_TextBoxNumero.Text = "Escribe un número";
            // 
            // lb_Result
            // 
            this.lb_Result.AutoSize = true;
            this.lb_Result.Location = new System.Drawing.Point(358, 211);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.Size = new System.Drawing.Size(0, 15);
            this.lb_Result.TabIndex = 2;
            // 
            // btn_Comprobar
            // 
            this.btn_Comprobar.Location = new System.Drawing.Point(512, 297);
            this.btn_Comprobar.Name = "btn_Comprobar";
            this.btn_Comprobar.Size = new System.Drawing.Size(229, 120);
            this.btn_Comprobar.TabIndex = 3;
            this.btn_Comprobar.Text = "Comprobar";
            this.btn_Comprobar.UseVisualStyleBackColor = true;
            this.btn_Comprobar.Click += new System.EventHandler(this.Btn_Comprobar_Click);
            // 
            // PrimoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Comprobar);
            this.Controls.Add(this.lb_Result);
            this.Controls.Add(this.lb_TextBoxNumero);
            this.Controls.Add(this.txtBox_Numero);
            this.Name = "PrimoForm";
            this.Text = "PrimoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBox_Numero;
        private Label lb_TextBoxNumero;
        private Label lb_Result;
        private Button btn_Comprobar;
    }
}