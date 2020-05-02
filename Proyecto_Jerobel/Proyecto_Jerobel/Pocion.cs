using System;
using System.Collections.Generic;
using System.Text;

/*

==============================================
=               ESTO ES UN ITEM              =
==============================================

*/

namespace Proyecto_Jerobel
{
    public class Pocion : Item
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("POCION  ");
            Console.ForegroundColor = ConsoleColor.White;
            base.Display();
        }
    }
}
