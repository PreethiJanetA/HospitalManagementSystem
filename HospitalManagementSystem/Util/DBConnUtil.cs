using System.Data.SqlClient;


namespace HospitalManagementSystem.Util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string connStr = DBPropertyUtil.GetPropertyString();
            return new SqlConnection(connStr);
        }
    }
}
