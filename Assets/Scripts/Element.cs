using UnityEngine;
using System.Collections;

public class Element {
    public int AtomischNummer;
    public string Afkorting;
    public string Naam;
    public double AtomischeZwaarte;
    // eventueel lijst met aantal electronen toevoegen om periodiek systeem goed te tonen
    //public List<int> Electronen;

    //boolean voor metaal, eventueel veranderen naar een type (niet-metalen, halogenen, edelgassen, etc)
    public bool Metaal;

    //boolean om te weten of vmbo-leerlingen deze stof uit hun hoofd moeten kennen
    public bool LeerstofVmbo;
    
	public Element(int nummer, string afk, string naam, double zwaarte)
    {
        AtomischNummer = nummer;
        Afkorting = afk;
        Naam = naam;
        AtomischeZwaarte = zwaarte;
    }
}
