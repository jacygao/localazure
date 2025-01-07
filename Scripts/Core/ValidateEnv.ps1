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
