function Get-AssemblyVersion
{
    Write-Verbose "Get-AssemblyVersion"
    if([String]::IsNullOrWhiteSpace($global:AssemblyVersion) -eq $true)
    {
        $xml = [xml](Get-Content $versionXml)            
        $global:MajorVersion = "$($xml.version.property[0].value)"
        $global:MinorVersion = "$($xml.version.property[1].value)"
        $global:BuildVersion = "$($xml.version.property[2].value)"
        $global:RevisionVersion = "$($xml.version.property[3].value)"
        $global:AssemblyVersion = "$($global:MajorVersion).$($global:MinorVersion).$($global:BuildVersion).$($global:RevisionVersion)"
    }
    Write-Verbose "AssemblyVersion=$($global:AssemblyVersion)"
    return $global:AssemblyVersion
}

function Get-BaseFolderPath
{
    Write-Verbose "Get-BaseFolderPath"
    $baseFolderPath = $PSScriptRoot
    Write-Verbose "BaseFolderPath=$baseFolderPath"
    return $baseFolderPath
}

function Get-ArtifactsFolder
{
    Write-Verbose "Get-ArtifactsFolder"
    $artifactsFolder = [System.IO.Path]::Combine("$(Get-BaseFolderPath)","artifacts")
    Write-Verbose "ArtifactsFolder=$artifactsFolder"
    return $artifactsFolder
}

function Get-BuildFolder
{
    Write-Verbose "Get-BuildFolder"
    $buildFolder = [System.IO.Path]::Combine("$(Get-BaseFolderPath)","build")
    Write-Verbose "BuildFolder=$buildFolder"
    return $buildFolder
}

function Get-BuildModulesFolder
{
    Write-Verbose "Get-BuildModulesFolder"
    $buildModulesFolder = [System.IO.Path]::Combine("$(Get-BuildFolder)","Modules")
    Write-Verbose "BuildModulesFolder=$buildModulesFolder"
    return $buildModulesFolder
}


function Get-SourceFolder
{
    Write-Verbose "Get-SourceFolder"
    $sourceFolder = [System.IO.Path]::Combine("$(Get-BaseFolderPath)","src")
    Write-Verbose "SourceFolder=$sourceFolder"
    return $sourceFolder
}


function Get-ModuleName
{
    Write-Verbose "Get-ModuleName"
    $moduleName = "_S_PowerShellModuleName_S_"
    Write-Verbose "ModuleName=$($moduleName)"
    return $moduleName
}

function Get-Authors
{    
    Write-Verbose "Get-Authors"
    $authors = "_S_Authors_S_"
    Write-Verbose "Authors=$($authors)"
    return $authors
}

function Get-CompanyName
{
    Write-Verbose "Get-CompanyName"
    $companyName = "_S_CompanyName_S_"
    Write-Verbose "CompanyName=$($companyName)"
    return $companyName
}

function Get-Year
{
    Write-Verbose "Get-Year"
    $year = "_S_Year_S_"
    if($year -notmatch "\d{4}")
    {
        $year = [System.DateTime]::Now.Year - 1
    }
    $currentYear = [System.DateTime]::Now.Year
    if($year -lt $currentYear)
    {
        $year = "$year-$currentYear"
    }
    Write-Verbose "Year=$year"
    return $year
}
#TEST: Get-Year

function Get-Copyright
{    
    Write-Verbose "Get-Copyright"
    $copyright = "Copyright © $(Get-CompanyName) $(Get-Year). All rights reserved."
    Write-Verbose "Copyright=$copyright"
    return $copyright
}
#TEST: Get-Copyright

function Get-Description
{
    Write-Verbose "Get-Description"
    $description = "_S_ProductDescription_S_"
    Write-Verbose "Description=$description"
    return $description
}

function Get-ArtifactsModulesFolder
{
    Write-Verbose "Get-ArtifactsModulesFolder"
    $ArtifactsModulesFolder = [System.IO.Path]::Combine("$(Get-ArtifactsFolder)","Modules")
    Write-Verbose "ArtifactsModulesFolder=$ArtifactsModulesFolder"
    return $ArtifactsModulesFolder
}

function Get-ArtifactsModuleFolder
{
    Write-Verbose "Get-ArtifactsModuleFolder"
    $artifactsModuleFolder = [System.IO.Path]::Combine("$(Get-ArtifactsModulesFolder)", "$(Get-ModuleName)", "$(Get-AssemblyVersion)")
    if([System.IO.Directory]::Exists($artifactsModuleFolder) -eq $false)
    {
        $dir = [System.IO.Directory]::CreateDirectory($artifactsModuleFolder)
    }
    Write-Verbose "ArtifactsModuleFolder=$artifactsModuleFolder"
    return $artifactsModuleFolder
}

function Get-SourceModuleFolder
{
    Write-Verbose "Get-SourceModuleFolder"
    $sourceModuleFolder = [System.IO.Path]::Combine("$(Get-SourceFolder)", "$(Get-ModuleName)")
    Write-Verbose "SourceModuleFolder=$sourceModuleFolder"
    return $sourceModuleFolder
}

