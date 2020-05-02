using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Slenderman : I_Enemigos
    {
        

        public Tablero mapa { get; set; }
        public Jugador Jugador1;
        public int x { get; set; }
        public int y { get; set; }
        bool turno = false;
        int nturno = 10;


        public Slenderman(Jugador J)
        {
            this.x = 0;
            this.y = 0;
            this.mapa = null;
            this.Jugador1 = J;
        }
        public void Display()
        {

        }

        public void Mover()
        {

            

            mapa.celdas[x, y].enemigo = null;

            if (turno == false)
            {
                if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true)
                {
                    if (Jugador1.x > this.x)
                    {
                        x++;
                    }
                }

                if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true)
                {
                    if (Jugador1.x < this.x)
                    {
                        x--;
                    }
                }

                if (mapa.isSafe(x, y-1) == true && mapa.celdas[x, y - 1].isWalkable() == true)
                {
                    if (Jugador1.y < this.y)
                    {
                        y--;
                    }
                }

                if (mapa.isSafe(x, y+1) == true && mapa.celdas[x, y + 1].isWalkable() == true)
                {
                    if (Jugador1.y > this.y)
                    {
                        y++;
                    }
                }
            }

            if (Jugador1.x == this.x && Jugador1.y == this.y)
            {
                Jugador1.vidas = Jugador1.vidas - 10;
                turno = true;


            }
            if (turno == true)
            {
                nturno--;
            }
            if (nturno == 0)
            {
                nturno = 10;
                turno = false;
            }



            mapa.celdas[x, y].enemigo = this;
        }

    }
}
