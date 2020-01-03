using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheldule
{
    class BusyAudinces
    {
        OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");

        public void AddAud(Lesson aud)
        {
            con.Open();
            string Aud = "INSERT INTO BusyAudinces VALUES('"+aud.Day+"','"+aud.Time+"','"+aud.aud+"')";
            OleDbCommand cmd = new OleDbCommand(Aud, con);
            cmd.ExecuteReader();
            con.Close();
        }
    }
}
