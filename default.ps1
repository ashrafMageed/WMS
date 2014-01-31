Framework '4.0'

properties {
	$project = 'WMS'
	$configuration = 'Release'
	$src = resolve-path '.\src'
}

task default -depends Test

task Test -depends Compile {
	$xunitRunner = join-path $src "packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"
	& $xunitRunner $src\$project.UITests\bin\$configuration\$project.UITests.dll
	
	if ($lastexitcode -gt 0)
    {
        throw "{0} unit tests failed." -f $lastexitcode
    }
    if ($lastexitcode -lt 0)
    {
        throw "Unit test run was terminated by a fatal error."
    }
}

task Compile {
	exec { msbuild /t:clean /v:q /nologo /p:Configuration=$configuration $src\$project.sln}
	exec { msbuild /t:build /v:q /nologo /p:Configuration=$configuration $src\$project.sln}
}