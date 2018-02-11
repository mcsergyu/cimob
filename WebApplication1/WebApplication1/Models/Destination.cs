using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    [JsonObject(IsReference = true)]
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "A indicação da cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A indicação do país é obrigatório")]
        [Display(Name = "País")]
        public string Pais { get; set; }

        public virtual List<Program> Programs { get; set; }
    }
}
