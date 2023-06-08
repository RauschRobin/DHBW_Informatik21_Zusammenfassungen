using System;
using System.Collections.Generic;
using System.IO;

namespace SpanningTreeAufgabe_Robin_Rausch_Semester4
{
    public class Parser
    {
        //Die Funktion readData() gibt eine Liste an Knoten zurück. Hierfür wird die angegebene Datei eingelesen und die genannten Knoten erstellt.
        public List<Knoten> readData(string filename)
        {
            List<Knoten> knotenList = new List<Knoten>();
            string fullPath;
            if(!filename.Contains("/") && !filename.Contains("\\"))
            {
                fullPath = Directory.GetCurrentDirectory() + "/" + filename;
            }
            else
            {
                fullPath = filename;
            }

            //Wenn die Datei nicht gefunden werden kann, erscheint eine Fehlermeldung und dass Programm wird beendet!
            if (!File.Exists(fullPath)){
                Console.WriteLine("Die Datei existiert nicht! Bitte geben sie den gesamten Dateipfad an.");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            try
            {
                var lines = File.ReadAllLines(fullPath);
                //Zuerst alle Knoten hinzufügen
                foreach (string line in lines)
                {
                    //Wenn Kommentar, dann überspringen
                    if (line.Contains("//"))
                    {
                        continue;
                    }
                    //Hinzufügen der Knoten
                    else if (line.Contains("=")){
                        string[] parts = line.Replace(" ", "").Replace(";", "").Split('=');
                        knotenList.Add(parseToKnoten(parts));
                    }
                }
                //Und dann alle Nachbarn laden. Sonst könnten einige Verbindungen fehlerhaft geladen werden!
                foreach (string line in lines)
                {
                    //Wenn Kommentar, dann überspringen
                    if (line.Contains("//"))
                    {
                        continue;
                    }
                    //Hinzufügen der Kanten
                    else if (line.Contains(":"))
                    {
                        string[] parts = line.Replace(" ", "").Replace(";", "").Split(':');
                        string[] verbindungen = parts[0].Split('-');
                        foreach (Knoten knoten in knotenList)
                        {
                            if (knoten.getKnotenName() == verbindungen[0])
                            {
                                addNachbarKnoten(knoten, verbindungen[1], Convert.ToInt32(parts[1]));
                            }
                        }
                        foreach (Knoten knoten in knotenList)
                        {
                            if (knoten.getKnotenName() == verbindungen[1])
                            {
                                addNachbarKnoten(knoten, verbindungen[0], Convert.ToInt32(parts[1]));
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                //Wenn ein Fehler aufgetreten ist, soll eine Fehlermeldung ausgegeben werden
                Console.WriteLine("Etwas ist schief gelaufen! Bitte prüfen sie ihre Eingabe und versuchen Sie es erneut.");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(-1);
            }

            return knotenList;
        }

        //parseToKnoten erstellt eine neue Instanz des Objektes Knoten und gibt diese zurück
        private Knoten parseToKnoten(string[] parts)
        {
            return new Knoten(parts[0], Convert.ToInt32(parts[1]));
        }

        //addNachbarKnoten setzt die Nachbarn der zuvor erstellten Knoten
        private void addNachbarKnoten(Knoten von, string zu, int kosten)
        {
            von.setLinkList(zu, kosten);
        }
    }
}
