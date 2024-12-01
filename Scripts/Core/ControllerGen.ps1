# Prompt user for paths
$openApiSpecPath = "./Specifications"
$outputPath = "./Core/Emulator/Controllers"

# Check if NSwag is installed
if (-not (Get-Command nswag -ErrorAction SilentlyContinue)) {
    Write-Host "NSwag is not installed. Installing NSwag CLI..."
    dotnet tool install -g NSwag.ConsoleCore
}

# Get all subdirectories in the OpenAPI spec path
$specDirectories = Get-ChildItem -Directory -Path $openApiSpecPath

# Get all files in the subdirectory
$specFiles = Get-ChildItem -File -Path $inputPath

# Loop through each subdirectory and generate controllers
foreach ($file in $specFiles) {
    $fileName = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    $controllerName = "{0}Controller.cs" -f ($fileName.Substring(0,1).ToUpper() + $fileName.Substring(1))
    $outputFilePath = Join-Path $outputDir $controllerName

    # Run NSwag to generate controller
    Write-Host "Generating controller from OpenAPI spec in $file.FullName..."
    nswag openapi2cscontroller /input:$file.FullName /output:$outputFilePath

    # Check if the file was generated
    if (Test-Path $outputFilePath) {
        Write-Host "Controller generated successfully: $outputFilePath"
    } else {
        Write-Host "Failed to generate controller for $file.FullName."
    }
}