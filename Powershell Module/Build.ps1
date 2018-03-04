properties {
  $global:config = "release"  
}

$VerbosePreference = "Continue"
. ".\BuildLibrary.ps1"

Task default -depends Deploy

Task Test -depends Compile, Clean {
  
  'Executed Test!'
}

Task Compile -depends Clean, UpdateAssemblyInfos {
  xcopy "$(Get-SourceModuleFolder)" "$(Get-BuildModuleFolder)" /e /q /y /i
  Exec { & "$(Get-MsbuildExe)" "$(Get-LibraryProjectPath)" /t:Build /p:Configuration=Release }  
  'Executed Compile!'
}

Task Clean {
  rd -Path "$(Get-ArtifactsFolder)" -recurse -force  -ErrorAction SilentlyContinue | out-null
  rd -Path "$(Get-BuildFolder)" -recurse -force  -ErrorAction SilentlyContinue | out-null
  'Executed Clean!'
}

Task CompileSetup -depends Test, UpdateModuleManifest {
    Exec { & "$(Get-MsbuildExe)" "$(Get-SetupProjectPath)" /t:Build /p:Configuration=Release /p:Platform=x86 }
    Exec { & "$(Get-MsbuildExe)" "$(Get-SetupProjectPath)" /t:Build /p:Configuration=Release /p:Platform=x64 }
    Exec { & "$(Get-MsbuildExe)" "$(Get-SetupBootstrapperProjectPath)" /t:Build /p:Configuration=Release }
}

Task Deploy -depends CompileSetup {
    Write-Verbose "Copy: '$(Get-BuildModuleFolder)' -> '$(Get-ArtifactsModuleFolder)'"
    Exec { xcopy "$(Get-BuildModuleFolder)" "$(Get-ArtifactsModuleFolder)" /e /q /y /i }
    Exec { copy "$(Get-SetupBootStrapperExe)" "$(Get-ArtifactsFolder)\" }
    "Executed Deploy!"
}

Task UpdateModuleManifest -depends Test {
    $moduleInfo = @{
        Path = "$(Get-BuildModuleManifestPath)"
        ModuleVersion = "$(Get-AssemblyVersion)"
        Author = "$(Get-Authors)"
        CompanyName = "$(Get-CompanyName)"
        Copyright = "$(Get-Copyright)"
        FunctionsToExport = @($(Get-FunctionsToExport))
    }
    Update-ModuleManifest @moduleInfo    
    "Executed UpdateModuleManifest!"
}

Task UpdateVersion {    
    $xml = [xml](Get-Content "$(Get-VersionXml)")            
    $xml.version.property[2].value = "$([System.DateTime]::Now.ToString('yy'))$([System.DateTime]::Now.DayOfYear.ToString('000'))"
    $xml.version.property[3].value = "$([System.Convert]::ToInt32($xml.version.property[3].value) + 1)"
    $xml.Save($versionXml)    
    "$updateVersionMessage $($xml.version.property[0].value).$($xml.version.property[1].value).$($xml.version.property[2].value).$($xml.version.property[3].value)"
    'Executed UpdateVersion!'
}

Task UpdateAssemblyInfos {
    $assemblyInfo = @{
        Path = "$(Get-SourceFolder)\_S_LibraryProjectName_S_\Properties\AssemblyInfo.cs"
        Description = "$(Get-Description)"
        Company = "$(Get-CompanyName)"
        Product = "$(Get-ModuleName)"
        Copyright = "$(Get-Copyright)"
        CLSCompliant = $true
        InformationalVersion="$(Get-AssemblyVersion).$(Get-RevisionHash)"
        Version="$(Get-AssemblyVersion)"
        FileVersion="$(Get-AssemblyVersion)"
    }    
    Update-AssemblyInfo @assemblyInfo
    'Executed UpdateAssemblyInfos!'
}


Task ? -Description "Helper to display task info" {
  Write-Documentation
}