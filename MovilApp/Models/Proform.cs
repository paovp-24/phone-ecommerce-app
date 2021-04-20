using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApp.Models
{
    public class Proform
    {

        public string NOMBR { get; set; }
        public string IMAGE { get; set; }
        public decimal PRECI { get; set; }


    }


    //public class ProformList
    //{
    //    public List<Proform> Shopping { get; set; }

    //    public ProformList()
    //    {
    //        Shopping = new List<Proform>();
    //        LoadProductsG();
    //        LoadProducts();
    //    }


    //    public void LoadProductsG()
    //    {

    //        Shopping = new List<Proform>();

    //        Shopping.Add(new Proform
    //        {
    //            NOMBR = "Samsung",
    //            IMAGE = "https://images.samsung.com/is/image/samsung/latin-galaxy-s20-plus-g985-bts-sm-g985fzpjgto-frontbpurple-thumb-261222598",
    //            PRECI = 5

    //        });
    //    }



    //    public void LoadProducts()
    //    {


    //        Shopping.Add(new Proform
    //        {
    //            NOMBR = "1",
    //            IMAGE = "2",
    //            PRECI = 3

    //        });
    //    }

    //}
}