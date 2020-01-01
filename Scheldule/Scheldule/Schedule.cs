using System;
using System.Data.OleDb;

namespace Scheldule
{
    class Schedule
    {
        OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");
        public int Created(int semestr)
        {
            con.Open();
            string createSch = "INSERT INTO schedule VALUES('" + semestr + "'); SELECT SCOPE_IDENTITY();";
            OleDbCommand command = new OleDbCommand(createSch, con);
            int result = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return result;
        }
    }
}
