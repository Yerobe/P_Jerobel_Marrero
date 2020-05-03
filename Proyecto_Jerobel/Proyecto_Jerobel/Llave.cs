using System;
using System.Collections.Generic;
using System.Text;

/*

==============================================
=                ESTO ES UN ITEM             =
==============================================

*/

namespace Proyecto_Jerobel
{
    public class Llave : Item
    {
        public override void Display()
        {

            Console.Write("LLAVE   ");
            base.Display();
        }
    }
}
