Abstraction Common Submodule
----------------------------
- Common includes for T4 handling
- Visual Studio 2010 specific projects for now
- First submodule tests

Usage:
Copy the RootProjectSupportCommand-directory contents to the main repository root
- Make folder "Abstractions" below the main root project
- Execute either "gitaddabstractionbase.cmd" or with SSH depending if you want authorized-modified version or not
(Note: for base only applies to people with valid checkin rights to the base)
- Execute "unzipdefaultcontent.cmd"; requires unzip command in path that recognizes -d option for extraction


OLD INFORMATION TO BE CHECKED FOR VALIDITY:

Usage (for read-only cloning):
git submodule add git://github.com/abstractiondev/abscommon Demos/ProjectStatusReportingDemo/Abstractions/abscommon

Updating all the read-only submodules:
git submodule foreach git pull origin master


Usage (for updating repositories):
git submodule add git@github.com:abstractiondev/abscommon Demos/ProjectStatusReportingDemo/Abstractions/abscommon

git submodule update --init

Updating submodules:
git submodule foreach git pull

Modifying submodules:


cd abscommon
git checkout master
<Do your editing>
git commit --all -m "Lots of fixes"
cd ..

git add abscommon
git commit -m "Bumped up the revision of abscommon"
REM git push origin master
==> It seems this didn't work; Git Extension's push worked; so the parameters
==> need to be checked.
