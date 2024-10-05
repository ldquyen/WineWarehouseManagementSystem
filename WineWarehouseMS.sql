create database WineWarehouseMS
use WineWarehouseMS
-- Table for User Account
CREATE TABLE Account (
    UserID VARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(50),
    Username VARCHAR(50),
    Password VARCHAR(50),
    Role INT -- 0: Staff, 1: Manager, 2: Admin
);

-- Table for Brewing Room
CREATE TABLE BrewingRoom (
    RoomID VARCHAR(50) PRIMARY KEY,
    RoomName NVARCHAR(50),
    Temperature INT, -- Range 7-18 for general, 5-12 for white wine, 12-19 for red wine
    Humidity INT,    -- Range 50-70%, ideal at 60%
    Note VARCHAR(MAX)
);

-- Table for Shelf
CREATE TABLE Shelf (
    ShelfID VARCHAR(50) PRIMARY KEY,
    RoomID VARCHAR(50),
    ShelfName NVARCHAR(50),
    MaxQuantity INT,
    UseQuantity INT,
    FOREIGN KEY (RoomID) REFERENCES BrewingRoom(RoomID)
);

-- Table for Category
CREATE TABLE Category (
    CategoryID VARCHAR(50) PRIMARY KEY,
    CategoryName NVARCHAR(50)
);

-- Table for Product
CREATE TABLE Product (
    ProductID VARCHAR(50) PRIMARY KEY,
    ProductName NVARCHAR(50),
    Description NVARCHAR(MAX),
    Origin VARCHAR(50),
    CategoryID VARCHAR(50),
    ProductDetailId VARCHAR(50),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

-- Table for ProductLine
CREATE TABLE ProductLine (
    ProductLineID VARCHAR(50) PRIMARY KEY,
    ProductID VARCHAR(50),
    Year INT,
    Alcohol INT,
    Capacity INT,
    Price MONEY,
    Quantity INT,
    ShelfID VARCHAR(50),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (ShelfID) REFERENCES Shelf(ShelfID)
);

-- Table for Import
CREATE TABLE Import (
    ImportID VARCHAR(50) PRIMARY KEY,
    ImportDate DATE,
    UserID VARCHAR(50),
    Note NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES Account(UserID)
);

-- Table for ImportDetail
CREATE TABLE ImportDetail (
    ImportID VARCHAR(50),
    ProductLineID VARCHAR(50),
    Quantity INT,
    FOREIGN KEY (ImportID) REFERENCES Import(ImportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for Export
CREATE TABLE Export (
    ExportID VARCHAR(50) PRIMARY KEY,
    ExportDate DATE,
    UserID VARCHAR(50),
    Note NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES Account(UserID)
);

-- Table for ExportDetail
CREATE TABLE ExportDetail (
    ExportID VARCHAR(50),
    ProductLineID VARCHAR(50),
    Quantity INT,
    FOREIGN KEY (ExportID) REFERENCES Export(ExportID),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID)
);

-- Table for CheckingRequest
CREATE TABLE CheckingRequest (
    CheckID VARCHAR(50) PRIMARY KEY,
    UserID VARCHAR(50),
    ProductID VARCHAR(50),
    CheckDateRequest DATETIME,
    Reason NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES Account(UserID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Table for Report
CREATE TABLE Report (
    ReportID VARCHAR(50) PRIMARY KEY,
    ProductLineID VARCHAR(50),
    StockQuantity INT,
    CheckedQuantity INT,
    CheckedDate DATE,
    Reason NVARCHAR(MAX),
    UserID VARCHAR(50),
    FOREIGN KEY (ProductLineID) REFERENCES ProductLine(ProductLineID),
    FOREIGN KEY (UserID) REFERENCES Account(UserID)
);
