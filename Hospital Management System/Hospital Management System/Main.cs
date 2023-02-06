using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void DiseaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDisease fd = new frmDisease();
            fd.Show();
            //fd.MdiParent = this;
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddpatient pr = new frmAddpatient();
            pr.Show();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePatient up = new frmUpdatePatient();
            up.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PatientInformationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient_Information_Report pa = new frmPatient_Information_Report();
            pa.Show();
            pa.Mdiparent = this;
        }

        private void TransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmTransaction ta = new frmTransaction();
            ta.Show();
            ta.Mdiparent = this;
        }
    }
}
