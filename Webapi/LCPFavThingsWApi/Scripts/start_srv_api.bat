@echo off
setlocal enableextensions

set ASPNETCORE_ENVIRONMENT=Development
set SGBDServiceMode=sqlserver
cd "C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapi\LCPFavThingsWApi"
start chrome "https://localhost:5001/swagger"
dotnet run --launch-profile "LCPFavThingsWApi"

pause
exit /b %errorlevel%
endlocal