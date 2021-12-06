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


        public static Student getstudentInfo(int sid)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string query = "SELECT * FROM Student WHERE Sid = @studentid";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentid", sid);
                MySqlDataReader reader = cmd.ExecuteReader();

                Student student = new Student();
                while (reader.Read())
                {
                    student.Class = reader["Class"].ToString();
                    student.StudentName = reader["StudentName"].ToString();

                }
                con.Close();



                return student;
            }
        }

        public static List<command> LoadCommandHist()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string Query = "SELECT  *  from command WHERE Student_Sid = '" + "1" + "' ORDER BY CommandSeq_id, OrderNum";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<command> CommandHistList = new List<command>();
                while (reader.Read())
                {
                    command commandObj = new command();
                    commandObj.Direction = reader["Direction"].ToString();
                    commandObj.CommandSeq_id = (int)reader["CommandSeq_id"];
                    commandObj.OrderNum = (int)reader["OrderNum"];
                    commandObj.Mapdata_Mid = (int)reader["Mapdata_Mid"];
                    commandObj.Student_Sid = (int)reader["Student_Sid"];

                    CommandHistList.Add(commandObj);
                }
                con.Close();
                return CommandHistList;
            }
        }


        public static List<Student> GetRobotData()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string Query = "select s.StudentName, s.Class, s.Sid, r.Conn_Status from student s inner join robotdata r on s.Sid = r.Student_Sid";
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
                string Query = "select s.StudentName, s.Class, s.Sid, r.Conn_Status from student s inner join robotdata r on s.Sid = r.Student_Sid where s.Class = '" + Class + "'";
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
        public static int getNewSeqID()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string queryNewSeqID = "SELECT  MAX(CommandSeq_id) as MAX from command";
                con.Open();
                MySqlCommand NewSeqCmd = new MySqlCommand(queryNewSeqID, con);
                MySqlDataReader readSeqID = NewSeqCmd.ExecuteReader();
                command cmd = new command();
                while (readSeqID.Read())
                {
                    cmd.CommandSeq_id = (int)readSeqID["MAX"] + 1;

                }
                int newSeqID = cmd.CommandSeq_id;
                con.Close();
                return 0;

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

        
        public static void GetMap(int mapid)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=password;port=3306"))
            {
                string query = "SELECT * FROM mapdata WHERE Mid = @mapid";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mapid", mapid);
                MySqlDataReader reader = cmd.ExecuteReader();

                mapdata map = new mapdata();
                while (reader.Read())
                {
                   
                    map.Mid = int.Parse(reader["Mid"].ToString());
                    map.Grid1 = reader["Grid1"].ToString();
                    map.Grid2 = reader["Grid2"].ToString();
                    map.Grid3 = reader["Grid3"].ToString();
                    map.Grid4 = reader["Grid4"].ToString();
                    map.Grid5 = reader["Grid5"].ToString();
                    map.Grid6 = reader["Grid6"].ToString();
                    map.Grid7 = reader["Grid7"].ToString();
                    map.Grid8 = reader["Grid8"].ToString();

                    map.Grid9 = reader["Grid9"].ToString();
                    map.Grid10 = reader["Grid10"].ToString();
                    map.Grid11 = reader["Grid11"].ToString();
                    map.Grid12 = reader["Grid12"].ToString();
                    map.Grid13 = reader["Grid13"].ToString();
                    map.Grid14 = reader["Grid14"].ToString();
                    map.Grid15 = reader["Grid15"].ToString();
                    map.Grid16 = reader["Grid16"].ToString();

                }
                con.Close();
            }
        }


    }
}