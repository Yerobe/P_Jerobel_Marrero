using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public interface I_Enemigos
    {

        Tablero mapa { get; set; }
        int x { get; set; }
        int y { get; set; }


        void Display();
        void Move();
    }
}
