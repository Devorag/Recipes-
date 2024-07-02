create or alter procedure dbo.RecipeDelete(
	@RecipeId int 
)
as 
begin
	begin try 
		begin tran 
		delete from RecipeIngredient where RecipeId = @RecipeId
		delete from RecipeSteps where RecipeId = @RecipeId 
		delete from Recipe where RecipeId = @RecipeId
		commit 
	end try 
	begin catch 
		rollback;
		throw;
	end catch
end
go