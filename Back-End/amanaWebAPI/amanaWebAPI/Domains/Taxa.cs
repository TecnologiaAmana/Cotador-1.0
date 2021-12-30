using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Taxa
    {
        public int IdTaxa { get; set; }
        public int? IdPlantio { get; set; }
        public short? IdNivelCobertura { get; set; }
        public double? ValorTaxaBasica { get; set; }
        public double? ValorTaxaReplantio { get; set; }
        public double ProdutividadeEsperada { get; set; }
        public int MaxSaca { get; set; }
        public short Lmgareplantio { get; set; }

        public double? ValorLmgaReplantio { get; set; }

        public virtual Nivelcobertura IdNivelCoberturaNavigation { get; set; }
        public virtual Plantio IdPlantioNavigation { get; set; }
        public double? Lmgabasica { get; set; }
        public double? ProdutivadeGarantida { get; set; }
        public double? PremioBasicaSubvencao { get; set; }
        public double? PremioBasica { get; set; }
        public double? PremioReplantio { get; set; }
        public double? PremioReplantioSubvencao { get; set; }
        public double? Subvencao { get; set; }
        public double? PremioSubvencao { get; set; }
        public double? PremioMedio { get; set; }
        public double? PremioMedioSubvencao { get; set; }

        public double? PremioTotal { get; set; }
    }
}
