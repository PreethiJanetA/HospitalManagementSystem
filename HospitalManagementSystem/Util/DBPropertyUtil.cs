using System;
using System.Collections.Generic;
using System.Configuration;


namespace HospitalManagementSystem.Util
{
    public class DBPropertyUtil
    {
        public static string GetPropertyString()
        {
            return ConfigurationManager.ConnectionStrings["hospitaldb"].ConnectionString;
        }
    }
}
