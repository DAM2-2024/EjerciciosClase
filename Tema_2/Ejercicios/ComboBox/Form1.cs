using System.Diagnostics.Metrics;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        private List<Country> countries;

        public Form1()
        {
            InitializeComponent();

            // Initialize the list of countries
            countries = new List<Country>
            {
                new Country { Name = "USA", Capital = "Washington, D.C.", Population = 331002651 },
                new Country { Name = "China", Capital = "Beijing", Population = 1444216107 },
                new Country { Name = "India", Capital = "New Delhi", Population = 1380004385 },
                // Add more countries as needed
            };

            // Set the items for the ComboBox
            comboBoxCountries.Items.AddRange(countries.Select(c => c.Name).ToArray());

            // Set default selection
            comboBoxCountries.SelectedIndex = 0;
        }

        private void comboBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update labels based on the selected country
            int selectedIndex = comboBoxCountries.SelectedIndex;

            labelSelectedCountry.Text = $"Selected Country: {countries[selectedIndex].Name}";
            labelCapital.Text = $"Capital: {countries[selectedIndex].Capital}";
            labelPopulation.Text = $"Population: {countries[selectedIndex].Population:N0}";
        }

        // Country.cs
        public class Country
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public long Population { get; set; }
        }

    }
}