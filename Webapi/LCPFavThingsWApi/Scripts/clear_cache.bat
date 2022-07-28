@echo off
setlocal enableextensions
set "pth1=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp\LCPFavThings"
set "pth2=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp\LCPFavThingsLib"
set "pth3=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapi\LCPFavThingsWApi"

if exist "%pth1%" (
	rmdir /s /q "%pth1%\bin"
	rmdir /s /q "%pth1%\obj"

	echo.
	echo Cleaned successfully of the bin and obj contents in project folder "%pth1%"
)

if exist "%pth2%" (
	rmdir /s /q "%pth2%\bin"
	rmdir /s /q "%pth2%\obj"
	
	echo.
	echo Cleaned successfully of the bin and obj contents in project folder "%pth2%"
)

if exist "%pth3%" (
	rmdir /s /q "%pth3%\bin"
	rmdir /s /q "%pth3%\obj"

	echo.
	echo Cleaned successfully of the bin and obj contents in project folder "%pth3%"
)

REM pause
exit /b %errorlevel%
endlocal