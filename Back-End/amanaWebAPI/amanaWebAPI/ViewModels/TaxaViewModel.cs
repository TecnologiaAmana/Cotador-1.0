using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.ViewModels
{
    public class TaxaViewModel
    {
        public int? IdPlantio { get; set; }

        [Required(ErrorMessage ="É necessário informar a área")]
        public int? Area { get; set; }

        public List<int?> Plantios { get; set; }
    }
}
