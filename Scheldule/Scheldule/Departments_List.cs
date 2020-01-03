using System;
using System.Data.OleDb;

namespace Scheldule
{
    class Departments_List
    {
        OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");

        public int FindDep(string nameD)
        {
            con.Open();
            string depart = "select id from ListDepartments where Name = '" + nameD + "'";
            OleDbCommand command = new OleDbCommand(depart, con);
            int result = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return result;
        }
    }
}
