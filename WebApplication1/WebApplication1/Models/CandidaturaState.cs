﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementaion of the various possible Candidatura states
    /// </summary>
    /// <remarks></remarks>
    public enum CandidaturaState
    {
        [Display(Name = "Aguarda agendamento")]
        scheduling,
        [Display(Name = "Aguarda entrevista")]
        interview,
        [Display(Name = "Cancelada")]
        canceled,
        [Display(Name = "Rejeitada")]
        rejected,
        [Display(Name = "Aprovada")]
        approved
    }
}
