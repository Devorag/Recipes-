drop table if exists users2
drop table if exists roles

go 
create table dbo.roles(
	roleId int not null identity primary key,
	roleName varchar(10) not null constraint u_Role_Role_Name unique,
	roleRank int not null constraint u_Role_Role_Rank unique 
)
go

create table dbo.users2(
	userId int not null identity primary key, 
	roleId int not null constraint f_Roles_Users2 foreign key references roles(roleId),
	username varchar(20) not null constraint u_Users2_User_Name unique,--constraint min amount chars 
	password varchar(20) not null, --constraint min amount chars
	sessionkey varchar(255) not null default '',
	sessionkeyDate datetime null 
)
go