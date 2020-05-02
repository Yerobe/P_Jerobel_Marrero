using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Gusano: I_Enemigos
    {

        public Tablero mapa { get; set; }
        public Jugador Jugador1;
        public int x { get; set; }
        public int y { get; set; }

        bool right;
        bool left;

        public Gusano(Jugador J)
        {
            this.x = 0;
            this.y = 0;
            this.mapa = null;
            this.right = true;
            this.left = true;
            this.Jugador1 = J;
        }
        public void Display()
        {

        } 

        public void Mover()
        {



            mapa.celdas[x, y].enemigo = null;
                    if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true && right==true)
                    {
                left = false;
                        x++;
                    }

                    if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true && left==true)
                    {
                        x--;
                right = false;
                    }

            if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == false)
            {
                right = true;
                left = false;
            }

            if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == false)
            {
                right = false;
                left = true;
            }

            if (Jugador1.x == this.x && Jugador1.y == this.y)
            {
                Jugador1.vidas = Jugador1.vidas - 10;
            }

            mapa.celdas[x, y].enemigo = this;
        }

    }
}
