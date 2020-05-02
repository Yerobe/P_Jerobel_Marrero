using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Tablero
    {
        public Celda[,] celdas;
        public int altura, anchura; //VARIABLES QUE SUSTITUIRAN GETLENGHT[X,Y]
        public int dureza;
        public int x_salida;
        public int y_salida;


        public Tablero()
        {
            celdas = new Celda[150, 150]; // TAMAÑO DEL TABLERO GLOBAL
            anchura = celdas.GetLength(0); // ANCHURA ADQUIERE VALOR
            altura = celdas.GetLength(1); // ALTURA ADQUIERE VALOR

            

            for (int i = 0; i < celdas.GetLength(0); i++) // FOR PARA DECLARAR CELDAS[I,J]
            {
                for (int j = 0; j < celdas.GetLength(1); j++)
                {

                    celdas[i, j] = new Celda();


                }

            }
        }

                            /*
                     
                    ==============================================
                    =              DIBUJAR TABLERO               =
                    ==============================================
                     
                      */

        public void Display(int centroX, int centroY)
        {

            int ventanax = 50, ventanay = 30; // VENTANA PEQUEÑA 



            for (int i = 0; i < ventanax; i++)
            {
                for (int j = 0; j < ventanay; j++)
                {
                    Console.SetCursorPosition(i, j);

                    int CeldaX, CeldaY;

                    CeldaX = centroX - ventanax / 2 + i;
                    CeldaY = centroY - ventanay / 2 + j;

                    if (CeldaX >= 0 && CeldaX < anchura && CeldaY >= 0 && CeldaY < altura)
                    {

                        celdas[CeldaX, CeldaY].Display();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // ZONA EXTERIOR NO JUGABLE
                        Console.Write("~");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }


                }
            }
        }


                            /*
                     
                    ==============================================
                    =         INFORMACION DE DUNGEON             =
                    ==============================================
                     
                      */

        public void informacion()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(52, 1);
            Console.WriteLine("Dungeon: " + Program.dungeon);
            
        }

                            /*
                     
                    ==============================================
                    =           CONTROL DE LOS VECINOS           =
                    ==============================================
                     
                      */

        public void CalculaVecinos(int x, int y) // CALCULA LOS VECINOS EN RELACIÓN A LOS MUROS
        {
            celdas[x, y].vecinos = 0;

            if (x > 0 && y > 0 && celdas[x - 1, y - 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }

            if (y > 0 && celdas[x, y - 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }

            if (x < celdas.GetLength(0) - 1 && y > 0 && celdas[x + 1, y - 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }

            if (x > 0 && celdas[x - 1, y].IsWall())
            {
                celdas[x, y].vecinos++;
            }


            if (x < celdas.GetLength(0) - 1 && celdas[x + 1, y].IsWall())
            {
                celdas[x, y].vecinos++;
            }


            if (x > 0 && y < celdas.GetLength(1) - 1 && celdas[x - 1, y + 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }

            if (y < celdas.GetLength(1) - 1 && celdas[x, y + 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }

            if (x < celdas.GetLength(0) - 1 && y < celdas.GetLength(1) - 1 && celdas[x + 1, y + 1].IsWall())
            {
                celdas[x, y].vecinos++;
            }
            

        }

        public void CalculaVecinos() // RETORNO DE VALORES EN CALCULAVECINOS
        {
            for (int x = 0; x < celdas.GetLength(0); x++)
            {
                for (int y = 0; y < celdas.GetLength(1); y++)
                {
                    CalculaVecinos(x, y);



                }
            }

        }

        public void QuitarVecinos(int s) // ELIMINACIÓN DE LAS CELDAS CON CANTIDADES DE VECINOS ESTIMADAS
        {
            int deletevecinos = s;

            for (int x = 0; x < celdas.GetLength(0); x++)
            {
                for (int y = 0; y < celdas.GetLength(1); y++)
                {

                    if (celdas[x, y].vecinos < deletevecinos)
                    {
                        celdas[x, y].valor = TipoCelda.Floor;
                    }



                }
            }

        }





                            /*
                     
                    ==============================================
                    =      ELEMTOS REPARTIDOS EN LAS CELDAS      =
                    ==============================================
                     
                      */




        public void DropRocas() // DIBUJA ROCAS
        {
            int posibilidad;
            int rocasdropeadas = 0;

            for (int i = 0; i < celdas.GetLength(0); i++)
            {
                for (int j = 0; j < celdas.GetLength(1); j++)
                {

                    if (celdas[i, j].valor == TipoCelda.Floor)
                    {

                        Random r = new Random();
                        posibilidad = r.Next(300);

                        if (posibilidad == 1 && rocasdropeadas < 3)
                        {
                            int Dureza;
                            Dureza = r.Next(100);

                            celdas[i, j].valor = TipoCelda.Rock;
                            celdas[i,j].fuerzaRock = Dureza;
                            rocasdropeadas = rocasdropeadas + 1;
                        }
                    }
                }

            }

        }


        public void putItems(int quantity) // DIBUJA ELEMENTOS ITEMS
        {
            Random r = new Random();
            for (int i = 0; i < quantity; i++)
            {
                int x, y;
                do
                {
                    x = r.Next(this.anchura); //repite valor aleatorio sino salió suelo o si el objeto era distinto de null (ya había un item en esa celda)
                    y = r.Next(this.altura);
                } while (celdas[x, y].valor != TipoCelda.Floor || celdas[x, y].objeto != null);

                if (r.Next(100) < 50) //50% de monedas y 50% de pociones
                {
                    celdas[x, y].objeto = new Pocion();
                }
                else
                {
                    celdas[x, y].objeto = new Moneda();

                }

            }
        }


        public void putKey(int quantity) // DIBUJA LLAVES
        {
            Random r = new Random();
            int x, y;
            do
            {
                x = r.Next(this.anchura); //repite valor aleatorio sino salió suelo o si el objeto era distinto de null (ya había un item en esa celda)
                y = r.Next(this.altura);
            } while (celdas[x, y].valor != TipoCelda.Rock);

            celdas[x, y].objeto = new Llave();
        }

        public void putDiamond(int quantity) // DIBUJA DIAMANTES
        {
            Random r = new Random();
            int x, y;
            for (int i = 0; i < quantity; i++)
            {
                do
                {
                    x = r.Next(this.anchura); //repite valor aleatorio sino salió suelo o si el objeto era distinto de null (ya había un item en esa celda)
                    y = r.Next(this.altura);
                } while (celdas[x, y].valor != TipoCelda.Floor || celdas[x, y].objeto != null);

                celdas[x, y].objeto = new Diamante();
            }
               
        }

        public void putBlacksmith(int quantity) // COLOCA A LOS HERREROS POR EL MAPA 
        {
            Random r = new Random();
            int x, y;
            for(int i = 0; i < quantity; i++)
            {
                do
                {
                    x = r.Next(this.anchura); //repite valor aleatorio sino salió suelo o si el objeto era distinto de null (ya había un item en esa celda)
                    y = r.Next(this.altura);
                } while (celdas[x, y].valor != TipoCelda.Floor);

                celdas[x, y].valor = TipoCelda.Blacksmith;
            }
           
        }

        public void putExit(int quantity) // DIBUJA LA SALIDA AL SIGUIENTE NIVEL
        {
            Random r = new Random();
            int x, y;

            do
            {
                x = r.Next(this.anchura); //repite valor aleatorio sino salió suelo o si el objeto era distinto de null (ya había un item en esa celda)
                y = r.Next(this.altura);
            } while (celdas[x, y].valor != TipoCelda.Floor);

            celdas[x, y].valor = TipoCelda.Exit;

            x_salida = x;
            y_salida = y;

        }







        /*

==============================================
=          CREACIÓN DE LOS LABERINTOS        =
==============================================

  */


        public void RandomWalk(int floors) // GENERADOR DE FLOOR
        {
            // RANDOM WALK
            //POSITION OF WALKER
            int x, y;
            int countfloors;
            int maxfloors = floors;
            int direccion;

            for (int i = 0; i <= celdas.GetLength(0) - 1; i++)
            {

                for (int j = 0; j <= celdas.GetLength(1) - 1; j++)
                {
                    celdas[i, j].valor = TipoCelda.Wall; // PONE TODO EL MAPA CON MUROS


                }
            }
            // pick a mapp cell as the starting point
            x = anchura / 2; // CENTRAR X
            y = altura / 2; // CENTRAR Y

            // turn the select mapp cell into floor
            celdas[x, y].valor = TipoCelda.Floor;
            countfloors = 1;

            Random r = new Random();
            //While insufficiente cells have been turned into floor


            while (countfloors <= maxfloors) // NUMERO MÁXIMO DE SUELOS DESCUBIERTOS
            {

                if (x < 0 || y < 0 || x >= anchura || y >= altura)
                {
                    x = anchura / 2;
                    y = altura / 2;
                }

                //Take one stemp in a random direction
                direccion = r.Next(4); // RANDOM DE 4

                switch (direccion)
                {
                    
                    case 0: // MOVIMIENTO IZQUIERDA
                        if (x > 0) // LIMITACIÓN DE PARED
                        {
                            x = x - 1;
                        }
                        break;

                    case 1: // MOVIIENTO ARRIBA
                        if (y > 0)// LIMITACIÓN DE PARED
                        {
                            y = y - 1;
                        }
                        break;

                    case 2: // MOVIIENTO DERECHA
                        if (x < anchura -1)// LIMITACIÓN DE PARED
                        {
                            x = x + 1;
                        }
                        break;

                    case 3: // MOVIMIENTO ABAJO
                        if(y < altura -1)// LIMITACIÓN DE PARED
                        {
                            y = y + 1;
                        }
                        break;

                }
                countfloors = countfloors + 1;
                celdas[x, y].valor = TipoCelda.Floor;
            }


        }

        /*

==============================================
=          LIMITACIÓN DE MUROS DEL MAPA      =
==============================================

*/

        public bool isSafe(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < celdas.GetLength(0)-1 && y < celdas.GetLength(1)-1)
            {
                return true;
            }
            else
            {
                return false;


            }
        }

        /*

==============================================
=          LIMPIEZA DEL BUFFER COMPLETO      =
==============================================

*/

           public void Clear()
        {

        }


    }
}
