using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.DTOs
{
    public class PatientDTO
    {
        public long Id { get; set; }
       
        public String Name { get; set; }
       
        public String BloodGroup { get; set; }
       
        public String Gender { get; set; }
      
        public String Password { get; set; }
       
        public String EmailId { get; set; }
       
        public String PhoneNumber { get; set; }
        public String Location { get; set; }

        public String Image { get; set; }

    }
}
