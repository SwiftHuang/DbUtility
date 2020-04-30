del nupkgs /Q
dotnet pack --output nupkgs -c Release
dotnet nuget push nupkgs\*.nupkg -s http://10.100.133.83:8130/ -k wtl 
