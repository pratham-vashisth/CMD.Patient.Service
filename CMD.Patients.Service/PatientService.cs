using AutoMapper;
using CMD.Patients.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.Service
{
    public class PatientService : IPatientService
    {
        BusinessLogic.PatientManager manager = BusinessLogic.PatientManager.GetPatientManager();

        public bool AddPatient(Patient patient)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            PatientDTO patientDTO = mapper.Map<PatientDTO>(patient);

            return manager.AddPatient(patientDTO);
        }

        public List<Patient> GetAllPatients()
        {
            List<PatientDTO> patients = manager.GetAllPatients();
            List<Patient> allPatients = new List<Patient>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>());
            var mapper = new Mapper(config);

            for (int i = 0; i < patients.Count; i++)
            {
                Patient patient = mapper.Map<Patient>(patients[i]);
                allPatients.Add(patient);
            }
            return allPatients;
        }

        public Patient GetPatientById(String emailId)
        {
            PatientDTO pat = manager.GetPatientById(emailId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>());
            var mapper = new Mapper(config);
            Patient patient = mapper.Map<Patient>(pat);

            return patient;
        }

        public bool UpdatePatient(Patient patient, String emailId)
        {
            bool isUpadated = false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            PatientDTO patientDTO = mapper.Map<PatientDTO>(patient);

            if (manager.UpdatePatient(patientDTO, emailId))
            {
                isUpadated = true;
            }
            return isUpadated;

        }
        public bool RemovePatient(String emailId)
        {
            bool isRemoved = false;
            if (manager.DeletePatient(emailId))
            {
                isRemoved = true;
            }
            return isRemoved;
        }

        public bool ValidatePatient(string emailId, string password)
        {
            bool isValid = false;
            if (manager.ValidatePatientForSignIn(emailId, password))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
