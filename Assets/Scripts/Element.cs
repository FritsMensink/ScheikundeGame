using UnityEngine;
using System.Collections;

public class Element {
    public int AtomischNummer;
    public string Afkorting;
    public string Naam;
    public double AtomischeZwaarte;
    // eventueel lijst met aantal electronen toevoegen om periodiek systeem goed te tonen
    //public List<int> Electronen;

    //boolean om te weten of vmbo-leerlingen deze stof uit hun hoofd moeten kennen
    public bool LeerstofVmbo;

    //x en y coordinaten voor de plek in het periodiek systeem
    public int x;
    public int y;

    public enum Metaal
    {
        Metalloïde, NietMetaal, Halogeen, Edelgas, Alkalimetaal, Aardalkalimetaal, Lanthanide, Actinide, Overgangsmetaal, PostTransitionMetaal
    }

    public Metaal MetaalSoort;

	public Element(int nummer, string afk, string naam, double zwaarte, int x, int y, Metaal soort, bool vmbo = false)
    {
        AtomischNummer = nummer;
        Afkorting = afk;
        Naam = naam;
        AtomischeZwaarte = zwaarte;
        this.x = x;
        this.y = y;
        MetaalSoort = soort;
        LeerstofVmbo = vmbo;
    }
}
