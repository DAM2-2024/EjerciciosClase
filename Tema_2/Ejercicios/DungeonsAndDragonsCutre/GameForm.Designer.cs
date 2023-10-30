namespace DungeonsAndDragonsCutre
{
    partial class GameForm
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
            this.pbox_Enemies = new System.Windows.Forms.PictureBox();
            this.btn_lAt = new System.Windows.Forms.Button();
            this.btn_nAt = new System.Windows.Forms.Button();
            this.btn_hAt = new System.Windows.Forms.Button();
            this.lb_one = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_Vida_Enemy = new System.Windows.Forms.Label();
            this.lb_Vida = new System.Windows.Forms.Label();
            this.lb_Vida_Enemigo = new System.Windows.Forms.Label();
            this.lb_Historico = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Enemies)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbox_Enemies
            // 
            this.pbox_Enemies.Location = new System.Drawing.Point(203, 56);
            this.pbox_Enemies.Name = "pbox_Enemies";
            this.pbox_Enemies.Size = new System.Drawing.Size(285, 233);
            this.pbox_Enemies.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Enemies.TabIndex = 0;
            this.pbox_Enemies.TabStop = false;
            // 
            // btn_lAt
            // 
            this.btn_lAt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_lAt.Location = new System.Drawing.Point(203, 295);
            this.btn_lAt.Name = "btn_lAt";
            this.btn_lAt.Size = new System.Drawing.Size(94, 86);
            this.btn_lAt.TabIndex = 1;
            this.btn_lAt.Text = "Light atack";
            this.btn_lAt.UseVisualStyleBackColor = false;
            // 
            // btn_nAt
            // 
            this.btn_nAt.Location = new System.Drawing.Point(303, 295);
            this.btn_nAt.Name = "btn_nAt";
            this.btn_nAt.Size = new System.Drawing.Size(94, 86);
            this.btn_nAt.TabIndex = 2;
            this.btn_nAt.Text = "Normal atack";
            this.btn_nAt.UseVisualStyleBackColor = true;
            // 
            // btn_hAt
            // 
            this.btn_hAt.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_hAt.Location = new System.Drawing.Point(403, 295);
            this.btn_hAt.Name = "btn_hAt";
            this.btn_hAt.Size = new System.Drawing.Size(94, 86);
            this.btn_hAt.TabIndex = 3;
            this.btn_hAt.Text = "Heavy atack";
            this.btn_hAt.UseVisualStyleBackColor = false;
            // 
            // lb_one
            // 
            this.lb_one.AutoSize = true;
            this.lb_one.Location = new System.Drawing.Point(303, 410);
            this.lb_one.Name = "lb_one";
            this.lb_one.Size = new System.Drawing.Size(45, 15);
            this.lb_one.TabIndex = 4;
            this.lb_one.Text = "Tu vida";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lb_Historico);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lb_Vida_Enemy);
            this.panel2.Controls.Add(this.lb_Vida);
            this.panel2.Controls.Add(this.lb_Vida_Enemigo);
            this.panel2.Controls.Add(this.lb_one);
            this.panel2.Controls.Add(this.btn_hAt);
            this.panel2.Controls.Add(this.btn_nAt);
            this.panel2.Controls.Add(this.btn_lAt);
            this.panel2.Controls.Add(this.pbox_Enemies);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 450);
            this.panel2.TabIndex = 6;
            // 
            // lb_Vida_Enemy
            // 
            this.lb_Vida_Enemy.AutoSize = true;
            this.lb_Vida_Enemy.Location = new System.Drawing.Point(389, 9);
            this.lb_Vida_Enemy.Name = "lb_Vida_Enemy";
            this.lb_Vida_Enemy.Size = new System.Drawing.Size(0, 15);
            this.lb_Vida_Enemy.TabIndex = 6;
            // 
            // lb_Vida
            // 
            this.lb_Vida.AutoSize = true;
            this.lb_Vida.Location = new System.Drawing.Point(345, 410);
            this.lb_Vida.Name = "lb_Vida";
            this.lb_Vida.Size = new System.Drawing.Size(0, 15);
            this.lb_Vida.TabIndex = 5;
            // 
            // lb_Vida_Enemigo
            // 
            this.lb_Vida_Enemigo.AutoSize = true;
            this.lb_Vida_Enemigo.Location = new System.Drawing.Point(303, 9);
            this.lb_Vida_Enemigo.Name = "lb_Vida_Enemigo";
            this.lb_Vida_Enemigo.Size = new System.Drawing.Size(80, 15);
            this.lb_Vida_Enemigo.TabIndex = 0;
            this.lb_Vida_Enemigo.Text = "Vida Enemigo";
            // 
            // lb_Historico
            // 
            this.lb_Historico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Historico.FormattingEnabled = true;
            this.lb_Historico.ItemHeight = 15;
            this.lb_Historico.Location = new System.Drawing.Point(0, 0);
            this.lb_Historico.Name = "lb_Historico";
            this.lb_Historico.Size = new System.Drawing.Size(200, 450);
            this.lb_Historico.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Enemies)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbox_Enemies;
        private Button btn_lAt;
        private Button btn_nAt;
        private Button btn_hAt;
        private Label lb_one;
        private Panel panel1;
        private Panel panel2;
        private Label lb_Vida_Enemigo;
        private Label lb_Vida;
        private Label lb_Vida_Enemy;
        private ListBox lb_Historico;
    }
}