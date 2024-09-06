using PatientManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace PatientManagementSystem.Repository
{
    public class PatientRepositoryImplementation : IPatientRepository
    {
        //Dependency Injection
        private readonly string connectionString;

        //Constructor injection
        public PatientRepositoryImplementation(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectionStringMVC");
        }

        //Add patients
        public void AddPatient(Patient patient)
        {

        }

        //Get all patients
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                //Connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("sp_SelectPatients", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Patient patient = new Patient();
                        patient.PatientId = Convert.ToInt32(dr["PatientId"].ToString());
                        patient.RegistrationNo = Convert.ToInt32(dr["RegistrationNo"].ToString());
                        patient.PatientName = dr["PatientName"].ToString();
                        patient.DOB = Convert.ToDateTime(dr["DOB"].ToString());
                        patient.Gender = dr["Gender"].ToString();
                        patient.Address = dr["Address"].ToString();
                        patient.PhoneNumber = dr["PhoneNumber"].ToString();

                        //Add to list
                        patients.Add(patient);

                    }
                    connection.Close();
                }
                return patients;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
