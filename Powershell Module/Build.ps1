properties {
  $testMessage = 'Executed Test!'
  $compileMessage = 'Executed Compile!'
  $cleanMessage = 'Executed Clean!'
  $updateVersionMessage = 'Executed UpdateVersion!'
  $baseFolder = Resolve-Path .
  $buildFolder = [System.IO.Path]::Combine($baseFolder, "build")
  $srcFolder = [System.IO.Path]::Combine($baseFolder,"src")
  $artifactsFolder = [System.IO.Path]::Combine($baseFolder,"artifacts")
  $global:config = "debug"
  $versionXml = Join-Path -Path $baseFolder -ChildPath "version.xml"
}

$VerbosePreference = "SilentlyContinue"

Task default -depends Deploy

Task Test -depends Compile, Clean {
  $testMessage
}

Task Compile -depends Clean {
  $compileMessage
}

Task Clean {
  rd -Path "$(Get-ArtifactsFolder)" -recurse -force  -ErrorAction SilentlyContinue | out-null  
  $cleanMessage
}

Task Deploy -depends Test,CompileModuleManifest {

    "Executed Deploy!"
}

Task CompileModuleManifest -depends Test {
    New-ModuleManifest -Path "$(Get-ModuleManifestPath)" -ModuleVersion "$(Get-AssemblyVersion)" -Guid "$(New-Guid)" -Author "$(Get-Authors)" -CompanyName "$(Get-CompanyName)" -Copyright "$(Get-Copyright)" -Description "$(Get-Description)" -DotNetFrameworkVersion "4.5.2" -PowerShellVersion "5.0" | Out-Null
    "Executed CompileModuleManifest!"
}

Task UpdateVersion {    
    $xml = [xml](Get-Content $versionXml)            
    $xml.version.property[2].value = "$([System.DateTime]::Now.ToString('yy'))$([System.DateTime]::Now.DayOfYear.ToString('000'))"
    $xml.version.property[3].value = "$([System.Convert]::ToInt32($xml.version.property[3].value) + 1)"
    $xml.Save($versionXml)    
    "$updateVersionMessage $($xml.version.property[0].value).$($xml.version.property[1].value).$($xml.version.property[2].value).$($xml.version.property[3].value)"
}

Task ? -Description "Helper to display task info" {
  Write-Documentation
}

###############################################################################
### Helper functions
###############################################################################

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
    $copyright = "Copyright � $(Get-CompanyName) $(Get-Year). All rights reserved."
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

function Get-ArtifactsModuleFolder
{
    Write-Verbose "Get-ArtifactsModuleFolder"
    $artifactsModuleFolder = [System.IO.Path]::Combine("$(Get-ArtifactsFolder)", "$(Get-ModuleName)", "$(Get-AssemblyVersion)")
    if([System.IO.Directory]::Exists($artifactsModuleFolder) -eq $false)
    {
        $dir = [System.IO.Directory]::CreateDirectory($artifactsModuleFolder)
    }
    Write-Verbose "ArtifactsModuleFolder=$artifactsModuleFolder"
    return $artifactsModuleFolder
}


function Get-ModuleManifestPath
{
    Write-Verbose "Get-ModuleManifestPath"
    $moduleManifestPath = [System.IO.Path]::Combine("$(Get-ArtifactsModuleFolder)", "$(Get-ModuleName).psd1")
    Write-Verbose "ModuleManifestPath=$moduleManifestPath"
    return $moduleManifestPath
}