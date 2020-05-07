using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class EnemiGenerator
    {

        public List <I_Enemigos> Enemigos; // ARRAY_LIST DE ENEMIGOS
        public Tablero mapa = new Tablero();
        public Jugador Jugador1;
        public bool slenderman;

        public EnemiGenerator(Tablero t, Jugador J)
        {
            Enemigos = new List<I_Enemigos>();
            this.mapa = t;
            this.Jugador1 = J;
            slenderman = true;
        }


        public void PutEnemy(int quantity, int quantity2) // DIBUJA ELEMENTOS
        {
            Random r = new Random();

            for (int i = 0; i < quantity; i++) // CONDICIONAL DE CANTIDAD DE ENEMIGOS GENERADOS
            {

                if (r.Next(10) < 5)
                {
                    Enemigos.Add(new Gusano(Jugador1));
                }
                else
                {
                    Enemigos.Add(new Golem(Jugador1));
                }


            }

            for(int i = 0; i < quantity2; i++) // GENERADOR INDEPENDIENTE PARA LOS ENEMIGOS SLENDERMAN
            {
                Enemigos.Add(new Slenderman(Jugador1));
            }
        }

            


        public void DisplayEnemy() // DIBUJAR ENEMIGOS
        {
            Random r = new Random();

            for (int i = 0; i < Enemigos.Count; i++)
            {
                int x, y;

                do
                {

                    x = r.Next(this.mapa.celdas.GetLength(0)); // POSICION X ALEATORIA
                    y = r.Next(this.mapa.celdas.GetLength(1)); // POSICION Y ALEATORIA


                } while (mapa.celdas[x, y].Valor != TipoCelda.Floor || mapa.celdas[x, y].Enemi != null);


                mapa.celdas[x, y].Enemi = Enemigos[i];

                Enemigos[i].x = x;
                Enemigos[i].y = y;
                Enemigos[i].mapa = this.mapa;



            }
        }

        
        




    }
    }

