using Microsoft.Maui.Controls;

namespace RecipeMAUI
{
    public partial class App : Application
    {
        public static bool LoggedIn = false;
        public static string ConnStringSetting = "";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
