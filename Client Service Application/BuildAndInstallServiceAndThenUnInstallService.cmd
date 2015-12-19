@ECHO OFF
call UnInstallService.cmd
@Echo Building...
call Build.cmd
@Echo Installing service...
call InstallService.cmd
Echo Press any key to uninstall service...
pause
call UnInstallService.cmd

