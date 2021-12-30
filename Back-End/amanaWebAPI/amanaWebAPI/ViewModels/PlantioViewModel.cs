using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.ViewModels
{
    public class PlantioViewModel
    {
        [Required(ErrorMessage ="É necessário informar a seguradora")]
        public short IdSeguradora { get; set; }
        [Required(ErrorMessage = "É necessário informar o município")]
        public short IdMunicipio { get; set; }
        [Required(ErrorMessage = "É necessário informar a cultura")]
        public short IdCultura { get; set; }
    }
}
