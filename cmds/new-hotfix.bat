git checkout -b hotfix-%1 develop
./bump-version.bat %1
git commit -a -m "Bumped version number to %1"
