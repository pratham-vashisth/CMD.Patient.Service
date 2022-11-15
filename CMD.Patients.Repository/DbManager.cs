using CMD.Patients.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.Repository
{
    public class DbManager
    {
        private static DbManager instance = null;
        private DbManager() { }
        public static DbManager GetDbManager()
        {
            if (instance == null)
            {
                instance = new DbManager();
            }
            return instance;
        }
        PatientsDbContext patientsDbContext = new PatientsDbContext();
        public bool AddPatient(Patient patients)
        {

            bool IsAdded = false;

            try
            {
                SignInPatients signInPatients = new SignInPatients();
                signInPatients.EmailId = patients.EmailId;
                signInPatients.Password = patients.Password;

                patientsDbContext.patientsSignIn.Add(signInPatients);
                patientsDbContext.patients.Add(patients);
                patientsDbContext.SaveChanges();
                IsAdded = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return IsAdded;
        }
        public List<Models.Patient> GetAllPatients()
        {
            List<Models.Patient> allPatients = patientsDbContext.patients.ToList();
            return allPatients;
        }
        public Models.Patient GetPatientById(long id)
        {
            //var patient = patientsDbContext.patients.FirstOrDefault(x => x.Id == id);
            foreach(var x in patientsDbContext.patients.ToList())
            {
                if(x.Id == id)
                return x;
            }
            return null;
        }
        public bool UpdatePatient(Models.Patient patient, long id)
        {
            bool IsUpdated = false;
            var patientToBeUpdated = patientsDbContext.patients.FirstOrDefault(x => x.Id == id);
            if (patientToBeUpdated != null)
            {
                patientToBeUpdated.Name = patient.Name;
                patientToBeUpdated.EmailId = patient.EmailId;
                patientToBeUpdated.PhoneNumber = patient.PhoneNumber;
                patientToBeUpdated.Password = patient.Password;
                patientToBeUpdated.Location = patient.Location;
                patientsDbContext.SaveChanges();
                IsUpdated = true;
            }
            return IsUpdated;
        }
        public bool DeletePatientById(long id)
        {
            bool isDeleted = false;
            var patientToBeDeleted = patientsDbContext.patients.FirstOrDefault(x => x.Id == id);
            if (patientToBeDeleted != null)
            { 
                patientsDbContext.patients.Remove(patientToBeDeleted);
                patientsDbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public bool ValidatePatientForSignIn(string emailId, string password)
        {
            bool IsValid = false;
            var patientToBeSignedIn = patientsDbContext.patientsSignIn.FirstOrDefault(x => x.EmailId.Equals(emailId));
            if (patientToBeSignedIn != null)
            {
                if (patientToBeSignedIn.Password.Equals(password))
                {
                    IsValid = true; 
                }
            }
            return IsValid; 
        }
    }
}

