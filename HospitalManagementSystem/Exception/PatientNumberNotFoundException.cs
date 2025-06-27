using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exception
{
    public class PatientNumberNotFoundException : RankException
    {
        public PatientNumberNotFoundException(string message) : base(message) { }
    }
}
