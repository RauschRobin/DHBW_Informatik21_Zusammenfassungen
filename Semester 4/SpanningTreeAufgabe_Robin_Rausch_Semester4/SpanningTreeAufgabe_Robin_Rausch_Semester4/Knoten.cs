using System;
using System.Collections.Generic;

namespace SpanningTreeAufgabe_Robin_Rausch_Semester4
{
    public class Knoten
    {
        private string knotenName;
        private int knotenId;
        List<TreeLink> linkList = new List<TreeLink>();
        private string nextHop;
        private int root;
        private int kostenZuRoot;

        //Jeder Knoten stellt eine Instanz dieser Klasse dar
        public Knoten(string knotenName, int knotenId)
        {
            //Initialisierung/Erstellung eines neuen Knotens
            setKnotenName(knotenName);
            setKnotenId(knotenId);
            setRoot(knotenId);
            setKostenZuRoot(0);
        }

        //Setzen der Nachbarn
        public void setLinkList(string nachbarKnoten, int kosten)
        {
            linkList.Add(new TreeLink(nachbarKnoten, kosten));
        }

        //Getter aller Nachbarn
        public List<TreeLink> getLinkList()
        {
            return linkList;
        }

        //Getter des Knotennamens
        public string getKnotenName()
        {
            return knotenName;
        }

        //Setter des Knotennamens
        private void setKnotenName(string knotenName)
        {
            this.knotenName = knotenName;
        }

        //Getter der KnotenId
        public int getKnotenId()
        {
            return knotenId;
        }

        //Setter der KnotenId
        private void setKnotenId(int knotenId)
        {
            this.knotenId = knotenId;
        }

        //Getter des NextHop
        public string getNextHop()
        {
            return nextHop;
        }

        //Setter des NextHop
        public void setNextHop(string nextHop)
        {
            this.nextHop = nextHop;
        }

        //Getter
        public int getRoot()
        {
            return root;
        }

        //Setter
        public void setRoot(int root)
        {
            this.root = root;
        }

        //Getter
        public int getKostenZuRoot()
        {
            return kostenZuRoot;
        }

        //Setter
        public void setKostenZuRoot(int kostenZuRoot)
        {
            this.kostenZuRoot = kostenZuRoot;
        }
    }
}
