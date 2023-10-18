using Pokedex.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        public Pokedex()
        {
            InitializeComponent();
            InitializeEvents();
            //CreateRandomNumberOfButtons();
            
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
                    Text = pokemon.Nombre
                };
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