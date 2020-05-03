using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Jugador
    {
        public Celda[,] celdas;
        public int x, y;
        public int life;
        public int anteriorx, anteriory;
        public int pico;
        public int key;
        Inventario bagpack;
        public int coins;
        public int diamond;
        

        public Tablero mapa;

        public Jugador(Tablero t)
        {
            Random r = new Random();
            int posibilidad = r.Next(50);
            x = 75; //POSICION DEL JUGADOR X
            y = 75; // POSICIONES DEL JUGADOR Y
            this.mapa = t; // DECLARACIÓN DEL TABLERO
            life = 300; // VIDAS DEL JUGADOR 
            pico = posibilidad; // DUREZA DEL PICO
            key = 0;
            coins = 200; // MONEDAS DEL JUGADOR
            diamond = 50;

            bagpack = new Inventario();

        }

        /*
                     
                    ==============================================
                    =    DISPLAY DEL JUGADOR  + MOVIMIENTO       =
                    ==============================================
                     
                      */

        public void Display()
        {
            bagpack.Display();
            Console.SetCursorPosition(25, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red; // COLOR DEL JUGADOR
            Console.Write("Ö"); // ICONO DEL JUGADOR
            Console.ForegroundColor = ConsoleColor.Black;


        }



        public void Move(int incX, int incY) // MOVIMIENTO GENERALIZADO
        {
            int nuevax, nuevay;
            nuevax = x + incX;
            nuevay = y + incY;
            anteriorx = x;
            anteriory = y;

            if (nuevax >= 0 && nuevax < mapa.anchura) // LIMITACIÓN EN X
            {
                x = nuevax;
                if (mapa.celdas[x, y].valor == TipoCelda.Wall) // LIMITACIÓN DE MUROS EN POSCIÓN X
                {
                    x = nuevax - incX;
                }
            }
            if (nuevay >= 0 && nuevay < mapa.altura) // LIMITACIÓN EN Y
            {
                y = nuevay;
                if (mapa.celdas[x, y].valor == TipoCelda.Wall) // LIMITACIÓN DE MUROS EN POSICIÓN Y
                {
                    y = nuevay - incY;
                }
            }


        }


        public void MoveUp() // MOVER ARRIBA
        {
            Move(0, -1);
        }
        public void MoveDown() // MOVER ABAJO
        {
            Move(0, 1);
        }
        public void MoveLeft() // MOVER IZQUIERDA
        {
            Move(-1, 0);
        }
        public void MoveRight() // MOVER DERECHA
        {
            Move(1, 0);
        }
        public void MoveUpLeft() // MOVER DIAGONAL IZQUIERDA SUPERIOR
        {
            Move(-1, -1);
        }
        public void MoveUpRight() // MOVER DIAGONAL DERECHA SUPERIOR
        {
            Move(1, -1);
        }
        public void MoveDownLeft() // MOVER DIAGONAL IZQUIERDA INFERIOR
        {
            Move(-1, 1);
        }
        public void MoveDownRight() // MOVER DIAGONAL DERECHA INFERIOR
        {
            Move(1, 1);
        }







        /*
                     
                    ==============================================
                    =          INFORMACIÓN + DETALLES            =
                    ==============================================
                     
                      */
                      

        public void Informacion()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(52, 3);
            Console.WriteLine("La Posición de X es: " + x + " "); // IMPRIME POSICIÓN X
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(52, 4);
            Console.WriteLine("La Posición de Y es: " + y + " "); // IMPIME POSICIÓN Y
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(52, 5);
            Console.WriteLine("Vidas " + life + " "); // IMPRIME LAS VIDAS ACTUALES
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(52, 6);
            Console.WriteLine("Dureza del Pico " + pico + " "); // IMPRIME LA DUREZA DEL PICO ACTUAL
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(104, 1);
            Console.WriteLine("Monedas : " + coins); // IMPRIME LA CANTIDAD DE LAS MONEDAS
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(104, 2);
            Console.WriteLine("Diamantes : " + diamond); // IMPRIME LA CANTIDAD DE LOS DIAMANTES
        }





        /*

            ==============================================
            =          INTERACCION CON ITEMS             =
            ==============================================

              */




        public void CogeItem()
        {
            if (!(mapa.celdas[x, y].objeto is Llave))
            {
                if (mapa.celdas[x, y].objeto != null)
                {
                    bool puedecoger;

                    puedecoger = bagpack.TryAdd(mapa.celdas[x, y].objeto); // METO ITEM EN LA MOCHILA
                    if (puedecoger)
                    {
                        mapa.celdas[x, y].objeto = null; // QUITA EL SUELO
                    }

                }
            }
        }

        public void UseItem()
        {


            bagpack.UseItem(this);


        }

        /*   public void IndicadorBolsa() // INDICA LA CAPACIDAD LIBRE DE LA MOCHILA
           {
               mochila.IndicadorBolsa();
           }*/
        public void selectPreviousItem()
        {
            bagpack.ItemIndex = Math.Max(bagpack.ItemIndex - 1, -1);

        }

        public void selectNextItem()
        {
            bagpack.ItemIndex = Math.Min(bagpack.items.Count - 1, bagpack.ItemIndex + 1); // ATENCION AL FINAL
        }





        /*

            ==============================================
            =  POSICION DEL JUGADOR ENCIMA DE UNA CELDA  =
            ==============================================

              */


        public void RompeRocas() // JUGADIR ENCIMA DE UNA ROCA
        {
            if (mapa.celdas[x, y].valor == TipoCelda.Rock && pico >= mapa.celdas[x, y].fuerzaRock && bagpack.cantidad_objetos < 10)
            {
                pico = pico - mapa.celdas[x, y].fuerzaRock; // ROTURA DEL PICO AL ROMPER UNA PIEDRA

                if (mapa.celdas[x, y].objeto is Llave)
                {
                    bagpack.TryAdd(mapa.celdas[x, y].objeto);
                }
                mapa.celdas[x, y].valor = TipoCelda.Floor;
            }
            else
            {
                Console.SetCursorPosition(52, 9);
                Console.WriteLine("El pico no es suficiente");
            }

        }



        public void Vidas()
        {
            int calculo = 1; // ME AYUDA A QUE SI CAMINO EN DIAGONAL NO ME HAGA UN -2 DE VIDAS

            if (x != anteriorx && calculo == 1) // DISMINUCIÓN DE VIDAS
            {
                life = life - 1;
                calculo = calculo - 1;
            }
            if (y != anteriory && calculo == 1) // DISMINUCIÓN DE VIDAS
            {
                life = life - 1;
                calculo = calculo - 1;
            }
            if (mapa.celdas[x, y].valor == TipoCelda.Heart && mapa.celdas[x, y].IsHeart()) // CONDICIÓN DONDE DEBE SER CASILLA CORAZÓN Y JUGADOR DEBE ESTAR ENCIMA
            {
                mapa.celdas[x, y].valor = TipoCelda.Floor; // RECOGE CORAZON Y DEJA LA CASILLA EN FLOOR
                life = life + 10; // AUMENTO DE VIDA
            }
            if (life <= 0) // MUERTE DEL JUGADOR
            {
                Program.state = 2;
            }

        }

        public void RockDrop() // MÉTODO CUANDO LAS ROCAS SON ROTAS
        {
            if (mapa.celdas[x, y].valor == TipoCelda.Rock && mapa.celdas[x, y].IsRock()) // CONDICIÓN DONDE DEBE SER CASILLA CORAZÓN Y JUGADOR DEBE ESTAR ENCIMA
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(52, 7);
                Console.WriteLine("Deseas analizar la roca, presione 5 ");
                ConsoleKeyInfo opcion;
                opcion = Console.ReadKey(true);
                if (opcion.Key == ConsoleKey.NumPad5)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(52, 8);
                    Console.WriteLine("La dureza de la roca es de " + mapa.celdas[x, y].fuerzaRock + " si deseas romperla presione P"); // IMPRIME LAS DUREZA DE LA ROCA ANTERIOR ANALIZADA
                    life++;
                }

            }
            if (mapa.celdas[x, y].valor != TipoCelda.Rock) // LIMPIEZA DEL TEXTO POR CONSOLA DE LAS ROCAS
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(52, 7);
                Console.WriteLine("                                       ");
                Console.SetCursorPosition(52, 8);
                Console.WriteLine("                                                                 ");
                Console.SetCursorPosition(52, 9);
                Console.WriteLine("                           ");
            }
        }
       


        public void I_am_a_blacksmith()
        {
            Boolean salirherrero = true;
            if (mapa.celdas[x, y].valor == TipoCelda.Blacksmith && mapa.celdas[x, y].IsBlacksmith())
            {
                for (int x = 52; x < 119; x++)
                {
                    for (int y = 1; y < 27; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(" ");
                    }
                }

                do
                {


                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;


                    int g = 0;

                    Interaction();

                    g = MapaAsteriscos(g);

                    Price();

                    salirherrero = Shopping(salirherrero);

                } while (salirherrero == true); // CONDICIÓN PARA SALIR DE LA INTERACCION CON EL HERRERO
            }
        }


        // MÉTODOS EXTERNOS

        private static void Price()
        {
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("1) Mejorar el Pico +10 equivale a 5 Diamantes y 20 Monedas");
            Console.SetCursorPosition(55, 16);
            Console.WriteLine("2) Mejorar el Pico +30 equivale a 12 Diamantes y 30 Monedas");
            Console.SetCursorPosition(55, 17);
            Console.WriteLine("3) Mejorar el Pico +50 equivale a 30 Diamantes y 50 Monedas");
        }

        private bool Shopping(bool salirherrero)
        {
            ConsoleKeyInfo opcion = Console.ReadKey(true);


            int o_diamantes = 0;
            int o_monedas = 0;

            switch (opcion.Key) // MOVIMIENTO DEL JUGADOR
            {

                case ConsoleKey.E: // MOVIMIENTO HACIA ARRIBA
                    salirherrero = false;
                    for (int x = 52; x < 115; x++)
                    {
                        for (int y = 1; y < 27; y++)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(" ");
                        }
                    }
                    break;
                case ConsoleKey.D1:
                    o_monedas = coins - 20;
                    o_diamantes = diamond - 5;
                    if (diamond >= 5 && coins >= 20 && o_monedas >= 0 && o_diamantes >= 0)
                    {

                        pico = pico + 10;
                        diamond = diamond - 5;
                        coins = coins - 20;
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("                                ");
                    }
                    else
                    {
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No tienes suficientes fondos");
                    }
                    break;
                case ConsoleKey.D2:
                    o_monedas = coins - 30;
                    o_diamantes = diamond - 12;
                    if (diamond >= 12 && coins >= 30 && o_monedas >= 0 && o_diamantes >= 0)
                    {
                        pico = pico + 30;
                        diamond = diamond - 5;
                        coins = coins - 30;
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("                                 ");
                    }
                    else
                    {
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No tienes suficientes fondos");
                    }
                    break;
                case ConsoleKey.D3:
                    o_monedas = coins - 50;
                    o_diamantes = diamond - 30;
                    if (diamond >= 30 && coins >= 50 && o_monedas >= 0 && o_diamantes >= 0)
                    {
                        pico = pico + 50;
                        diamond = diamond - 5;
                        coins = coins - 50;
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("                                ");
                    }
                    else
                    {
                        Console.SetCursorPosition(55, 20);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No tienes suficientes fondos");
                    }
                    break;
            }

            return salirherrero;
        }

        private static int MapaAsteriscos(int g)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 35; i++)
                {
                    Console.SetCursorPosition(65 + i, 2 + g);

                    Console.Write("*");
                }
                g = g + 4;
            }


            g = 0;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 4; i++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(65 + g, 3 + i);
                    Console.WriteLine("*");


                }
                g = g + 34;
            }

            return g;
        }

        private void Interaction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(71, 4);
            Console.WriteLine("BIENVENIDO AL HERRERO");

            Console.SetCursorPosition(55, 8);
            Console.WriteLine("Este es el puesto del Herrero, aquí podrás forjar tu Pico");

            Console.SetCursorPosition(55, 10);
            Console.WriteLine("Altualmente cuentas con:");

            Console.SetCursorPosition(57, 12);
            Console.WriteLine("Monedas : " + coins + "   ");

            Console.SetCursorPosition(57, 13);
            Console.WriteLine("Diamantes : " + diamond + "   ");

            Console.SetCursorPosition(57, 25);
            Console.WriteLine("Si deseas salir, presione E");
        }


        /*
                     
                    ==============================================
                    =            BRUJULA DE LA SALIDA            =
                    ==============================================
                     
                      */


        public void Brujula() // BRUJULA QUE APUNTA AL TIPO CELDA SALIDA
        {
            if (mapa.x_salida < x)
            {
                Console.SetCursorPosition(112, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO
                Console.SetCursorPosition(111, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(110, 25);
                Console.WriteLine("<");
            }
            if (mapa.x_salida > x)
            {
                Console.SetCursorPosition(110, 25);
                Console.WriteLine(" ");  // LIMPIEZA DEL BUFFER CONTRARIO
                Console.SetCursorPosition(111, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(112, 25);
                Console.WriteLine(">");
            }
            if (mapa.y_salida < y)
            {
                Console.SetCursorPosition(111, 26);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO
                Console.SetCursorPosition(111, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(111, 24);
                Console.WriteLine("^");
            }
            if (mapa.y_salida > y)
            {
                Console.SetCursorPosition(111, 24);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFER CONTRARIO
                Console.SetCursorPosition(111, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(111, 26);
                Console.WriteLine("v");
            }
            if (mapa.x_salida == x && mapa.y_salida == y)
            {
                Console.SetCursorPosition(111, 24);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFER CONTRARIO
                Console.SetCursorPosition(111, 26);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO
                Console.SetCursorPosition(110, 25);
                Console.WriteLine(" ");  // LIMPIEZA DEL BUFFER CONTRARIO
                Console.SetCursorPosition(112, 25);
                Console.WriteLine(" "); // LIMPIEZA DEL BUFFET CONTRARIO

                Console.SetCursorPosition(111, 25);
                Console.WriteLine("O"); // LIMPIEZA DEL BUFFET CONTRARIO
            }
        }

        public void NextLevel() // CONDICIONES CUANDO SE CAMBIA DE NIVEL
        {
            if (mapa.celdas[x, y].valor == TipoCelda.Exit && bagpack.cantidad_llaves == 1)
            {
                Program.state = 1; // CAMBIO EN EL SWITCH DE PROGRAM
                Program.dungeon++; // AUMENTA UN NIVEL DE MAZMORRAS
                bagpack.items.Clear(); // VACIA EL INVENTARIO
                Console.Clear(); // LIMPIA LA CONSOLA

            }
        }



        

       

       



    } // DIAGONALES FINALES 
}
