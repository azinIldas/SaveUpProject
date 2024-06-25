using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace saveup
{
    public partial class ArtikelHinzufuegenSeite : ContentPage
    {
        public ArtikelHinzufuegenSeite()
        {
            InitializeComponent();
        }

        private async void OnSpeichernClicked(object sender, EventArgs e)
        {
            var beschreibung = ArtikelBeschreibung.Text;
            var preis = decimal.Parse(ArtikelPreis.Text);

            var neuerArtikel = new GespeicherterArtikel
            {
                Beschreibung = beschreibung,
                Preis = preis,
                Datum = DateTime.Now
            };

            // Artikel zur Liste hinzufügen und in JSON-Datei speichern
            await App.ArtikelSpeicher.SpeichereArtikelAsync(neuerArtikel);

            // Aktualisiere die Hauptseite
            if (Navigation.NavigationStack.FirstOrDefault() is Hauptseite hauptseite)
            {
                await hauptseite.AktualisiereGesamtbetrag();
            }

            await Navigation.PopAsync();
        }
    }
}
