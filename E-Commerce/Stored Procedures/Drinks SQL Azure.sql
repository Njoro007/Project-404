create table Products
(
ProductID int primary key identity(1,1),
Name varchar(500),
Description varchar(1000),
Price varchar(50),
ImageUrl varchar(500),
CategoryID int,
ProductQuantity int
)

create table Category
(
CategoryID int primary key identity(1,1),
CategoryName varchar(200)
)

create table CustomerProducts
(
    CustomerID int null,
    ProductID int null,
    TotalProduct int null
)