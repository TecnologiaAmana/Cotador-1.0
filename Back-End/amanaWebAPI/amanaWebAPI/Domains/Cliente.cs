using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Propriedades = new HashSet<Propriedade>();
        }

        public short IdCliente { get; set; }
        public string NomeClinte { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Propriedade> Propriedades { get; set; }
    }
}
