using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.ViewModels
{
    public class TaxaViewModel
    {
        [Required(ErrorMessage ="É necessário informar o Plantio")]
        public int? IdPlantio { get; set; }

        [Required(ErrorMessage ="É necessário informar a área")]
        public int? Area { get; set; }

        [Required(ErrorMessage ="É necessário informar o nivel de cobertura")]
        public short? IdNivelCobertura { get; set; }
    }
}
