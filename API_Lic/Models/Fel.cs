using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Lic.Models
{
    public class Fel
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public float Durata { get; set; }
        public float Pret { get; set; }
        public bool InStoc { get; set; }
    }
}
