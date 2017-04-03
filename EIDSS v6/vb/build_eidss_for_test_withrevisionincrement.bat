call "C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\sdkvars.bat"
msbuild EIDSS_Build.proj /target:Build /property:Configuration=Release /p:Platform="Any CPU";TestBuild=true;IncrementBuildVersion=false
pause