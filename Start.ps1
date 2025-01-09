#!/usr/bin/env pwsh

# Validate the environment
try {
    ./Scripts/Core/ValidateEnv.ps1
} catch {
    Write-Host "Environment validation failed."
    exit 1
}

Start the application
try {
    dotnet run --project ./Gateway/Gateway.AppHost/Gateway.AppHost.csproj
} catch {
    Write-Host "Failed to start the application."
    exit 1
}
