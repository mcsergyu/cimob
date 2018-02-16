using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of the entity application
    /// </summary>
    /// <remarks></remarks>
    public class Entity
    {

        /// <summary>
        /// Gets or sets unique entity id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        [Key]
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets of entity name.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [Required(ErrorMessage = "A indicação da entidade é obrigatório")]
        public string EntityName { get; set; }

        public virtual List<Program> Programs { get; set; }
    }
}

