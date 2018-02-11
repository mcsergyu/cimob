using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of application to mobility program
    /// </summary>
    /// <remarks></remarks>
    public class Candidatura
    {
        /// <summary>
        /// Gets or sets Candidatura unique id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        [Key]
        public int CandidaturaId { get; set; }

        /// <summary>
        /// Gets or sets linked program id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>Foreignkey</remarks>
        [ForeignKey("Program")]
        [Display(Name = "Programa")]
        public int ProgramId { get; set; }

        /// <summary>
        /// Gets or sets linked user id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>Foreignkey</remarks>
        [ForeignKey("ApplicationUser")]
        [Display(Name = "Candidato")]
        public String UserId { get; set; }

        /// <summary>
        /// Gets or sets linked interview id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>Foreignkey</remarks>
        [ForeignKey("Entrevista")]
        [Display(Name = "Entrevista")]
        public int InterviewId { get; set; }

        /// <summary>
        /// Gets or sets application submission date.
        /// </summary>
        /// <value>DateTime</value>
        /// <remarks></remarks>
        [DataType(DataType.Date)]
        [Display(Name = "Data de submissão")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets date of last state change.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        [DataType(DataType.Date)]
        [Display(Name = "Data de último estado")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime LastStateDate { get; set; }

        /// <summary>
        /// Gets or sets application state.
        /// </summary>
        /// <value>CandidaturaState</value>
        /// <remarks></remarks>
        [Display(Name = "Estado")]
        public CandidaturaState State { get; set; }

        [Display(Name = "Programa")]
        public virtual Program AppliedProgram { get; set; }

        [Display(Name = "Candidato")]
        public virtual ApplicationUser SubmissionUser { get; set; }

        [Display(Name = "Entrevista")]
        public virtual Interview Entrevista { get; set; }
    }
}
