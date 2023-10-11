namespace NumerosPrimosWinForm
{
    public partial class Form1 : Form
    {
        int contador;
        public Form1()
        {
            InitializeComponent();
            contador = 1;
        }

        private void Btn_ClickPrincipal_Click(object sender, EventArgs e)
        {
            Form formBase = new Form();
            Label lbResultado = new Label();
            lbResultado.Text = $"Le has dado {contador} clicks";
            formBase.Controls.Add(lbResultado);
            formBase.Show(); 
            contador++;
        }

        private void Btn_ClickPrincipal_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}