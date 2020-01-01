using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheldule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void учебныйПланToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurriculumForm cf = new CurriculumForm();
            this.Hide();
            cf.ShowDialog();
            this.Close();

        }
    }
}
