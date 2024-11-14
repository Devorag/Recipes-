delete users2
delete roles

insert roles(roleName, roleRank)
select 'user', '1'
union select 'superuser', '2'
union select 'admin', '3'

insert users2(roleId, UserName, password)
select r.roleId, 'user', 'password' from roles r where r.rolerank = 1 
union
select r.roleId, 'sam', 'password' from roles r where r.rolerank = 2
union
select r.roleId, 'admin', 'password' from roles r where r.rolerank = 3 


select * from roles
select * from users2