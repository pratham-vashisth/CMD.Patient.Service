using AutoMapper;
using CMD.Patients.DTOs;
using CMD.Patients.Models;
using CMD.Patients.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.BusinessLogic
{
    public class PatientManager
    {
        private PatientManager()
        { }
        private static PatientManager patientManager = null;
        public static PatientManager GetPatientManager()
        {
            if (patientManager == null)
            {
                patientManager = new PatientManager();
            }
            return patientManager;
        }
        DbManager dbManager = DbManager.GetDbManager();
        public bool AddPatient(PatientDTO patientDTO)
        {
            //automapper and passing
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>());
            var mapper = new Mapper(config); 
            Patient patient = mapper.Map<Patient>(patientDTO);

            return dbManager.AddPatient(patient);
        }
        public List<PatientDTO> GetAllPatients()
        {
            List<Patient> patients = dbManager.GetAllPatients();
            List<PatientDTO> allPatients = new List<PatientDTO>();

            //automapper logic
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            for (int i = 0; i < patients.Count(); i++)
            {
                PatientDTO patient = mapper.Map<PatientDTO>(patients[i]);
                allPatients.Add(patient);
            }
            return allPatients;
        }
        public PatientDTO GetPatientById(String emailId)
        {
            long idToBeSearched = GetPatientIdUsingEmailId(emailId);
            Patient pat = dbManager.GetPatientById(idToBeSearched);

            //automapper logic pat->patient
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            PatientDTO patient = mapper.Map<PatientDTO>(pat);
            
            return patient;
        }
        public bool UpdatePatient(PatientDTO patientDTO, String emailId)
        {
            bool isUpdated = false;

           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>());
            var mapper = new Mapper(config);
            Patient patient = mapper.Map<Patient>(patientDTO);

            long idToBeSearched = GetPatientIdUsingEmailId(emailId);
            if (dbManager.UpdatePatient(patient, idToBeSearched))
            {
                isUpdated = true;
            }
            return isUpdated;
        }
        public bool DeletePatient(String emailId)
        {
            bool isDeleted = false;
            long idToBeSearched = GetPatientIdUsingEmailId(emailId);

            if (dbManager.DeletePatientById(idToBeSearched))
            {
                isDeleted = true;
            }

            return isDeleted;
        }



        private long GetPatientIdUsingEmailId(String emailId)
        {
            long idToBeSearched = 0;
            List<PatientDTO> patList = GetAllPatients();
            foreach (PatientDTO patientDTO in patList)
            {
                if (patientDTO.EmailId.Equals(emailId))
                {
                    idToBeSearched = patientDTO.Id;
                }
            }
            return idToBeSearched;
        }

        public bool ValidatePatientForSignIn(string emailId, string password)
        {
            bool isValid = false;
            if (dbManager.ValidatePatientForSignIn(emailId, password))
            {
                isValid = true;
            }
            return isValid; 
        }
    }
}
    