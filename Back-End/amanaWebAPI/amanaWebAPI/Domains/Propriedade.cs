using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Propriedade
    {
        public Propriedade()
        {
            Plantios = new HashSet<Plantio>();
        }

        public short IdPropriedade { get; set; }
        public short? IdMunicipio { get; set; }
        public short? IdCliente { get; set; }
        public short Area { get; set; }
        public string NomePropriedade { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual ICollection<Plantio> Plantios { get; set; }
    }
}
