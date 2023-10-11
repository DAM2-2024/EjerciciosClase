namespace NumerosPrimosWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ClickPrincipal = new System.Windows.Forms.Button();
            this.lbPrincipal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ClickPrincipal
            // 
            this.btn_ClickPrincipal.Location = new System.Drawing.Point(180, 53);
            this.btn_ClickPrincipal.Name = "btn_ClickPrincipal";
            this.btn_ClickPrincipal.Size = new System.Drawing.Size(103, 124);
            this.btn_ClickPrincipal.TabIndex = 0;
            this.btn_ClickPrincipal.Text = "Click me";
            this.btn_ClickPrincipal.UseVisualStyleBackColor = true;
            this.btn_ClickPrincipal.Click += new System.EventHandler(this.Btn_ClickPrincipal_Click);
            this.btn_ClickPrincipal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_ClickPrincipal_MouseClick);
            // 
            // lbPrincipal
            // 
            this.lbPrincipal.AutoSize = true;
            this.lbPrincipal.Location = new System.Drawing.Point(180, 252);
            this.lbPrincipal.Name = "lbPrincipal";
            this.lbPrincipal.Size = new System.Drawing.Size(131, 15);
            this.lbPrincipal.TabIndex = 1;
            this.lbPrincipal.Text = "Mi primerita Aplicación";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 396);
            this.Controls.Add(this.lbPrincipal);
            this.Controls.Add(this.btn_ClickPrincipal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_ClickPrincipal;
        private Label lbPrincipal;
    }
}