@echo off
setlocal enableextensions

cd "C:\Users\Luis\Documents\Visual Studio 2022\Projects\LCPFTMain\Webapp\LCPFavThingsWApi\ssl"

REM Source: https://aboutssl.org/how-to-create-and-import-self-signed-certificate-to-android-device/
openssl genrsa -out lcpfavthings.key 2048
openssl req -new -days 3650 -key lcpfavthings.key -out lcpfavthingsca.pem
openssl x509 -req -days 3650 -in lcpfavthingsca.pem -signkey lcpfavthings.key -extfile ./android_options.txt -out lcpfavthingsca.crt
openssl x509 -inform PEM -outform DER -in lcpfavthingsca.crt -out lcpfavthingsca.der.crt

REM cd ../
REM adb root
REM adb push ssl/. /mnt/sdcard/
REM adb exit

pause
exit /b %errorlevel%
endlocal