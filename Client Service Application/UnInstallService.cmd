@ECHO OFF
@Echo Installing service
sc stop "_S_ShortProductName_S_Service"
InstallUtil /uninstall "%~dp0bin\Release\_S_ServiceProjectName_S_\_S_ServiceProjectName_S_.exe"

