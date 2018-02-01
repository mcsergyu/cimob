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

        public int CandidaturaId { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(120, ErrorMessage = "Não pode exceder os 120 caracteres")]
        public String Description { get; set; }

        [Display(Name = "Data Agendada")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Confirmada")]
        public Boolean Confirmed { get; set; }

    }
}
