using System;
using System.Net;
using Oracle.ManagedDataAccess.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OracleDatabaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //string conString = "User Id=SYSTEM;Password=Pa$$word;Data Source=scott";

            string conString = "User Id = SYSTEM; Password = password; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = " +
"localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = scott)))";

            using (OracleConnection con = new OracleConnection(conString))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connected to Oracle database.");

                    string sqlQuery = "SELECT * FROM EMP";
                    
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("EMPNO\tENAME\tJOB\t\tMGR\tHIREDATE\tSAL\tCOMM\tDEPTNO");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["EMPNO"]}\t{reader["ENAME"]}\t{reader["JOB"]}\t{reader["MGR"]}\t{reader["HIREDATE"]}\t{reader["SAL"]}\t{reader["COMM"]}\t{reader["DEPTNO"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
