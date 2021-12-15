﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContactDetailsLibrary;
using LocationLibrary;

namespace SupplierLibrary.Models
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierABN { get; set; }

        [Required]
        public ICollection<ContactDetails> ContactDetails { get; set; }

        [Required]
        public ICollection<Location> Location { get; set; }
    }
}