using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class frmAddpatient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=ASDF;Integrated Security=True");
       
        public frmAddpatient()
        {
            InitializeComponent();
        }

        private void LblMsg_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO patient VALUES (@id, @name, @email, @dob, @ge, @contactNo, @D_Id, @im)", con);

            Image img = Image.FromFile(txtPicturePath.Text);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);

            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ge", cmbGender.Text);
            cmd.Parameters.AddWithValue("@contactNo", txtContact.Text);
            cmd.Parameters.AddWithValue("@D_Id", cmbDisease.SelectedValue);
            cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.VarBinary) { Value = ms.ToArray() });
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Added Successfully");

            con.Close();
            LoadGrid();
        }
        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM  patient", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void LoadCombo()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  D_Id,D_Name from Disease", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbDisease.DisplayMember = "D_Name";
            cmbDisease.ValueMember = "D_Id";
            cmbDisease.DataSource = dt;
            con.Close();
        }

        private void FrmAddpatient_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }

        private void Btnpic_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog2.FileName);
                this.pictureBox1.Image = img;
                txtPicturePath.Text = openFileDialog2.FileName;
            }
        }
    }
    
}
