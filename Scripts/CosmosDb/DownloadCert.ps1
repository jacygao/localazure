# Define parameters for downloading the certificate
$downloadParams = @{
    Uri                  = 'https://localhost:8081/_explorer/emulator.pem'
    Method               = 'GET'
    OutFile              = 'emulatorcert.crt'
    SkipCertificateCheck = $True
}

# Try to download the certificate
try {
    Write-Host "Downloading certificate from $($downloadParams.Uri)..."
    Invoke-WebRequest @downloadParams -ErrorAction Stop
    Write-Host "Certificate downloaded successfully."
}
catch {
    Write-Host "Error downloading certificate: $_" -ForegroundColor Red
    exit 1
}

# Check if the certificate file exists before importing
if (Test-Path 'emulatorcert.crt') {
    Write-Host "Certificate file found, proceeding with import..."
    
    # Define parameters for importing the certificate
    $importParams = @{
        FilePath           = 'emulatorcert.crt'
        CertStoreLocation  = 'Cert:\CurrentUser\Root'
    }

    try {
        Import-Certificate @importParams -ErrorAction Stop
        Write-Host "Certificate imported successfully."
    }
    catch {
        Write-Host "Error importing certificate: $_" -ForegroundColor Red
        exit 1
    }
}
else {
    Write-Host "Certificate file not found. Import operation aborted." -ForegroundColor Red
    exit 1
}