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
        private Button Button1;
        private Button Button2;
        private Button Button3;
        private Button Button4;


        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            FlowLayoutPanel = new FlowLayoutPanel();
            Button1 = new Button();
            Button2 = new Button();
            Button3 = new Button();
            Button4 = new Button();
            wrapContentsCheckBox = new CheckBox();
            flowTopDownBtn = new RadioButton();
            flowBottomUpBtn = new RadioButton();
            flowLeftToRight = new RadioButton();
            flowRightToLeftBtn = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            FlowLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // FlowLayoutPanel
            // 
            FlowLayoutPanel.AutoSize = true;
            FlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FlowLayoutPanel.Controls.Add(Button1);
            FlowLayoutPanel.Controls.Add(Button2);
            FlowLayoutPanel.Controls.Add(Button3);
            FlowLayoutPanel.Controls.Add(Button4);
            FlowLayoutPanel.Dock = DockStyle.Fill;
            FlowLayoutPanel.Location = new Point(0, 0);
            FlowLayoutPanel.Name = "FlowLayoutPanel";
            FlowLayoutPanel.Size = new Size(213, 273);
            FlowLayoutPanel.TabIndex = 0;
            // 
            // Button1
            // 
            Button1.Location = new Point(3, 3);
            Button1.Name = "Button1";
            Button1.Size = new Size(75, 23);
            Button1.TabIndex = 0;
            Button1.Text = "Button1";
            // 
            // Button2
            // 
            Button2.Location = new Point(84, 3);
            Button2.Name = "Button2";
            Button2.Size = new Size(75, 23);
            Button2.TabIndex = 1;
            Button2.Text = "Button2";
            // 
            // Button3
            // 
            Button3.Location = new Point(3, 32);
            Button3.Name = "Button3";
            Button3.Size = new Size(75, 23);
            Button3.TabIndex = 2;
            Button3.Text = "Button3";
            // 
            // Button4
            // 
            Button4.Location = new Point(84, 32);
            Button4.Name = "Button4";
            Button4.Size = new Size(75, 23);
            Button4.TabIndex = 3;
            Button4.Text = "Button4";
            // 
            // wrapContentsCheckBox
            // 
            wrapContentsCheckBox.Checked = true;
            wrapContentsCheckBox.CheckState = CheckState.Checked;
            wrapContentsCheckBox.Location = new Point(3, 3);
            wrapContentsCheckBox.Name = "wrapContentsCheckBox";
            wrapContentsCheckBox.Size = new Size(104, 24);
            wrapContentsCheckBox.TabIndex = 1;
            wrapContentsCheckBox.Text = "Wrap Contents";
            wrapContentsCheckBox.CheckedChanged += WrapContentsCheckBox_CheckedChanged;
            // 
            // flowTopDownBtn
            // 
            flowTopDownBtn.AutoSize = true;
            flowTopDownBtn.Location = new Point(3, 33);
            flowTopDownBtn.Name = "flowTopDownBtn";
            flowTopDownBtn.Size = new Size(129, 24);
            flowTopDownBtn.TabIndex = 2;
            flowTopDownBtn.Text = "Flow TopDown";
            flowTopDownBtn.CheckedChanged += FlowTopDownBtn_CheckedChanged;
            // 
            // flowBottomUpBtn
            // 
            flowBottomUpBtn.AutoSize = true;
            flowBottomUpBtn.Location = new Point(3, 63);
            flowBottomUpBtn.Name = "flowBottomUpBtn";
            flowBottomUpBtn.Size = new Size(134, 24);
            flowBottomUpBtn.TabIndex = 3;
            flowBottomUpBtn.Text = "Flow BottomUp";
            flowBottomUpBtn.CheckedChanged += FlowBottomUpBtn_CheckedChanged;
            // 
            // flowLeftToRight
            // 
            flowLeftToRight.AutoSize = true;
            flowLeftToRight.Location = new Point(3, 123);
            flowLeftToRight.Name = "flowLeftToRight";
            flowLeftToRight.Size = new Size(141, 24);
            flowLeftToRight.TabIndex = 4;
            flowLeftToRight.Text = "Flow LeftToRight";
            flowLeftToRight.CheckedChanged += FlowLeftToRight_CheckedChanged;
            // 
            // flowRightToLeftBtn
            // 
            flowRightToLeftBtn.AutoSize = true;
            flowRightToLeftBtn.Location = new Point(3, 93);
            flowRightToLeftBtn.Name = "flowRightToLeftBtn";
            flowRightToLeftBtn.Size = new Size(141, 24);
            flowRightToLeftBtn.TabIndex = 5;
            flowRightToLeftBtn.Text = "Flow RightToLeft";
            flowRightToLeftBtn.CheckedChanged += FlowRightToLeftBtn_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(wrapContentsCheckBox);
            flowLayoutPanel1.Controls.Add(flowTopDownBtn);
            flowLayoutPanel1.Controls.Add(flowBottomUpBtn);
            flowLayoutPanel1.Controls.Add(flowRightToLeftBtn);
            flowLayoutPanel1.Controls.Add(flowLeftToRight);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 273);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(213, 125);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // Pokedex
            // 
            ClientSize = new Size(213, 398);
            Controls.Add(FlowLayoutPanel);
            Controls.Add(flowLayoutPanel1);
            Name = "Pokedex";
            Text = "DiseñoResponsivo";
            FlowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
    }
}