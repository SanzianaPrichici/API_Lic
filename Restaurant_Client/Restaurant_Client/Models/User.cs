using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Client.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
        public int Cli_ID { get; set; }
    }
}
