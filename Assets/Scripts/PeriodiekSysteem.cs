using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PeriodiekSysteem {
    //de lijst van elementen, alle gegevens hier gevonden: http://www.ptable.com/?lang=nl
    public static List<Element> Elementen = new List<Element>() {
        new Element(1, "H", "Waterstof", 1.008),
        new Element(2, "He", "Helium", 4.002602),
        new Element(3, "Li", "Lithium", 6.94),
        new Element(4, "Be", "Beryllium", 9.0121831),
        new Element(5, "B", "Boor", 10.81),
        new Element(6, "C", "Koolstof", 12.011),
        new Element(7, "N", "Stikstof", 14.007),
        new Element(8, "O", "Zuurstof", 15.999),
        new Element(9, "F", "Fluor", 18.998403163),
        new Element(10, "Ne", "Neon", 20.1797),
        new Element(11, "Na", "Natrium", 22.98976928),
        new Element(12, "Mg", "Magnesium", 24.305),
        new Element(13, "Al", "Aluminium", 26.9815385),
        new Element(14, "Si", "Silicium", 28.085),
        new Element(15, "P", "Fosfor", 30.973761998),
        new Element(16, "S", "Zwavel", 32.06),
        new Element(17, "Cl", "Chloor", 35.45),
        new Element(18, "Ar", "Argon", 39.948),
        new Element(19, "K", "Kalium", 39.0983),
        new Element(20, "Ca", "Calcium", 40.078),
        new Element(21, "Sc", "Scandiur", 44.955908),
        new Element(22, "Ti", "Titanium", 47.867),
        new Element(23, "V", "Vanadium", 50.9415),
        new Element(24, "Cr", "Chroom", 51.9961),
        new Element(25, "Mn", "Mangaan", 54.938044),
        new Element(26, "Fe", "Ijzer", 55.845),
        new Element(27, "Co", "Kobalt", 58.933194),
        new Element(28, "Ni", "Nikkel", 58.6934),
        new Element(29, "Cu", "Koper", 63.546),
        new Element(30, "Zn", "Zink", 65.38),
        new Element(31, "Ga", "Gallium", 69.723),
        new Element(32, "Ge", "Germanium", 72.63),
        new Element(33, "As", "Arseen", 74.921595),
        new Element(34, "Se", "Seleen", 78.971),
        new Element(35, "Br", "Broom", 79.904),
        new Element(36, "Kr", "Krypton", 83.798)
    };
}
