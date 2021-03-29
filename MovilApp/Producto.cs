using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApp
{
    public class Producto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
