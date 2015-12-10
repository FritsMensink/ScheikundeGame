using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeriodiekSysteem {
    public List<Element> Elementen;

    public PeriodiekSysteem()
    {
        //de lijst van elementen wordt aangemaakt, alle gegevens hier gevonden: http://www.ptable.com/?lang=nl
        Elementen = new List<Element>();
        Element Waterstof = new Element(1, "H", "Waterstof", 1.008);
        Elementen.Add(Waterstof);
        Element Helium = new Element(2, "He", "Helium", 4.002602);
        Elementen.Add(Helium);
        Element Lithium = new Element(3, "Li", "Lithium", 6.94);
        Elementen.Add(Lithium);
        Element Beryllium = new Element(4, "Be", "Beryllium", 9.0121);
        Elementen.Add(Beryllium);
        Element Boor = new Element(5, "B", "Boor", 10.81);
        Elementen.Add(Boor);
    }

}
