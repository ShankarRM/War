dotnet restore
dotnet build
dotnet test .\GeekTrust.War.Test -v n --no-build --no-restore
dotnet run --project .\GeekTrust.War\GeekTrust.War.csproj


