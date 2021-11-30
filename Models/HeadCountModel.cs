using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewComponentEmployee.Models
{
    public class HeadCountModel
    {
        public int id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string empname { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
