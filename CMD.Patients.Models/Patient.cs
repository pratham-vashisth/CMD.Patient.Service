using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMD.Patients.Models
{
   
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String BloodGroup { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String EmailId { get; set; }
        [Required]
        [StringLength(12)]
        public String PhoneNumber { get; set; }
        public String Location { get; set; }

        public String Image { get; set; }

    }
}
