using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApp.Models
{
    public class Factura
    {
        public int USUARIO_ID { get; set; }
        public int PLAN_ID { get; set; }
        public decimal MONTO_FACTURA { get; set; }
        public int CANT_PRODUCTOS { get; set; }
        public string ESTADO { get; set; }
    }
}