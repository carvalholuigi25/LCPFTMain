@echo off
setlocal enableextensions

cd "C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapi\LCPFavThingsWApi"
REM start chrome "https://10.0.2.2:5001/swagger"
dotnet run --launch-profile "LCPFavThingsWApi_AndroidEmu"

pause
exit /b %errorlevel%
endlocal