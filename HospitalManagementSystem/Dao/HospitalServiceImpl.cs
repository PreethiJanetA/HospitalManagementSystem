using HospitalManagementSystem.Entity;
using HospitalManagementSystem.Exception;
using HospitalManagementSystem.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Dao
{

    public class HospitalServiceImpl : IHospitalService
    {
        public Appointment GetAppointmentById(int appointmentId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE appointmentId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", appointmentId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Appointment(
                                (int)reader["appointmentId"],
                                (int)reader["patientId"],
                                (int)reader["doctorId"],
                                Convert.ToDateTime(reader["appointmentDate"]),
                                reader["description"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE patientId = @pid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", patientId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new PatientNumberNotFoundException("Patient ID not found.");
                        }
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment(
                                (int)reader["appointmentId"],
                                (int)reader["patientId"],
                                (int)reader["doctorId"],
                                Convert.ToDateTime(reader["appointmentDate"]),
                                reader["description"].ToString()
                            ));
                        }
                    }
                }
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE doctorId = @did";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@did", doctorId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment(
                                (int)reader["appointmentId"],
                                (int)reader["patientId"],
                                (int)reader["doctorId"],
                                Convert.ToDateTime(reader["appointmentDate"]),
                                reader["description"].ToString())
                            );
                        }
                    }
                }
            }
            return appointments;
        }

        public bool ScheduleAppointment(Appointment appt)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Appointment (patientId, doctorId, appointmentDate, description) VALUES ( @pid, @did, @date, @desc)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@pid", appt.PatientId);
                    cmd.Parameters.AddWithValue("@did", appt.DoctorId);
                    cmd.Parameters.AddWithValue("@date", appt.AppointmentDate);
                    cmd.Parameters.AddWithValue("@desc", appt.Description);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateAppointment(Appointment appt)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Appointment SET patientId = @pid, doctorId = @did, appointmentDate = @date, description = @desc WHERE appointmentId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", appt.PatientId);
                    cmd.Parameters.AddWithValue("@did", appt.DoctorId);
                    cmd.Parameters.AddWithValue("@date", appt.AppointmentDate);
                    cmd.Parameters.AddWithValue("@desc", appt.Description);
                    cmd.Parameters.AddWithValue("@id", appt.AppointmentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Appointment WHERE appointmentId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", appointmentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddPatient(Patient patient)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Patient (patientId, firstName, lastName, dateOfBirth, gender, contactNumber, address) VALUES (@id, @fname, @lname, @dob, @gender, @contact, @address)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", patient.PatientId);
                    cmd.Parameters.AddWithValue("@fname", patient.FirstName);
                    cmd.Parameters.AddWithValue("@lname", patient.LastName);
                    cmd.Parameters.AddWithValue("@dob", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@contact", patient.ContactNumber);
                    cmd.Parameters.AddWithValue("@address", patient.Address);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddDoctor(Doctor doctor)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Doctor (doctorId, firstName, lastName, specialization, contactNumber) VALUES (@id, @fname, @lname, @spec, @contact)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", doctor.DoctorId);
                    cmd.Parameters.AddWithValue("@fname", doctor.FirstName);
                    cmd.Parameters.AddWithValue("@lname", doctor.LastName);
                    cmd.Parameters.AddWithValue("@spec", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@contact", doctor.ContactNumber);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Patient GetPatientById(int patientId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Patient WHERE patientId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", patientId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient(
                                (int)reader["patientId"],
                                reader["firstName"].ToString(),
                                reader["lastName"].ToString(),
                                Convert.ToDateTime(reader["dateOfBirth"]),
                                reader["gender"].ToString(),
                                reader["contactNumber"].ToString(),
                                reader["address"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Doctor WHERE doctorId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", doctorId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Doctor(
                                (int)reader["doctorId"],
                                reader["firstName"].ToString(),
                                reader["lastName"].ToString(),
                                reader["specialization"].ToString(),
                                reader["contactNumber"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }
    }
}
