using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimob_BackOffice
{
    public enum CandidaturaState
    {
        //[DisplayName(Name = "Aguarda agendamento")]
        scheduling,
        //[Display(Name = "Aguarda entrevista")]
        interview,
        //[Display(Name = "Cancelada")]
        canceled,
        //[Display(Name = "Rejeitada")]
        rejected,
        //[Display(Name = "Aprovada")]
        approved
    }
}
