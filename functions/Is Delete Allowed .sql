CREATE OR ALTER FUNCTION dbo.IsDeleteAllowed(@RecipeId INT)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @value VARCHAR(100)

    IF NOT EXISTS (
        SELECT *
        FROM Recipe r 
        WHERE r.RecipeId = @RecipeId AND
              (r.RecipeStatus = 'Drafted' or DATEDIFF(day, r.DateArchived, GETDATE()) <= 30)
    )
    BEGIN
        SET @value = 'Can only delete a recipe that is currently drafted or that has been archived in the past 30 days.'
    END
    ELSE
    BEGIN
        SET @value = ''
    END

    RETURN @value
END
GO
