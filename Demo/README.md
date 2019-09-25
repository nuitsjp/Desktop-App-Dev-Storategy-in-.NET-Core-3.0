dotnet new sln
mkdir ModernWpfDemo
cd ModernWpfDemo
dotnet new wpf
dotnet sln ..\Demo.sln add ModernWpfDemo.csproj
dotnet run

dotnet publish -c Release -r win10-x64
dotnet publish -c Release -r win10-x64 /p:PublishSingleFile=true
dotnet publish -c Release -r win10-x64 /p:PublishSingleFile=true /p:PublishReadyToRun=true
dotnet publish -c Release -r win10-x64 /p:PublishSingleFile=true /p:PublishReadyToRun=true /p:PublishTrimmed=true

[Net.ServicePointManager]::SecurityProtocol = "tls12, tls11, tls" ; Invoke-WebRequest https://github.com/dgiagio/warp/releases/download/v0.3.0/windows-x64.warp-packer.exe -OutFile warp-packer.exe

.\warp-packer --arch windows-x64 --input_dir bin\Release\netcoreapp3.0\win10-x64\publish --exec ModernWpfDemo.exe --output ModernWpfDemo.exe

dotnet publish -c Release -r win10-x64 /p:PublishSingleFile=true /p:PublishReadyToRun=true --self-contained=false

https://www.hanselman.com/blog/MakingATinyNETCore30EntirelySelfcontainedSingleExecutable.aspx


https://github.com/dotnet/designs/blob/master/accepted/single-file/design.md#user-experience