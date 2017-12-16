using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cimob.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        public string Description2 { get; set; }

    }
}