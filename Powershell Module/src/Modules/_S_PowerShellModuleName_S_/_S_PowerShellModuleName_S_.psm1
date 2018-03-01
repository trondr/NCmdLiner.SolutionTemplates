$VerbosePreference = "Continue"

function Get-ModuleFolder
{
    Write-Verbose "Get-ModuleFolder"
    $moduleFolder = $PSScriptRoot
    Write-Verbose "ModuleFolder=$moduleFolder"
    return $moduleFolder
}

function Get-ModuleName
{
    Write-Verbose "Get-ModuleName"
    $moduleName = "_S_PowerShellModuleName_S_"
    Write-Verbose "ModuleName=$($moduleName)"
    return $moduleName
}

function Get-FuctionsFolder
{
    Write-Verbose "Get-FuctionsFolder"
    $fuctionsFolder = [System.IO.Path]::Combine("$(Get-ModuleFolder)", "Functions")
    Write-Verbose "fuctionsFolder=$fuctionsFolder"
    return $fuctionsFolder
}

Get-ChildItem -Path "$(Get-FuctionsFolder)" -Filter '*.ps1' | 
                    ForEach-Object {
                        Write-Verbose ("Importing function '$($_.FullName)'.")
                        . $_.FullName | Out-Null
                    }
