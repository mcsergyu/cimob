using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of scheduled interviews.
    /// </summary>
    /// <remarks></remarks>
    public class Interview
    {
        /// <summary>
        /// Gets or sets interview unique id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        public int InterviewId { get; set; }

        /// <summary>
        /// Gets or sets linked application id.
        /// </summary>
        /// <value>int</value>
        /// <remarks></remarks>
        public int CandidaturaId { get; set; }

        /// <summary>
        /// Gets or sets interview description.
        /// </summary>
        /// <value>String</value>
        /// <remarks></remarks>
        [Display(Name = "Descrição")]
        [MaxLength(120, ErrorMessage = "Não pode exceder os 120 caracteres")]
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets schedule date.
        /// </summary>
        /// <value>DateTime</value>
        /// <remarks></remarks>
        [Display(Name = "Data Agendada")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the schedule date is confirmed.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if ; otherwise, <see langword="false" />.</value>
        /// <remarks></remarks>
        [Display(Name = "Confirmada")]
        public Boolean Confirmed { get; set; }

    }
}
