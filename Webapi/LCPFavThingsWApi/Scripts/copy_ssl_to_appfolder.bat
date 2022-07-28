@echo off
setlocal enableextensions
set "pthfiles=/sdcard"
set "pthdb=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapi\LCPFavThingsWApi\ssl"

REM adb shell rm -rf "%pthfiles%" || true
REM adb shell mkdir "%pthfiles%"

adb push "%pthdb%\lcpfavthings.key" "%pthfiles%"
adb push "%pthdb%\lcpfavthingsca.crt" "%pthfiles%"
adb push "%pthdb%\lcpfavthingsca.der.crt" "%pthfiles%"
adb push "%pthdb%\lcpfavthingsca.pem" "%pthfiles%"

pause
exit /b %errorlevel%
endlocal