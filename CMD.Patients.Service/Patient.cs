using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.Service
{
    [DataContract]
    public class Patient
    {
       
        public long Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String EmailId { get; set; } 
        [DataMember]
        public String PhoneNumber { get; set; }
        [DataMember]
        public String Location { get; set; }
        [DataMember]
        public String BloodGroup { get; set; }     
        [DataMember]
        public String Gender { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String Image { get; set; }
    }
}
