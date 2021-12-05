using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2201_Robot_Car_Website.Models;
using MySql.Data.MySqlClient;

namespace _2201_Robot_Car_Website.Data
{
    public class DataAccess
    {
        public static List<Student> GetClasses()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string Query = "SELECT StudentName, Class  from Student";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Student> Studentlist = new List<Student>();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Class = reader["Class"].ToString();
                    student.StudentName = reader["StudentName"].ToString();

                    Studentlist.Add(student);
                }
                con.Close();
                return Studentlist;
            }
        }

        public static void SaveCommandHistory(List<command> cmd)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string InsertSql = "INSERT INTO command VALUES (@Direction, @CommandSeq_id, @OrderNum, @Student_Sid, @Mapdata_Mid)";
                con.Open();

                foreach (command cmdItem in cmd)
                {
                    MySqlCommand sqlCommand = new MySqlCommand(InsertSql, con);
                    sqlCommand.Parameters.AddWithValue("@Direction", cmdItem.Direction);
                    sqlCommand.Parameters.AddWithValue("@CommandSeq_id", cmdItem.CommandSeq_id);
                    sqlCommand.Parameters.AddWithValue("@OrderNum", cmdItem.OrderNum);
                    sqlCommand.Parameters.AddWithValue("@Student_Sid", cmdItem.Student_Sid);
                    sqlCommand.Parameters.AddWithValue("@Mapdata_Mid", cmdItem.Mapdata_Mid);
                    sqlCommand.ExecuteNonQuery();
                }
                con.Close();
            }
        }



    }
}