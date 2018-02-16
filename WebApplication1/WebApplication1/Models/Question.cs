using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cimob.Models
{
    /// <summary>
    /// Implementation of the secret question
    /// </summary>
    /// <remarks></remarks>
    public class Question
    {
        /// <summary>
        /// Gets or sets Question id.
        /// </summary>
        /// <value>int</value>
        /// <remarks>autoincrement</remarks>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets secret question.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets secret answer.
        /// </summary>
        /// <value>string</value>
        /// <remarks></remarks>
        public string Description2 { get; set; }

    }
}