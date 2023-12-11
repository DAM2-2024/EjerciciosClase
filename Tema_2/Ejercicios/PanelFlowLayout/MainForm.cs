using Microsoft.VisualBasic;
using PanelFlowLayout.Utils;

namespace PanelFlowLayout
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
        }

        private void InitializeFlowLayoutPanel()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            for (int i = 1; i <= new Random().Next(10, 20); i++)
            {
                flowLayoutPanel.Controls.Add(CreatePanel("Button" + i.ToString()));
            }

            Controls.Add(flowLayoutPanel);
        }

        private static Panel CreatePanel(string buttonText)
        {
            Panel panel = new Panel
            {
                BackColor = Color.LightGray,
                Size = new Size(300, 50),
                Margin = new Padding(5)
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(Utils.Constants.RESOURCE_NAME),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50),
                Dock = DockStyle.Fill
            };

            Button button = new Button
            {
                Text = buttonText,
                Size = new Size(100, 40)
            };
            button.Click += (sender, e) => MessageBox.Show($"Button {buttonText} Clicked!");
            button.Dock = DockStyle.Right;

            // Add controls to the panel

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(button);

            return panel;
        }
    }
}