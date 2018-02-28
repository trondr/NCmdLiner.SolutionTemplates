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

    "Executed CompileModuleManifest!"
}

Task CompileModuleManifest -depends Test {
    New-ModuleManifest -Path "$(Get-ModuleManifestPath)" -ModuleVersion "$(Get-AssemblyVersion)" -Guid "$(New-Guid)" -Author "$(Get-Authors)" -CompanyName "$(Get-CompanyName)" -Copyright "$(Get-Copyright)" -Description "$(Get-Description)" -DotNetFrameworkVersion "4.5.2"
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

function Get-AssemblyVersion
{
    if([String]::IsNullOrWhiteSpace($global:AssemblyVersion) -eq $true)
    {
        $xml = [xml](Get-Content $versionXml)            
        $global:MajorVersion = "$($xml.version.property[0].value)"
        $global:MinorVersion = "$($xml.version.property[1].value)"
        $global:BuildVersion = "$($xml.version.property[2].value)"
        $global:RevisionVersion = "$($xml.version.property[3].value)"
        $global:AssemblyVersion = "$($global:MajorVersion).$($global:MinorVersion).$($global:BuildVersion).$($global:RevisionVersion)"
    }
    return $global:AssemblyVersion
}

function Get-BaseFolderPath
{
    $baseFolder = $PSScriptRoot
    return $baseFolder
}

function Get-ArtifactsFolder
{
    Join-Path -Path "$(Get-BaseFolderPath)" -ChildPath "artifacts"
}

function Get-ModuleName
{
    return "_S_PowerShellModuleName_S_"
}

function Get-Authors
{
    return "_S_Authors_S_"
}

function Get-CompanyName
{
    return "_S_CompanyName_S_"
}

function Get-Year
{
    $year = "_S_Year_S_"
    if($year -notmatch "\d{4}")
    {
        $year = [System.DateTime]::Now.Year - 1
    }
    $currentYear = [System.DateTime]::Now.Year
    if($year -lt $currentYear)
    {
        return "$year-$currentYear"
    }
    return $year
}
#TEST: Get-Year

function Get-Copyright
{
    return "Copyright © $(Get-CompanyName) $(Get-Year). All rights reserved."
}
#TEST: Get-Copyright

function Get-Description
{
    return "_S_ProductDescription_S_"
}

function Get-ArtifactsModuleFolder
{
    $artifactsModuleFolder = [System.IO.Path]::Combine("$(Get-ArtifactsFolder)", "$(Get-ModuleName)", "$(Get-AssemblyVersion)")
    if([System.IO.Directory]::Exists($artifactsModuleFolder) -eq $false)
    {
        [System.IO.Directory]::CreateDirectory($artifactsModuleFolder)
    }
    return $artifactsModuleFolder
}


function Get-ModuleManifestPath
{
    Join-Path -Path "$(Get-ArtifactsModuleFolder)" -ChildPath "$(Get-ModuleName).psd1"
}