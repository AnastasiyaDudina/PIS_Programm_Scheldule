using System.Data.OleDb;

namespace Scheldule
{
    class Disciplines_List
    {
        OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");
        public int CurriculumID { get; set; }

        public void AddDiscipline(int dis)
        {
            con.Open();
            string AddDir = "INSERT INTO ListDisciplines VALUES('" + CurriculumID + "','" + dis + "');";
            OleDbCommand command = new OleDbCommand(AddDir, con);
            command.ExecuteScalar();
            con.Close();
        }
    }
}
