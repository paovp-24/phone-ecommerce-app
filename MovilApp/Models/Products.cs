using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApp.Models
{
    public class Products
    {
        public int PRODUCTO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DETALLES { get; set; }
        public string IMAGEN { get; set; }
        public string GARANTIA { get; set; }
        public decimal PRECIO { get; set; }
        public int STOCK { get; set; }

        public static List<Products> carrito = new List<Products>();

        public void agregarItem(Products item)
        {
            carrito.Add(item);
        }


        public void removerItem(int index)
        {
            carrito.RemoveAt(index);
        }


        public decimal devolverPrecio()
        {
            decimal totalCarrito = 0;

            foreach (Products item in carrito)
            {
                totalCarrito += item.PRECIO;
            }
            return totalCarrito;
        }


    }



   

}
