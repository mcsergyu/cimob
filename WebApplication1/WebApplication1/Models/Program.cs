using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of application to programs
    /// </summary>
    /// <remarks></remarks>
    [JsonObject(IsReference = true)]
    public class Program
    {
        /// <summary>
        /// Gets or sets Program unique Id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        [Key]
        public int ProgramId { get; set; }

        /// <summary>
        /// Gets or sets Name of the Program.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [Display(Name = "Nome do Programa")]
        [Required(ErrorMessage = "A indicação do nome do programa é obrigatório")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets linked destination id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>Foreignkey</remarks>
        [ForeignKey("Destination")]
        [Display(Name = "Destino do programa")]
        public int DestinationId { get; set; }

        /// <summary>
        /// Gets or sets linked entity id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>Foreignkey</remarks>
        [ForeignKey("Entity")]
        [Display(Name = "Entidade Parceira")]
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets description of the program.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A indicação da descrição é obrigatório")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets number of vacancies.
        /// </summary>
        /// <value>int</value>
        /// <remarks></remarks>
        [Display(Name = "Número de vagas")]
        [Required(ErrorMessage = "A indicação do nº de vagas é obrigatório")]
        [Range(1, 10000000, ErrorMessage = "O valor tem de ser maior que 0")]
        public int Vacancies { get; set; }


        /// <summary>
        /// Gets or sets program begining date.
        /// </summary>
        /// <value>DateTime</value>
        /// <remarks></remarks>
        [DataType(DataType.Date)]
        [Display(Name = "Início do programa")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets program end date.
        /// </summary>
        /// <value>DateTime</value>
        /// <remarks></remarks>
        [DataType(DataType.Date)]
        [Display(Name = "Fim do programa")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets of scholarship value.
        /// </summary>
        /// <value>double</value>
        /// <remarks></remarks>
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "O valor da bolsa tem de ser um valor positivo")]
        [Display(Name = "Bolsa")]
        public double Bolsa { get; set; }

        public virtual Entity ProgramEntity { get; set; }
        public virtual Destination ProgramDestination { get; set; }
    }
}
