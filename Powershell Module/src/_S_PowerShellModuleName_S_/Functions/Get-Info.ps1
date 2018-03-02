function Get-Info
{
	   <#
    .SYNOPSIS
    Get info example function.
    
    .DESCRIPTION
    Get info about computer
    
    .OUTPUTS
    System.Boolean.
    
    .EXAMPLE
    Get-Info -ComputerName 'pc01'
       
    #>
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        # The name of the computer to get info from.
        $ComputerName
    )
    
    Set-StrictMode -Version 'Latest'

    Use-CallerPreference -Cmdlet $PSCmdlet -Session $ExecutionContext.SessionState

    Write-Output "$($env:ComputerName):$($env:UserName)"
}