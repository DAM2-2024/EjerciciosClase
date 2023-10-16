using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MiticaCalculadoraDI.OperationEnum;

namespace MiticaCalculadoraDI
{
    public partial class Calculador : Form
    {
        private List<Button> botonesNumero;
        private List<Button> botonesOperando;
        decimal valueLabelBeforeOperaton = 0;
        OperacionesCalculadora operation = OperacionesCalculadora.defecto;


        public Calculador()
        {
            InitializeComponent();
            botonesNumero = new List<Button>()
            {
                btn_Uno,
                btn_Dos,
                btn_Tres,
                btn_Cuatro,
                btn_Cinco,
                btn_Seis,
                btn_Siete,
                btn_Ocho,
                btn_Nueve,
                btn_Cero
            };
            botonesOperando = new List<Button>()
            {
                btn_Mult,
                btn_Sumar,
                btn_Restar
            };
            ChangeButtonColors();
            AddEvents();
        }


        private void AddEvents()
        {
            botonesNumero.ForEach(x =>
            {
                x.Click -= new System.EventHandler(this.Btn_Click);
                x.Click += new System.EventHandler(this.Btn_Click);
            });
            botonesOperando.ForEach(x =>
            {
                x.Click -= new System.EventHandler(this.Btn_Operation_CLick);
                x.Click += new System.EventHandler(this.Btn_Operation_CLick);
            });

            btn_Igual.Click -= new System.EventHandler(this.Btn_Operation_Igual);
            btn_Igual.Click += new System.EventHandler(this.Btn_Operation_Igual);
        }

        private void ChangeButtonColors()
        {
            botonesNumero.ForEach(x => x.BackColor = SystemColors.ButtonHighlight);
        }
        private void Btn_Operation_Igual(object sender, EventArgs e)
        {
            switch(operation)
            {
                case OperacionesCalculadora.multiplicar:
                    lb_Resultado.Text = (decimal.Parse(lb_Resultado.Text) * valueLabelBeforeOperaton).ToString();
                    break;
                case OperacionesCalculadora.sumar:
                    lb_Resultado.Text = (decimal.Parse(lb_Resultado.Text) + valueLabelBeforeOperaton).ToString();
                    break;
                case OperacionesCalculadora.restar:
                    lb_Resultado.Text = (decimal.Parse(lb_Resultado.Text) - valueLabelBeforeOperaton).ToString();
                    break;
            }    
        }

        private void Btn_Operation_CLick(object sender, EventArgs e)
        {

            if (!decimal.TryParse(lb_Resultado.Text, out decimal resultado))
            {
                return;
            }
            valueLabelBeforeOperaton = resultado;
            lb_Resultado.Text = string.Empty;
            Button? clickedButton = sender as Button;

            if (clickedButton?.Name  == btn_Restar.Name)
            {
                operation = OperacionesCalculadora.restar;
            }
            if (clickedButton?.Name == btn_Mult.Name)
            {
                operation = OperacionesCalculadora.multiplicar;
            }
            if (clickedButton?.Name == btn_Sumar.Name)
            {
                operation = OperacionesCalculadora.sumar;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            
            if (clickedButton?.Name== btn_Uno.Name)
            {
                lb_Resultado.Text += "1";
            }
            if (clickedButton?.Name == btn_Dos.Name)
            {
                lb_Resultado.Text += "2";
            }
            if (clickedButton?.Name == btn_Tres.Name)
            {
                lb_Resultado.Text += "3";
            }
            if (clickedButton?.Name == btn_Cuatro.Name)
            {
                lb_Resultado.Text += "4";
            }
            if (clickedButton?.Name == btn_Cinco.Name)
            {
                lb_Resultado.Text += "5";
            }
            if (clickedButton?.Name == btn_Seis.Name)
            {
                lb_Resultado.Text += "6";
            }
            if (clickedButton?.Name == btn_Siete.Name)
            {
                lb_Resultado.Text += "7";
            }
            if (clickedButton?.Name == btn_Ocho.Name)
            {
                lb_Resultado.Text += "8";
            }
            if (clickedButton?.Name == btn_Nueve.Name)
            {
                lb_Resultado.Text += "9";
            }
            if (clickedButton?.Name == btn_Cero.Name)
            {
                lb_Resultado.Text += "0";
            }
        }
    }
}
