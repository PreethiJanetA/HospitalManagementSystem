using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public Patient() { }

        public Patient(int patId, string fname, string lname, DateTime dob, string gender, string contact, string address)
        {
            PatientId = patId;
            FirstName = fname;
            LastName = lname;
            DateOfBirth = dob;
            Gender = gender;
            ContactNumber = contact;
            Address = address;
        }

        public override string ToString()
        {
            return $"{PatientId}: {FirstName} {LastName}, DOB: {DateOfBirth}, Gender: {Gender}, Contact: {ContactNumber}, Address: {Address}";
        }
    }
}
