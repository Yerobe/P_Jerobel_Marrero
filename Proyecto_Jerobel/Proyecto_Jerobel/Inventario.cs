using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Jerobel
{
    public class Inventario
    {
       public List<Item> items;
        public int ItemIndex;
        public int cantidad_llaves;
        public int cantidad_objetos;
        public int cantidad_diamantes;
        public Inventario()
        {
            ItemIndex = -1;
            items = new List<Item>();
            cantidad_llaves = 0;
            cantidad_objetos = 0;
            cantidad_diamantes = 0;
        }
    

                
                            /*
                     
                    ==============================================
                    =              DIBUJAR inventario            =
                    ==============================================
                     
                      */
        public void Display()
        {
            for(int i = 0; i < items.Count; i++)
            {

                if(i != ItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                int cantidad = 10 - items.Count; // CANTIDAD DEL ESPACIO LIBRE DE LA BOLSA
                if (items.Count < 10)
                {
                    
                    Console.SetCursorPosition(67, 15);
                    Console.WriteLine("Te quedan " + cantidad + " espacios disponibles");
                }
                else // BOLSA LLENA
                {
                    Console.SetCursorPosition(67, 15);
                    Console.WriteLine("                                       "); // LIMPIEZA DE TEXTO
                    Console.SetCursorPosition(67, 15);
                    Console.WriteLine("BOLSA LLENA");
                }
                Console.SetCursorPosition(52, 10+i);
                items[i].Display();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(52, 10 + items.Count);
            Console.WriteLine("                 ");

        }



                
                            /*
                     
                    ==============================================
                    =              COGER ITEMS                   =
                    ==============================================
                     
                      */
        public bool TryAdd(Item objeto)
        {
            if(items.Count < 10)
            {
                cantidad_objetos++; // INDICADOR DE OBJETOS EN BOLSA
                if(objeto is Llave) // ME PERMITIRÁ LIMITAR LAS LLAVES A 1
                {
                    cantidad_llaves++;
                }
                if(objeto is Diamante)
                {
                    cantidad_diamantes++;
                }
                items.Add(objeto);
                return true;
            }
            else
            {
                return false;
            }

        }


                                    /*
                     
                    ==============================================
                    =               SELECCIONAR ITEMS            =
                    ==============================================
                     
                      */


        public void SelectItem (int numeroItem)
        {
            ItemIndex = numeroItem;
        }


                
                            /*
                     
                    ==============================================
                    =              USAR ITEMS                    =
                    ==============================================
                     
                      */


        public bool UseItem(Jugador j) // RECIBE LOS VALORES COMPLETOS DEL JUGADOR
        {
            

            if (ItemIndex != -1)

            {
                Item objeto = items[ItemIndex];



                if (objeto is Moneda)
                {
                    j.monedas = j.monedas + 10;
                    this.Borra();
                    return true;
                }
                if(objeto is Llave)
                {
                    return true; // UN ITEM LLAVE NO SE PUEDE ELIMINAR DEL INVENTARIO
                }
                if (objeto is Diamante)
                {
                    j.diamantes = j.diamantes + 1;
                    this.Borra();
                    return true;
                }
                else
                {
                    j.vidas = j.vidas + 10;
                    this.Borra();
                    return true;
                }
            }
            
            else
            {
                return false;
            }
        }



                
                            /*
                     
                    ==============================================
                    =                BORRAR ITEMS                =
                    ==============================================
                     
                      */

        public bool Borra()
        {
            cantidad_objetos--;
            items.RemoveAt(ItemIndex);
            ItemIndex = -1;
            return true;
           // ItemIndex = ItemIndex - 1;
        }



                

        



    }


}
