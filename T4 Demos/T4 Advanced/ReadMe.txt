Demo Contents (require T4 Toolbox installed):
--------------
Advanced1 : Custom file changes to T4 processing with T4ScriptFileGenerator
	- Run any arbitrary code on file change
	- Use "Host." when hostSpecific=true
	- Watch out for Advanced1.txt renames!
Advanced2 : Generate classes based on generator-separated .txt file contents
	- Note: the T4ScriptFileGenerator is not required, but then the .txt changes are not reflected automatically
Advanced3 : Separating reading from immediate generation with class-structure
Advanced4 : Separating explicitly declared intermediate structure reading and generating
Advanced5 : Adding property declaration for intermediate structure and generation
	- Adding also GenerateUsings() to support namespace using declarations