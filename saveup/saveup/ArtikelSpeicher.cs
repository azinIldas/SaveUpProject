using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace saveup
{
    public class ArtikelSpeicher
    {
        private readonly string dateiPfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "artikel.json");

        public async Task<List<GespeicherterArtikel>> LadeArtikelAsync()
        {
            if (!File.Exists(dateiPfad))
            {
                return new List<GespeicherterArtikel>();
            }

            var json = await File.ReadAllTextAsync(dateiPfad);
            return JsonConvert.DeserializeObject<List<GespeicherterArtikel>>(json) ?? new List<GespeicherterArtikel>();
        }

        public async Task SpeichereArtikelAsync(GespeicherterArtikel artikel)
        {
            var artikelListe = await LadeArtikelAsync();
            artikelListe.Add(artikel);
            var json = JsonConvert.SerializeObject(artikelListe, Formatting.Indented);
            await File.WriteAllTextAsync(dateiPfad, json);
        }

        public async Task LoescheAlleArtikelAsync()
        {
            if (File.Exists(dateiPfad))
            {
                File.Delete(dateiPfad);
            }
            await Task.CompletedTask;
        }
    }
}