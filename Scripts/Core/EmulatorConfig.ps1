Write-Host "Configuring https for emulator... Please pay attention to prompts."
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 123456

dotnet dev-certs https --trust