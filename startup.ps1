# Development Environment Startup Script
# Requirements: Podman installed and running

Write-Host "🚀 Starting Development Environment..." -ForegroundColor Cyan

# 1. Start Infrastructure
Write-Host "📦 Starting Podman containers..." -ForegroundColor Yellow
podman-compose -f deploy/podman-compose.yml up -d

# 2. Wait for SQL Database (Port 1433)
Write-Host "⏳ Waiting for SQL Database to be ready..." -ForegroundColor Yellow
while (!(Test-NetConnection -Port 1433 -ComputerName localhost)) {
    Write-Host "Waiting..."
    Start-Sleep -Seconds 2
}
Write-Host "✅ SQL Database is UP." -ForegroundColor Green

# 3. Wait for CosmosDB Emulator (Port 8081)
Write-Host "⏳ Waiting for CosmosDB Emulator to be ready..." -ForegroundColor Yellow
while (!(Test-NetConnection -Port 8081 -ComputerName localhost)) {
    Write-Host "Waiting..."
    Start-Sleep -Seconds 2
}
Write-Host "✅ CosmosDB Emulator is UP." -ForegroundColor Green

# 4. Launch App
Write-Host "🚀 Launching .NET Application..." -ForegroundColor Green
dotnet run --project ./src/TemplateProject/WebApi/WebApi.csproj

<EOF>