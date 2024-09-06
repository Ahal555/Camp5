using PatientManagementSystem.Models;
using PatientManagementSystem.Repository;

namespace PatientManagementSystem.Service
{

    public class PatientServiceImplementation : IPatientService
    {
        //Fields
        private readonly IPatientRepository _patientRepository;

        //Dependency Injection
        public PatientServiceImplementation(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        //List of patients
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
        }
    }
}
