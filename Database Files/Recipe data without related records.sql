
insert Recipe(CuisineID, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select (select c.cuisineId from Cuisine c where c.CuisineType = 'American'), u.usersID,  'Deli roll', 450, '01-03-2023', null, '11-11-2023' from users u where u.lastname = 'Diena'
union select (select c.cuisineId from Cuisine c where c.CuisineType = 'French'), u.usersId, 'Brocoli soup', 125, '04-05-2021', '12-10-2021', null from users u where u.LastName = 'Azoulay'
union select (select c.cuisineId from Cuisine c where c.CuisineType = 'English'), u.usersId, 'Lamb chops', 450, '11-10-2017', '01-01-2018', '02-02-2019' from users u where u.lastname = 'Weinberger'
union select (select c.CuisineId from cuisine c where c.CuisineType = 'American'), u.usersId, 'Sweet roll', 500, '01-01-2016', null , null from users u where u.LastName = 'Svei'
union select (select c.cuisineId from Cuisine C where c.CuisineType = 'American'), u.usersId, 'Smores', 300, '01-01-2019', '04-04-2019', '05-05-2020' from users u where u.lastname = 'Svei'
union select (select c.cuisineId from cuisine c where c.CuisineType = 'French'), u.usersId, 'Waffles', 200, '08-12-2023', null, '01-03-2024' from users u where u.lastname = 'Korb'
union select (select c.cuisineId from cuisine c where c.cuisineType = 'Indian'), u.usersId, 'Roasted Potatoes', 150, '07-06-2015', '06-06-2016', null from users u where u.lastname = 'Mozes'
union select (select c.cuisineId from cuisine c where c.CuisineType = 'Chinese'), u.usersId, 'Chicken Poppers', 325, '01-01-2021', '03-04-2021', '11-11-2021' from users u where u.lastname = 'Katz'

