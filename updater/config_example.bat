rem Linux Debian Autoapdater

color 0a
title Updating your Linux Debian Server...

rem Altes Log wird falls vorhanden einmal gesichert. Es ist immer EINE ältere Version des Logs verfügbar

if exist linux_update.LOG (
    ren linux_update.LOG linux_update.old.LOG
    goto run
) else (
    goto run
)

:run

rem Das ist die einzige Zeile die angepasst werden muss wenn du die Datei selber anlegst
rem root - Hier kommt der Name des jeweiligen Benutzers rein - ES MUSS SICH UM EINEN ADMINISTRATOR HANDELN
rem 192.168.0.1 - Hier kommt die IP deines Servers rein
rem 22 - Das ist der Port auf welchem der SSH-Zugriff erfolgen soll
rem passwort12345 - Hier kommt dein Passwort rein
call linux_debian_updater.bat root 192.168.0.1 22 passwort12345! > linux_update.LOG

title Ready!
rem Dieses Fenster wird in 30 Sekunden automatisch geschlossen!
timeout /t 30 /nobreak