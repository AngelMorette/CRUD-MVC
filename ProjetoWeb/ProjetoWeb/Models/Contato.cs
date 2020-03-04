using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWeb.Models
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        internal class Find : Contato
        {
            private int? id;

            public Find(int? id)
            {
                this.id = id;
            }
        }
    }
}