using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Cultura
    {
        public Cultura()
        {
            Plantios = new HashSet<Plantio>();
        }

        public short IdCultura { get; set; }
        public string NomeCultura { get; set; }

        public virtual ICollection<Plantio> Plantios { get; set; }
    }
}
