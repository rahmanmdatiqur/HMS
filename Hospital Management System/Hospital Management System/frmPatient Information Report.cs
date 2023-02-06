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
    public partial class frmPatient_Information_Report : Form
    {
        public frmPatient_Information_Report()
        {
            InitializeComponent();
        }

        public Main Mdiparent { get; internal set; }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
