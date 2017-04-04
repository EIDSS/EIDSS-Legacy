rd /S /Q out
mkdir out
xcopy bin\debug out /E /EXCLUDE:copyToOutExclude.txt >> list.txt
copy Scripts\hmisAll.sql out >> list.txt