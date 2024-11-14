CREATE OR ALTER PROCEDURE dbo.RecipeGet
(
    @CuisineName VARCHAR(100) = '',
    @All BIT = 0,
    @IncludeBlank BIT = 0
)
AS
BEGIN
   select CusineName=@CuisineName

END;
GO
grant execute on RecipeGet to approle