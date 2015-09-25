git checkout -b release-%1 develop
./bump-version.bat %1
git checkout develop
git merge --no-ff release-%1
git commit -a -m "Bumped version number to %1"
