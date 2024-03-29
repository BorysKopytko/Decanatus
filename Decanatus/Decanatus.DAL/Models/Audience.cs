﻿using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Audience : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
    }
}
