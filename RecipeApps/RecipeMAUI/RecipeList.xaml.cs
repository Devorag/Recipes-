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
		DataTable dt = Recipes.SearchRecipes();
		RecipeLst.ItemsSource = dt.Rows;
	}

    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
		SearchRecipes();
    }
}