using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace setup
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablen
            string filename;
            string user;
            string ip;
            string port;
            string password;
            string currentPath = Directory.GetCurrentDirectory();

            //Abfragen um Variablen zu füllen
            Console.WriteLine("Herzlich Willkommen zum Setup von Linux Debian Updater!");
            Console.WriteLine("Dieses Programm wurde entwickelt von SpielenmitLili");
            Console.WriteLine("Es gilt die: GNU GENERAL PUBLIC LICENSE VERSION 3");
            Console.WriteLine("Lese alle Nachrichten in der Konsole genau und erfülle die um sicherzustellen, dass alles funktioniert!");

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Fangen wir mit dem Namen des Rechners an");
            Console.WriteLine("Bitte gib einen Wunschnamen für den Rechner an um den später untescheiden zu können und drücke ENTER");
            Console.WriteLine(" ");

            filename = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Ok. Die Datei wird " + filename + ".bat heißen!");

            Console.WriteLine(" ");

            Console.WriteLine("Als nächstes der Benutzername");
            Console.WriteLine("Bitte gib den Benutzernamen des Nutzers mit dem das Update ausgeführt werden soll und drücke auf ENTER");
            Console.WriteLine("WICHTIG: Der Nutzer MUSS Administratorrechte haben um das Update ausführen zu können!");
            Console.WriteLine(" ");

            user = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Super. Der Nutzer lautet: " + user);

            Console.WriteLine(" ");

            Console.WriteLine("So, dann ist die IP dran.");
            Console.WriteLine("Bitte gebe die IP deines Servers ein und drücke auf ENTER");
            Console.WriteLine(" ");

            ip = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Perfekt. Die IP " + ip + " wird verwendet um eine Verbindung mit dem Server herzustellen!");

            Console.WriteLine(" ");

            Console.WriteLine("Dann kommen wir zum Port");
            Console.WriteLine("Gebe den Port an mit dem die SSH-Verbindung aufgenommen werden soll und drücke auf ENTER");
            Console.WriteLine("Hinweis: In den meisten Fällen lautet der Port 22");
            Console.WriteLine(" ");

            port = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Gut gemacht. Der Port für den SSH-Zugriff wurde auf: " + port + " gesetzt!");

            Console.WriteLine(" ");

            Console.WriteLine("Dann kommen wir zum letzten. Passwort");
            Console.WriteLine("Bitte gebe das Passwort für den Nutzer " + user + "@" + ip + " und drücke auf ENTER");
            Console.WriteLine(" ");

            password = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("So, damit haben wir alles. Das Passwort lautet: " + password);

            Console.WriteLine(" ");
            Console.WriteLine("Die Datei wird nun generiert. Das dauert ein paar Augenblicke");

            Thread.Sleep(5000);

            //Hier wird die Datei erstellt
            using (StreamWriter generateFile = new StreamWriter(filename + ".bat"))
            {
                generateFile.WriteLine("rem THIS FILE WAS GENERATED AUTOMATICALLY");
                generateFile.WriteLine("rem Linux Debian Autoapdater");
                generateFile.WriteLine("color 0a");
                generateFile.WriteLine(" ");
                generateFile.WriteLine("rem Ein ganz altes Log wird entfernt falls vorhanden");
                generateFile.WriteLine(" ");
                generateFile.WriteLine("if exist linux_update.old.LOG (");
                generateFile.WriteLine("    del /q linux_update.old.LOG");
                generateFile.WriteLine("    goto renamelog");
                generateFile.WriteLine(") else (");
                generateFile.WriteLine("    goto renamelog");
                generateFile.WriteLine(")");
                generateFile.WriteLine(" ");
                generateFile.WriteLine(":renamelog");
                generateFile.WriteLine("rem Altes Log wird falls vorhanden einmal gesichert. Es ist immer EINE ältere Version des Logs verfügbar");
                generateFile.WriteLine(" ");
                generateFile.WriteLine("if exist linux_update.LOG (");
                generateFile.WriteLine("    ren linux_update.LOG linux_update.old.LOG");
                generateFile.WriteLine("    goto run");
                generateFile.WriteLine(") else (");
                generateFile.WriteLine("    goto run");
                generateFile.WriteLine(")");
                generateFile.WriteLine(" ");
                generateFile.WriteLine(":run");
                generateFile.WriteLine(" ");
                generateFile.WriteLine("call linux_debian_updater.bat " + user + " " + ip + " " + port + " " + password + " > linux_update.LOG");
                generateFile.WriteLine(" ");
                generateFile.WriteLine("title Ready!");
                generateFile.WriteLine("rem Dieses Fenster wird in 30 Sekunden automatisch geschlossen!");
                generateFile.WriteLine("timeout /t 30 /nobreak");
            }

            //Tempdatei zum Verschieben wird angelegt
            using (StreamWriter generateFileMove = new StreamWriter("moveFile_temp.bat"))
            {
                generateFileMove.WriteLine("cd ..");
                generateFileMove.WriteLine("move " + currentPath + "\\" + filename + ".bat %CD%\\updater\\");
            }

            //Datei wird in Unterverzeichnis verschoben indem die Tempfile ausgeführt wird
            Process moveThisFile;
            try
            {
                moveThisFile = new Process();
                moveThisFile.StartInfo.WorkingDirectory = currentPath;
                moveThisFile.StartInfo.FileName = "moveFile_temp.bat";
                moveThisFile.StartInfo.CreateNoWindow = true;
                moveThisFile.Start();
                moveThisFile.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //Die Tempfile wird gelöscht!
            File.Delete("moveFile_temp.bat");

            Console.WriteLine(" ");
            Console.WriteLine("Dateierstellung war erfolgreich! Datei " + filename + ".bat wurde im Ordner 'updater' abgelegt");

            Console.WriteLine("Um das Programm nutzen zu können führe die Datei " + filename + ".bat aus dem Ordner 'updater' darin einfach aus!");

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Thread.Sleep(5000);
            Console.WriteLine("Programm wurde beendet. Drücke beliebige Taste um zu schließen...");

            Console.ReadKey();
        }
    }
}
