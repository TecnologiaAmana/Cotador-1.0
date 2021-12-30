using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Nivelcobertura
    {
        public Nivelcobertura()
        {
            Taxas = new HashSet<Taxa>();
        }

        public short IdNivelCobertura { get; set; }
        public short ValorCobertura { get; set; }

        public virtual ICollection<Taxa> Taxas { get; set; }
    }
}
