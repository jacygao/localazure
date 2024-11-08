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

    # Run docker-compose up
    Write-Host "Running 'docker-compose up'..."
    docker-compose up -d

    # Wait for all containers to start
    Write-Host "Waiting for containers to start..."
    $containers = docker compose ps -q
    
    foreach ($container in $containers) {
        $containerName = docker inspect -f '{{.Name}}' $container
        $containerName = $containerName.Trim('/') 

        # Display initial status
        Write-Host "$containerName starting" -NoNewline

        do {
            $status = (docker container inspect -f '{{.State.Status}}' $container)
            Start-Sleep -Seconds 1

            # Update status on the same line
            if ($status -ne 'running') {
                Write-Host "`r$containerName starting" -NoNewline
            }

        } while ($status -ne 'running')

        # Update final status to "started" in green
        Write-Host "`r$([char]27)[2K$containerName " -NoNewline
        Set-TextColor -color Green
        Write-Host "started" -NoNewline
        Set-TextColor -color White
        Write-Host ""
    }
    
    Write-Host "All containers are started."
    
    # Run the specified script
    Write-Host "Install CosmosDB Certificate..."
    .\Scripts\CosmosDb\InstallCert.ps1
    
} else {
    Write-Host "Docker is not installed."
}
