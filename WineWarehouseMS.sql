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
	CheckingStatus Bit,
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Table for Report
CREATE TABLE Report (
    ReportID INT PRIMARY KEY IDENTITY(1,1),
    ProductLineID INT,
    CheckingRequestID INT,
    StockQuantity INT,
    CheckedQuantity INT,
    CheckedDate DATE,
    Reason NVARCHAR(MAX),
    AccountID INT,
    ReportStatus BIT,
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID),
    FOREIGN KEY (CheckingRequestID) REFERENCES CheckingRequest(CheckingRequestID),
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

INSERT INTO BrewingRoom (RoomName, Temperature, Humidity, Note)
VALUES ('Room A', 18, 60, 'Main brewing room'),
       ('Room B', 17, 65, 'Secondary brewing room'),
       ('Room C', 16, 70, 'For special wine type');

INSERT INTO Shelf (BrewingRoomID, ShelfName, MaxQuantity, UseQuantity)
VALUES 
    (1, 'Shelf A.1', 150, 0),
    (1, 'Shelf A.2', 200, 0),
    (2, 'Shelf B.1', 150, 0),
	(2, 'Shelf B.2', 200, 0),
	(3, 'Shelf C.1', 50, 0)

INSERT INTO Product (ProductName, ProductDescription, Origin, CategoryID)
VALUES 
    ('Cabernet Sauvignon', 'A full-bodied red wine with notes of dark fruits', 'France', 1),
    ('Merlot', 'Smooth red wine with flavors of plum and cherry', 'USA', 1),
    ('Chardonnay', 'Crisp white wine with hints of green apple and citrus', 'Australia', 2),
    ('Sauvignon Blanc', 'Light-bodied white wine with fresh tropical flavors', 'New Zealand', 2),
    ('Prosecco', 'Sparkling wine with a light and fruity taste', 'Italy', 3),
    ('Champagne', 'High-quality sparkling wine from the Champagne region', 'France', 3),
    ('Pinot Noir Rosé', 'Rosé wine with delicate flavors of strawberry and rose', 'USA', 4),
    ('Syrah Rosé', 'Dry rosé wine with hints of raspberry and cherry', 'Spain', 4),
    ('Port', 'Sweet dessert wine with rich flavors of dried fruits and nuts', 'Portugal', 5),
    ('Sherry', 'Fortified wine with a nutty and caramel flavor', 'Spain', 6);

