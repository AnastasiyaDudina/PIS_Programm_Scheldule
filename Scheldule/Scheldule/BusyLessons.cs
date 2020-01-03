using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheldule
{
    class BusyLessons
    {
        OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");

        public int SchID { get; set; }

        public void AddLesson(Lesson UndLesson)
        {
            con.Open();
            string Lessons = "INSERT INTO BusyLessons VALUES('"+ SchID + "','"+ UndLesson.NameD+ "','"+ UndLesson.Day+ "','"+ UndLesson.Time+ "','"+ UndLesson.aud+ "')";
            OleDbCommand command = new OleDbCommand(Lessons, con);
            command.ExecuteReader();
            con.Close();
        }
    }
}
