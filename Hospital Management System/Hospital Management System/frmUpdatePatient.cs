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
    public partial class frmUpdatePatient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=ASDF;Integrated Security=True");

        public frmUpdatePatient()
        {
            InitializeComponent();
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
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE patient SET name=@name, email=@email, dob=@dob, gender=@ge, contactNo=@contactNo, D_Id=@D_Id, Picture=@im WHERE id=@id", con );

            Image img = Image.FromFile(txtPicturePath.Text);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ge", cmbGender.SelectedItem);
            cmd.Parameters.AddWithValue("@contactNo", txtContact.Text);
            cmd.Parameters.AddWithValue("@D_Id", cmbDisease.SelectedValue);
            cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.VarBinary) { Value = ms.ToArray() });
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Successfully");

            con.Close();
            LoadGrid();
        }
        private void LoadCombo()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM  Disease", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbDisease.DisplayMember = "D_Name";
            cmbDisease.ValueMember = "D_Id";
            cmbDisease.DataSource = dt;

            //Load cmbTutorId
            //SqlDataAdapter sda2 = new SqlDataAdapter("select ID,Name,Gender, Age,BG_ID,Unit_ml,Date,Address,ContactNo,Email,Photo ", con);
            //DataTable dt2 = new DataTable();
            //sda2.Fill(dt2);
            //txtID.DisplayMember = "ID,";
            //txtID.ValueMember = "Name,";
            //txtID.DataSource = dt2;

            con.Close();

        }
        private void FrmUpdatePatient_Load(object sender, EventArgs e)
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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {


                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;

                SqlCommand cmd = new SqlCommand("Select * from patient where id=@id", con);

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtId.Text = dr.GetInt32(0).ToString();
                    txtName.Text = dr.GetString(1);
                    txtEmail.Text = dr.GetString(2);
                    dateTimePicker1.Value = dr.GetDateTime(3).Date;
                    cmbGender.SelectedItem = dr.GetSqlValue(4).ToString();
                    txtContact.Text = dr.GetString(5);
                    cmbDisease.SelectedValue = dr.GetInt32(dr.GetOrdinal("D_Id"));

                    pictureBox1.Image = Image.FromStream(dr.GetStream(7));
                }
                con.Close();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(" DELETE FROM patient WHERE ID = @i", con);
            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(txtId.Text));
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Delete Successfully");

            }
            con.Close();
            LoadGrid();
        }
    }
    
}
