using CountryRoads.Clients;
using CountryRoads.Model;
using CountryRoads.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountryRoads
{
    public partial class Main : Form
    {
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _statusLabel;
        List<Country>? _allCountries; 
        public Main()
        {
            InitializeComponent();
            InitializeUI();
            RequestData();
        }

        private async Task RequestData()
        {
            try
            {
                _allCountries = await HttpJsonClient<List<Country>>.RequestCountryDataAsync(Constants.BASE_URL_API, "all");

                AddDataFlowLayout(_allCountries);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _statusLabel.Text = "Error";
            }
            _statusLabel.Text = "Loaded";
        }

        private void AddDataFlowLayout(IEnumerable<Country> countries)
        {
            flowPanel.Controls.Clear();
            foreach (var country in countries)
            {
                Label label = new Label();
                label.Text = country.name.common;
                flowPanel.Controls.Add(label);
                label.Click += Label_Click;
            }
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            Label? label = sender as Label;
            Country countrySelected = _allCountries?.FirstOrDefault(x => x.name.common == label?.Text) ?? new Country();

            Form form = new Form();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                RowCount = 5,
                ColumnCount = 1,

            };
            FlowLayoutPanel flowLayout = LoadTableLayout(countrySelected, tableLayoutPanel);
            tableLayoutPanel.Controls.Add(flowLayout, 0, 4);
            form.Controls.Add(tableLayoutPanel);
            form.ShowDialog();

            MostVisited? currentMostWanted = CountryClient.Instance.GetAll().FirstOrDefault(x => x.Name == countrySelected.name.common);

            MostVisited current =currentMostWanted ?? new MostVisited();
            current.Name=countrySelected.name.common;

            CountryClient.Instance.Upsert(current);
        }

        private static FlowLayoutPanel LoadTableLayout(Country countrySelected, TableLayoutPanel tableLayoutPanel)
        {
            Label lbEscudo = new Label();
            lbEscudo.Text = "Escudo";
            tableLayoutPanel.Controls.Add(lbEscudo, 0, 0);

            PictureBox pictureBoxscudo = new PictureBox();
            pictureBoxscudo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxscudo.Load(countrySelected?.flags?.png ?? Constants.DEFAULT_POKEMON_IMAGE_URL);
            tableLayoutPanel.Controls.Add(pictureBoxscudo, 0, 1);


            Label lbBandera = new Label();
            lbBandera.Text = "Bandera";
            tableLayoutPanel.Controls.Add(lbBandera, 0, 2);

            PictureBox pictureBoxFlag = new PictureBox();
            pictureBoxFlag.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFlag.Load(countrySelected?.coatOfArms?.png ?? Constants.DEFAULT_POKEMON_IMAGE_URL);
            tableLayoutPanel.Controls.Add(pictureBoxFlag, 0, 3);

            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.FlowDirection = FlowDirection.LeftToRight;
            flowLayout.Dock = DockStyle.Fill;

            Label lbCapital = new Label();
            lbCapital.Text = $"Capital: {countrySelected?.capital?.FirstOrDefault() ?? "No Data"}";


            Label lbRegion = new Label();
            lbRegion.Text = $"Region: {countrySelected?.region ?? "No Data"}";

            flowLayout.Controls.Add(lbCapital);
            flowLayout.Controls.Add(lbRegion);
            return flowLayout;
        }

        private void InitializeUI()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            ToolStripMenuItem allCountriesMenuItem = new ToolStripMenuItem("All Countries");
            ToolStripMenuItem mostVisitedMenuItem = new ToolStripMenuItem("Most Visited");
            
            mostVisitedMenuItem.Click += MostVisitedMenuItem_Click;
            allCountriesMenuItem.Click += AllVisitedMenuItem_Click;
            MenuStrip menuStrip = new MenuStrip()
            {
                Font = new Font("Segoe UI", 12),
            };
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            menuStrip.Items.Add(allCountriesMenuItem);
            menuStrip.Items.Add(mostVisitedMenuItem);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);


            _statusStrip = new StatusStrip();
            _statusLabel = new ToolStripStatusLabel("Loading");
            _statusStrip.Items.Add(_statusLabel);

            this.Controls.Add(_statusStrip);
            this.FormClosing += MainForm_FormClosing;
        }
        private void AllVisitedMenuItem_Click(object? sender, EventArgs e)
        {
            AddDataFlowLayout(_allCountries);
        }


        private void MostVisitedMenuItem_Click(object? sender, EventArgs e)
        {
            List<MostVisited> mostVisitedCountries =CountryClient.Instance.GetAll();
            List<string> nameMostVisitedCountries = mostVisitedCountries.OrderByDescending(x=>x.Visitas)
                                                                        .Select(x => x.Name.ToLower())
                                                                        .Take(20)
                                                                        .ToList();

            AddDataFlowLayout(_allCountries?.Where(x =>
                nameMostVisitedCountries.Contains(x.name.common.ToLower())) ?? new List<Country>()
            );
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
