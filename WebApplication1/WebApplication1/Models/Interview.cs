using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class Interview
    {
        public int InterviewId { get; set; }

        [ForeignKey("Candidatura")]
        [Display(Name = "Candidatura")]
        public int CandidaturaId { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(120, ErrorMessage = "Não pode exceder os 120 caracteres")]
        public String Description { get; set; }

        [Display(Name = "Data Agendada")]
        public DateTime StartDate { get; set; }

        public Boolean Confirmed { get; set; }
    }
}
