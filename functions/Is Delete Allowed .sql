create or alter function dbo.IsDeleteAllowed(@RecipeId int) 
returns varchar(60) 

as 
begin   
   declare @value varchar(60) = ' '
       IF not EXISTS (
        SELECT 1 FROM Recipe r WHERE R.RecipeId = @RecipeId AND
         (r.RecipeStatus = 'Drafted' 
               OR DATEDIFF(day, r.DateArchived, GETDATE()) >= 30 ))
        begin 
            select @value = 'Cannot delete recipe that is not currently drafted or that has not been archived in the past 30 days'
        end 
        return @value 
end 
go 

select dbo.IsDeleteAllowed(r.recipeid) 
from recipe r 