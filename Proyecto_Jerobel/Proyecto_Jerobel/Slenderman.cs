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

        public void Move()
        {

            

            mapa.celdas[x, y].Enemi = null;

            if (turno == false) // MOVIMIENTO DEL ENEMIGO
            {
                if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true) // MOVIMIENTO DERECHA
                {
                    if (Jugador1.x > this.x)
                    {
                        x++;
                    }
                }

                if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true) // MOVIMIENTO IZQUIERDA
                {
                    if (Jugador1.x < this.x)
                    {
                        x--;
                    }
                }

                if (mapa.isSafe(x, y-1) == true && mapa.celdas[x, y - 1].isWalkable() == true) // MOVIMIENTO ABAJO
                {
                    if (Jugador1.y < this.y)
                    {
                        y--;
                    }
                }

                if (mapa.isSafe(x, y+1) == true && mapa.celdas[x, y + 1].isWalkable() == true) // MOVIMIENTO ARRIBA
                {
                    if (Jugador1.y > this.y)
                    {
                        y++;
                    }
                }
            }

            if (Jugador1.x == this.x && Jugador1.y == this.y) // RESTAR VIDA AL JUGADOR EN CASO DE COLISION
            {
                Jugador1.life = Jugador1.life - 10;
                turno = true;


            }
            if (turno == true) // CONDICIONAL DE MOVIMIENTO, POR LO QUE SI ESTA COLISIONA DURANTE 10 TURNOS NO SE MOVERÁ
            {
                nturno--;
            }
            if (nturno == 0)
            {
                nturno = 10;
                turno = false;
            }



            mapa.celdas[x, y].Enemi = this;
        }

    }
}
