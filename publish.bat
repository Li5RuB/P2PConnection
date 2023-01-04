dotnet publish -r linux-x64 --configuration Release

xcopy /E /I .\P2PConnect\bin\Release\net6.0\linux-x64\publish ..\P2PPublish 

cd ..\P2PPublish 

git add .

git commit -m "%Date%.%Time%"

git push

pause