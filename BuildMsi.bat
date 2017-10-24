:: Color 0C
@echo For a newer version change the Program ID and Version Infos in the wxs file.
@echo ---------------------------------------------------------------------------
:: Color 07
@echo off
:: @set INPUT=
:: @set /P INPUT=Type Version (e.g. V1.2): %=%
echo on
Set ProgName=YouTubeDownloader
Set Wix3xPath=%ProgramFiles%\WiX Toolset v3.11\bin
"%Wix3xPath%\candle.exe" -nologo %ProgName%.wxs -out %ProgName%.wixobj -ext WixUtilExtension -ext WixUIExtension  -ext WixNetFxExtension
"%Wix3xPath%\light.exe" -nologo %ProgName%.wixobj -out %ProgName%.msi -ext WixUtilExtension -ext WixUIExtension  -ext WixNetFxExtension
pause

