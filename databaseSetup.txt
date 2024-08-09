# library-management-system
This is a Library Management System made as a Mini Project for 4th semester of my Computer Engineering Course.

** Microsoft SQL Server Management Studio is a requirement for this project as it requires a SQL Server to store Books and Student Information

The Authentication Server Address must be edited in the code to have access to the server.

The following queries must be run on the studio to create the table that required for the information to be stored


//For Student Table
create table newStudent(
sid int NOT NULL IDENTITY(1,1) primary key,
sName varchar(50) NOT NULL,
sRoll varchar(50) NOT NULL,
sDepart varchar(50) NOT NULL,
sSem varchar(50) NOT NULL,
sCont bigint NOT NULL)


//For Issue and Return Book Table
create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_Roll varchar(50) not null,
std_Name varchar(50) NOT NULL,
std_Depart varchar(50) NOT NULL,
std_Sem varchar(50) NOT NULL,
std_Cont bigint NOT NULL,
book_name varchar(250) NOT NULL,
book_issue_date varchar(250) not null,
book_return_date varchar(250));
