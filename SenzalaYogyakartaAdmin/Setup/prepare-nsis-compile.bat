@echo off
mkdir source
mkdir source\icon
del source\icon\* /Q
del source\* /Q
copy "..\bin\release\SenzalaYogyakartaManajemenSiswa.exe" source
copy "..\bin\release\MongoDB.Bson.dll" source
copy "..\bin\release\MongoDB.Driver.dll" source
mkdir source\icon
copy "..\bin\release\icon\capoeira-icon.ico" "source\icon\" 

