using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }

        public Doctor() { }

        public Doctor(int docId, string fname, string lname, string spec, string contact)
        {
            DoctorId = docId;
            FirstName = fname;
            LastName = lname;
            Specialization = spec;
            ContactNumber = contact;
        }

        public override string ToString()
        {
            return $"{DoctorId}: {FirstName} {LastName}, Specialization: {Specialization}, Contact: {ContactNumber}";
        }
    }
}
