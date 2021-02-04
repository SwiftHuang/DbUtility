del *.nupkg /Q
nuget Pack -Build -Properties Configuration=Release
nuget push *.nupkg -Source http://10.100.133.83:8130/ wtl
@pause