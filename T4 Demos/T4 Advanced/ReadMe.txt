Demo Contents (require T4 Toolbox installed):
--------------
Advanced1 : Custom file changes to T4 processing with T4ScriptFileGenerator
	- Run any arbitrary code on file change
	- Use "Host." when hostSpecific=true
	- Watch out for Advanced1.txt renames!
	- Output any content with this.GenerationEnvironment.Append
Advanced2 : Generate classes based on generator-separated .txt file contents
	- Note: the T4ScriptFileGenerator is not required, but then the .txt changes are not reflected automatically
Advanced3 : Separating reading from immediate generation with class-structure
Advanced4 : Separating explicitly declared intermediate structure reading and generating
Advanced5 : Adding property declaration for intermediate structure and generation
	- Adding also GenerateUsings() to support namespace using declarations
Advanced6_ADM : Toolchain supported process flow for "Advanced5"
	- XML Schema file is processed with T4 to provide serialization classes
	- Serialization classes are provided as .ttinclude
	- T4 generator gets serialization out-of-the-box and intermediate structure/model intellisense
