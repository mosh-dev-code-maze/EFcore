using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Models
{
    public class Student
    {
        /// <summary>
        /// Student ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// First Name of student
        /// </summary>
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Range(1,120)]
        public int Age { get; set; }
        
        [Phone]
        public string PhoneNumber { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
    }
}
