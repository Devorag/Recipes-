--IMPORTANT create login in master 
drop login dev_login_hmwk
create login dev_login_hmwk with PASSWORD =  'Homewk123!'

drop user if exists dev_user 
create user dev_user from login dev_login_hmwk 

alter role db_datareader add member dev_user
alter role db_Datawriter add member dev_user lo