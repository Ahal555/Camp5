using PatientManagementSystem.Models;

namespace PatientManagementSystem.Service
{
    public interface IPatientService
    {
        //View patient details
        IEnumerable<Patient> GetAllPatients();
    }
}
