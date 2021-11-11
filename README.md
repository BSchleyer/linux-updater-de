# linux-updater-de
Ein einfacher Updater mit Setupprogramm für Linux Debian über SSH von Windows

# Linux Updater

Das hier ist ein einfacher Updater für deinen Linux Debian Server

Hiermit kannst du nach einmaliger Einrichtung deinen Server schnell auf den neusten stand bringen ohne selber irgendwelche Befehle eingeben zu müssen sondern **nur** indem du eine **Datei öffnest**!

Alles andere übernimmt dieses Programm für dich


# Bevor du startest

Um dieses Programm ausführen zu können benötigst du eine **vollständige** als **Administrator** ausgeführte Installation vom SSH-Client **Putty**
[Du kannst es hier herunterladen](https://www.chiark.greenend.org.uk/~sgtatham/putty/latest.html)

# Einrichtung

Es gibt zwei Möglichkeiten das Programm für die Anwendung einzurichten.
Sobald du von Github den Ordner mit dem vollständigen Programm heruntergeladen und entpackt hast, befinden sich dort zwei Ordner:

- setup
- updater

## Automatische Einrichtung

Um die Startdatei automatisch generieren zu lassen benötigst du den Ordner **setup**. Darin musst du die **updater.exe ausführen** und anschließend die Aufforderungen in der Konsole ausführen.
Sobald du alle benötigten Informationen eingegeben hast wird automatisch eine Datei generiert und in den Ordner **setup** abgelegt mit der du die Updates starten kannst.

**Diese Datei musst du in den Verzeichnis *updater* verschieben damit das Programm einwandfrei funktioniert!**

Wenn du mehrere Server mit diesem Script updaten möchtest dann führe **updater.exe** mehrmals aus.

## Manuelle Einrichtung

Du kannst das Programm natürlich auch manuell einrichten.
Wenn du dich dafür entscheidest kannst du den Ordner **setup** ***ignorieren***.
Wenn du in den Ordner **updater** gehst findest du dort die Datei **config_example.bat**.

1. Kopiere diese Datei in den **selben Ordner** und benenne sie so wie du möchtest
2. **Öffne** die Datei mit einem Editor deine Wahl (beliebt sind Notepad++, Editor oder Visual Studio Code)
3. Gehe in **Zeile 31** und verändere die entsprechenden Parameter
	> root - Hier kommt der Benutzer rein mit dem sich das Programm anmelden soll. **Wichtig**: Dieser Benutzer muss über **Administratorrechte** auf dem Server auf dem das Update ausgeführt werden soll verfügen!

	> 192.168.0.1 - Hier kommt die **IP-Adresse** des Servers auf dem das Update ausgeführt werden soll.

	> 22 - Dabei handelt es sich um den SSH-Port des betroffenen Servers. **Normalerweise** ist es **22**, es kann jedoch **geändert** worden sein. Du solltest am besten wissen, über welchen Port du dich auf deinen Server verbinden kannst.

	> passwort12345! - Hier das **Passwort** eintragen damit das Programm sich mit dem Server verbinden kann.

# Nutzung

Einmal eingerichtet musst du um das Programm zu nutzen einfach die eingerichtete Startdatei (siehe Abschnitt Einrichtung) Datei im Ordner **updater** ausführen. Alles andere übernimmt das Programm.

# Logging

Damit man Fehler besser nachvollziehen kann und sogar vielleicht reparieren erstellt das Programm Logdateien welche im Verzeichnis **updater** gespeichert werden.
Um Speicherplatz zu sparen werden nur die Logdateien der letzten zwei Sitzungen gespeichert.
**Diese Datei werden nirgendwo übertragen und bleiben nur auf deinem Rechner!**
