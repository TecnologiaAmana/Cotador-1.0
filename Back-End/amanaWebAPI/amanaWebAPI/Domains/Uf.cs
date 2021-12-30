using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Uf
    {
        public Uf()
        {
            Municipios = new HashSet<Municipio>();
        }

        public byte IdUf { get; set; }
        public string NomeUf { get; set; }
        public string Abreviacao { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
