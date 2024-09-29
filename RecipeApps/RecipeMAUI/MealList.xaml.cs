using RecipeSystem;

namespace RecipeMAUI;

public partial class MealList : ContentPage
{
	public MealList()
	{
		InitializeComponent();
		LoadMeals();
	}
	private void LoadMeals()
	{
		MealLst.ItemsSource = new bizMeal().GetList();
	}

    private void MealsBtn_Clicked(object sender, EventArgs e)
    {
		LoadMeals();
    }
}