using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saveup
{
    public partial class ArtikelListeSeite : ContentPage
    {
        public ArtikelListeSeite()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var artikel = await App.ArtikelSpeicher.LadeArtikelAsync();
            ArtikelListView.ItemsSource = artikel;
        }

        private async void OnLeerenClicked(object sender, EventArgs e)
        {
            // Alle Artikel löschen
            await App.ArtikelSpeicher.LoescheAlleArtikelAsync();
            ArtikelListView.ItemsSource = new List<GespeicherterArtikel>();
        }
    }
}
