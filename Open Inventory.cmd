@echo off
setlocal
set "InventoryApp=%~dp0artifacts\desktop\InvventoryServices.exe"
if not exist "%InventoryApp%" (
    echo The updated app has not been built yet.
    echo Run: dotnet publish "%~dp0InvventoryServices\InvventoryServices.csproj" -c Release --self-contained false -o "%~dp0artifacts\desktop"
    pause
    exit /b 1
)
start "" /D "%~dp0artifacts\desktop" "%InventoryApp%"
