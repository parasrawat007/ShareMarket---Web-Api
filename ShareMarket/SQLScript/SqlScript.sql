Create table Users(
	Id int primary key identity(1,1),
	[Name] varchar(30) not null,
	Email varchar(30) Unique not null check(Email Like '%@%.%'),
	Username varchar(30) not null,
	[Password] varchar(30) not null,
	IsActive bit default(0)
	);

Insert into Users([Name],Email,[Password],Username, IsActive) values('Paras','parasrawat67@gmail.com','parasrawat007','ghf007',1);

Create procedure USP_GetUsers
As
select Id,[Name],Email,[Password],Username, IsActive from Users
return

Create procedure USP_GetUser
	@id int
as
select Id,[Name],Email,[Password],Username, IsActive from Users where id=@id
return

Create procedure USP_CreateUser
	@Name varchar(20),
	@Email varchar(20),
	@Password varchar(30),
	@username varchar(30),
	@IsActive bit
as
	Insert into Users([Name],Email,[Password],Username ,IsActive) 
	Values(@Name,@Email,@Password,@Username,@IsActive)
return