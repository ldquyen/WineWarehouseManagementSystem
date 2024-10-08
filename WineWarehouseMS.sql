create database WineWarehouseMS
use WineWarehouseMS
-- Table for User Account
CREATE TABLE Account (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    AccountName NVARCHAR(50),
    Username VARCHAR(50),
    UserPassword VARCHAR(50),
    AccountRole INT -- 0: Staff, 1: Manager, 2: Admin
);

-- Table for Brewing Room
CREATE TABLE BrewingRoom (
    BrewingRoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomName NVARCHAR(50),
    Temperature INT, -- Range 7-18 for general, 5-12 for white wine, 12-19 for red wine
    Humidity INT,    -- Range 50-70%, ideal at 60%
    Note VARCHAR(MAX)
);

-- Table for Shelf
CREATE TABLE Shelf (
    ShelfID INT PRIMARY KEY IDENTITY(1,1),
    BrewingRoomID INT,
    ShelfName NVARCHAR(50),
    MaxQuantity INT,
    UseQuantity INT,
    FOREIGN KEY (BrewingRoomID) REFERENCES BrewingRoom(BrewingRoomID)
);

-- Table for Category
CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50)
);

-- Table for Product
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(50),
    ProductDescription NVARCHAR(MAX),
    Origin VARCHAR(50),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

-- Table for ProductLine
CREATE TABLE ProductLine (
    ProductLineID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    ProductYear INT,
    ProductAlcohol INT,
    Capacity INT,
    Price MONEY,
    Quantity INT,
    ShelfID INT,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (ShelfID) REFERENCES Shelf(ShelfID)
);

-- Table for Import
CREATE TABLE Import (
    ImportID INT PRIMARY KEY IDENTITY(1,1),
    ImportDate DATE,
    AccountID INT,
    Note NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

-- Table for ImportDetail
CREATE TABLE ImportDetail (
	ImportDetailID INT PRIMARY KEY IDENTITY(1,1),
    ImportID INT,
    ProductLineID INT,
    Quantity INT,
    FOREIGN KEY (ImportID) REFERENCES Import(ImportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for Export
CREATE TABLE Export (
    ExportID INT PRIMARY KEY IDENTITY(1,1),
    ExportDate DATE,
    AccountID INT,
    Note NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

-- Table for ExportDetail
CREATE TABLE ExportDetail (
	ExportDetailID INT PRIMARY KEY IDENTITY(1,1),
    ExportID INT,
    ProductLineID INT,
    Quantity INT,
    FOREIGN KEY (ExportID) REFERENCES Export(ExportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for CheckingRequest
CREATE TABLE CheckingRequest (
    CheckingRequestID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT,
    ProductID INT,
    CheckDateRequest DATETIME,
    Reason NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Table for Report
CREATE TABLE Report (
    ReportID INT PRIMARY KEY IDENTITY(1,1),
    ProductLineID INT,
    StockQuantity INT,
    CheckedQuantity INT,
    CheckedDate DATE,
    Reason NVARCHAR(MAX),
    AccountID INT,
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);


INSERT INTO Account ( AccountName, Username, UserPassword, AccountRole)
VALUES  ('staff name', 'staff', 'wwms1234', 1),
		('manager name', 'manager', 'wwms1234', 2),
		('admin name', 'admin', 'wwms1234', 3);

INSERT INTO Category ( CategoryName)
VALUES ('Red Wine'),
       ('White Wine'),
       ('Sparkling Wine'),
       ('Rose Wine'),
       ('Dessert Wine'),
       ('Fortified Wine');

SELECT * FROM Product