@echo off
setlocal enableextensions
set "AndroidSdkDirectory=C:\android-sdk"
set "ANDROID_HOME=C:\android-sdk"
set "pthproj=C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp"
set "apkproj=%pthproj%\LCPFavThings\bin\Debug\net6.0-android\com.lcp.lcpfavthings.apk"

cls
call "%pthproj%\LCPFavThingsWApi\Scripts\clear_cache.bat"
cd "%pthproj%\LCPFavThings"

dotnet clean
REM dotnet build "%pthproj%\LCPFavThings" --configuration "Debug"
REM adb devices -l or adb get-serialno
dotnet build "%pthproj%\LCPFavThings\LCPFavThings.csproj" -c "Debug" -f net6.0-windows10.0.22000.0 --verbosity n
dotnet build "%pthproj%\LCPFavThings\LCPFavThings.csproj" -t:Run -f net6.0-android -p:_DeviceName=e05a2949 --verbosity n

pause
exit /b %errorlevel%
endlocal