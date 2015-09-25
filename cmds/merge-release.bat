git checkout master
git merge --no-ff release-%1
git tag -a %1
git branch -d release-%1
