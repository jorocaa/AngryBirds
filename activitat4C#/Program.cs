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
    // CLASE ANGRYBIRDS
    public class AngryBird {
        public string nombre;
        public string especie;
        public string poder;
        public int energia;

        // CONSTRUCTOR CARTA ANGRYBIRD
        public AngryBird(string nombre, string especie, string poder, int energia){
            this.nombre = nombre;
            this.especie = especie;
            this.poder = poder;
            this.energia = energia;
        }

        // BORRAR CARTAS ANGRYBIRDS (PROBLEMAS?)
        public void Delete()
        {
            this.nombre = null;
            this.especie= null;
            this.poder= null;
            this.energia = 0;
        }
        
    }

    // CLASE JUGADOR
    public class Jugador {
        public string nombre;
        public AngryBird[] cartas;

        //CONSTRUCTOR JUGADOR
        public Jugador(string nombre, AngryBird[] cartas){
            this.nombre = nombre;
            this.cartas = cartas;
        }
    }

    // CLASE PARTIDA
    public class Partida{
        // PREGUNTAMOS CON CUÁNTAS CARTAS QUIEREN JUGAR
        public static int preguntarCartas(){
            int numCartas = 0;
            bool choice = false;
            while (choice == false){
                Console.WriteLine("Cuantas cartas quereis: 1, 3, 5: ");
                string numberCarts = Console.ReadLine();
                switch (numberCarts){
                    case "1":
                        // ESCOGEN 1 CARTA
                        numCartas = 1;
                        choice = true;
                        break;
                    case "3":
                        // ESCOGEN 3 CARTAS
                        numCartas = 3;
                        choice = true;
                        break;
                    case "5":
                        // ESCOGEN 5 CARTAS
                        numCartas = 5;
                        choice = true;
                        break;
                    default:
                        // ERROR AL ESCOGER
                        Console.WriteLine("Esta opcion no existe");
                        break;
                }
            }
            // RETORNAMOS CON CUÁNTAS CARTAS QUIEREN JUGAR
            return numCartas;
        }   

        // REPARTIMOS CARTAS A LOS JUGADORES
        public static AngryBird[] repartirCartas(int number_of_carts, AngryBird [] listaAngry,AngryBird [] jugador){
            for (int x =0; x<number_of_carts;x++){
                var rand = new Random();
                int num = rand.Next(0,listaAngry.Length);
                jugador[x] = listaAngry[num];
            }

            return jugador;
        }

        // LA BATALLA DE CARTAS
        public static void PlayGame(AngryBird [] jugador1CartasRepartidas, AngryBird [] jugador2CartasRepartidas){
            // CONTADOR DE PUNTOS POR JUGADOR
            int puntosJ1 = 0;
            int puntosJ2 = 0;
            Console.Clear();
            
            // GESTIONAR BATALLA
            for (int x = 0; x<jugador1CartasRepartidas.Length;x++){
                // PREGUNTAMOS QUE CARTA QUIERE SACAR EL JUGADOR 1
                Console.WriteLine("Jugador1 que carta deseas sacar? ");

                // MOSTRAMOS LAS CARTAS DEL JUGADOR 1
                MostrarCartas(jugador1CartasRepartidas);
                
                // COMPROBAMOS OPCIÓN INTRODUCIDA
                int posicionJ1 = ExistePosicionCarta(jugador1CartasRepartidas);

                // PREGUNTAMOS QUE CARTA QUIERE SACAR EL JUGADOR 2
                Console.WriteLine("Jugador2 que carta deseas sacar? ");

                // MOSTRAMOS LAS CARTAS DEL JUGADOR 2
                MostrarCartas(jugador2CartasRepartidas);
            
                // COMPROBAMOS OPCIÓN INTRODUCIDA
                int posicionJ2 = ExistePosicionCarta(jugador2CartasRepartidas);
                
                // SI EL JUGADOR 1 TIENE MÁS ENERGÍA QUE EL JUGADOR 2
                if(jugador1CartasRepartidas[posicionJ1].energia > jugador2CartasRepartidas[posicionJ2].energia)
                {
                    // PUNTO PARA JUGADOR 1
                    puntosJ1+=1;
                    Console.WriteLine("Gana el jugador 1");

                }
                // SI ELS JUGADORS EMPATEN
                else if(jugador1CartasRepartidas[posicionJ1].energia == jugador2CartasRepartidas[posicionJ2].energia){
                    Console.WriteLine("EMPATE");

                }
                // SI EL JUGADOR 2 TIENE MÁS ENERGÍA QUE EL JUGADOR 1
                else{
                    puntosJ2+=1;
                    Console.WriteLine("Gana el jugador 2");
                }
                
            }
            // MOSTRAR AL GANADOR
            MostrarGanador(puntosJ1, puntosJ2);
        }

        // MOSTRAR CARTAS
        public static void MostrarCartas(AngryBird [] mostrarCartas){
            Console.WriteLine("===========ESTAS SON TUS CARTAS===========");
            for(int x=0;x<mostrarCartas.Length;x++){
                Console.WriteLine(x + "- Nombre: "+mostrarCartas[x].nombre +" Especie: " +  mostrarCartas[x].especie +" Poder: " +  mostrarCartas[x].poder + " Energia: "+ mostrarCartas[x].energia + "\n");
            }
        }

        // COMPROVAR POSICIÓN CARTA
        public static int ExistePosicionCarta(AngryBird [] cartasJugador ){
            
            Console.WriteLine("===========ELEGIR CARTA JUGADOR===========");
            bool salir = false;
            int numSelect = 0;
            while(salir == false){
                string selectCart = Console.ReadLine();
                numSelect = int.Parse(selectCart);
                if (numSelect >= cartasJugador.Length){
                    Console.WriteLine("Lo sentimos no tienes tantas Cartas");
                }else{
                    salir = true;
                    
                }
            }
            Console.Clear();
            return numSelect;            
        }

        // MOSTRAR GANADOR
        public static void MostrarGanador(int puntosJ1, int puntosJ2){
            Console.Clear();
            if(puntosJ1>puntosJ2){
                Console.WriteLine("HA GANADO EL JUGADOR 1 !!!!!!!!!");
            }else if(puntosJ2>puntosJ1){
                Console.WriteLine("HA GANADO EL JUGADOR 2 !!!!!!!!!");
            }else{
                Console.WriteLine("EMPATE !!!!!!!!!");
            }
        }
        public void Batalla(){
            // CREAR CARTAS
            AngryBird rojo = new AngryBird("Red","cardenal","ninguno",2);
            AngryBird amarillo = new AngryBird("Chuck","canario","velocidad",23);
            AngryBird azules = new AngryBird("Jay Jake Jim","azulejo","dividirse en tres",64);
            AngryBird verde = new AngryBird("Hal","tucán","efecto bumerang",45);
            AngryBird negro = new AngryBird("Bomb","cuervo","explotar",67);
            AngryBird blanco = new AngryBird("Matilda","gallina","lanzar un huevo explosivo",91);
            AngryBird naranja = new AngryBird("Bubbles","gorrión","hincharse",13);
            AngryBird rosa = new AngryBird("Stella","cacatua Galah","hacer burbujas",31);
            AngryBird rojoGordo = new AngryBird("Terence","cardenal","su peso",44);

            // GESTIONAR CARTAS EN ARRAY
            AngryBird [] listaAngry = {rojo,amarillo,azules,verde,negro,blanco,naranja,rosa,rojoGordo};

            //CREAR A LOS 2 Jugadores
            Console.WriteLine("DAME TU NOMBRE DE JUGADOR1");
            string nombre = Console.ReadLine();            
            Console.WriteLine("DAME TU NOMBRE DE JUGADOR2");
            string nombre2 = Console.ReadLine();

            bool salir = false;
            //NUMERO TOTAL DE CARTAS 
            while (salir==false)
            {
                // PREGUNTAR TOTAL DE CARTAS
                int number_of_carts = preguntarCartas();
               
                //JUGADORES POR DEFECTO
                
                AngryBird [] jugador1 = new AngryBird [number_of_carts];
                AngryBird [] jugador2 = new AngryBird [number_of_carts];

                

                //CREAR JUGADOR CON CLASE ME DA PEREZA CAMBIAR TODA LA ESTRUCTURA 
                //AngryBird [] jugador1RepartirCartas = new AngryBird [number_of_carts];
                //AngryBird [] jugador1CartasRepartidas = repartirCartas(number_of_carts,listaAngry,jugador1RepartirCartas);
                //Jugador jugador1 = new Jugador(nombre, jugador1CartasRepartidas);

                //JUGADOR2 CON CLASE ME DA PEREZA CAMBIAR TODA LA ESTRUCTURA 
                //AngryBird [] jugador2RepartirCartas = new AngryBird [number_of_carts];
                //AngryBird [] jugador2CartasRepartidas = repartirCartas(number_of_carts,listaAngry,jugador2RepartirCartas);
                //Jugador jugador2 = new Jugador(nombre2, jugador2CartasRepartidas);

                // JUGADORES CON LAS CARTAS REPARTIDAS
                AngryBird [] jugador1CartasRepartidas = repartirCartas(number_of_carts,listaAngry,jugador1);
                AngryBird [] jugador2CartasRepartidas = repartirCartas(number_of_carts,listaAngry,jugador2);                

                PlayGame(jugador1CartasRepartidas, jugador2CartasRepartidas);
                //PlayGame(jugador1, jugador2);

                Jugador JugadorNum1 = new Jugador(nombre, jugador1CartasRepartidas);
                Jugador JugadorNum2 = new Jugador(nombre, jugador2CartasRepartidas);
            } 
        }
    }
    // CLASE PRINCIPAL
    class JuegoDeCartas
    {
        // COMIENZA EL PROGRAMA
        static void Main(string[] args)
        {
            Partida start = new Partida();
            start.Batalla();
        } 
    }
}
