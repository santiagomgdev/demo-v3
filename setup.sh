#!/bin/bash

set -e

PROJECT_NAME="${1:-DemoV3}"

echo "Creating project: $PROJECT_NAME"
echo ""

# Create solution
dotnet new sln -n $PROJECT_NAME

# Create projects
dotnet new classlib -n Domain -o src/Domain
dotnet new classlib -n Contracts -o src/Contracts
dotnet new webapi -n Application -o src/Application
dotnet new classlib -n Infrastructure -o src/Infrastructure

# Add to solution
dotnet sln add src/Domain/Domain.csproj
dotnet sln add src/Contracts/Contracts.csproj
dotnet sln add src/Application/Application.csproj
dotnet sln add src/Infrastructure/Infrastructure.csproj

# Add references
dotnet add src/Application/Application.csproj reference src/Domain/Domain.csproj
dotnet add src/Application/Application.csproj reference src/Contracts/Contracts.csproj
dotnet add src/Application/Application.csproj reference src/Infrastructure/Infrastructure.csproj

dotnet add src/Infrastructure/Infrastructure.csproj reference src/Domain/Domain.csproj
dotnet add src/Infrastructure/Infrastructure.csproj reference src/Contracts/Contracts.csproj

# Create folders - Domain
mkdir -p src/Domain/Entities
mkdir -p src/Domain/Services
mkdir -p src/Domain/ValueObjects
mkdir -p src/Domain/Enums

# Create folders - Contracts
mkdir -p src/Contracts/Example
mkdir -p src/Contracts/Common
mkdir -p src/Contracts/External/Payment
mkdir -p src/Contracts/External/Notification
mkdir -p src/Contracts/External/Auth

# Create folders - Application
mkdir -p src/Application/Example/UseCases/CreateExample
mkdir -p src/Application/Data
mkdir -p src/Application/Common/Behaviours
mkdir -p src/Application/Common/Middleware
mkdir -p src/Application/Common/Filters
mkdir -p src/Application/Common/Extensions

# Create folders - Infrastructure
mkdir -p src/Infrastructure/Data/Configurations
mkdir -p src/Infrastructure/Data/Repositories
mkdir -p src/Infrastructure/Data/Migrations
mkdir -p src/Infrastructure/Legacy/Entities
mkdir -p src/Infrastructure/Legacy/Repositories
mkdir -p src/Infrastructure/Adapters
mkdir -p src/Infrastructure/Mappers
mkdir -p src/Infrastructure/Services
mkdir -p src/Infrastructure/ExternalServices/Http/Common
mkdir -p src/Infrastructure/ExternalServices/Grpc/Protos
mkdir -p src/Infrastructure/ExternalServices/Messaging/RabbitMQ
mkdir -p src/Infrastructure/ExternalServices/Messaging/Kafka
mkdir -p src/Infrastructure/ExternalServices/Messaging/Messages
mkdir -p src/Infrastructure/ExternalServices/Configuration

# Create folders - Tests
mkdir -p tests/Integration/Example
mkdir -p tests/Integration/ExternalServices/Mocks
mkdir -p tests/Unit/Domain/Services
mkdir -p tests/Unit/Application/Handlers
mkdir -p tests/Unit/Infrastructure/ExternalServices

# Install essential packages
echo "Installing essential packages..."

# Application
dotnet add src/Application/Application.csproj package FluentValidation
dotnet add src/Application/Application.csproj package FluentValidation.DependencyInjectionExtensions

# Infrastructure
dotnet add src/Infrastructure/Infrastructure.csproj package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add src/Infrastructure/Infrastructure.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
dotnet add src/Infrastructure/Infrastructure.csproj package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
dotnet add src/Infrastructure/Infrastructure.csproj package Microsoft.EntityFrameworkCore.Design --version 9.0.0

# Clean auto-generated files
rm -f src/Domain/Class1.cs
rm -f src/Contracts/Class1.cs
rm -f src/Infrastructure/Class1.cs

# Create .gitignore
cat > .gitignore << 'EOF'
# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
[Ww][Ii][Nn]32/
[Aa][Rr][Mm]/
[Aa][Rr][Mm]64/
bld/
[Bb]in/
[Oo]bj/
[Ll]og/
[Ll]ogs/

# Visual Studio / Rider
.vs/
.vscode/
.idea/
*.suo
*.user
*.userosscache
*.sln.docstates
*.sln.iml
*.rsuser

# NuGet
*.nupkg
*.snupkg
**/packages/*
*.nuget.props
*.nuget.targets
project.lock.json
project.fragment.lock.json
artifacts/

# Test Results
[Tt]est[Rr]esult*/
*.trx
*.coverage

# ASP.NET Core
**/appsettings.Development.json
**/appsettings.Local.json

# Database files
*.db
*.db-shm
*.db-wal

# OS files
.DS_Store
Thumbs.db
EOF

# Build
echo ""
echo "Building solution..."
dotnet restore
dotnet build

echo ""
echo "✓ Setup complete!"
echo ""
echo "Next steps:"
echo "  - Run optional-packages.sh to install MediatR, Serilog, etc."
echo "  - Update connection strings in src/Application/appsettings.json"
echo "  - Start coding your domain logic"
echo ""
