-- Creates missing tables without deleting data or inserting demo accounts.
-- InventoryDB may belong to another system; keep this database separate.
IF DB_ID(N'InvventoryServicesDB') IS NULL
    EXEC(N'CREATE DATABASE [InvventoryServicesDB]');
GO
USE [InvventoryServicesDB];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(200) NOT NULL,
        Email NVARCHAR(320) NOT NULL UNIQUE,
        PasswordHash VARBINARY(32) NOT NULL,
        PasswordSalt VARBINARY(16) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END;

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(200) NOT NULL,
        Category NVARCHAR(200) NULL,
        SKU NVARCHAR(100) NULL,
        CurrentStock INT NOT NULL DEFAULT 0,
        MinStock INT NOT NULL DEFAULT 0,
        Price DECIMAL(18,2) NOT NULL DEFAULT 0,
        Location NVARCHAR(200) NULL,
        Remarks NVARCHAR(500) NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        UpdatedAt DATETIME2 NULL
    );
    CREATE INDEX IX_Products_SKU ON dbo.Products(SKU);
    CREATE INDEX IX_Products_Category ON dbo.Products(Category);
    CREATE INDEX IX_Products_Location ON dbo.Products(Location);
END;

IF OBJECT_ID(N'dbo.ProductBatches', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ProductBatches (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ProductId INT NOT NULL,
        BatchNo NVARCHAR(100) NULL,
        Qty INT NOT NULL DEFAULT 0,
        UnitCost DECIMAL(18,2) NOT NULL DEFAULT 0,
        ExpiryDate DATETIME2 NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CONSTRAINT FK_ProductBatches_Products FOREIGN KEY(ProductId)
            REFERENCES dbo.Products(Id) ON DELETE CASCADE
    );
    CREATE INDEX IX_ProductBatches_ProductId ON dbo.ProductBatches(ProductId);
    CREATE INDEX IX_ProductBatches_ExpiryDate ON dbo.ProductBatches(ExpiryDate);
END;

IF OBJECT_ID(N'dbo.InventoryTransfers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InventoryTransfers (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(200) NOT NULL,
        Quantity INT NOT NULL,
        FromLocation NVARCHAR(100) NOT NULL,
        ToLocation NVARCHAR(100) NOT NULL,
        Remarks NVARCHAR(500) NULL,
        TransferDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
    CREATE INDEX IX_InventoryTransfers_TransferDate ON dbo.InventoryTransfers(TransferDate);
END;

IF OBJECT_ID(N'dbo.InventoryAdjustments', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InventoryAdjustments (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ProductId INT NOT NULL,
        ProductName NVARCHAR(200) NOT NULL,
        Category NVARCHAR(100) NULL,
        SKU NVARCHAR(100) NULL,
        AdjustmentType NVARCHAR(50) NOT NULL,
        Quantity INT NOT NULL,
        Reason NVARCHAR(200) NULL,
        Notes NVARCHAR(500) NULL,
        AdjustedBy NVARCHAR(100) NULL,
        AdjustedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CONSTRAINT FK_InventoryAdjustments_Products FOREIGN KEY(ProductId)
            REFERENCES dbo.Products(Id)
    );
    CREATE INDEX IX_InventoryAdjustments_ProductId ON dbo.InventoryAdjustments(ProductId);
    CREATE INDEX IX_InventoryAdjustments_AdjustedAt ON dbo.InventoryAdjustments(AdjustedAt);
END;

IF OBJECT_ID(N'dbo.RecentTransactions', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.RecentTransactions (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Type NVARCHAR(100) NULL,
        Description NVARCHAR(1000) NULL,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END;

IF OBJECT_ID(N'dbo.StockSummaries', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.StockSummaries (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        SummaryDate DATE NOT NULL,
        TotalProducts INT NULL,
        TotalStock INT NULL,
        LowStockCount INT NULL,
        TotalValue DECIMAL(18,2) NULL,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END;

IF OBJECT_ID(N'dbo.BatchSummaries', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BatchSummaries (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        SummaryDate DATE NOT NULL,
        TotalBatches INT NULL,
        ExpiringSoon INT NULL,
        ExpiredBatches INT NULL,
        TotalValue DECIMAL(18,2) NULL,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END;

COMMIT TRANSACTION;
PRINT 'InvventoryServicesDB setup complete. Open the app and register your account.';
GO
