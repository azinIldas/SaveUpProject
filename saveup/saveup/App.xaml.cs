using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System.IO;

namespace saveup
{
    public partial class App : Application
    {
        static ArtikelSpeicher? artikelSpeicher;

        public static ArtikelSpeicher ArtikelSpeicher
        {
            get
            {
                if (artikelSpeicher == null)
                {
                    artikelSpeicher = new ArtikelSpeicher();
                }
                return artikelSpeicher;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Hauptseite());
        }
    }
}
