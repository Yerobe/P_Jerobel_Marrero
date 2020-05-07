using System;
using System.IO;

namespace Proyecto_Jerobel
{
    public class Program
    {
        static Tablero TableroGeneral;
        static Jugador Jugador1;
        public static int state; // ESTADO QUE DECIDIRÁ EN QUE MODO NOS ENCONTRAMOS
        public static int dungeon; // NUMERO DE DUNGEON ACTUAL
        public static Golem golem;  // DECLARACION DEL ENEMIGO GOLEM
        public static Gusano gusano; // DECLARACION DEL ENEMIGO GUSANO
        public static EnemiGenerator GeneradorEnemy; // GENERADOR DE ENEMIGOS
        public static void Main(string[] args)
        {
            state = 3; // ESTADO QUE DECIDIRÁ LA PARTIDA
            dungeon = 1; // NÚMERO DEL NIVEL EN EL QUE NOS ENCONTRAMOS
            Boolean ejecutado = false; // BOOLEAN QUE FUNCIONARÁ COMO DESENCADENANTE QUE AL REPETIR PARTIDA, SE EJECUTE EL STATE 0 Y HAGA EL RANDOMWALK


            ConsoleKeyInfo opcion; // LECTURA POR TECLADO

            

            do // CONDICIOENS QUE FUNCIONARÁ COMO CAMBIO DE RONDAS
            {
                TableroGeneral = new Tablero(); // DECLARACIÓN DE LA CLASE TABLERO

                do
                {
                    switch (state)
                    {
                        case 3: //PANTALLA DE INICIO
                           
                       

                            if (File.Exists("../../data/Inicio.txt")) // LECTURA DE LA PANTALLA DE INICIO
                            {
                                StreamReader archivo;
                                String contenido;

                                archivo = new StreamReader("../../data/Inicio.txt");
                                contenido = archivo.ReadToEnd();
                                Console.WriteLine(contenido);
                            }

                            opcion = Console.ReadKey(true); // LECTURA POR TECLADO
                            if (opcion.Key == ConsoleKey.G) // OPCION = COMIENZO DEL JUEGO
                            {
                                state = 0;
                                Console.Clear();
                            }
                            if (opcion.Key == ConsoleKey.I) // OPCION = INFORMACION DEL JUEGO
                            {
                                state = 4;
                                Console.Clear();
                            }


                            break;

                        case 0: // CASO 1 = DURANTE PARTIDA
                            ejecutado = true;

                            TableroGeneral.RandomWalk(5000);  // GENERAMOS LA CREACIÓN DEL SUELO MEDIANTE RANDOMWALK

                            Jugador1 = new Jugador(TableroGeneral); // DECLARACIÓN DE LA CLASE JUGADOR
                            GeneradorEnemy = new EnemiGenerator(TableroGeneral, Jugador1);

                            for (int i = 0; i < 5; i++) // BUCLE PARA REALIZAR UNA LIMPIEZA CORRECTA
                            {
                                TableroGeneral.CalculaVecinos(); // CALCULA LOS MUROS DEL ARDEDOR (VECINOS)
                                TableroGeneral.QuitarVecinos(3); // CANTIDAD DE VECINOS < NÚMERO
                            }

                            TableroGeneral.DropRocas(); // DROPEA ROCAS
                            TableroGeneral.putBlacksmith(10); // DROPEA LOS HERREROS
                            TableroGeneral.putItems(50); // DROPEA LOS ITEMS TOTALES
                            TableroGeneral.putKey(1); // DROPEA LAS LLAVES
                            TableroGeneral.putExit(1); // DROPEA LAS SALIDAS
                            TableroGeneral.putDiamond(50); // DROPEA LOS DIAMANTES

                            GeneradorEnemy.PutEnemy(50,2); // INVOCACIÓN DE LOS ENEMIGOS / SLENDERMAN
                            GeneradorEnemy.DisplayEnemy(); // DIBUJAR DE LOS ENEMIGOS

                            break;

                        case 2: // CASO 2 = DERROTA DEL JUGADOR

                            ejecutado = false;
                            Console.Clear();
                            Console.SetCursorPosition(5, 10);
                            Console.ForegroundColor = ConsoleColor.White;
                            

                            if (File.Exists("../../data/GameOver.txt")) // PANTALLA DE GAMEOVER
                            {
                                StreamReader archivo;
                                String contenido;

                                archivo = new StreamReader("../../data/GameOver.txt");
                                contenido = archivo.ReadToEnd();
                                Console.WriteLine(contenido);

                                opcion = Console.ReadKey(true);
                                if (opcion.Key == ConsoleKey.R)
                                {
                                    state = 0;
                                    Console.Clear();
                                }
                                if (opcion.Key == ConsoleKey.M)
                                {
                                    state = 3;
                                    Console.Clear();
                                }
                            }
                            break;

                        case 4:
                            if (File.Exists("../../data/Informacion.txt"))
                            {
                                StreamReader archivo;
                                String contenido;

                                archivo = new StreamReader("../../data/Informacion.txt");
                                contenido = archivo.ReadToEnd();
                                Console.WriteLine(contenido);
                                opcion = Console.ReadKey(true); // LECTURA POR TECLADO

                                if (opcion.Key == ConsoleKey.G)
                                {
                                    state = 3;
                                    Console.Clear();
                                }
                            }
                            break;

                    }
                    } while (ejecutado == false) ;



                TableroGeneral.Display(Jugador1.x, Jugador1.y); // DIBUJAMOS EL TABLERO EN LAS POSCIONES DEL JUGADOR

                do // CONDICIONAL REPETITIVO DURANTE LA PARTIDA
                    {

                        while (Console.KeyAvailable == true) // LIMPIEZA DEL BUFFER DEL TECLADO
                        {
                            Console.ReadKey(true);
                        }


                    TableroGeneral.informacion(); // IMPRIME INFORMACIÓN DEL TABLERO
                        Jugador1.Display(); // DIBUJA JUGADOR
                        Jugador1.Vidas(); // CONTROLA LAS VIDAS DEL JUGADOR
                        Jugador1.RockDrop(); // CUANDO JUGADOR ESTÁ ENCIMA DE UNA ROCA
                        Jugador1.IamBlackSmith(); // CUANDO JUGADOR ESTÁ ENCIMA DE UN HERRERO
                    
                        Jugador1.Informacion(); // DIBUJA LA INFORMACIÓN DEL JUGADOR
                        Jugador1.NextLevel(); // CAMBIA EL STATE CUANDO ENCUENTRA SALIDA
                        Jugador1.Brujula(); // BRUJULA DE LA SALIDA

                    


                    Console.CursorVisible = false; // DESHABILITAMOS LA VISIBILIDAD DEL CURSOS
                        opcion = Console.ReadKey(true); // LECTURA POR TECLADO

                        switch (opcion.Key) // MOVIMIENTO DEL JUGADOR
                        {

                            case ConsoleKey.NumPad8: // MOVIMIENTO HACIA ARRIBA.
                                Jugador1.MoveUp();
                                break;

                            case ConsoleKey.NumPad2: // MOVIMIENTO HACIA ABAJO.
                                Jugador1.MoveDown();
                                break;

                            case ConsoleKey.NumPad4: // MOVIMIENTO HACIA LA IZQUIERDA.
                                Jugador1.MoveLeft();
                                break;

                            case ConsoleKey.NumPad6: // MOVIMIENTO HACIA LA DERECHA.
                                Jugador1.MoveRight();
                                break;

                            case ConsoleKey.NumPad7: // MOVIMIENTO HACIA LA DIAGONAL SUPERIOR IZQUIERDA.
                                Jugador1.MoveUpLeft();
                                break;

                            case ConsoleKey.NumPad9: // MOVIMIENTO HACIA LA DIAGONAL SUPERIOR DERECHA.
                                Jugador1.MoveUpRight();
                                break;

                            case ConsoleKey.NumPad1: // MOVIMIENTO HACIA LA DIAGONAL INFERIOR IZQUIERDA.
                                Jugador1.MoveDownLeft();
                                break;
                            case ConsoleKey.NumPad3: // MOVIMIENTO HACIA LA DIAGONAL INFERIOR DERECHA.
                                Jugador1.MoveDownRight();
                                break;
                            case ConsoleKey.P:
                                Jugador1.RompeRocas();
                                break;
                            case ConsoleKey.Enter: // ELIMINA EL ITEM DEL INVENTARIO
                                Jugador1.UseItem();
                                Jugador1.life++;
                                break;
                            case ConsoleKey.Q: // SELECCIONA UN ITEM ARRIBA
                                Jugador1.selectPreviousItem();
                                Jugador1.life++;
                                break;
                            case ConsoleKey.A:
                                Jugador1.selectNextItem(); // SELECCIONA UN ITEM ABAJO
                                Jugador1.life++;
                                break;
                            case ConsoleKey.B:
                                state = 1;
                                break;
                        case ConsoleKey.M:
                            Jugador1.Inmortal();
                            break;

                    }

                        Jugador1.CogeItem();

                    foreach (I_Enemigos enemigos in GeneradorEnemy.Enemigos)
                    {
                        enemigos.Move();
                    }

                    TableroGeneral.Display(Jugador1.x, Jugador1.y); // DIBUJAMOS EL TABLERO EN LAS POSCIONES DEL JUGADOR

                } while (state == 0); // SALIR DEL PROGRAMA
                    if (state == 1)
                    {
                        state = 0;
                    }
                } while (opcion.Key != ConsoleKey.Escape);
            }
            }
    }

    

