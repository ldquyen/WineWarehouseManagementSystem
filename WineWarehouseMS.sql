create database WineWarehouseMS
use WineWarehouseMS
-- Table for User Account
CREATE TABLE Account (
    AccountID INT PRIMARY KEY,
    AccountName NVARCHAR(50),
    Username VARCHAR(50),
    UserPassword VARCHAR(50),
    AccountRole INT -- 0: Staff, 1: Manager, 2: Admin
);

-- Table for Brewing Room
CREATE TABLE BrewingRoom (
    BrewingRoomID INT PRIMARY KEY,
    RoomName NVARCHAR(50),
    Temperature INT, -- Range 7-18 for general, 5-12 for white wine, 12-19 for red wine
    Humidity INT,    -- Range 50-70%, ideal at 60%
    Note VARCHAR(MAX)
);

-- Table for Shelf
CREATE TABLE Shelf (
    ShelfID INT PRIMARY KEY,
    BrewingRoomID INT,
    ShelfName NVARCHAR(50),
    MaxQuantity INT,
    UseQuantity INT,
    FOREIGN KEY (BrewingRoomID) REFERENCES BrewingRoom(BrewingRoomID)
);

-- Table for Category
CREATE TABLE Category (
    CategoryID INT PRIMARY KEY,
    CategoryName NVARCHAR(50)
);

-- Table for Product
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(50),
    ProductDescription NVARCHAR(MAX),
    Origin VARCHAR(50),
    CategoryID INT,
    ProductDetailId VARCHAR(50),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

-- Table for ProductLine
CREATE TABLE ProductLine (
    ProductLineID INT PRIMARY KEY,
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
    ImportID INT PRIMARY KEY,
    ImportDate DATE,
    AccountID INT,
    Note NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

-- Table for ImportDetail
CREATE TABLE ImportDetail (
	ImportDetailID INT PRIMARY KEY,
    ImportID INT,
    ProductLineID INT,
    Quantity INT,
    FOREIGN KEY (ImportID) REFERENCES Import(ImportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for Export
CREATE TABLE Export (
    ExportID INT PRIMARY KEY,
    ExportDate DATE,
    AccountID INT,
    Note NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

-- Table for ExportDetail
CREATE TABLE ExportDetail (
	ExportDetailID INT PRIMARY KEY,
    ExportID INT,
    ProductLineID INT,
    Quantity INT,
    FOREIGN KEY (ExportID) REFERENCES Export(ExportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for CheckingRequest
CREATE TABLE CheckingRequest (
    CheckingRequestID INT PRIMARY KEY,
    AccountID INT,
    ProductID INT,
    CheckDateRequest DATETIME,
    Reason NVARCHAR(MAX),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Table for Report
CREATE TABLE Report (
    ReportID INT PRIMARY KEY,
    ProductLineID INT,
    StockQuantity INT,
    CheckedQuantity INT,
    CheckedDate DATE,
    Reason NVARCHAR(MAX),
    AccountID INT,
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);
