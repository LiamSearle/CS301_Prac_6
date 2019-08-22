@echo off
rem batch file for making a Coco/R C# application - CSC 301 2016
if "%1" == "" goto missing
if not exist %1.atg goto badfile
coco %1.atg -options m %2 %3 %4 %5 %6
if errorlevel 1 goto badatg
rem del listing.txt
if not exist %1.cs goto stop
if not exist %1\*.cs goto short
csc %1.cs Parser.cs Scanner.cs Library.cs %1\*.cs > errors.txt
goto check
:short
csc %1.cs Parser.cs Scanner.cs Library.cs > errors.txt
:check
if errorlevel 1 goto errors
del errors.txt
echo Compiled %1.exe
goto stop
:errors
errors.txt
goto stop
:missing
echo No grammar file specified - use cmake ATGFile [options]
goto stop
:badfile
echo Cannot find %1.atg
goto stop
:badatg
listing.txt
:stop
