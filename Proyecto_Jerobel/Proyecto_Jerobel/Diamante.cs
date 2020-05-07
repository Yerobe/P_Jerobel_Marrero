using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Diamante : Item
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // COLOR DE DIAMANTE
            Console.Write("DIAMANTE"); // ESCRITUA POR PANTALLA
            Console.ForegroundColor = ConsoleColor.White; // VOVLER COLOR
            base.Display(); // DIBUJAR
        }
    }

}
