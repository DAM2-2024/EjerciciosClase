namespace ComboBox
{
    partial class Form1
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
            this.comboBoxCountries = new System.Windows.Forms.ComboBox();
            this.labelSelectedCountry = new System.Windows.Forms.Label();
            this.labelCapital = new System.Windows.Forms.Label();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCountries
            // 
            this.comboBoxCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountries.FormattingEnabled = true;
            this.comboBoxCountries.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCountries.Name = "comboBoxCountries";
            this.comboBoxCountries.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCountries.TabIndex = 0;
            this.comboBoxCountries.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountries_SelectedIndexChanged);
            // 
            // labelSelectedCountry
            // 
            this.labelSelectedCountry.AutoSize = true;
            this.labelSelectedCountry.Location = new System.Drawing.Point(12, 50);
            this.labelSelectedCountry.Name = "labelSelectedCountry";
            this.labelSelectedCountry.Size = new System.Drawing.Size(94, 13);
            this.labelSelectedCountry.TabIndex = 1;
            this.labelSelectedCountry.Text = "Selected Country: ";
            // 
            // labelCapital
            // 
            this.labelCapital.AutoSize = true;
            this.labelCapital.Location = new System.Drawing.Point(12, 80);
            this.labelCapital.Name = "labelCapital";
            this.labelCapital.Size = new System.Drawing.Size(52, 13);
            this.labelCapital.TabIndex = 2;
            this.labelCapital.Text = "Capital: ";
            // 
            // labelPopulation
            // 
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Location = new System.Drawing.Point(12, 110);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Size = new System.Drawing.Size(69, 13);
            this.labelPopulation.TabIndex = 3;
            this.labelPopulation.Text = "Population: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.labelPopulation);
            this.Controls.Add(this.labelCapital);
            this.Controls.Add(this.labelSelectedCountry);
            this.Controls.Add(this.comboBoxCountries);
            this.Name = "Form1";
            this.Text = "Country Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCountries;
        private System.Windows.Forms.Label labelSelectedCountry;
        private System.Windows.Forms.Label labelCapital;
        private System.Windows.Forms.Label labelPopulation;
    }
}