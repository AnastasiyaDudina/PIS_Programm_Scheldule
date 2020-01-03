using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheldule
{
    public partial class SchedForm : Form
    {
        public SchedForm()
        {
            InitializeComponent();
        }

        private void SchedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
        }

        private void SchedForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bD_projectDataSet.direction". При необходимости она может быть перемещена или удалена.
            this.directionTableAdapter.Fill(this.bD_projectDataSet.direction);
            comboBox1.SelectedIndex = -1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");
             con.Open();
             string gr = "select name from[group] where id_direction = '" + comboBox1.SelectedValue + "'";
             OleDbCommand command = new OleDbCommand(gr, con);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetValue(0));
                }
                comboBox2.SelectedIndex = 0;
            }
            con.Close();
        }
        public static int SchID { get; set; }
        public static int CurID { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                Direction d = new Direction();
                SchID = d.GetSchedule(comboBox2.Text, int.Parse(textBox1.Text));
                label4.Text = SchID.ToString();
                JournalDirection j = new JournalDirection();
                CurID = j.GetCurriculum(comboBox1.Text.ToString(), int.Parse(textBox1.Text));
                UpdateUndDiscipline();
                button2.Enabled = true;
            }
            else MessageBox.Show("Заполните все поля","Уведомление");

        }

        private void UpdateUndDiscipline()
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=DESKTOP-PHP72G2;Initial Catalog=BD_project;Integrated Security=SSPI");
            con.Open();
            string UndD = "select dd.discipline from discipline as dd Inner JOIN (select l.DisciplineID from ListDisciplines as l INNER JOIN discipline as d on l.DisciplineID = d.id where l.CurriculumID = '"+CurID+ "' EXCEPT( select disciplineName from BusyLessons where id_schedule = '" + SchID+"')) as ll on ll.DisciplineID = dd.id";
            OleDbCommand command = new OleDbCommand(UndD, con);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetValue(0));
                }
                comboBox3.SelectedIndex = 0;
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Disciplines_List ds = new Disciplines_List();
            ds.CurriculumID = CurID;
            ds.SchedID = SchID;
            int dss=int.Parse(ds.GetUndDisc(comboBox3.Text).ToString());
            UpdateUndDiscipline();
            Schedule sch = new Schedule();
            sch.SchedudeID = SchID;
            sch.AddDiscipline(dss);
            MessageBox.Show("Дисциплина ("+comboBox3.Text+") добавлена в расписание","Уведомление");
            UpdateUndDiscipline();
        }
    }
}
