using member_management.Models.Dto;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace member_management.ViewModels
{
    public class MemberListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();

        public MemberListViewModel()
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            string connStr = "User Id=C##FIN;Password=1234;Data Source=localhost:1521/xe";

            using (var conn = new OracleConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM MEMBER_MANAGEMENT";
                    using (var cmd = new OracleCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Members.Add(new Member
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                NAME = reader["NAME"].ToString(),
                                MAIL = reader["MAIL"].ToString(),
                                PHONE_NUMBER = reader["PHONE_NUMBER"].ToString(),
                                DEPARTMENT = reader["DEPARTMENT"].ToString(),
                                RANK = reader["RANK"].ToString(),
                                COLLEGE = reader["COLLEGE"]?.ToString(),
                                BIRTH = DateTime.TryParse(reader["BIRTH"].ToString(), out var birth) ? birth : DateTime.MinValue
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 로그 또는 디버깅 출력
                    Console.WriteLine("오류: " + ex.Message);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
