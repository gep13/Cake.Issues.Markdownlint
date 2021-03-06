#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context, 
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Issues.Markdownlint",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Issues.Markdownlint",
    appVeyorAccountName: "cakecontrib",
    shouldGenerateDocumentation: false,
    shouldRunCodecov: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    dupFinderExcludePattern: new string[] 
    { 
        BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Markdownlint.Tests/*.cs",
        BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Markdownlint.Tests/LogFileFormat/*.cs",
        BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Markdownlint*/**/*.AssemblyInfo.cs"
    },
    testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Cake.Issues]* -[Cake.Issues.Testing]* -[Shouldly]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
