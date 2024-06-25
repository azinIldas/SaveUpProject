using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

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

            // NavigationPage für Dark Mode anpassen
            MainPage = new NavigationPage(new Hauptseite())
            {
                BarBackgroundColor = Color.FromArgb("#121212"),
                BarTextColor = Color.FromArgb("#FFFFFF")
            };
        }
    }
}