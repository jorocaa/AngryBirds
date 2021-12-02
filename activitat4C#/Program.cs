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
    public class Partida{
        public class Jugador:Partida {
            public string nombre;
            public int turno;
            public Jugador(string nombre, int turno){
                this.nombre = nombre;
                this.turno = turno;
            }
        }

        public class AngryBird:Partida {
            public string nombre;
            public string especie;
            public string poder;
            public int energia;

            public AngryBird(string nombre, string especie, string poder, int energia){
                this.nombre = nombre;
                this.especie = especie;
                this.poder = poder;
                this.energia = energia;
            }        
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Partida.AngryBird rojo = new Partida.AngryBird("Red","cardenal","ninguno",2);
            Partida.AngryBird amarillo = new Partida.AngryBird("Chuck","canario","velocidad",23);
            Partida.AngryBird azules = new Partida.AngryBird("Jay Jake Jim","azulejo","dividirse en tres",64);
            Partida.AngryBird verde = new Partida.AngryBird("Hal","tucán","efecto bumerang",45);
            Partida.AngryBird negro = new Partida.AngryBird("Bomb","cuervo","explotar",67);
            Partida.AngryBird blanco = new Partida.AngryBird("Matilda","gallina","lanzar un huevo explosivo",91);
            Partida.AngryBird naranja = new Partida.AngryBird("Bubbles","gorrión","hincharse",13);
            Partida.AngryBird rosa = new Partida.AngryBird("Stella","cacatua Galah","hacer burbujas",31);
            Partida.AngryBird rojoGordo = new Partida.AngryBird("Terence","cardenal","su peso",44);

            Console.WriteLine(rojo.energia);
            Console.WriteLine("Fin");
        }
    }

    // CREAR JUGADORES


    // CUANTAS CARTAS QUIERES USAR
}
