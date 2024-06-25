using Microsoft.Maui.Controls;
using System;

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
            if (string.IsNullOrWhiteSpace(beschreibung))
            {
                await DisplayAlert("Fehler", "Die Beschreibung darf nicht leer sein.", "OK");
                return;
            }

            if (!decimal.TryParse(ArtikelPreis.Text, out var preis) || preis <= 0)
            {
                await DisplayAlert("Fehler", "Der Preis kann nicht unter 0 sein.", "OK");
                return;
            }

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
