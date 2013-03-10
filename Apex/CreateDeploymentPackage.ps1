[IO.Directory]::SetCurrentDirectory((Convert-Path (Get-Location -PSProvider FileSystem)))

# Create deployment folder structure.
New-Item -path '.\Deploy' -type directory -force
New-Item -path '.\Deploy\Core' -type directory -force
New-Item -path '.\Deploy\Legacy' -type directory -force
New-Item -path '.\Deploy\Legacy\WPF .NET 3.5' -type directory -force
New-Item -path '.\Deploy\Legacy\WinForms .NET 3.5' -type directory -force
New-Item -path '.\Deploy\Legacy\WP7 Windows Phone 7.0' -type directory -force
New-Item -path '.\Deploy\Legacy\WP7 Windows Phone 7.1' -type directory -force
New-Item -path '.\Deploy\Legacy\Silverlight 4' -type directory -force
New-Item -path '.\Deploy\Extensions' -type directory -force
New-Item -path '.\Deploy\Extensions\Snippets' -type directory -force
New-Item -path '.\Deploy\Extensions\Wizards' -type directory -force

# Copy over the core binaries.
Copy-Item -Path '.\Core\Apex\bin\Release\*.*' -Destination '.\Deploy\Core' -Force
Copy-Item -Path '.\Core\Apex.Silverlight\bin\Release\*.*' -Destination '.\Deploy\Core' -Force
Copy-Item -Path '.\Core\Apex.WinForms\bin\Release\*.*' -Destination '.\Deploy\Core' -Force
Copy-Item -Path '.\Core\Apex.WP7\bin\Release\*.*' -Destination '.\Deploy\Core' -Force

# Copy over the item templates.
Copy-Item -Path '.\Extensions\ItemTemplates\WPF\ApexModelItemTemplate\bin\Release\ItemTemplates' -Destination '.\Deploy\Extensions' -Force -Recurse
Copy-Item -Path '.\Extensions\ItemTemplates\WPF\ApexViewAndViewModelItemTemplate\bin\Release\ItemTemplates' -Destination '.\Deploy\Extensions' -Force -Recurse
Copy-Item -Path '.\Extensions\ItemTemplates\WPF\ApexViewItemTemplate\bin\Release\ItemTemplates' -Destination '.\Deploy\Extensions' -Force -Recurse
Copy-Item -Path '.\Extensions\ItemTemplates\WPF\ApexViewModelItemTemplate\bin\Release\ItemTemplates' -Destination '.\Deploy\Extensions' -Force -Recurse
Copy-Item -Path '.\Extensions\ItemTemplates\WPF\SingletonItemTemplate\bin\Release\ItemTemplates' -Destination '.\Deploy\Extensions' -Force -Recurse

# Copy over the project templates.
Copy-Item -Path '.\Extensions\ProjectTemplates\Silverlight\ZuneStyleApplicationTemplate\bin\Release\ProjectTemplates\CSharp\1033\ZuneStyleApplicationTemplate.zip' -Destination '.\Deploy\Extensions\ProjectTemplates\CSharp\1033\SilverlightZuneStyleApplicationTemplate.zip' -Force -Recurse
Copy-Item -Path '.\Extensions\ProjectTemplates\WPF\ZuneStyleApplicationTemplate\bin\Release\ProjectTemplates\CSharp\1033\ZuneStyleApplicationTemplate.zip' -Destination '.\Deploy\Extensions\ProjectTemplates\CSharp\1033\WPFZuneStyleApplicationTemplate.zip' -Force -Recurse

# Copy over the snippets.
Copy-Item -Path '.\Extensions\Snippets\*.snippet' -Destination '.\Deploy\Extensions\Snippets' -Force

# Copy over the wizards.
Copy-Item -Path '.\Extensions\ApexWizards\bin\Release\ApexWizards.dll' -Destination '.\Deploy\Extensions\Wizards' -Force

# Copy over the legacy projects.
Copy-Item -Path '.\Deploy\Legacy\WPF .NET 3.5' -Destination '.\Deploy\Legacy\WPF .NET 3.5' -Force