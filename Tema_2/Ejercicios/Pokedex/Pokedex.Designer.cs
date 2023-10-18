namespace Pokedex
{
    partial class Pokedex
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
        private FlowLayoutPanel FlowLayoutPanel;
        private CheckBox wrapContentsCheckBox;
        private RadioButton flowTopDownBtn;
        private RadioButton flowBottomUpBtn;
        private RadioButton flowLeftToRight;
        private RadioButton flowRightToLeftBtn;


        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.wrapContentsCheckBox = new System.Windows.Forms.CheckBox();
            this.flowTopDownBtn = new System.Windows.Forms.RadioButton();
            this.flowBottomUpBtn = new System.Windows.Forms.RadioButton();
            this.flowLeftToRight = new System.Windows.Forms.RadioButton();
            this.flowRightToLeftBtn = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel
            // 
            this.FlowLayoutPanel.AutoSize = true;
            this.FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel.Name = "FlowLayoutPanel";
            this.FlowLayoutPanel.Size = new System.Drawing.Size(771, 379);
            this.FlowLayoutPanel.TabIndex = 0;
            // 
            // wrapContentsCheckBox
            // 
            this.wrapContentsCheckBox.Checked = true;
            this.wrapContentsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wrapContentsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.wrapContentsCheckBox.Name = "wrapContentsCheckBox";
            this.wrapContentsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.wrapContentsCheckBox.TabIndex = 1;
            this.wrapContentsCheckBox.Text = "Wrap Contents";
            // 
            // flowTopDownBtn
            // 
            this.flowTopDownBtn.AutoSize = true;
            this.flowTopDownBtn.Location = new System.Drawing.Point(113, 3);
            this.flowTopDownBtn.Name = "flowTopDownBtn";
            this.flowTopDownBtn.Size = new System.Drawing.Size(103, 19);
            this.flowTopDownBtn.TabIndex = 2;
            this.flowTopDownBtn.Text = "Flow TopDown";
            // 
            // flowBottomUpBtn
            // 
            this.flowBottomUpBtn.AutoSize = true;
            this.flowBottomUpBtn.Location = new System.Drawing.Point(222, 3);
            this.flowBottomUpBtn.Name = "flowBottomUpBtn";
            this.flowBottomUpBtn.Size = new System.Drawing.Size(108, 19);
            this.flowBottomUpBtn.TabIndex = 3;
            this.flowBottomUpBtn.Text = "Flow BottomUp";
            // 
            // flowLeftToRight
            // 
            this.flowLeftToRight.AutoSize = true;
            this.flowLeftToRight.Location = new System.Drawing.Point(455, 3);
            this.flowLeftToRight.Name = "flowLeftToRight";
            this.flowLeftToRight.Size = new System.Drawing.Size(113, 19);
            this.flowLeftToRight.TabIndex = 4;
            this.flowLeftToRight.Text = "Flow LeftToRight";
            // 
            // flowRightToLeftBtn
            // 
            this.flowRightToLeftBtn.AutoSize = true;
            this.flowRightToLeftBtn.Location = new System.Drawing.Point(336, 3);
            this.flowRightToLeftBtn.Name = "flowRightToLeftBtn";
            this.flowRightToLeftBtn.Size = new System.Drawing.Size(113, 19);
            this.flowRightToLeftBtn.TabIndex = 5;
            this.flowRightToLeftBtn.Text = "Flow RightToLeft";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.wrapContentsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.flowTopDownBtn);
            this.flowLayoutPanel1.Controls.Add(this.flowBottomUpBtn);
            this.flowLayoutPanel1.Controls.Add(this.flowRightToLeftBtn);
            this.flowLayoutPanel1.Controls.Add(this.flowLeftToRight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 379);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(771, 125);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // Pokedex
            // 
            this.ClientSize = new System.Drawing.Size(771, 504);
            this.Controls.Add(this.FlowLayoutPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Pokedex";
            this.Text = "DiseñoResponsivo";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
    }
}