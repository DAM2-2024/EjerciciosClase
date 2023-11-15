using DungeonsAndDragonsCutre.Models;
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
        private Personaje _currentPersonaje;
        private int GetPuntos
        {
            get
            {
                return int.Parse(lbl_Puntos.Text.Split(":").LastOrDefault());
            }
        }

        public FichaPersonaje()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load -= new System.EventHandler(this.frm_Load);
            this.btn_MinusFuerza.Click -= new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_MinusSuerte.Click -= new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_MinusVida.Click -= new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_PlusFuerza.Click -= new System.EventHandler(this.BtnMas_Clicked);
            this.btn_PlusSuerte.Click -= new System.EventHandler(this.BtnMas_Clicked);
            this.btn_PlusVida.Click -= new System.EventHandler(this.BtnMas_Clicked);
            this.btn_Registrar.Click -= new EventHandler(this.BtnRegistrar_Clicked);

            this.Load += new System.EventHandler(this.frm_Load);
            this.btn_MinusFuerza.Click += new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_MinusSuerte.Click += new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_MinusVida.Click += new System.EventHandler(this.BtnMinus_Clicked);
            this.btn_PlusFuerza.Click += new System.EventHandler(this.BtnMas_Clicked);
            this.btn_PlusSuerte.Click += new System.EventHandler(this.BtnMas_Clicked);
            this.btn_PlusVida.Click += new System.EventHandler(this.BtnMas_Clicked);
            this.btn_Registrar.Click += new EventHandler(this.BtnRegistrar_Clicked);

        }

        private void frm_Load(object sender, EventArgs e)
        {
            _currentPersonaje = Personaje.GetInstance();
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

            cmb_Raza.Items.AddRange(Enum.GetNames(typeof(Raza)));
        }

        private void BtnMinus_Clicked(object sender, EventArgs e)
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

        private void BtnMas_Clicked(object sender, EventArgs e)
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


        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
           lb_Error.Text = "";

           if (string.IsNullOrEmpty(txb_Nombre.Text))
            {
                lb_Error.Text = "Tienes que introducir un nombre";
                return;
            }

           if (cmb_Raza.SelectedItem == null)
            {
                lb_Error.Text = "Tienes que elegir una raza";
                return;
            }

           if (cmb_Raza.SelectedItem.ToString()== Enum.GetName(Raza.Orco) && rb_Good.Checked)
           {
                lb_Error.Text = "Un orco no puede ser Good.";
                return;
           }

            if (cmb_Raza.SelectedItem.ToString() == Enum.GetName(Raza.Elfo) && rb_Evil.Checked)
            {
                lb_Error.Text = "Un elfo no puede ser Evil.";
                return;
            }

            if (cmb_Raza.SelectedItem.ToString() == Enum.GetName(Raza.Humano) && rb_Neutral.Checked)
            {
                lb_Error.Text = "Un humano no puede ser neutral.";
                return;
            }

            if (GetPuntos > 0)
            {
                lb_Error.Text = "Tienes que gastar los puntos";
                return;
            }

            _currentPersonaje.Name = txb_Nombre.Text;
            _currentPersonaje.Raza = (Raza) Enum.Parse(typeof(Raza),cmb_Raza.SelectedItem.ToString());
            _currentPersonaje.Naturaleza= rb_Neutral.Checked ? Naturaleza.Neutral :
                rb_Good.Checked ? Naturaleza.Good : Naturaleza.Evil;

            _currentPersonaje.Fuerza = int.Parse(txtBox_Fuerza.Text);
            _currentPersonaje.Suerte= int.Parse(txtBox_Suerte.Text);
            _currentPersonaje.Vida = 30 + (int.Parse(txtBox_Suerte.Text)*2);


            this.Close();

            Form formularioStart = new Form();
            Button startGameButton = new Button();
            startGameButton.Text = "START GAME";
            startGameButton.Left = (formularioStart.Width - startGameButton.Width) / 2;
            startGameButton.Top = (formularioStart.Height - startGameButton.Height) / 2;
            startGameButton.TextAlign = ContentAlignment.MiddleCenter;
            startGameButton.Click -= new System.EventHandler(this.BtnStartGame_Clicked);
            startGameButton.Click += new System.EventHandler(this.BtnStartGame_Clicked);
            formularioStart.Controls.Add(startGameButton);
            formularioStart.Show();
        }

        private void BtnStartGame_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button ?? new Button();
            Form parentForm = button.Parent as Form ?? new Form();
            parentForm.Close();
            GameForm gameForm = new GameForm(_currentPersonaje);
            gameForm.ShowDialog();
        }
    }
}
