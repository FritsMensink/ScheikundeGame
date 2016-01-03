﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PeriodiekSysteem {
    //de lijst van elementen die Vmbo studenten moeten weten, alle gegevens hier gevonden: http://www.ptable.com/?lang=nl
    public static List<Element> VmboElementen = new List<Element>() {
        new Element(1, "H", "Waterstof", 1.008, true),
        new Element(2, "He", "Helium", 4.002602, true),
        new Element(6, "C", "Koolstof", 12.011, true),
        new Element(7, "N", "Stikstof", 14.007, true),
        new Element(8, "O", "Zuurstof", 15.999, true),
        new Element(9, "F", "Fluor", 18.998403163, true),
        new Element(10, "Ne", "Neon", 20.1797, true),
        new Element(11, "Na", "Natrium", 22.98976928, true),
        new Element(12, "Mg", "Magnesium", 24.305, true),
        new Element(13, "Al", "Aluminium", 26.9815385, true),
        new Element(15, "P", "Fosfor", 30.973761998, true),
        new Element(16, "S", "Zwavel", 32.06, true),
        new Element(17, "Cl", "Chloor", 35.45, true),
        new Element(18, "Ar", "Argon", 39.948, true),
        new Element(20, "Ca", "Calcium", 40.078, true),
        new Element(26, "Fe", "Ijzer", 55.845, true),
        new Element(28, "Ni", "Nikkel", 58.6934, true),
        new Element(29, "Cu", "Koper", 63.546, true),
        new Element(30, "Zn", "Zink", 65.38, true),
        new Element(35, "Br", "Broom", 79.904, true),
        new Element(47, "Ag", "Zilver", 107.8682, true),
        new Element(48, "Cd", "Cadmium", 112.414, true),
        new Element(53, "I", "Jood", 126.90447, true),
        new Element(79, "Au", "Goud", 196.966569, true),
        new Element(80, "Hg", "Kwik", 200.59, true),
        new Element(82, "Pb", "Lood", 207.2, true),
    };

    //de complete lijst van elementen
    public static List<Element> Elementen = new List<Element>() {
        new Element(1, "H", "Waterstof", 1.008, true),
        new Element(2, "He", "Helium", 4.002602, true),
        new Element(3, "Li", "Lithium", 6.94),
        new Element(4, "Be", "Beryllium", 9.0121831),
        new Element(5, "B", "Boor", 10.81),
        new Element(6, "C", "Koolstof", 12.011, true),
        new Element(7, "N", "Stikstof", 14.007, true),
        new Element(8, "O", "Zuurstof", 15.999, true),
        new Element(9, "F", "Fluor", 18.998403163, true),
        new Element(10, "Ne", "Neon", 20.1797, true),
        new Element(11, "Na", "Natrium", 22.98976928, true),
        new Element(12, "Mg", "Magnesium", 24.305, true),
        new Element(13, "Al", "Aluminium", 26.9815385, true),
        new Element(14, "Si", "Silicium", 28.085),
        new Element(15, "P", "Fosfor", 30.973761998, true),
        new Element(16, "S", "Zwavel", 32.06, true),
        new Element(17, "Cl", "Chloor", 35.45, true),
        new Element(18, "Ar", "Argon", 39.948, true),
        new Element(19, "K", "Kalium", 39.0983),
        new Element(20, "Ca", "Calcium", 40.078, true),
        new Element(21, "Sc", "Scandiur", 44.955908),
        new Element(22, "Ti", "Titanium", 47.867),
        new Element(23, "V", "Vanadium", 50.9415),
        new Element(24, "Cr", "Chroom", 51.9961),
        new Element(25, "Mn", "Mangaan", 54.938044),
        new Element(26, "Fe", "Ijzer", 55.845, true),
        new Element(27, "Co", "Kobalt", 58.933194),
        new Element(28, "Ni", "Nikkel", 58.6934, true),
        new Element(29, "Cu", "Koper", 63.546, true),
        new Element(30, "Zn", "Zink", 65.38, true),
        new Element(31, "Ga", "Gallium", 69.723),
        new Element(32, "Ge", "Germanium", 72.63),
        new Element(33, "As", "Arseen", 74.921595),
        new Element(34, "Se", "Seleen", 78.971),
        new Element(35, "Br", "Broom", 79.904, true),
        new Element(36, "Kr", "Krypton", 83.798),
        new Element(37, "Rb", "Rubidium", 85.4678),
        new Element(38, "Sr", "Strontium", 87.62),
        new Element(39, "Y", "Yttrium", 88.90584),
        new Element(40, "Zr", "Zirkonium", 91.224),
        new Element(41, "Nb", "Niobium", 92.90637),
        new Element(42, "Mo", "Molybdeen", 95.95),
        new Element(43, "Tc", "Technetium", 98),
        new Element(44, "Ru", "Ruthenium", 101.07),
        new Element(45, "Rh", "Rhodium", 102.90550),
        new Element(46, "Pd", "Palladium", 106.42),
        new Element(47, "Ag", "Zilver", 107.8682, true),
        new Element(48, "Cd", "Cadmium", 112.414, true),
        new Element(49, "In", "Indium", 114.818),
        new Element(50, "Sn", "Tin", 118.710),
        new Element(51, "Sb", "Antimoon", 121.760),
        new Element(52, "Te", "Telluur", 127.60),
        new Element(53, "I", "Jood", 126.90447, true),
        new Element(54, "Xe", "Xenon", 131.293),
        new Element(55, "Cs", "Cesium", 132.90545196),
        new Element(56, "Ba", "Barium", 137.327),
        new Element(57, "La", "Lanthaan", 138.90547),
        new Element(58, "Ce", "Cerium", 140.116),
        new Element(59, "Pr", "Praseodymium", 140.90766),
        new Element(60, "Nd", "Neodymium", 144.242),
        new Element(61, "Pm", "Promethium", 145),
        new Element(62, "Sm", "Samarium", 150.36),
        new Element(63, "Eu", "Europium", 151.964),
        new Element(64, "Gd", "Gadolinium", 157.25),
        new Element(65, "Tb", "Terbium", 158.92535),
        new Element(66, "Dy", "Dysprosium", 162.500),
        new Element(67, "Ho", "Holmium", 164.93033),
        new Element(68, "Er", "Erbium", 167.259),
        new Element(69, "Tm", "Thulium", 168.93422),
        new Element(70, "Yb", "Ytterbium", 173.054),
        new Element(71, "Lu", "Lutetium", 174.9668),
        new Element(72, "Hf", "Hafnium", 178.49),
        new Element(73, "Ta", "Tantaal", 180.94788),
        new Element(74, "W", "Wolfraam", 183.84),
        new Element(75, "Re", "Renium", 186.207),
        new Element(76, "Os", "Osmium", 190.23),
        new Element(77, "Ir", "Iridium", 192.217),
        new Element(78, "Pt", "Platina", 195.084),
        new Element(79, "Au", "Goud", 196.966569, true),
        new Element(80, "Hg", "Kwik", 200.59, true),
        new Element(81, "Tl", "Thallium", 204.38),
        new Element(82, "Pb", "Lood", 207.2, true),
        new Element(83, "Bi", "Bismut", 208.98040),
        new Element(84, "Po", "Polonium", 209),
        new Element(85, "At", "Astaat", 210),
        new Element(86, "Rn", "Radon", 222),
        new Element(87, "Fr", "Francium", 223),
        new Element(88, "Ra", "Radium", 226),
        new Element(89, "Ac", "Actinium", 227),
        new Element(90, "Th", "Thorium", 232.0377),
        new Element(91, "Pa", "Protactinium", 231.03588),
        new Element(92, "U", "Uranium", 238.02891),
        new Element(93, "Np", "Neptunium", 237),
        new Element(94, "Pu", "Plutonium", 244),
        new Element(95, "Am", "Americium", 243),
        new Element(96, "Cm", "Curium", 247),
        new Element(97, "Bk", "Berkelium", 247),
        new Element(98, "Cf", "Californium", 251),
        new Element(99, "Es", "Einsteinium", 252),
        new Element(100, "Fm", "Fermium", 257),
        new Element(101, "Md", "Mendelevium", 258),
        new Element(102, "No", "Nobelium", 259),
        new Element(103, "Lr", "Lawrencium", 262),
        new Element(104, "Rf", "Rutherfordium", 267),
        new Element(105, "Db", "Dubnium", 268),
        new Element(106, "Sg", "Seaborgium", 271),
        new Element(107, "Bh", "Bohrium", 272),
        new Element(108, "Hs", "Hassium", 270),
        new Element(109, "Mt", "Meitnerium", 276),
        new Element(110, "Ds", "Darmstadtium", 281),
        new Element(111, "Rg", "Roentgenium", 280),
        new Element(112, "Cn", "Copernicium", 285),
        new Element(113, "Uut", "Ununtrium", 284),
        new Element(114, "Fl", "Flerovium", 289),
        new Element(115, "Uup", "Ununpentium", 288),
        new Element(116, "Lv", "Livermorium", 293),
        new Element(117, "Uus", "Ununseptium", 294),
        new Element(118, "Uuo", "Ununoctium", 294),
    };
}
