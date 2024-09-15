using RecipeSystem;

namespace RecipeMAUI;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        this.Loaded += Home_Loaded;
        this.Appearing += Home_Appearing;
	}

    private async void Home_Loaded(object? sender, EventArgs e)
    {
        if(App.LoggedIn == false)
        {
           await Navigation.PushModalAsync(new Login());
        }
    }
    private void Home_Appearing(object? sender, EventArgs e)
    {
        if(App.LoggedIn == true)
        {
            BindableLayout.SetItemsSource(DashboardLst,new bizDashboard().GetList());
        }
    }

    private async void RecipeBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RecipeList");
    }

    private async void MealBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MealList");
    }
}