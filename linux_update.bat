set user=%~1
set ip=%~2
set port=%~3
set password=%~4

rem Putty-Verzeichnis wird aufgerufen
cd ..
cd tools
cd external
cd putty

echo y | plink -ssh %user%@%ip% -P %port% "exit"

rem Das eigentliche Update wird ausgeführt
rem apt update
plink.exe -ssh %user%@%ip% -P %port% -pw %password% -batch apt update -y

rem apt upgrade
plink.exe -ssh %user%@%ip% -P %port% -pw %password% -batch apt upgrade -y

rem apt autoremove
plink.exe -ssh %user%@%ip% -P %port% -pw %password% -batch apt autoremove -y

rem autoclean
plink.exe -ssh %user%@%ip% -P %port% -pw %password% -batch apt autoclean -y