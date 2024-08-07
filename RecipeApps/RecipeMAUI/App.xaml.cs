namespace RecipeMAUI
{
    public partial class App : Application
    {
        public static bool LoggedIn = false;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
