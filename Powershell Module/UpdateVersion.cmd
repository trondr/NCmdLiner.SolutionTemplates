@Echo Off
Call "%~dp0tools\psake\psake.cmd" -buildFile '%~dp0Build.ps1' -taskList 'UpdateVersion'
Set exitCode=%ErrorLevel%
EXIT /B %exitCode%