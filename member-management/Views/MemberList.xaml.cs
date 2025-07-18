﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace member_management.Views
{
    /// <summary>
    /// list.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MemberList : Window
    {
        public MemberList()
        {
            InitializeComponent();
        }
        private void closeClick(object s, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void asdf(object s, RoutedEventArgs e)
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

        private void newPage(object s, RoutedEventArgs a)
        {
            MemberList1 m = new MemberList1();
            m.Show();
        }
    }
}
