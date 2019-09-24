dotnet new sln
mkdir ModernWpfDemo
cd ModernWpfDemo
dotnet new wpf
dotnet sln ..\Demo.sln add ModernWpfDemo.csproj
dotnet run