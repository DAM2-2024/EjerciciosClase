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
    public partial class GameForm : Form
    {
        private Personaje _currentPersonaje;
        private Enemigo _currentEnemigo;
        private List<string> oldEnemies = new List<string>();
        public GameForm(Personaje currentPersonaje)
        {
            InitializeComponent();
            this._currentPersonaje = currentPersonaje;
            CargarEnemigo();
            AddEvents();
            ActualizarVidas();
        }

        private void AddEvents()
        {
            btn_lAt.Click -= new EventHandler(BtnAtack_Clicked);
            btn_nAt.Click -= new EventHandler(BtnAtack_Clicked);
            btn_hAt.Click -= new EventHandler(BtnAtack_Clicked);

            btn_lAt.Click += new EventHandler(BtnAtack_Clicked);
            btn_nAt.Click += new EventHandler(BtnAtack_Clicked);
            btn_hAt.Click += new EventHandler(BtnAtack_Clicked);
        }

        private void CargarEnemigo()
        {
            Enemigo enemigo = new Enemigo();
            Random random = new Random();
            var imagenesEnemigos= Enemigo.GetPathEnemies();
            imagenesEnemigos.RemoveAll(x => oldEnemies.Contains(x));

            if (imagenesEnemigos.Count ==0)
            {
                //Mostrar Formulario Final de Juego
                return;
            }
            int index=random.Next(0, imagenesEnemigos.Count);
            enemigo.Path = imagenesEnemigos[index];
            pbox_Enemies.Load(enemigo.Path);
            lb_Vida_Enemy.Text=enemigo.Vida.ToString();
            _currentEnemigo = enemigo;
            oldEnemies.Add(enemigo.Path);
        }

        private void BtnAtack_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button ?? new Button();
            if (button.Name== btn_lAt.Name)
            {
                int probabilidad = Constants.LIGHT_ATACK_CHANCES + _currentPersonaje.Suerte;
                int fuerza = Constants.LIGHT_ATACK_STRENGTH + Convert.ToInt32(
                    Math.Floor(
                        decimal.Divide(Convert.ToDecimal(_currentPersonaje.Fuerza), Constants.LIGHT_ATACK_DIVISION))
                    );
                Random random = new Random();
                if (random.Next(0, 101) > probabilidad)
                {
                    lb_Historico.Items.Add($"Has fallado con un ataque light");
                    return;
                }
                _currentEnemigo.Vida -= fuerza;
                lb_Vida_Enemy.Text = _currentEnemigo.Vida.ToString();
                lb_Historico.Items.Add($"Has hecho {fuerza} de daño con un ataque light");
            }

            if (_currentEnemigo.Vida>0)
            {
                _currentPersonaje.Vida -= _currentEnemigo.Fuerza;
            }
            ActualizarVidas();

            if (_currentPersonaje.Vida <=0)
            {
                //Mostrar Formulario Final de Juego
            }
            if (_currentEnemigo.Vida<=0)
            {
                CargarEnemigo();
            }
        }

        public void ActualizarVidas()
        {
            lb_Vida_Enemy.Text = _currentEnemigo.Vida.ToString();
            this.lb_Vida.Text = _currentPersonaje.Vida.ToString();
        }
    }
}
