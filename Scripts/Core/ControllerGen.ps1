# Prompt user for paths
$openApiSpecPath = Read-Host -Prompt "Enter the path to the OpenAPI spec file"
$outputPath = Read-Host -Prompt "Enter the desired output path for the generated controllers"

# Check if NSwag is installed
if (-not (Get-Command nswag -ErrorAction SilentlyContinue)) {
    Write-Host "NSwag is not installed. Installing NSwag CLI..."
    dotnet tool install -g NSwag.ConsoleCore
}

# Run NSwag to generate controllers
Write-Host "Generating controllers from OpenAPI spec..."
nswag openapi2cscontroller /input:$openApiSpecPath /output:$outputPath

# Check if the file was generated
if (Test-Path $outputPath) {
    Write-Host "Controllers generated successfully: $outputPath"
} else {
    Write-Host "Failed to generate controllers."
}
