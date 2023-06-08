using System;
using System.Collections.Generic;

namespace SpanningTreeAufgabe_Robin_Rausch_Semester4
{
    public class Program
    {
        private static Parser _parser;
        private static List<Knoten> _knotenList;

        //Start des Programmes
        static void Main(string[] args)
        {
            //Wenn kein Parameter angegeben wurde, soll eine Fehlernachricht ausgegeben und das Programm beendet werden!
            if(args.Length == 0)
            {
                Console.WriteLine("Bitte geben sie einen Dateinamen mit den Protokolldaten als Parameter an!");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            //Einlesen der Daten geschieht im Parser. Die Funktion readData() gibt eine Liste an Knoten zurück.
            _parser = new Parser();
            _knotenList = _parser.readData(args[0]);

            // berechneTree soll so oft ausgeführt werden wie Knoten existieren
            for (int i = 0; i < _knotenList.Count; i++)
            {
                berechneTree();
            }

            Console.WriteLine("{");

            //Wenn mehr als zwei Roots existieren, soll eine Fehlermeldung ausgegeben und das Programm beendet werden!
            int counter = 0;
            int root_id = 0;
            while (true)
            {
                foreach (Knoten knoten in _knotenList)
                {
                    if (knoten.getKnotenId() == root_id)
                    {
                        counter++;
                    }
                }
                if (counter > 0)
                    break;
                root_id++;
            }
            if(counter != 1)
            {
                Console.WriteLine("Es wurden mehr oder weniger als 1 Root angegeben. Bitte überdenken Sie ihr Handeln.");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            // Zuletzt erfolgt die Ausgabe aller Ergebnisse:
            foreach (Knoten knoten in _knotenList)
            {
                if (knoten.getNextHop() == null)
                {
                    Console.WriteLine("\tRoot: " + knoten.getKnotenName());
                }
                else
                {
                    Console.WriteLine("\t" + knoten.getKnotenName() + " --- " + knoten.getNextHop());
                }
            }

            Console.WriteLine("}");
            Console.ReadKey(); 
        }

        //Die Funktion berechneTree setzt alle Verbindungen zu Nachbarknoten und ermittelt so den die besten Wege
        private static void berechneTree()
        {
            foreach (Knoten knoten in _knotenList)
            {
                foreach (TreeLink link in knoten.getLinkList())
                {
                    foreach (Knoten knoten2 in _knotenList)
                    {
                        if (link.getNachbarKnoten().Equals(knoten2.getKnotenName()))
                        {
                            if (knoten.getRoot() < knoten2.getRoot())
                            {
                                knoten2.setRoot(knoten.getRoot());
                                knoten2.setKostenZuRoot(knoten.getKostenZuRoot() + link.getKosten());
                                knoten2.setNextHop(knoten.getKnotenName());
                            }
                            else if (knoten.getRoot().Equals(knoten2.getRoot()))
                            {
                                if ((knoten.getKostenZuRoot() + link.getKosten()) < knoten2.getKostenZuRoot())
                                {
                                    knoten2.setKostenZuRoot(knoten.getKostenZuRoot() + link.getKosten());
                                    knoten2.setNextHop(knoten.getKnotenName());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
