[xml]$props = Get-Content -Path "./props.xml"

[Version]$version = $props.Project.PropertyGroup.Version

$version = [Version]::New($version.Major, $version.Minor, $version.Build + 1)

$props.Project.PropertyGroup.Version = "$version"

$stringWriter = New-Object System.IO.StringWriter 
$xmlWriter = New-Object System.XMl.XmlTextWriter $stringWriter 
$xmlWriter.Formatting = "indented" 
$xmlWriter.Indentation = 1
$xmlWriter.IndentChar = "`t"
$props.WriteContentTo($xmlWriter)

$xmlWriter.Flush()
$stringWriter.Flush() 

Set-Content -Path "./props.xml" $stringWriter.ToString()

Write-Host version is changed to $version