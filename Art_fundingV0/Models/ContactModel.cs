
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Art_fundingV0.Models
{
    public class ContactModel
    {

        [Required]
        public string Message { get; set; }

        [Required]
        public int artisteId { get; set; }
    }
}