using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.ProgramViewModels
{
    public class ProgramViewModel
    {
        [Display(Name = "Nome do Programa")]
        [Required(ErrorMessage = "A indicação do nome do programa é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A indicação da entidade é obrigatório")]
        public string Entity { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A indicação da descrição é obrigatório")]
        public int Description { get; set; }

        [Display(Name = "Número de vagas")]
        [Required(ErrorMessage = "A indicação do nº de vagas é obrigatório")]
        [Range(1, 10000000, ErrorMessage = "O valor tem de ser maior que 0")]
        public int Vacancies { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime EndDate { get; set; }

        public virtual EntityViewModel ProgramEntity { get; set; }
        public virtual DestinationViewModel ProgramDestination { get; set; }
   
    }
}
