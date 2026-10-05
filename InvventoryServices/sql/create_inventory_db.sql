-- SQL script to create a simple inventory database for the InvventoryServices project
-- Usage: run on your SQL Server (e.g., in SSMS). Adjust names, file locations, and permissions as required.

-- 1) Create database (optional) -------------------------------------------------
IF DB_ID(N'InvventoryServicesDB') IS NULL
BEGIN
    CREATE DATABASE InvventoryServicesDB;
END
GO

USE InvventoryServicesDB;
GO

-- 2) Create Products table -----------------------------------------------------
IF OBJECT_ID('dbo.Products','U') IS NOT NULL DROP TABLE dbo.Products;
CREATE TABLE dbo.Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    Category NVARCHAR(200) NULL,
    SKU NVARCHAR(100) NULL,
    CurrentStock INT NOT NULL DEFAULT(0),
    MinStock INT NOT NULL DEFAULT(0),
    Price DECIMAL(18,2) NOT NULL DEFAULT(0.00),
    Location NVARCHAR(200) NULL,
    Remarks NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL
);
GO

CREATE INDEX IX_Products_SKU ON dbo.Products(SKU);
CREATE INDEX IX_Products_Category ON dbo.Products(Category);
CREATE INDEX IX_Products_Location ON dbo.Products(Location);
GO

-- 3) Create InventoryTransfers table ------------------------------------------
-- Matches existing EnsureTransfersTable in application code
IF OBJECT_ID('dbo.InventoryTransfers','U') IS NOT NULL DROP TABLE dbo.InventoryTransfers;
CREATE TABLE dbo.InventoryTransfers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    Quantity INT NOT NULL,
    FromLocation NVARCHAR(100) NOT NULL,
    ToLocation NVARCHAR(100) NOT NULL,
    Remarks NVARCHAR(500) NULL,
    TransferDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

CREATE INDEX IX_InventoryTransfers_ProductName ON dbo.InventoryTransfers(ProductName);
CREATE INDEX IX_InventoryTransfers_TransferDate ON dbo.InventoryTransfers(TransferDate);
GO

-- 4) Create InventoryAdjustments table ---------------------------------------
-- Used to store adjustments / history for product stock
IF OBJECT_ID('dbo.InventoryAdjustments','U') IS NOT NULL DROP TABLE dbo.InventoryAdjustments;
CREATE TABLE dbo.InventoryAdjustments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    QuantityChange INT NOT NULL,
    AdjustmentType NVARCHAR(50) NOT NULL, -- e.g., 'StockIn','StockOut','Correction'
    Remarks NVARCHAR(500) NULL,
    AdjustmentDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    PerformedBy NVARCHAR(100) NULL,
    CONSTRAINT FK_InventoryAdjustments_Products FOREIGN KEY(ProductId) REFERENCES dbo.Products(Id) ON DELETE CASCADE
);
GO

CREATE INDEX IX_InventoryAdjustments_ProductId ON dbo.InventoryAdjustments(ProductId);
CREATE INDEX IX_InventoryAdjustments_AdjustmentDate ON dbo.InventoryAdjustments(AdjustmentDate);
GO

-- 5) Optional: Seed sample data -----------------------------------------------
-- Use bracketed identifiers to avoid conflicts with reserved words in some environments
INSERT INTO dbo.Products ([ProductName], [Category], [SKU], [CurrentStock], [MinStock], [Price], [Location], [Remarks])
VALUES
('Apple iPhone 14', 'Electronics', 'IP14-256GB', 12, 5, 499.99, 'Main Warehouse', 'Sample product'),
('USB-C Cable 1m', 'Accessories', 'USBC-1M', 50, 10, 3.50, 'Sales Floor', NULL),
('Milk 1L', 'Grocery', 'MILK-1L', 8, 10, 1.20, 'Cold Storage', 'Keep refrigerated'),
('Notebook A5', 'Stationery', 'NOTE-A5', 200, 50, 0.99, 'Storage Room', NULL);
GO

INSERT INTO dbo.InventoryTransfers ([ProductName], [Quantity], [FromLocation], [ToLocation], [Remarks])
VALUES
('USB-C Cable 1m', 10, 'Main Warehouse', 'Sales Floor', 'Replenish sales floor'),
('Milk 1L', 20, 'Cold Storage', 'Outlet', 'Restock outlet');
GO

INSERT INTO dbo.InventoryAdjustments ([ProductId], [QuantityChange], [AdjustmentType], [Remarks], [PerformedBy])
SELECT p.Id, -2, 'Sale', 'Sold via POS', 'system' FROM dbo.Products p WHERE p.SKU = 'IP14-256GB';
GO

-- 6) Example read queries -----------------------------------------------------
-- All low-stock products
SELECT [Id], [ProductName], [Category], [SKU], [CurrentStock], [MinStock], [Location]
FROM dbo.Products
WHERE [CurrentStock] <= [MinStock]
ORDER BY [ProductName]; 
-- Transfer history
SELECT TOP 100 * FROM dbo.InventoryTransfers ORDER BY TransferDate DESC;

-- Adjustment history for a product (replace @productId)
-- DECLARE @productId INT = 1;
-- SELECT * FROM dbo.InventoryAdjustments WHERE ProductId = @productId ORDER BY AdjustmentDate DESC;

-- End of script
