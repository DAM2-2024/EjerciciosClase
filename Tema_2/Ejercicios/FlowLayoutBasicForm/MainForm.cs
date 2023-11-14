namespace FlowLayoutBasicForm
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
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;

            // Add some sample panels to the FlowLayoutPanel
            for (int i = 1; i <= 5; i++)
            {
                flowLayoutPanel.Controls.Add(CreatePanel("Image" + i.ToString(), "Button" + i.ToString()));
            }

            Controls.Add(flowLayoutPanel);
        }

        private Panel CreatePanel(string imageName, string buttonText)
        {
            // Create a panel
            Panel panel = new Panel();
            panel.BackColor = Color.LightGray;
            panel.Size = new Size(300, 50);
            panel.Margin = new Padding(5);

            // Create a PictureBox on the left side
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName); // Replace with your image source
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(50, 50);

            // Create a Button on the right side
            Button button = new Button();
            button.Text = buttonText;
            button.Size = new Size(100, 40);
            button.Click += (sender, e) => MessageBox.Show($"Button {buttonText} Clicked!");

            // Add controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(button);

            return panel;
        }
    }
}