using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class Candidatura
    {
        [Key]
        public int CandidaturaId { get; set; }

        [ForeignKey("Program")]
        [Display(Name = "Programa")]
        public int ProgramId { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "Candidato")]
        public String UserId { get; set; }

        [ForeignKey("Entrevista")]
        [Display(Name = "Entrevista")]
        public int InterviewId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de submissão")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de último estado")]
        [Required(ErrorMessage = "A indicação da data é obrigatório")]
        public DateTime LastStateDate { get; set; }

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
