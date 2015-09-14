@echo off

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
echo "%appveyor_build_version%" > build\%configuration%\VersionInfo.dat

echo Packing files...
cp src\bin\%configuration%\Gemini.exe build\%configuration%\Gemini.exe
rem 7z a build\%configuration%\Gemini.zip src\bin\%configuration%\*.exe

echo Adding files to Git
git config user.email "revam@users.noreply.github.com"
git config user.name "revam@users.noreply.github.com"
git config credential.helper store
echo "https://%access_token%:x-oauth-basic@github.com" > "%USERPROFILE%\.git-credentials"
git add -f build
@echo on
git commit -m "Add latest build from AppVeyor"
git push --verbose origin %appveyor_repo_branch%
