using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumerosPrimosWinForm
{
    public partial class PrimoForm : Form
    {
        public PrimoForm()
        {
            InitializeComponent();
        }

        private void Btn_Comprobar_Click(object sender, EventArgs e)
        {
            string valorTexto = txtBox_Numero.Text;
            if (!int.TryParse(valorTexto, out int numero))
            {
                lb_Result.Text = "No es un número";
                return;
            }

            int contador = 0;
            for (int i = 1; i <= Math.Ceiling(Math.Sqrt(numero)); i++)
            {
                if (numero % i == 0)
                {
                    contador++;
                }
            }
            if (contador == 1)
            {
                lb_Result.Text = "Es primo";
                return;
            }
            lb_Result.Text = "No es primo, primo";
        }
    }
}
