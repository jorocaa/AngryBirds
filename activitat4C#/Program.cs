
using System;

namespace activitat4C_
{
    public class AngryBird {
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

        public void Delete()
        {
            this.nombre = null;
            this.especie= null;
            this.poder= null;
            this.energia = 0;
        }
        
    }

    public class Jugador {
        public string nombre;
        public AngryBird[] cartas;

        //CONSTRUCTOR
        public Jugador(string nombre, AngryBird[] cartas){
            this.nombre = nombre;
            this.cartas = cartas;
        }
    }



    class Program
    {

        public static int preguntarCartas(){
            int numCartas = 0;
            bool choice = false;
            while (choice == false){
                Console.WriteLine("Cuantas cartas quereis: 1, 3, 5: ");
                string numberCarts = Console.ReadLine();
                switch (numberCarts){
                    case "1":
                        numCartas = 1;
                        choice = true;
                        break;
                    case "3":
                        numCartas = 3;
                        choice = true;
                        break;
                    case "5":
                        numCartas = 5;
                        choice = true;
                        break;
                    default:
                        Console.WriteLine("Esta opcion no existe");
                        break;
                }
            }
            
            return numCartas;
        }   
        // crear jugador 1/2;
        public static AngryBird[] repartirCartas(int number_of_carts, AngryBird [] listaAngry,AngryBird [] jugador){
            for (int x =0; x<number_of_carts;x++){
                var rand = new Random();
                int num = rand.Next(0,listaAngry.Length);
                jugador[x] = listaAngry[num];
            }

            return jugador;
        }

        //ESTO TIENE QUE SER BOOL
        public static void PlayGame(AngryBird [] jugador1CartasRepartidas, AngryBird [] jugador2CartasRepartidas){
            int puntosJ1 = 0;
            int puntosJ2 = 0;
            Console.Clear();
            for (int x = 0; x<jugador1CartasRepartidas.Length;x++){
                Console.WriteLine("Jugador1 que carta deseas sacar? ");
                MostrarCartas(jugador1CartasRepartidas);
                
                int posicionJ1 = ExistePosicionCarta(jugador1CartasRepartidas);

                Console.WriteLine("Jugador2 que carta deseas sacar? ");
                MostrarCartas(jugador2CartasRepartidas);
            
                int posicionJ2 = ExistePosicionCarta(jugador2CartasRepartidas);
                
                if(jugador1CartasRepartidas[posicionJ1].energia > jugador2CartasRepartidas[posicionJ2].energia)
                {
                    puntosJ1+=1;
                    Console.WriteLine("Gana el jugador 1");

                }else
                {
                    puntosJ2+=1;
                    Console.WriteLine("Gana el jugador 2");
                }
                
            }
            MostrarGanador(puntosJ1, puntosJ2);
            
            
        }

        public static void MostrarCartas(AngryBird [] mostrarCartas){
            Console.WriteLine("===========ESTAS SON TUS CARTAS===========");
            for(int x=0;x<mostrarCartas.Length;x++){
                Console.WriteLine("Nombre: "+mostrarCartas[x].nombre +" Especie: " +  mostrarCartas[x].especie +" Poder: " +  mostrarCartas[x].poder + " Energia: "+ mostrarCartas[x].energia + "\n");
            }
        }

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

            AngryBird [] listaAngry = {rojo,amarillo,azules,verde,negro,blanco,naranja,rosa,rojoGordo};

            //CREAR A LOS 2 Jugadores
            Console.WriteLine("DAME TU NOMBRE DE JUGADOR1");
            string nombre = Console.ReadLine();
            
            Console.WriteLine("DAME TU NOMBRE DE JUGADOR2");
            string nombre2 = Console.ReadLine();


            //Console.WriteLine(listaAngry[3].nombre);
            bool salir = false;
            
            //NUMERO TOTAL DE CARTAS 
            while (salir==false)
            {
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

            } 
        } 
    }
}
