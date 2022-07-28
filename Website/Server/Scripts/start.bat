@echo off
setlocal enableextensions
@REM set "srvpth=%LCPFTWebsite%\Server"
set "srvpth=C:\Users\%username%\Documents\Visual Studio 2022\Projects\LCPFTMain\Website\Server"

cls

if exist "%srvpth%" (
	cd "%srvpth%"
	dotnet run --launch-profile "LCPFavThingsWebsite.Server"
) else (
	echo The server "%srvpth%" has not been found!
)

exit /b %errorlevel%
endlocal