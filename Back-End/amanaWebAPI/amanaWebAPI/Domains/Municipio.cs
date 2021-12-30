using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Municipio
    {
        public Municipio()
        {
            Plantios = new HashSet<Plantio>();
            Propriedades = new HashSet<Propriedade>();
        }

        public short IdMunicipio { get; set; }
        public byte? IdUf { get; set; }
        public string NomeMunicipio { get; set; }

        public virtual Uf IdUfNavigation { get; set; }
        public virtual ICollection<Plantio> Plantios { get; set; }
        public virtual ICollection<Propriedade> Propriedades { get; set; }
    }
}
