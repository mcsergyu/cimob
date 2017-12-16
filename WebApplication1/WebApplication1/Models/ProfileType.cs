using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cimob.Models
{
    public class ProfileType
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

    }
}