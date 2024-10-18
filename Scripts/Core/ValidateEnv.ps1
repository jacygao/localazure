# Check if Docker is installed
if (Get-Command docker -ErrorAction SilentlyContinue) {
    Write-Host "Docker is installed."
    
    # Check if Docker daemon is running by inspecting the Docker version
    try {
        docker version -f "{{.Server.Version}}" > $null
        Write-Host "Docker daemon is running."

        # Run docker-compose up
        Write-Host "Running 'docker-compose up'..."
        docker-compose up -d

        # Wait for all containers to start
        Write-Host "Waiting for containers to start..."
        $containers = docker-compose ps -q
        foreach ($container in $containers) {
            do {
                $status = (docker inspect -f '{{.State.Health.Status}}' $container)
                Start-Sleep -Seconds 5
            } while ($status -ne 'healthy')
        }

        # Run the specified script
        Write-Host "All containers are started. Running the script './Scripts/CosmosDb/DownloadCert.ps1'..."
        .\Scripts\CosmosDb\DownloadCert.ps1

    } catch {
        Write-Host "Docker daemon is not running."
    }
} else {
    Write-Host "Docker is not installed."
}
