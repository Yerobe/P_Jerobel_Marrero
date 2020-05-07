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

        public void Move() //
        {
            int direccion;
            Random r = new Random();


            direccion = r.Next(4) + 1;
            mapa.celdas[x, y].Enemi = null;
            switch (direccion)
            {

                case 1: // MOVIMIENTO DERECHA
                    if (mapa.isSafe(x+1, y) == true && mapa.celdas[x + 1, y].isWalkable() == true) // CONDICIONALES DE SEGURIDAD
                    {
                        x++;
                    }

                    break;
                case 2: // MOVIMIENTO IZQUIERDA
                    if (mapa.isSafe(x-1, y) == true && mapa.celdas[x - 1, y].isWalkable() == true) // CONDICIONALES DE SEGURIDAD
                    {
                        x--;
                    }
                    break;
                case 3: // MOVIMIENTO ARRIBA
                    if (mapa.isSafe(x, y+1) == true && mapa.celdas[x, y + 1].isWalkable() == true) // CONDICIONALES DE SEGURIDAD
                    {
                        y++;
                    }
                    break;
                case 4: // MOVIMIENTO ABAJO
                    if (mapa.isSafe(x, y-1) == true && mapa.celdas[x, y - 1].isWalkable() == true) // CONDICIONALES DE SEGURIDAD
                    {
                        y--;
                    }

                    
                        break;
            }
            if (Jugador1.x == this.x && Jugador1.y == this.y) // SEGURIDAD A LA HORA DE CUANDO EL ENEMIGO ALCANCE AL JUGADOR
            {
                Jugador1.life = Jugador1.life - 10;
            }
            mapa.celdas[x, y].Enemi = this;
        }

    }
}
