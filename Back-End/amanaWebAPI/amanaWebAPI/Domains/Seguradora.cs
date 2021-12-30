using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Seguradora
    {
        public Seguradora()
        {
            Plantios = new HashSet<Plantio>();
        }

        public short IdSeguradora { get; set; }
        public string NomeSeguradora { get; set; }

        public virtual ICollection<Plantio> Plantios { get; set; }
    }
}
