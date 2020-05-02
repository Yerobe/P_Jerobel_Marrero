using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Celda
    {
        public int valor; //INDICARÁ EL TIPO DE CELDA [WALL - VACIA]
        public int vecinos;
        public int fuerzaRock; // DURABILIDAD DE LA ROCA
        public Item objeto;
        public I_Enemigos enemigo;

        public Celda()
        {
            valor = 0;
            vecinos = 0;
            fuerzaRock = 0;
            objeto = null;
            enemigo = null;
        }


        
                            /*
                     
                    ==============================================
                    =              DIBUJAR CELDAS                =
                    ==============================================
                     
                      */

        public void Display() // DIBUJA CELDA
        {



            if (objeto != null)
            {
                if (this.objeto is Moneda)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("o"); // MONEDAS
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.objeto is Pocion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*"); //POCIONES
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.objeto is Llave)
                {
                    if (valor == TipoCelda.Rock) // DIBUJA LA LLAVE ENCIMA DE UNA ROCA CON EL MISMO ICONO
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
                if (this.objeto is Diamante)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("D"); // DIAMANTE
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else if (this.enemigo != null)
            {
                if (this.enemigo is Golem)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("ö");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.enemigo is Gusano)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("§");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (this.enemigo is Slenderman)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Φ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                switch (valor)
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
            if(valor == TipoCelda.Wall)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public Boolean IsHeart()
        {
            if (valor == TipoCelda.Heart)
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
            if (valor == TipoCelda.Rock)
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
            if (valor == TipoCelda.Blacksmith)
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
            if (valor == TipoCelda.Blacksmith)
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
            if (valor == TipoCelda.Exit)
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
            if (valor == TipoCelda.Floor)
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
            if (valor == TipoCelda.Wall)
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
