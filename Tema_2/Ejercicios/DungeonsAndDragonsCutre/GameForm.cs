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
        private Estadistica _estadistica;
        private List<string> oldEnemies = new List<string>();
        public GameForm(Personaje currentPersonaje)
        {
            InitializeComponent();
            _estadistica = new Estadistica();
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
                MostrarCreditos();
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
            int fuerza = 0;
            int probabilidad = 0;
            if (button.Name== btn_lAt.Name)
            {
                probabilidad = Constants.LIGHT_ATACK_CHANCES + _currentPersonaje.Suerte;
                fuerza = Constants.LIGHT_ATACK_STRENGTH + Convert.ToInt32(
                    Math.Floor(
                        decimal.Divide(Convert.ToDecimal(_currentPersonaje.Fuerza), Constants.LIGHT_ATACK_DIVISION))
                    );
            }
            else if (button.Name == btn_nAt.Name)
            {
                probabilidad = Constants.NORMAL_ATACK_CHANCES + _currentPersonaje.Suerte;
                fuerza = Constants.NORMAL_ATACK_STRENGTH + Convert.ToInt32(
                    Math.Floor(
                        decimal.Divide(Convert.ToDecimal(_currentPersonaje.Fuerza), Constants.NORMAL_ATACK_DIVISION))
                    );
            }
            else if (button.Name == btn_hAt.Name)
            {
                probabilidad = Constants.STRONG_ATACK_CHANCES + _currentPersonaje.Suerte;
                fuerza = Constants.STRONG_ATACK_STRENGTH + _currentPersonaje.Fuerza;

            }

            Atack(probabilidad, fuerza);

            if (_currentEnemigo.Vida>0)
            {
                _currentPersonaje.Vida -= _currentEnemigo.Fuerza;
            }

            ActualizarVidas();

            LoadStadistica(fuerza, _currentEnemigo.Fuerza);

            if (_currentPersonaje.Vida <=0)
            {
                MostrarCreditos();
            }
            if (_currentEnemigo.Vida<=0)
            {
                CargarEnemigo();
            }
        }
        private void Atack(int probabilidad, int fuerza)
        {
            Random random = new Random();
            if (random.Next(0, 101) > probabilidad)
            {
                lb_Historico.Items.Add($"Has fallado el ataque");
                return;
            }
            _currentEnemigo.Vida -= fuerza;
            lb_Vida_Enemy.Text = _currentEnemigo.Vida.ToString();
            lb_Historico.Items.Add($"Has hecho {fuerza} de daño");
        }
        public void ActualizarVidas()
        {
            lb_Vida_Enemy.Text = _currentEnemigo.Vida.ToString();
            this.lb_Vida.Text = _currentPersonaje.Vida.ToString();
        }

        private void LoadStadistica(int damage, int damageEnemigo)
        {
            _estadistica.Max_Dealt_Damage = _estadistica.Max_Dealt_Damage > damage 
                ? _estadistica.Max_Dealt_Damage : damage;
            _estadistica.Max_Recieved_Damage = _estadistica.Max_Recieved_Damage > damageEnemigo 
                ? _estadistica.Max_Recieved_Damage : damageEnemigo;

            _estadistica.Min_Dealt_Damage = _estadistica.Min_Dealt_Damage > damage
                ? damage : _estadistica.Min_Dealt_Damage;
            _estadistica.Min_Recieved_Damage = _estadistica.Min_Recieved_Damage > damageEnemigo
                ? damageEnemigo : _estadistica.Max_Recieved_Damage;
        }
        private void MostrarCreditos()
        {
            Form form = new Form();
            form.BackColor = Color.Black;
            form.AutoSize= true;
            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                WrapContents = true,
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill
            };

            Label lb_HasGanado = new Label();
            lb_HasGanado.ForeColor = Color.White;
            lb_HasGanado.Font = new Font(lb_HasGanado.Font, FontStyle.Bold);
            lb_HasGanado.Text = "HAS GANADO";
            flow.Controls.Add(lb_HasGanado);

            Label lb_TiempoJugado= new Label();
            lb_TiempoJugado.AutoSize = true;
            lb_TiempoJugado.Font = new Font(lb_TiempoJugado.Font, FontStyle.Bold);
            lb_TiempoJugado.ForeColor = Color.White;
            lb_TiempoJugado.Text = $"Tiempo jugado en segundos: {_estadistica.TiempoJugado}";
            flow.Controls.Add(lb_TiempoJugado);

            Label lb_Max_Dealt_Damage = new Label();
            lb_Max_Dealt_Damage.AutoSize = true;
            lb_Max_Dealt_Damage.Font = new Font(lb_HasGanado.Font, FontStyle.Bold);
            lb_Max_Dealt_Damage.ForeColor = Color.White;
            lb_Max_Dealt_Damage.Text = $"Daño máximo realizado: {_estadistica.Max_Dealt_Damage}";
            flow.Controls.Add(lb_Max_Dealt_Damage);

            Label lb_Min_Dealt_Damage = new Label();
            lb_Min_Dealt_Damage.AutoSize = true;
            lb_Min_Dealt_Damage.ForeColor = Color.White;
            lb_Min_Dealt_Damage.Font = new Font(lb_HasGanado.Font, FontStyle.Bold);
            lb_Min_Dealt_Damage.Text = $"Daño mínimo realizado: {_estadistica.Min_Dealt_Damage}";
            flow.Controls.Add(lb_Min_Dealt_Damage);

            Label lb_Max_Recieved_Damage = new Label();
            lb_Max_Recieved_Damage.AutoSize = true;
            lb_Max_Recieved_Damage.ForeColor = Color.White;
            lb_Max_Recieved_Damage.Font = new Font(lb_HasGanado.Font, FontStyle.Bold);
            lb_Max_Recieved_Damage.Text = $"Daño máximo recibido: {_estadistica.Max_Recieved_Damage}";
            flow.Controls.Add(lb_Max_Recieved_Damage);

            Label lb_Min_Recieved_Damage = new Label();
            lb_Min_Recieved_Damage.AutoSize = true;
            lb_Min_Recieved_Damage.Font = new Font(lb_HasGanado.Font, FontStyle.Bold);
            lb_Min_Recieved_Damage.ForeColor = Color.White;
            lb_Min_Recieved_Damage.Text = $"Daño mínimo recibido: {_estadistica.Min_Recieved_Damage}";
            flow.Controls.Add(lb_Min_Recieved_Damage);

            form.Controls.Add(flow);
            this.Close();
            form.ShowDialog();
        }
    }
}
