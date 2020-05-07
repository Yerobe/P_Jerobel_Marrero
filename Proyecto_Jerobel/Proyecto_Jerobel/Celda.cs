using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Celda
    {
        public int Valor; //INDICARÁ EL TIPO DE CELDA [WALL - VACIA]
        public int Neighbors;
        public int ForceRock; // DURABILIDAD DE LA ROCA
        public Item objectt;
        public I_Enemigos Enemi;

        public Celda()
        {
            Valor = 0;
            Neighbors = 0;
            ForceRock = 0;
            objectt = null;
            Enemi = null;
        }


        
                            /*
                     
                    ==============================================
                    =              DIBUJAR CELDAS                =
                    ==============================================
                     
                      */

        public void Display() // DIBUJA CELDA
        {



            if (objectt != null)
            {
                if (this.objectt is Moneda)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("o"); // MONEDAS
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.objectt is Pocion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*"); //POCIONES
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.objectt is Llave)
                {
                    if (Valor == TipoCelda.Rock) // DIBUJA LA LLAVE ENCIMA DE UNA ROCA CON EL MISMO ICONO
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("#"); // LLAVES DEBAJO DE DROPS
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else // ELIMINA LA LLAVE EN EL MAPA AL DESTRUIR LA ROCA
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" "); // LLAVES DEBAJO DE DROPS
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                }
                if (this.objectt is Diamante)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("D"); // DIAMANTE
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else if (this.Enemi != null)
            {
                if (this.Enemi is Golem)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("ö");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.Enemi is Gusano)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("§");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.Enemi is Slenderman)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Φ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                switch (Valor)
                {
                    case TipoCelda.Wall:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case TipoCelda.Floor:
                        Console.Write(" ");
                        break;
                    case TipoCelda.Rock:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("#");
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case TipoCelda.Exit:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("&");
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case TipoCelda.Blacksmith:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("¤");
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                }
            }



            /*

    ==============================================
    =               TIPO DE CELDAS               =
    ==============================================

      */

        }

        public Boolean IsWall()
        {
            if(Valor == TipoCelda.Wall)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public Boolean IsHeart()
        {
            if (Valor == TipoCelda.Heart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsRock()
        {
            if (Valor == TipoCelda.Rock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsBlacksmith()
        {
            if (Valor == TipoCelda.Blacksmith)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsDiamond()
        {
            if (Valor == TipoCelda.Blacksmith)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isExit()
        {
            if (Valor == TipoCelda.Exit)
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
=        CONDICIÓN PARA ENEMIGOS             =
==============================================

*/


        public bool isWalkable()
        {
            if (Valor == TipoCelda.Floor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isMuro()
        {
            if (Valor == TipoCelda.Wall)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
