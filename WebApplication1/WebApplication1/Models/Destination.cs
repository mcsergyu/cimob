using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of destinations
    /// </summary>
    /// <remarks></remarks>
    [JsonObject(IsReference = true)]
    public class Destination
    {
        /// <summary>
        /// Gets or sets unique destination id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        [Key]
        public int DestinationId { get; set; }

        /// <summary>
        /// Gets or sets city of the program.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [Required(ErrorMessage = "A indicação da cidade é obrigatório")]
        public string Cidade { get; set; }

        /// <summary>
        /// Gets or sets country of the program.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [Required(ErrorMessage = "A indicação do país é obrigatório")]
        [Display(Name = "País")]
        public string Pais { get; set; }


        public virtual List<Program> Programs { get; set; }
    }
}
