using Pokedex.Models;
using Pokedex.Utils;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        public Pokedex()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load -= new System.EventHandler(this.FormLoad);
            this.flowBottomUpBtn.CheckedChanged-= new System.EventHandler(this.FlowTopDownBtn_CheckedChanged);
            this.flowLeftToRight.CheckedChanged -= new System.EventHandler(this.FlowLeftToRight_CheckedChanged);
            this.flowRightToLeftBtn.CheckedChanged -= new System.EventHandler(this.FlowRightToLeftBtn_CheckedChanged);
            this.flowTopDownBtn.CheckedChanged -= new System.EventHandler(this.FlowTopDownBtn_CheckedChanged);

            this.flowBottomUpBtn.CheckedChanged += new System.EventHandler(this.FlowTopDownBtn_CheckedChanged);
            this.flowLeftToRight.CheckedChanged += new System.EventHandler(this.FlowLeftToRight_CheckedChanged);
            this.flowRightToLeftBtn.CheckedChanged += new System.EventHandler(this.FlowRightToLeftBtn_CheckedChanged);
            this.flowTopDownBtn.CheckedChanged += new System.EventHandler(this.FlowTopDownBtn_CheckedChanged);
            this.Load += new System.EventHandler(this.FormLoad);
        }

        private async void FormLoad(object sender, EventArgs e)
        {
            PokemonData pokemonData = await RequestPokemonDataAsync();
            GeneratePokemonButtons(pokemonData);
        }

        private void GeneratePokemonButtons(PokemonData pokemonData)
        {
            foreach(Pokemon pokemon in pokemonData.Pokemons)
            {
                Button button = new()
                {
                    Text = pokemon.Nombre,
                    Name= pokemon.UrlData
                };
                button.Click -= new EventHandler(Pokemon_ClikedAsync);
                button.Click += new EventHandler(Pokemon_ClikedAsync);
                FlowLayoutPanel.Controls.Add(button);
            }
        }

        private static async Task<PokemonData> RequestPokemonDataAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                PokemonData? myJsonResponse = await httpClient.GetFromJsonAsync<PokemonData>("https://pokeapi.co/api/v2/pokemon?limit=151&offset=0");
                return myJsonResponse ?? new PokemonData();
            }
        }

        private void CreateRandomNumberOfButtons()
        {
            Random rnd = new Random();
            int num = rnd.Next() % 50;
            for (int i = 0; i < num; i++)
            {
                Button button = new()
                {
                    Text = i.ToString()
                };
                FlowLayoutPanel.Controls.Add(button);
            }
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

        public async void Pokemon_ClikedAsync( System.Object sender, System.EventArgs e)
        {
            Form formularioPokemon = new Form();

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.WrapContents = true;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.Dock = DockStyle.Fill;

            Button botonClicked= sender as Button ?? new Button();
            using (HttpClient httpClient = new HttpClient())
            {
                PokeInfo? myJsonResponse = await httpClient.GetFromJsonAsync<PokeInfo>(botonClicked.Name);

                PropertyInfo[] properties = typeof(Sprites).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object? value =property.GetValue(myJsonResponse?.sprites ?? new Sprites());
                    if (value is not string)
                    {
                        continue;
                    }
            
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode=PictureBoxSizeMode.StretchImage
                    pictureBox.Load(value.ToString() ?? Constants.DEFAULT_POKEMON_IMAGE_URL);
                    panel.Controls.Add(pictureBox);
                }
            }
            formularioPokemon.Controls.Add(panel);

            formularioPokemon.Show();
        }

    }
}