using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;

namespace saveup
{
    public partial class ArtikelListeSeite : ContentPage
    {
        public ICommand LoescheArtikelCommand { get; private set; }

        public ArtikelListeSeite()
        {
            InitializeComponent();
            LoescheArtikelCommand = new Command<GespeicherterArtikel>(async (artikel) => await LoescheArtikel(artikel));
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var artikel = await App.ArtikelSpeicher.LadeArtikelAsync();
            ArtikelListView.ItemsSource = artikel;
        }

        private async Task LoescheArtikel(GespeicherterArtikel artikel)
        {
            var artikelListe = (List<GespeicherterArtikel>)ArtikelListView.ItemsSource;
            artikelListe.Remove(artikel);
            ArtikelListView.ItemsSource = null;
            ArtikelListView.ItemsSource = artikelListe;

            // Speichere die aktualisierte Liste
            var json = JsonConvert.SerializeObject(artikelListe, Formatting.Indented);
            var dateiPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "artikel.json");
            await File.WriteAllTextAsync(dateiPfad, json);
        }

        private async void OnLeerenClicked(object sender, EventArgs e)
        {
            // Alle Artikel löschen
            await App.ArtikelSpeicher.LoescheAlleArtikelAsync();
            ArtikelListView.ItemsSource = new List<GespeicherterArtikel>();
        }
    }
}
