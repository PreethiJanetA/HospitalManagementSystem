using HospitalManagementSystem.Entity;
using System.Collections.Generic;


namespace HospitalManagementSystem.Dao
{
    public interface IHospitalService
    {
        Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        bool ScheduleAppointment(Appointment appt);
        bool UpdateAppointment(Appointment appt);
        bool CancelAppointment(int appointmentId);
    }
}
