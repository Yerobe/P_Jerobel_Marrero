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

        bool right; // MOVIMIENTO DERECHA
        bool left; // MOVIMIENTO IZQUIERDA

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

        public void Move()
        {



            mapa.celdas[x, y].Enemi = null;
                    if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true && right==true) // CONDICIONAL DE MOVIMIENTO IZQUIERDO
                    {
                left = false;
                        x++;
                    }

                    if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true && left==true) // CONDICIONAL DE MOVIMIENTO DERECHO
            {
                        x--;
                right = false;
                    }

            if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == false) // DECIDE HACIA DONDE SE MOVERA EL JUGADOR
            {
                right = true;
                left = false;
            }

            if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == false) // DECIDE HACIA DONDE SE MOVERA EL JUGADOR
            {
                right = false;
                left = true;
            }

            if (Jugador1.x == this.x && Jugador1.y == this.y) // CONDICION DE RESTAR VIDA AL JUGADOR
            {
                Jugador1.life = Jugador1.life - 10;
            }

            mapa.celdas[x, y].Enemi = this;
        }

    }
}
