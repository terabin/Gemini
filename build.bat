@echo off
:: Print path
pwd

:: Restore and comy packages
echo Restoring packages
powershell nuget restore
powershell copy-item -path packages -destination src -recurse

:: Build the executable
echo Starting build
msbuild "Gemini.sln" /verbosity:minimal /logger:"C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"

echo Moving executable
::Write-out
mkdir build
mkdir build\%configuration%
echo %appveyor_build_version% > build\%configuration%\VersionInfo.dat

echo Packing files...
7z a build\%configuration%\Gemini.zip %APPVEYOR_BUILD_FOLDER%\src\bin\*.exe

echo Adding built files to Git
git config credential.helper store
rem "https://$($env:access_token):x-oauth-basic@github.com" > "%USERPROFILE%\.git-credentials"
git add -f build
git commit -m "Add latest build from AppVeyor"
git push %APPVEYOR_REPO_BRANCH%