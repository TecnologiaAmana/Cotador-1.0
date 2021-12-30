using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Plantio
    {
        public Plantio()
        {
            Taxas = new HashSet<Taxa>();
        }

        public int IdPlantio { get; set; }
        public short? IdSeguradora { get; set; }
        public short? IdMunicipio { get; set; }
        public short? IdCultura { get; set; }
        public short? IdPropriedade { get; set; }

        public virtual Cultura IdCulturaNavigation { get; set; }
        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual Propriedade IdPropriedadeNavigation { get; set; }
        public virtual Seguradora IdSeguradoraNavigation { get; set; }
        public virtual ICollection<Taxa> Taxas { get; set; }
    }
}
