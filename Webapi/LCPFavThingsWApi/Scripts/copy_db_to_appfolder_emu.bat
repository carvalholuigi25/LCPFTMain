@echo off
setlocal enableextensions
set "pthfiles=/data/data/com.lcp.lcpfavthings/files"
set "pthdb=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapi\LCPFavThingsWApi\Data\SQLite\lcpfavthingsdb.db"

cd "%ANDROID_HOME%\emulator"
REM emulator -avd Pixel_2_API_31
REM adb kill-server
REM adb start-server
adb root

adb shell rm -rf "%pthfiles%" || true
adb shell mkdir "%pthfiles%"
adb push "%pthdb%" "%pthfiles%/"

pause
exit /b %errorlevel%
endlocal