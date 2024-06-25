using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace saveup
{
    public partial class Hauptseite : ContentPage
    {
        public Hauptseite()
        {
            InitializeComponent();
            // Initialisiere den Gesamtbetrag beim Erstellen der Seite
            _ = AktualisiereGesamtbetrag();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await AktualisiereGesamtbetrag();
        }

        private async void OnArtikelHinzufuegenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtikelHinzufuegenSeite());
        }

        private async void OnArtikelAnzeigenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtikelListeSeite());
        }

        public async Task AktualisiereGesamtbetrag()
        {
            var artikelListe = await App.ArtikelSpeicher.LadeArtikelAsync();
            var gesamtbetrag = artikelListe.Sum(a => a.Preis);
            GesamtbetragLabel.Text = $"Gesamtbetrag: {gesamtbetrag.ToString("C", System.Globalization.CultureInfo.CreateSpecificCulture("de-CH"))}";
        }
    }
}
