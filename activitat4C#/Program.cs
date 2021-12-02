﻿
// Crearem un programa amb C# per dos jugadors en mode batalla.
// A cada partida, prèviament, es podrà establir un màxim d’angry birds per jugador: 1, 3 o 5.

// Els dos jugadors tindran la mateixa quantitat d’angry birds.

// Quan comença el joc es reparteixen la quantitat d’angry birds acordada per jugador i,
// per torns, cada jugador mostra el seu angry bird: guanya el de major energia.

// Guanya el jugador que ha guanyat més batalles (torns).
// Podria donar-se el cas d’empatar.

// Les formes de jugar podrien ser variades en funció del vostre nivell de programació:
// Si no sabeu com fer els torns (v1): sumeu l’energia de tots els angry birds de cada jugador i guanya qui més energia suma;
// Si sabeu fer torns, en versió fàcil (v2): es compara a cada torn un angry bird aleatori per part de cada jugador;
// Si sabeu fer torns i teniu més temps (v3): cada jugador pot triar, en cada torn, amb quin angry bird juga.
// Si teniu súper poders (v4): com el cas anterior però contra la màquina.



using System;

namespace activitat4C_
{
    public class AngryBird {
            public string nombre;
            public int especie;
            public int poder;
            public int energia;
        
    }
    class Program
    {
        // crear jugador 1/2;
        static void Main(string[] args)
        {
            AngryBird rojo = new AngryBird("Red","cardenal","ninguno",2);
            AngryBird amarillo = new AngryBird("Chuck","canario","velocidad",23);
            AngryBird azules = new AngryBird("Jay Jake Jim","azulejo","dividirse en tres",64);
            AngryBird verde = new AngryBird("Hal","tucán","efecto bumerang",45);
            AngryBird negro = new AngryBird("Bomb","cuervo","explotar",67);
            AngryBird blanco = new AngryBird("Matilda","gallina","lanzar un huevo explosivo",91);
            AngryBird naranja = new AngryBird("Bubbles","gorrión","hincharse",13);
            AngryBird rosa = new AngryBird("Stella","cacatua Galah","hacer burbujas",31);
            AngryBird rojoGordo = new AngryBird("Terence","cardenal","su peso",44);
        }
    }
   

        
        // Pájaro rojo: nombre: Red; especie: cardenal; poder: ninguno; energía: 2
        // Pájaro amarillo: nombre: Chuck; especie: canario; poder: velocidad; energía: 23
        // Pájaros azules: nombres: Jay, Jake y Jim; especie: azulejo; poder: dividirse en tres; energía: 64
        // Pájaro verde: nombre: Hal; especie: tucán; poder: efecto bumerang; energía: 45
        // Pájaro negro: nombre: Bomb; especie: cuervo; poder: explotar; energía: 67
        // Pájaro blanco: nombre: Matilda; especie: gallina; poder: lanzar un huevo explosivo; energía: 91
        // Pájaro naranja: nombre: Bubbles; especie: gorrión; poder: hincharse; energía: 13
        // Pájaro rosa: nombre: Stella; especie: cacatua Galah; poder: hacer burbujas; energía: 31
        // Pájaro rojo gordo: nombre: Terence; especie: cardenal; poder: su peso; energía: 44

    


    // CREAR JUGADORES


    // CUANTAS CARTAS QUIERES USAR
}