function Get-BuildModuleFolder
{
    Write-Verbose "Get-BuildModuleFolder"
    $BuildModuleFolder = [System.IO.Path]::Combine("$(Get-BuildModulesFolder)", "$(Get-ModuleName)")
    Write-Verbose "BuildModuleFolder=$BuildModuleFolder"
    return $BuildModuleFolder
}

function Get-ModuleManifestPath
{
    Write-Verbose "Get-ModuleManifestPath"
    $moduleManifestPath = [System.IO.Path]::Combine("$(Get-ArtifactsModuleFolder)", "$(Get-ModuleName).psd1")
    Write-Verbose "ModuleManifestPath=$moduleManifestPath"
    return $moduleManifestPath
}

function Get-SourceModuleManifestPath
{
    Write-Verbose "Get-SourceModuleManifestPath"
    $sourceModuleManifestPath = [System.IO.Path]::Combine("$(Get-SourceModuleFolder)", "$(Get-ModuleName).psd1")
    Write-Verbose "SourceModuleManifestPath=$sourceModuleManifestPath"
    return $sourceModuleManifestPath
}

function Get-BuildModuleManifestPath
{
    Write-Verbose "Get-BuildModuleManifestPath"
    $BuildModuleManifestPath = [System.IO.Path]::Combine("$(Get-BuildModuleFolder)", "$(Get-ModuleName).psd1")
    Write-Verbose "BuildModuleManifestPath=$BuildModuleManifestPath"
    return $BuildModuleManifestPath
}

function Get-FunctionsFolder
{
    Write-Verbose "Get-FunctionsFolder"
    $functionsFolder = [System.IO.Path]::Combine("$(Get-SourceModuleFolder)","Functions")
    Write-Verbose "FunctionsFolder=$($functionsFolder)"
    return $functionsFolder
}

function Get-FunctionsToExport
{
    Write-Verbose "Get-FunctionsToExport"
    $functionsToExport = [System.Collections.ArrayList]@()    
    Get-ChildItem -Path "$(Get-FunctionsFolder)" -Filter '*.ps1' | 
                    Where-Object { $_.Name -notmatch '-Private' } |
                    ForEach-Object {                        
                        $functionName = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
                        Write-Verbose ("Adding function $($functionName)") 
                        $functionsToExport.Add($functionName)
                        
                    }| Out-Null

    return $functionsToExport.ToArray()
}
#TEST: Get-FunctionsToExport

function Get-RevisionHash
{
    $RevisionHash = (git rev-parse HEAD).Substring(0,7)
    Write-Verbose "RevisionHash=$($RevisionHash)"
    return $RevisionHash
}
#TEST: Get-RevisionHash
function Update-AssemblyInfo
{
     [CmdletBinding(SupportsShouldProcess=$true)]
     param(
        [Parameter(Mandatory=$true)]
        [string]
        $Path,
        [Parameter(Mandatory=$true)]
        [string]
        $Description,
        [Parameter(Mandatory=$true)]
        [string]
        $Company,
        [Parameter(Mandatory=$true)]
        [string]
        $Product,
        [Parameter(Mandatory=$true)]
        [string]
        $Copyright,
        [Parameter(Mandatory=$true)]
        [string]
        $CLSCompliant,
        [Parameter(Mandatory=$true)]
        [string]
        $InformationalVersion,
        [Parameter(Mandatory=$true)]
        [string]
        $Version,
        [Parameter(Mandatory=$true)]
        [string]
        $FileVersion
     )   
    begin{}
    process
    {
        $sb = [System.Text.StringBuilder]::new()
        [void]$sb.AppendLine("//------------------------------------------------------------------------------")
        [void]$sb.AppendLine("// <auto-generated>")
        [void]$sb.AppendLine("//     This code was generated by a tool.")
        [void]$sb.AppendLine("//     Runtime Version: 4.0.30319.42000")
        [void]$sb.AppendLine("//")
        [void]$sb.AppendLine("//     Changes to this file may cause incorrect behavior and will be lost if")
        [void]$sb.AppendLine("//     the code is regenerated.")
        [void]$sb.AppendLine("// </auto-generated>")
        [void]$sb.AppendLine("//------------------------------------------------------------------------------")
        [void]$sb.AppendLine("")
        [void]$sb.AppendLine("using System;")
        [void]$sb.AppendLine("using System.Reflection;")
        [void]$sb.AppendLine("")
        [void]$sb.AppendLine("")
        [void]$sb.AppendLine("[assembly: AssemblyDescription(`"$($Description)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyCompany(`"$($Company)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyProduct(`"$($Product)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyCopyright(`"$($Copyright)`")]")
        [void]$sb.AppendLine("[assembly: CLSCompliant($($CLSCompliant))]")
        [void]$sb.AppendLine("[assembly: AssemblyInformationalVersion(`"$($InformationalVersion)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyVersion(`"$($Version)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyFileVersion(`"$($FileVersion)`")]")
        $text = $sb.ToString()
        $text | Out-File -FilePath $Path
    }
    end{}
}