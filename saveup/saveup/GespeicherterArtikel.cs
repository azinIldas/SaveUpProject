using System;

namespace saveup
{
    public class GespeicherterArtikel
    {
        public string Beschreibung { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public DateTime Datum { get; set; }
    }
}
