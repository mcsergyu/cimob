using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class Program
    {
        [Key]
        public int ProgramId { get; set; }

        [Display(Name = "Nome do Programa")]
        [Required(ErrorMessage = "A indicação do nome do programa é obrigatório")]
        public string Name { get; set; }

        [ForeignKey("Destination")]
        [Display(Name = "Destino do programa")]
        public int DestinationId { get; set; }

        [ForeignKey("Entity")]
        [Display(Name = "Entidade Parceira")]
        public int EntityId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A indicação da descrição é obrigatório")]
        public string Description { get; set; }

        [Display(Name = "Número de vagas")]
        [Required(ErrorMessage = "A indicação do nº de vagas é obrigatório")]
        [Range(1, 10000000, ErrorMessage = "O valor tem de ser maior que 0")]
        public int Vacancies { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Início do programa")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fim do programa")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime EndDate { get; set; }

        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "O valor da bolsa tem de ser um valor positivo")]
        [Display(Name = "Bolsa")]
        public double Bolsa { get; set; }

        public virtual Entity ProgramEntity { get; set; }
        public virtual Destination ProgramDestination { get; set; }
    }
}
