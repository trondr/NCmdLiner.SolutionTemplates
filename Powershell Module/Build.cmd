@Echo Off
Call "%~dp0tools\psake\psake.cmd" -buildFile '%~dp0build.ps1'
Set exitCode=%ErrorLevel%
EXIT /B %exitCode%