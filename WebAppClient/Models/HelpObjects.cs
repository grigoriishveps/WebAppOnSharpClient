using System.Collections.Generic;

namespace WebAppClient.Models
{
    public class HelpObjects
    {
        
        public IEnumerable<Patient> Patients;
        public IEnumerable<Doctor> Doctors;
        public IEnumerable<Disease> Disease;

        public HelpObjects(IEnumerable<Patient> patients, IEnumerable<Doctor> doctors, IEnumerable<Disease> disease)
        {
            Patients = patients;
            Doctors = doctors;
            Disease = disease;
        }
    }
}