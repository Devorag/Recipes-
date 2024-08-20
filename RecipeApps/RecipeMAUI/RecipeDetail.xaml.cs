using RecipeSystem;

namespace RecipeMAUI;

public partial class RecipeDetail : ContentPage
{
	bizRecipe recipe = new();
	public RecipeDetail(int recipeidval = 0)
	{
		InitializeComponent();
		recipe.Load(recipeidval);
		this.BindingContext = recipe;
	}

    private void Save()
    {
        MessageLbl.Text = "";
        try
        {
            recipe.Save();
        }
        catch(Exception ex)
        {
            MessageLbl.Text = ex.Message;
        }
    }
    
    private async void Delete()
    {
        try
        {
            recipe.Delete();
            await ClosePage();
        }
        catch(Exception ex)
        {
            MessageLbl.Text = ex.Message;
        }
    }

    private async Task ClosePage()
    {
        await Navigation.PopAsync();
    }

    private void SaveBtn_Clicked_1(object sender, EventArgs e)
    {
        Save();
    }

    private void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        Delete();
    }

    private async void CancelBtn_Clicked(object sender, EventArgs e)
    {
        await ClosePage();
    }
}