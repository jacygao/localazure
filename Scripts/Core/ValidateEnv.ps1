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
        Write-Host $container
        do {
            $status = (docker container inspect -f '{{.State.Status}}' $container)
            Start-Sleep -Seconds 5
        } while ($status -ne 'running')
    }
    Write-Host "All containers are started."
    
    # Run the specified script
    Write-Host "All containers are started. Install CosmosDB Certificate..."
    .\Scripts\CosmosDb\InstallCert.ps1
    
} else {
    Write-Host "Docker is not installed."
}
