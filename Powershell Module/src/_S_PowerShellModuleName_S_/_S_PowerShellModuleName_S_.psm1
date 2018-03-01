$VerbosePreference = "Continue"

function Get-ModuleFolder
{
    Write-Verbose "Get-ModuleFolder"
    $ModuleFolder = $PSScriptRoot
    Write-Verbose "ModuleFolder=$ModuleFolder"
    return $ModuleFolder
}

function Get-FuctionsFolder
{
    Write-Verbose "Get-FuctionsFolder"
    $FuctionsFolder = [System.IO.Path]::Combine("$(Get-ModuleFolder)", "Functions")
    Write-Verbose "FuctionsFolder=$FuctionsFolder"
    return $FuctionsFolder
}

Get-ChildItem -Path "$(Get-FuctionsFolder)" -Filter '*.ps1' | 
                    ForEach-Object {
                        Write-Verbose ("Importing function '$($_.FullName)'.")
                        . $_.FullName | Out-Null
                    }
