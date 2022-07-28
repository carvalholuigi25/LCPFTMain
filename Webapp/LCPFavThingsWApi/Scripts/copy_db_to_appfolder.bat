@echo off
setlocal enableextensions
set "pthfiles=/sdcard/Android/data/com.lcp.lcpfavthings/files"
set "pthdb=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp\LCPFavThingsWApi\Data\SQLite\lcpfavthingsdb.db"

REM adb kill-server
REM adb start-server

adb shell rm -rf "%pthfiles%" || true
adb shell mkdir "%pthfiles%"
adb push "%pthdb%" "%pthfiles%/"

pause
exit /b %errorlevel%
endlocal