#!/usr/bin/env pwsh

# Validate the environment
try {
    ./Scripts/Core/ValidateEnv.ps1
} catch {
    Write-Host "Environment validation failed."
    exit 1
}

# Set environment variables
$env:ASPNETCORE_URLS = "https://localhost:17027;http://localhost:15064"
$env:DOTNET_DASHBOARD_OTLP_ENDPOINT_URL = "https://localhost:21217"
$env:DOTNET_RESOURCE_SERVICE_ENDPOINT_URL = "https://localhost:22028"

# Start the application
try {
    ./Gateway/Gateway.AppHost/bin/Release/net8.0/Gateway.AppHost.exe
} catch {
    Write-Host "Failed to start the application."
    exit 1
}
