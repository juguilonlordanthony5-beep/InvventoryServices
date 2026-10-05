# Project database

The app uses SQL Server Express on this computer (`.\SQLEXPRESS`) and the
`InvventoryServicesDB` database, with Windows authentication. Login, registration,
and inventory screens all use the shared connection in `DatabaseService`.

## First use

1. Run `Setup Database.cmd` to create the database and missing tables.
2. Run `Open Inventory.cmd` to open the published app.
3. Click **Register** and choose your own name, email, and password.
4. Log in with that email and password, then add your products.

No default password or demo inventory is created. Passwords are saved as salted
hashes. Running setup again preserves existing tables and records; it does not
migrate an incompatible schema.

The database contains Users, Products, ProductBatches, InventoryTransfers,
InventoryAdjustments, RecentTransactions, StockSummaries, and BatchSummaries.
The separate existing `InventoryDB` database is not used or modified.

## Viewing the database

In SQL Server Management Studio, connect to `.\SQLEXPRESS` with Windows
Authentication, then expand **Databases > InvventoryServicesDB > Tables**.

## Another SQL Server

Run `InvventoryServices/sql/create_inventory_db.sql` against that server first.
Set the `INVENTORYDB_CONNECTION` environment variable before starting the app to
override its default connection. For example, in PowerShell:

```powershell
$env:INVENTORYDB_CONNECTION = 'Data Source=YOURSERVER\SQLEXPRESS;Initial Catalog=InvventoryServicesDB;Integrated Security=True;TrustServerCertificate=True;'
& '.\Open Inventory.cmd'
```

The Windows account running the application must have access to the database.
The bundled setup is for a local SQL Express server. Use a trusted server
certificate for production connections.

## Rebuild after source changes

```powershell
dotnet publish InvventoryServices/InvventoryServices.csproj -c Release --self-contained false -o artifacts/desktop
```
