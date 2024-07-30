use master
go 
create login appadmin with PASSWORD = 'ABC123!!!'
go 

use RecipeDb 
go 
create user appadmin_user from login appadmin 
go 
