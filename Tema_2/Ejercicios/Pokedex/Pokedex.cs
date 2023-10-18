namespace Pokedex
{
    public partial class Pokedex : Form
    {
        public Pokedex()
        {
            InitializeComponent();
        }

        public void WrapContentsCheckBox_CheckedChanged(
        System.Object sender,
        System.EventArgs e)
        {
            this.FlowLayoutPanel.WrapContents =
                this.wrapContentsCheckBox.Checked;
        }

        public void FlowTopDownBtn_CheckedChanged(
            System.Object sender,
            System.EventArgs e)
        {
            this.FlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        }

        public void FlowBottomUpBtn_CheckedChanged(
            System.Object sender,
            System.EventArgs e)
        {
            this.FlowLayoutPanel.FlowDirection = FlowDirection.BottomUp;
        }

        public void FlowLeftToRight_CheckedChanged(
            System.Object sender,
            System.EventArgs e)
        {
            this.FlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
        }

        public void FlowRightToLeftBtn_CheckedChanged(
            System.Object sender,
            System.EventArgs e)
        {
            this.FlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
        }
    }
}