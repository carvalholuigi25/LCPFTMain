@echo off
setlocal enableextensions
set "srvpth=%LCPFTWebsite%\Webapp\Server"

cls

if exist "%srvpth%" (
	cd "%srvpth%"
	dotnet run --launch-profile "LCPFavThingsWebsite.Server"
) else (
	echo The server "%srvpth%" has not been found!
)

exit /b %errorlevel%
endlocal