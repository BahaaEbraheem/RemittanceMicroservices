﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static EShopOnAbp.CustomerService.Enums.Enums;

namespace EShopOnAbp.CustomerService.Customers
{
    public class CreateUpdateCustomerDto : IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string FatherName { get; set; }
        [Required]

        public string MotherName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]

        public string Phone { get; set; }

        public string Address { get; set; }
        [Required]

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    "The date of birth cannot be greater than today's date 0!",
                    new[] { "BirthDate" }
                );
            }
        }
    }
}
