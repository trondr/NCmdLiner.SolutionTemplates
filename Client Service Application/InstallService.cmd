@ECHO OFF
@Echo Installing service
InstallUtil "%~dp0bin\Release\_S_ServiceProjectName_S_\_S_ServiceProjectName_S_.exe"
sc start "_S_ShortProductName_S_Service"

