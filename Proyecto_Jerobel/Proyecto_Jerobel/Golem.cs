using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Golem : I_Enemigos
    {

        public Tablero mapa { get; set; }
        public Jugador Jugador1;
        public int x { get; set; }
        public int y { get; set; }

        public Golem(Jugador J)
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
            int direccion;
            Random r = new Random();


            direccion = r.Next(4) + 1;
            mapa.celdas[x, y].enemigo = null;
            switch (direccion)
            {

                case 1:
                    if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true)
                    {
                        x++;
                    }

                    break;
                case 2:
                    if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true)
                    {
                        x--;
                    }
                    break;
                case 3:
                    if (mapa.isSafe(x, y+1) == true && mapa.celdas[x, y + 1].isWalkable() == true)
                    {
                        y++;
                    }
                    break;
                case 4:
                    if (mapa.isSafe(x, y-1) == true && mapa.celdas[x, y - 1].isWalkable() == true)
                    {
                        y--;
                    }

                    
                        break;
            }
            if (Jugador1.x == this.x && Jugador1.y == this.y)
            {
                Jugador1.vidas = Jugador1.vidas - 10;
            }
            mapa.celdas[x, y].enemigo = this;
        }

    }
}
