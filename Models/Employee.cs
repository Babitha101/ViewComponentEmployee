using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentEmployee.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
