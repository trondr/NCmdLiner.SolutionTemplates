@ECHO OFF
Set ProductName=_S_ShortProductName_S_
Set SolutionName=_S_SolutionName_S_

IF EXIST "%VSDEVCMD%" goto Build
IF EXIST "%MSBUILDPATH%" goto Build
IF EXIST "%NET4XPATH%" goto Build

:VSEnv
Set VSDEVCMD=%VS140COMNTOOLS%VsDevCmd.bat
Echo Checking to see if Visual Studio 2015 is installed ("%VS140COMNTOOLS%")
IF NOT EXIST "%VSDEVCMD%" set BuildMessage="Visual Studio 2015 do not seem to be installed, trying MSBuild instead..." & goto MSBuildEnv
Echo Preparing build environment...
call "%VSDEVCMD%"

:MSBuildEnv
Set MSBUILDPATH=%ProgramFiles(x86)%\MSBuild\14.0\Bin
Echo Checking to see if MSBuild is installed ("%MSBUILDPATH%")
IF NOT EXIST "%MSBUILDPATH%" set BuildMessage="Neither Visual Studio 2015 or MSBuild  seem to be installed. Terminating." & goto End
Set Path=%Path%;%MSBUILDPATH%

:NetEnv
Set NET4XPATH=%windir%\Microsoft.NET\Framework64\v4.0.30319
Echo Checking to see if .NET 4.x is installed ("%NET4XPATH%")
IF NOT EXIST "%NET4XPATH%" set BuildMessage=".NET 4.x does not seem to be installed. Terminating." & goto End
Set Path=%Path%;%NET4XPATH%

:Build
Echo Building %ProductName%...
nuget.exe restore %SolutionName%.sln
msbuild.exe %SolutionName%.build %1 %2 %3 %4 %5 %6 %7 %8 %9
Set BuildErrorLevel=%ERRORLEVEL%
IF %BuildErrorLevel%==0 Set BuildMessage=Sucessfully build %ProductName%
IF NOT %BuildErrorLevel% == 0 Set BuildMessage=Failed to build %ProductName%

:End
Echo %BuildMessage%
