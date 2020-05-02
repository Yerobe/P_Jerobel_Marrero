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
    public class Moneda : Item
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("MONEDA  ");
            Console.ForegroundColor = ConsoleColor.White;
            base.Display();
        }
    }
}
