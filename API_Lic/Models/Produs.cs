using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Lic.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public int Cantitate { get; set; }
        public float Pret { get; set; }
        public bool Alergen { get; set; }
    }
}
