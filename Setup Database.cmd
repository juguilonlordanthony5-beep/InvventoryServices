@echo off
setlocal
where sqlcmd >nul 2>&1
if errorlevel 1 (
    echo SQL Server command-line tools are required to run this setup.
    echo You can also run InvventoryServices\sql\create_inventory_db.sql in SQL Server Management Studio.
    pause
    exit /b 1
)
sqlcmd -S ".\SQLEXPRESS" -E -C -b -i "%~dp0InvventoryServices\sql\create_inventory_db.sql"
if errorlevel 1 (
    echo Setup failed. Check that SQL Express is running and your Windows account has permission.
    pause
    exit /b 1
)
echo Database is ready. Open Inventory.cmd starts the app. Use Register to create your account.
pause
