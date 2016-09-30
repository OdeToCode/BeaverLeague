pushd src\beaverleague.data
dotnet ef migrations add %1
dotnet ef database update
popd