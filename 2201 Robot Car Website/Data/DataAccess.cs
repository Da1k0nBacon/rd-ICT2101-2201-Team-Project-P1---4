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

        public static List<Student> GetRobotData()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string Query = "select s.StudentName, s.Class, r.Conn_Status from Student s inner join robotdata r on s.Sid = r.Student_Sid";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Student> Studentlist = new List<Student>();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Class = reader["Class"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.ConStatus = int.Parse(reader["Conn_Status"].ToString());

                    Studentlist.Add(student);
                }
                con.Close();
                return Studentlist;
            }
        }

        public static List<Student> GetRobotDataTest(string Class)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string Query = "select s.StudentName, s.Class, s.Sid, r.Conn_Status from robotwebsitedb.student s inner join robotwebsitedb.robotdata r on s.Sid = r.Student_Sid where s.Class = '" + Class + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Student> Studentlist = new List<Student>();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Class = reader["Class"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.ConStatus = int.Parse(reader["Conn_Status"].ToString());

                    Studentlist.Add(student);
                }
                con.Close();
                return Studentlist;
            }
        }



    }
}