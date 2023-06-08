using System;

namespace SpanningTreeAufgabe_Robin_Rausch_Semester4
{
    public class TreeLink
    {
        private string nachbarKnoten;
        private int kosten;

        //Erstellung/Instanziierung der Nachbarknoten eines Knotens
        public TreeLink(string nachbarKnoten, int kosten)
        {
            setNachbarKnoten(nachbarKnoten);
            setKosten(kosten);
        }

        //Getter der Nachbarknoten
        public string getNachbarKnoten()
        {
            return nachbarKnoten;
        }

        //Setter der Nachbarknoten
        private void setNachbarKnoten(string nachbarKnoten)
        {
            this.nachbarKnoten = nachbarKnoten;
        }

        //Getter der Kosten
        public int getKosten()
        {
            return kosten;
        }

        //Setter der Kosten
        private void setKosten(int kosten)
        {
            this.kosten = kosten;
        }
    }
}
