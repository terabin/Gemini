@echo off
:: Print path
pwd

:: Restore and comy packages
echo "Restoring packages"
powershell nuget restore
powershell copy-item -path packages -destination src -recurse

:: Build the executable
echo "Starting build"
msbuild "Gemini.sln" /verbosity:minimal /logger:"%programfiles%\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"

echo "Moving executable"
::Write-out
mkdir build
mkdir build\%configuration%
powershell add-content "build\$env:configuration\VersionInfo.dat" [System.Reflection]AssemblyName.GetAssemblyName("src\bin\$env:configuration\Gemini.exe").Version

echo "Packing files..."
7z a myapp.zip %APPVEYOR_BUILD_FOLDER%\bin\*.dll

echo "Adding built files to Repo"
git config --global credential.helper store
powershell add-content "$env:USERPROFILE\.git-credentials" "https://$($env:access_token):x-oauth-basic@github.com`n"
git add builds
git commit -m "Add latest build from AppVeyor"
git push origin/%APPVEYOR_REPO_BRANCH% %APPVEYOR_REPO_BRANCH%
