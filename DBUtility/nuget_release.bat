del nupkgs /Q
nuget pack DBUtility.csproj -OutputDirectory nupkgs -Properties Configuration=Release
nuget push nupkgs\*.nupkg -Source http://10.100.133.83:8130/ -ApiKey wtl 