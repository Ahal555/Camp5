using PatientManagementSystem.Models;

namespace PatientManagementSystem.Repository
{
    public interface IPatientRepository
    {
        //View patient details
        IEnumerable<Patient> GetAllPatients();

        //AddPatient
        void AddPatient(Patient patient);       
    }
}
