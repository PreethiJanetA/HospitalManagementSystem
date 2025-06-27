using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }

        public Appointment() { }

        public Appointment(int apptId, int patId, int docId, DateTime date, string desc)
        {
            AppointmentId = apptId;
            PatientId = patId;
            DoctorId = docId;
            AppointmentDate = date;
            Description = desc;
        }

        public override string ToString()
        {
            return $"{AppointmentId}: Patient {PatientId}, Doctor {DoctorId}, Date: {AppointmentDate}, Description: {Description}";
        }
    }
}
