using Microsoft.Maui.Controls;

namespace RecipeMAUI
{
    public partial class App : Application
    {
        public static bool LoggedIn = false;
        public static string ConnStringSetting = "Server =.\\SQLExpress;Database=RecipeDB";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
