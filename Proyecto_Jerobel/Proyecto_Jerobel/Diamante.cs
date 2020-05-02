using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Diamante : Item
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("DIAMANTE");
            Console.ForegroundColor = ConsoleColor.White;
            base.Display();
        }
    }
}
