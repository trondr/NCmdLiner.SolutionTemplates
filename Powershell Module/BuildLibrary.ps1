function Get-SignToolExe
{
    Write-Verbose "Get-SignToolExe"
    $programFilesx86 = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFilesX86);
    $programFiles = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFiles);    
    $fileList = [System.Collections.ArrayList]@()
    $fileList += [System.IO.Path]::Combine($programFilesx86,"Windows Kits","10","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFilesx86,"Windows Kits","8.1","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFilesx86,"Windows Kits","8.0","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFilesx86,"Microsoft SDKs","Windows","v7.0A","bin","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFiles,"Windows Kits","10","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFiles,"Windows Kits","8.1","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFiles,"Windows Kits","8.0","bin","x86","signtool.exe")
    $fileList += [System.IO.Path]::Combine($programFiles,"Microsoft SDKs","Windows","v7.0A","bin","signtool.exe")
    $delegate = [Func[string,bool]] { [System.IO.File]::Exists($args[0]) }
    $SignToolExe = [Linq.Enumerable]::First([string[]]$fileList, $delegate)
    Write-Verbose "SignToolExe=$SignToolExe"
    return $SignToolExe
}
#TEST:
Get-SignToolExe

function Get-SignDescription
{
    Write-Verbose "Get-SignDescription"
    $SignDescription = "_S_ProductDescription_S_"
    Write-Verbose "SignDescription=$SignDescription"
    return $SignDescription
}

function Get-TimeStampServer
{
    Write-Verbose "Get-TimeStampServer"
    $TimeStampServer = "http://timestamp.comodoca.com/authenticode;http://timestamp.verisign.com/scripts/timstamp.dll;http://timestamp.globalsign.com/scripts/timstamp.dll"
    Write-Verbose "TimeStampServer=$TimeStampServer"
    return $TimeStampServer
}

function Get-Sha1Thumbprint
{
    Write-Verbose "Get-Sha1Thumbprint"
    $Sha1Thumbprint = "F8B61231E99586AA6EBE6CA3B334C0BF4DCD2F56"
    Write-Verbose "Sha1Thumbprint=$Sha1Thumbprint"
    return $Sha1Thumbprint
}

function Get-LibrarySignFiles
{
    $fileList = [System.Collections.ArrayList]@()
    Get-ChildItem -Path "$(Get-BuildLibraryProjectFolder)" -Filter "*.dll" | %{ $fileList += $_.FullName} | Out-Null
    return $fileList
}
#TEST: Get-LibrarySignFiles | Format-Table

function Get-BuildLibraryProjectFolder
{
    Write-Verbose "Get-BuildLibraryProjectFolder"
    $BuildLibraryProjectFolder = [System.IO.Path]::Combine("$(Get-BuildFolder)","bin","Release","_S_LibraryProjectName_S_")
    Write-Verbose "BuildLibraryProjectFolder=$BuildLibraryProjectFolder"
    return $BuildLibraryProjectFolder
}


function Get-SetupBootStrapperExe
{
    Write-Verbose "Get-SetupBootStrapperExe"
    $SetupBootStrapperExe = [System.IO.Path]::Combine("$(Get-BuildFolder)","bin","Release","_S_SetupBootstrapperProjectName_S_","_S_SetupBootstrapperProjectName_S_.exe")
    Write-Verbose "SetupBootStrapperExe=$SetupBootStrapperExe"
    return $SetupBootStrapperExe
}

function Get-LibraryProjectPath
{
    Write-Verbose "Get-LibraryProjectPath"
    $LibraryProjectPath = [System.IO.Path]::Combine("$(Get-SourceFolder)","_S_LibraryProjectName_S_","_S_LibraryProjectName_S_.csproj")
    Write-Verbose "LibraryProjectPath=$LibraryProjectPath"
    return $LibraryProjectPath
}

function Get-SetupProjectPath
{
    Write-Verbose "Get-SetupProjectPath"
    $SetupProjectPath = [System.IO.Path]::Combine("$(Get-SourceFolder)","_S_SetupProjectName_S_","_S_SetupProjectName_S_.wixproj")
    Write-Verbose "SetupProjectPath=$SetupProjectPath"
    return $SetupProjectPath
}

function Get-SetupBootstrapperProjectPath
{
    Write-Verbose "Get-SetupBootstrapperProjectPath"
    $SetupBootstrapperProjectPath = [System.IO.Path]::Combine("$(Get-SourceFolder)","_S_SetupBootstrapperProjectName_S_","_S_SetupBootstrapperProjectName_S_.wixproj")
    Write-Verbose "SetupBootstrapperProjectPath=$SetupBootstrapperProjectPath"
    return $SetupBootstrapperProjectPath
}

function Get-SolutionPath
{
    Write-Verbose "Get-SolutionPath"
    $SolutionPath = [System.IO.Path]::Combine("$(Get-BaseFolderPath)","_S_SolutionName_S_.sln")
    Write-Verbose "SolutionPath=$SolutionPath"
    return $SolutionPath
}

function Get-MsbuildExe
{
    Write-Verbose "Get-MsbuildExe"
    $path = & "$(Get-VswhereExe)" -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
    if ($path) 
    {
      $MsbuildExe = join-path $path 'MSBuild\15.0\Bin\MSBuild.exe'      
    }
    if((Test-Path -Path $MsbuildExe) -eq $false)
    {
        throw "MSbuild.exe not found: $MsbuildExe"
    }
    Write-Verbose "MsbuildExe=$MsbuildExe"
    return $MsbuildExe
}
#Test: Get-MsbuildExe

function Get-VswhereExe
{
    Write-Verbose "Get-VswhereExe"
    $VswhereExe = [System.IO.Path]::Combine("$(Get-ToolsFolder)","vswhere","vswhere.exe")
    Write-Verbose "VswhereExe=$VswhereExe"
    return $VswhereExe
}

function Get-ToolsFolder
{
    Write-Verbose "Get-ToolsFolder"
    $ToolsFolder = [System.IO.Path]::Combine("$(Get-BaseFolderPath)","tools")
    Write-Verbose "ToolsFolder=$ToolsFolder"
    return $ToolsFolder
}

function Get-VersionXml
{
    Write-Verbose "Get-VersionXml"
    $VersionXml = [System.IO.Path]::Combine($(Get-BaseFolderPath),"version.xml")
    Write-Verbose "VersionXml=$VersionXml"
    return $VersionXml
}

function Get-AssemblyVersion
{
    Write-Verbose "Get-AssemblyVersion"
    if([String]::IsNullOrWhiteSpace($global:AssemblyVersion) -eq $true)
    {
        $xml = [xml](Get-Content -Path "$(Get-VersionXml)")
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
        [void]$sb.AppendLine("[assembly: AssemblyDescription(`"$($Description)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyCompany(`"$($Company)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyProduct(`"$($Product)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyCopyright(`"$($Copyright)`")]")
        [void]$sb.AppendLine("[assembly: CLSCompliant($($CLSCompliant.ToString().ToLower()))]")
        [void]$sb.AppendLine("[assembly: AssemblyInformationalVersion(`"$($InformationalVersion)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyVersion(`"$($Version)`")]")
        [void]$sb.AppendLine("[assembly: AssemblyFileVersion(`"$($FileVersion)`")]")
        $text = $sb.ToString()
        $text | Out-File -FilePath $Path
    }
    end{}
}