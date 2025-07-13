using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member_management.DBUtil
{
    internal class DBUtils
    {
        private static void Asdf()
        {
            string connectionString = "User Id=C##FIN;Password=1234;Data Source=localhost:1521/xe";

            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("DB 연결 성공!");

                    string sql = "SELECT * FROM MEMBER_MANAGEMENT";

                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, NAME: {reader["NAME"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"오류 발생: {ex.Message}");
                }
            }
        }
    }
}
