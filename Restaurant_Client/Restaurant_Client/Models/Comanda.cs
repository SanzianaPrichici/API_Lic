using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Client.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public int ID_CLI { get; set; }
        public int ID_Masa { get; set; }
        public int Suma { get; set; }
        public string Status { get; set; }
    }
}
