# Function to set text color in the console
function Set-TextColor {
    param (
        [ConsoleColor]$color
    )
    $Host.UI.RawUI.ForegroundColor = $color
}

# Check if Docker is installed
if (Get-Command docker -ErrorAction SilentlyContinue) {
    Write-Host "Docker is installed."
    
    # Check if Docker daemon is running by inspecting the Docker version
    $dockerInfo = docker info 2>&1
    if($dockerInfo -like "*error during connect*") {
        Write-Host "Docker daemon is not running."
        Exit 1
    }
    Write-Host "Docker daemon is running"
} else {
    Write-Host "Docker is not installed."
}

# Check if .NET SDK is installed and the version is >= 8.0.0
$dotnetVersion = $null
if (Get-Command dotnet -ErrorAction SilentlyContinue) {
    $dotnetVersion = dotnet --version
    if ($dotnetVersion -ge "8.0.0") {
        Write-Host ".NET SDK version $dotnetVersion is installed."
    } else {
        Write-Host "Installed .NET SDK version is less than 8.0.0."
        Write-Host "Please download the latest version of .NET SDK from: https://dotnet.microsoft.com/en-us/download/dotnet"
        Exit 1
    }
} else {
    Write-Host ".NET SDK is not installed."
    Write-Host "Please download and install .NET SDK from: https://dotnet.microsoft.com/en-us/download/dotnet"
    Exit 1
}