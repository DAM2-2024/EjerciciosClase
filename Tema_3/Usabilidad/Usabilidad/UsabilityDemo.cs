using System.Drawing.Drawing2D;

namespace Usabilidad
{
    public partial class UsabilityDemo : Form
    {
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;

        public UsabilityDemo()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Usability Demo";

            //Hacer que el form esté centrado
            this.StartPosition = FormStartPosition.CenterScreen;

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            fileMenu.DropDownItems.Add("Save", null, SaveFile);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("Exit", null, ExitApplication);

            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDownItems.Add("About", null, ShowAboutDialog);

            MenuStrip menuStrip = new MenuStrip()
            {
                Font = new Font("Segoe UI", 12),
            };
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(helpMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            Button openButton = CreateStyledButton("Open File");

            openButton.Click += (s, eventArgs) => OpenFile(s, eventArgs);

            Button saveButton = CreateStyledButton("Save File");

            saveButton.Click += (s, eventArgs) => SaveFile(s, eventArgs);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                RowCount = 2,
                ColumnCount = 2,

            };
            tableLayoutPanel.Controls.Add(menuStrip, 0, 0);
            tableLayoutPanel.Controls.Add(openButton, 0, 1);
            tableLayoutPanel.Controls.Add(saveButton, 1, 1);
            this.Controls.Add(tableLayoutPanel);

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(openButton, "Open a file (Ctrl + O)");
            toolTip.SetToolTip(saveButton, "Save the current file (Ctrl + S)");

            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel("Ready");
            statusStrip.Items.Add(statusLabel);

            this.Controls.Add(statusStrip);
            this.FormClosing += MainForm_FormClosing;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                MessageBox.Show($"File opened: {fileName}", "Open File");
                statusLabel.Text = $"Opened: {fileName}";
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                MessageBox.Show($"File saved: {fileName}", "Save File");
                statusLabel.Text = $"Saved: {fileName}";
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowAboutDialog(object sender, EventArgs e)
        {
            MessageBox.Show($"Usability Demo{Environment.NewLine}Version 1.1", "About");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private Button CreateStyledButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Size = new Size(150, 60),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(90, 90, 90),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 12),
                Margin = new Padding(10),
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.DarkGray,
                    MouseDownBackColor = Color.FromArgb(150, 150, 150)
                }
            };
            return button;
        }
    }
}