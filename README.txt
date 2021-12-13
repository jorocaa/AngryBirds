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
            this.nombre = "";
            this.especie= "";
            this.poder= "";
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

        // REPARTIMOS CARTAS A LOS JUGADORES ////////////////// CONTROLAR QUE NO SE REPARTAN CARTAS REPETIDAS //////////////////
        public static AngryBird[] repartirCartas(int number_of_carts, AngryBird [] listaAngry,AngryBird [] jugador){
            int[] listaNum = new int[number_of_carts];
            
            for (int x=0; x<number_of_carts; x++){
                int num; 
                bool existe;
                
                do{
                    existe = false;
                    var rand = new Random();
                    num = rand.Next(0,listaAngry.Length);
                    
                    
                    for (int a = 0; a <listaNum.Length;a++){   
                        Console.WriteLine(listaNum[a]); 
                        if(num == listaNum[a]){
                            existe = true;
                        } 
                    }
                    
                }while(existe);
                listaNum[x] = num;
                jugador[x] = listaAngry[num];

                
            }
            

            return jugador;
        }

        // LA BATALLA DE CARTAS
        public static void PlayGame(Jugador JugadorNum1, Jugador JugadorNum2){
            // CONTADOR DE PUNTOS POR JUGADOR
            int puntosJ1 = 0;
            int puntosJ2 = 0;
            
            Console.Clear();
            
            // GESTIONAR BATALLA
            for (int x = 0; x<JugadorNum1.cartas.Length;x++){
                // MOSTRAR PUNTUACIÓN 
                Console.WriteLine(JugadorNum1.nombre+": "+puntosJ1+"\n"+JugadorNum2.nombre+": "+puntosJ2);

                // PREGUNTAMOS QUE CARTA QUIERE SACAR EL JUGADOR 1
                Console.WriteLine(JugadorNum1.nombre+" que carta deseas sacar? ");

                // MOSTRAMOS LAS CARTAS DEL JUGADOR 1
                MostrarCartas(JugadorNum1);
                
                // COMPROBAMOS OPCIÓN INTRODUCIDA
                int posicionJ1 = ExistePosicionCarta(JugadorNum1);

                // PREGUNTAMOS QUE CARTA QUIERE SACAR EL JUGADOR 2
                Console.WriteLine(JugadorNum2.nombre+" que carta deseas sacar? ");

                // MOSTRAMOS LAS CARTAS DEL JUGADOR 2
                MostrarCartas(JugadorNum2);
            
                // COMPROBAMOS OPCIÓN INTRODUCIDA
                int posicionJ2 = ExistePosicionCarta(JugadorNum2);
                
                // CARTAS JUGADAS
                Console.WriteLine(JugadorNum1.nombre+" ha jugado con la carta "+JugadorNum1.cartas[posicionJ1].nombre+ "con un poder de "+JugadorNum1.cartas[posicionJ1].energia+"\n"+JugadorNum2.nombre+" ha jugado con la carta "+JugadorNum2.cartas[posicionJ2].nombre+ "con un poder de "+JugadorNum2.cartas[posicionJ2].energia);

                // SI EL JUGADOR 1 TIENE MÁS ENERGÍA QUE EL JUGADOR 2
                if(JugadorNum1.cartas[posicionJ1].energia > JugadorNum2.cartas[posicionJ2].energia)
                {
                    // PUNTO PARA JUGADOR 1
                    puntosJ1+=1;
                }
                // SI ELS JUGADORS EMPATEN
                else if(JugadorNum1.cartas[posicionJ1].energia == JugadorNum2.cartas[posicionJ2].energia){
                    Console.WriteLine("EMPATE");
                }
                // SI EL JUGADOR 2 TIENE MÁS ENERGÍA QUE EL JUGADOR 1
                else{
                    puntosJ2+=1;
                }
                
                // ELIMINAR CARTAS USADAS
                JugadorNum1.cartas[posicionJ1].Delete();
                JugadorNum2.cartas[posicionJ2].Delete();
            }
            // MOSTRAR AL GANADOR
            MostrarGanador(puntosJ1, puntosJ2, JugadorNum1, JugadorNum2);
        }

        // MOSTRAR CARTAS
        public static void MostrarCartas(Jugador  mostrarCartas){
            Console.WriteLine("===========ESTAS SON TUS CARTAS===========");
            for(int x=0;x<mostrarCartas.cartas.Length;x++){
                if(mostrarCartas.cartas[x].nombre != ""){
                    Console.WriteLine(x + "- Nombre: "+mostrarCartas.cartas[x].nombre +" Especie: " +  mostrarCartas.cartas[x].especie +" Poder: " +  mostrarCartas.cartas[x].poder + " Energia: "+ mostrarCartas.cartas[x].energia + "\n");
                }
            }
        }

        // COMPROVAR POSICIÓN CARTA
        public static int ExistePosicionCarta(Jugador cartasJugador ){
            
            Console.WriteLine("===========ELEGIR CARTA JUGADOR===========");
            bool salir = false;
            int numSelect;
            do{
                string selectCart = Console.ReadLine();
                numSelect = int.Parse(selectCart);
                if (numSelect >= cartasJugador.cartas.Length || cartasJugador.cartas[numSelect].nombre == ""){
                    Console.WriteLine("Lo sentimos no tienes tantas Cartas");
                }else{
                    salir = true;
                }
            }while(salir == false);
            Console.Clear();
            return numSelect;            
        }

        // MOSTRAR GANADOR
        public static void MostrarGanador(int puntosJ1, int puntosJ2, Jugador jugador1, Jugador jugador2){
            Console.Clear();
            if(puntosJ1>puntosJ2){
                Console.WriteLine("HA GANADO EL "+jugador1.nombre+"!!!!!!!!!");
            }else if(puntosJ2>puntosJ1){
                Console.WriteLine("HA GANADO EL "+jugador2.nombre+"!!!!!!!!!");
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
            AngryBird [] listaAngry2 = {rojo,amarillo,azules,verde,negro,blanco,naranja,rosa,rojoGordo};

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
                AngryBird [] jugador2CartasRepartidas = repartirCartas(number_of_carts,listaAngry2,jugador2);                

               
                //PlayGame(jugador1, jugador2);

                Jugador JugadorNum1 = new Jugador(nombre, jugador1CartasRepartidas);
                Jugador JugadorNum2 = new Jugador(nombre2, jugador2CartasRepartidas);
                
                PlayGame(JugadorNum1, JugadorNum2);
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
