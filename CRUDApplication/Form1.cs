using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUDApplication
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=stu_information_db;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stu_information_dbDataSet.stuinfo_tbl' table. You can move, or remove it, as needed.
            // this.stuinfo_tblTableAdapter.Fill(this.stu_information_dbDataSet.stuinfo_tbl);
            dataGridView1.DataSource = null;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT * FROM stuinfo_tbl";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; // bind directly
            con.Close();
        }

        void reloadGridAndClearField()
        {
            

            regnoTextbox.Clear();
            fnameTextbox.Clear();
            lnameTextbox.Clear();
            streetTextbox.Clear();
            cityTextbox.Clear();
            districtComboBox.Text = "";
            nicTextbox.Clear();
            mobileTextbox.Clear();
            emailTextbox.Clear();

           
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            String sql = "INSERT INTO stuinfo_tbl (RegNo, FirstName, LastName, Street, City, District, NicNo, MobileNo, Email) VALUES (@regno, @fname , @lname, @street, @city, @district, @nicno, @mobileno, @email)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@regno", regnoTextbox.Text);
            cmd.Parameters.AddWithValue("@fname", fnameTextbox.Text);
            cmd.Parameters.AddWithValue("@lname", lnameTextbox.Text);
            cmd.Parameters.AddWithValue("@street", streetTextbox.Text);
            cmd.Parameters.AddWithValue("@city", cityTextbox.Text);
            cmd.Parameters.AddWithValue("@district", districtComboBox.Text);
            cmd.Parameters.AddWithValue("@nicno", nicTextbox.Text);
            cmd.Parameters.AddWithValue("@mobileno", mobileTextbox.Text);
            cmd.Parameters.AddWithValue("@email", emailTextbox.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            viewBtn_Click(sender, e);
            reloadGridAndClearField();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "UPDATE stuinfo_tbl SET FirstName=@fname, LastName=@lname, Street=@street, City=@city, District=@district, NicNo=@nicno, MobileNo=@mobileno, Email=@email WHERE RegNo=@regno";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@regno", regnoTextbox.Text);
            cmd.Parameters.AddWithValue("@fname", fnameTextbox.Text);
            cmd.Parameters.AddWithValue("@lname", lnameTextbox.Text);
            cmd.Parameters.AddWithValue("@street", streetTextbox.Text);
            cmd.Parameters.AddWithValue("@city", cityTextbox.Text);
            cmd.Parameters.AddWithValue("@district", districtComboBox.Text);
            cmd.Parameters.AddWithValue("@nicno", nicTextbox.Text);
            cmd.Parameters.AddWithValue("@mobileno", mobileTextbox.Text);
            cmd.Parameters.AddWithValue("@email", emailTextbox.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Success", "Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            con.Close();

            viewBtn_Click(sender, e);

            reloadGridAndClearField();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            regnoTextbox.Text = row.Cells[0].Value.ToString();
            fnameTextbox.Text = row.Cells[1].Value.ToString();
            lnameTextbox.Text = row.Cells[2].Value.ToString();
            streetTextbox.Text = row.Cells[3].Value.ToString();
            cityTextbox.Text = row.Cells[4].Value.ToString();
            districtComboBox.Text = row.Cells[5].Value.ToString();
            nicTextbox.Text = row.Cells[6].Value.ToString();
            mobileTextbox.Text = row.Cells[7].Value.ToString();
            emailTextbox.Text = row.Cells[8].Value.ToString();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are sure you want delete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                con.Open();

                string sql = "DELETE from stuinfo_tbl WHERE RegNo=@regno";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@regno", regnoTextbox.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                viewBtn_Click(sender, e);

                reloadGridAndClearField();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "UPDATE stuinfo_tbl SET FirstName=@fname, LastName=@lname, Street=@street, City=@city, District=@district, NicNo=@nicno, MobileNo=@mobileno, Email=@email WHERE RegNo=@regno";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@regno", regnoTextbox.Text);
            cmd.Parameters.AddWithValue("@fname", fnameTextbox.Text);
            cmd.Parameters.AddWithValue("@lname", lnameTextbox.Text);
            cmd.Parameters.AddWithValue("@street", streetTextbox.Text);
            cmd.Parameters.AddWithValue("@city", cityTextbox.Text);
            cmd.Parameters.AddWithValue("@district", districtComboBox.Text);
            cmd.Parameters.AddWithValue("@nicno", nicTextbox.Text);
            cmd.Parameters.AddWithValue("@mobileno", mobileTextbox.Text);
            cmd.Parameters.AddWithValue("@email", emailTextbox.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Save Success", "Sucess", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            con.Close();

            viewBtn_Click(sender, e);

            reloadGridAndClearField();
        }
    }
}
