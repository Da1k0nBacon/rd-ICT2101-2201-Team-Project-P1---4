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



    }
}