using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class Entity
    {

        [Key]
        public int EntityId { get; set; }

        [Required(ErrorMessage = "A indicação da entidade é obrigatório")]
        public string EntityName {get; set; }

        public virtual List<Program> Programs { get; set; }
    }
}

