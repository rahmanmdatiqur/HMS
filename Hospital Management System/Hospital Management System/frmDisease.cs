using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class frmDisease : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ASDF;Trusted_connection=True");
        public frmDisease()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Disease VALUES(@DN)", con);
            cmd.Parameters.AddWithValue("@DN", txtDiseaseName.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            lblMsg.Text = "Data inserted successfully!!!";

            con.Close();
            LoadGrid();

        }
        private void LoadGrid()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QOKUV3F;Initial Catalog=ASDF;Trusted_connection=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Disease", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void FrmDisease_Load(object sender, EventArgs e)
        {
            LoadGrid();

        }
    }
}
