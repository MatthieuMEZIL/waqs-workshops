function GetAllT4RootItems($parent)
{
	$result = @()
	foreach ($value in $parent.ProjectItems)
	{
	    if ($value.Name.EndsWith(".tt"))
	    {
            $result = $result + $value
	    }
	    else
	    {
		    if ($value -ne $parent -and $value.Name -ne $null)
    		{
    			$result = $result + (GetAllT4RootItems($value))
    			$result = $result + (GetAllT4RootItems($value.SubProject))
    		}
		}
	}
	return $result
}

Export-ModuleMember GetAllT4RootItems

function RecursiveRunCustomTool($item)
{
    if ($item -ne $null)
    {
        $fileName = $item.Properties | ?{$_.Name -eq 'LocalPath'} | select -ExpandProperty Value
        Write-Host $fileName
        try
        {
            $item.Object.RunCustomTool()
        }
        catch
        {
            Write-Host $fileName + ' failed'
        }
        foreach ($subItem in $item.ProjectItems | ?{($_ -ne $null) -and ($_.Name.EndsWith(".tt"))})
        {
            RecursiveRunCustomTool $subItem
        }
    }
}


function RecursiveGeneration($file)
{
    $ttItem = $DTE.Solution.FindProjectItem($file)
    RecursiveRunCustomTool($ttItem)
}

Register-TabExpansion 'RecursiveGeneration' @{ 
'file' = { GetProjects | foreach {(GetAllT4RootItems $_)} | foreach {$_.Properties | ?{$_.Name -eq 'LocalPath'} | select -ExpandProperty Value} | Sort-Object };
}

Export-ModuleMember RecursiveGeneration


function TransformAllT4Templates()
{
    GetProjects | foreach {(GetAllT4RootItems $_)} | foreach {RecursiveRunCustomTool $_}
}

Export-ModuleMember TransformAllT4Templates