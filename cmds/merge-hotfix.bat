git checkout master
git merge --no-ff hotfix-%1
git tag -a %1
git checkout develop
git merge --no-ff hotfix-%1
git branch -d hotfix-%1
