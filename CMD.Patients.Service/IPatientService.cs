using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.Service
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPatientService
    {
        [OperationContract]
        bool AddPatient(Patient patient);

        [OperationContract]
        List<Patient> GetAllPatients();

        [OperationContract]
        Patient GetPatientById(String emailId);

        [OperationContract]
        bool UpdatePatient(Patient patient,String id);

        [OperationContract]
        bool RemovePatient(String emailId);
        [OperationContract]
        bool ValidatePatient(String emailId, String password);
    }
}
