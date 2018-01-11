using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.ProgramViewModels
{
    public class EntityViewModel
    {
        [Key]
        public int EntityId { get; set; }

        [Required(ErrorMessage = "A indicação da entidade é obrigatório")]
        public string Entity { get; set; }

        public virtual List<ProgramViewModel> Programs { get; set; }
    }
}
