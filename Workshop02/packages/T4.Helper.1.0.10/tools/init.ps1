param($installPath, $toolsPath, $package)

foreach ($_ in Get-Module | ?{$_.Name -eq 'T4.Helper'})
{
    Remove-Module 'T4.Helper'
}

Import-Module (Join-Path $toolsPath T4.Helper.psm1)
