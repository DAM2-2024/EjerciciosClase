using DungeonsAndDragonsCutre.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonsAndDragonsCutre
{
    public partial class FichaPersonaje : Form
    {
        public FichaPersonaje()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load -= new System.EventHandler(this.frm_Load);
            this.btn_MinusFuerza.Click -= new System.EventHandler(this.btnMinus_Clicked);
            this.btn_MinusSuerte.Click -= new System.EventHandler(this.btnMinus_Clicked);
            this.btn_MinusVida.Click -= new System.EventHandler(this.btnMinus_Clicked);

            this.btn_PlusFuerza.Click -= new System.EventHandler(this.btnMas_Clicked);
            this.btn_PlusSuerte.Click -= new System.EventHandler(this.btnMas_Clicked);
            this.btn_PlusVida.Click -= new System.EventHandler(this.btnMas_Clicked);

            this.Load += new System.EventHandler(this.frm_Load);
            this.btn_MinusFuerza.Click += new System.EventHandler(this.btnMinus_Clicked);
            this.btn_MinusSuerte.Click += new System.EventHandler(this.btnMinus_Clicked);
            this.btn_MinusVida.Click += new System.EventHandler(this.btnMinus_Clicked);

            this.btn_PlusFuerza.Click += new System.EventHandler(this.btnMas_Clicked);
            this.btn_PlusSuerte.Click += new System.EventHandler(this.btnMas_Clicked);
            this.btn_PlusVida.Click += new System.EventHandler(this.btnMas_Clicked);

        }

        private void frm_Load(object sender, EventArgs e)
        {
            int cantidad = 0;
            Random rnd = new Random();
            int num = rnd.Next() % 7;
            cantidad += num;
            txtBox_Fuerza.Text = num.ToString();

            num = rnd.Next() % (10- num);
            txtBox_Vida.Text = num.ToString();
            cantidad += num;

            num= rnd.Next() % (10 - cantidad);
            txtBox_Suerte.Text = num.ToString();
            cantidad += num;
            lbl_Puntos.Text += $" {10 - cantidad}";
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button ?? new Button();
            int numero = 0;
            if (button.Name == btn_MinusFuerza.Name && txtBox_Fuerza.Text != "0")
            {
                ModificarPuntosMinusButton(button, numero, txtBox_Fuerza);
                return;
            }
            if (button.Name == btn_MinusSuerte.Name && txtBox_Suerte.Text != "0")
            {
                ModificarPuntosMinusButton(button, numero, txtBox_Suerte);
                return;
            }
            if (button.Name == btn_MinusVida.Name && txtBox_Vida.Text != "0")
            {
                ModificarPuntosMinusButton(button, numero, txtBox_Vida);
            }
        }

        private void btnMas_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button ?? new Button();
            int numero = 0;
            if (button.Name == btn_PlusFuerza.Name && GetPuntos>0)
            {
                ModificarPuntosMasButton(button, numero, txtBox_Fuerza);
                return;
            }
            if (button.Name == btn_PlusSuerte.Name && GetPuntos > 0)
            {
                ModificarPuntosMasButton(button, numero, txtBox_Suerte);
                return;
            }
            if (button.Name == btn_PlusVida.Name && GetPuntos > 0)
            {
                ModificarPuntosMasButton(button, numero, txtBox_Vida);
            }
        }

        private void ModificarPuntosMasButton(Button button, int numero, TextBox textBox)
        {
            numero = int.Parse(textBox.Text);
            numero++;
            textBox.Text = numero.ToString();
            int puntosRestantes = GetPuntos;
            puntosRestantes--;
            lbl_Puntos.Text = Constants.LABEL_PUNTOS + puntosRestantes.ToString();
        }

        private void ModificarPuntosMinusButton(Button button, int numero, TextBox textBox)
        {
            numero = int.Parse(textBox.Text);
            numero--;
            textBox.Text = numero.ToString();
            int puntosRestantes = GetPuntos;
            puntosRestantes++;
            lbl_Puntos.Text = Constants.LABEL_PUNTOS + puntosRestantes.ToString();
        }

        private int GetPuntos
        {
            get
            {
                return int.Parse(lbl_Puntos.Text.Split(":").LastOrDefault());
            }
        }
    }
}
