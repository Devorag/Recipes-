use master
go 
drop login appadmin 
go 
create login appadmin with PASSWORD = 'ABC123!!!'
go 

use RecipeDb 
go 
drop user if exists appadmin_user 
go 
create user appadmin_user from login appadmin 
go 
