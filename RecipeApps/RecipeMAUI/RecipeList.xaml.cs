using RecipeSystem;
using System.Data;

namespace RecipeMAUI;

public partial class RecipeList : ContentPage
{
	public RecipeList()
	{
		InitializeComponent();
	}

	private void SearchRecipes()
	{
		bizRecipe recipe = new();
		var lstRecipe = recipe.Search();
		RecipeLst.ItemsSource = lstRecipe;
	}

    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
		SearchRecipes();
    }

    private async void RecipeLst_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		bizRecipe recipe = (bizRecipe)e.Item;
		await Navigation.PushAsync(new RecipeDetail(recipe.RecipeId));
    }

    private async void NewBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecipeDetail(0));
    }
}