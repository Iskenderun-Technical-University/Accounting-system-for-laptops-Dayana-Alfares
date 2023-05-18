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

namespace ist
{
    public partial class addProduct : Form
    {
        public addProduct()
        {
            InitializeComponent();
        }

        private void hp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dayana_istDataSet2.tb_laptop_information' table. You can move, or remove it, as needed.
         //   this.tb_laptop_informationTableAdapter.Fill(this.dayana_istDataSet2.tb_laptop_information);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //button for insert data 
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=DAYANAALFARES SQLEXPRESS01;Initial Catalog=dayana;Integrated Security=True";

            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "" && guna2TextBox5.Text != "" && guna2TextBox5.Text != "" && guna2TextBox7.Text != "" && guna2TextBox8.Text != "" && guna2TextBox9.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO [tb_laptop_information] (isim,fiyat,Hard,Marka,Ekran,isletim,about,Kapasitesi,islemci,stars)" +
                 "VALUES(@isim,@fiyat,@Hard,@Marka,@Ekran,@isletim,@about,@Kapasitesi,@islemci,@stars)", con1);
                con1.Open(); 
                cmd.Parameters.AddWithValue("@isim",guna2TextBox1);
                cmd.Parameters.AddWithValue("@fiyat",guna2TextBox2);
                cmd.Parameters.AddWithValue("@Hard", guna2TextBox3);
                cmd.Parameters.AddWithValue("@Marka", guna2TextBox4);
                cmd.Parameters.AddWithValue("@Ekran", guna2TextBox5);
                cmd.Parameters.AddWithValue("@isletim",guna2TextBox5);
                cmd.Parameters.AddWithValue("@about",guna2TextBox7);
                cmd.Parameters.AddWithValue("@Kapasitesi", guna2TextBox8);
                cmd.Parameters.AddWithValue("@islemci", guna2TextBox9);
                cmd.Parameters.AddWithValue("@stars", guna2TextBox9);
               
                cmd.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Record Inserted Successfully");
            //    DisplayData();
             //  ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }











       

  
           
   

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();

            con1.ConnectionString = @"Data Source=DAYANAALFARES SQLEXPRESS01;Initial Catalog=dayana;Integrated Security=True";

            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "" && guna2TextBox4.Text != "" && guna2TextBox5.Text != "" && guna2TextBox5.Text != "" && guna2TextBox7.Text != "" && guna2TextBox8.Text != "" && guna2TextBox9.Text != "")
            {
                cmd = new SqlCommand("update tb_laptop_information set isim=@isim,fiyat=@fiyat,Hard=@Hard,Marka=@Marka,Ekran=@Ekran,isletim=@isletim,about=@about,Kapasitesi=@Kapasitesi,islemci=@islemci,stars=@stars   where ID=@id", con1);
                con1.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@isim", guna2TextBox1);
                cmd.Parameters.AddWithValue("@fiyat", guna2TextBox2);
                cmd.Parameters.AddWithValue("@Hard", guna2TextBox3);
                cmd.Parameters.AddWithValue("@Marka", guna2TextBox4);
                cmd.Parameters.AddWithValue("@Ekran", guna2TextBox5);
                cmd.Parameters.AddWithValue("@isletim", guna2TextBox5);
                cmd.Parameters.AddWithValue("@about", guna2TextBox7);
                cmd.Parameters.AddWithValue("@Kapasitesi", guna2TextBox8);
                cmd.Parameters.AddWithValue("@islemci", guna2TextBox9);
                cmd.Parameters.AddWithValue("@stars", guna2TextBox9);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con1.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;

        private void DisplayData()
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=DAYANAALFARES SQLEXPRESS01;Initial Catalog=dayana;Integrated Security=True";

            con1.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from tb_laptop_information", con1);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con1.Close();
        }
        //Clear Data  
        private void ClearData()
        {
           guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            ID = 0;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=DAYANAALFARES SQLEXPRESS01;Initial Catalog=dayana;Integrated Security=True";
            if (ID != 0)
            {
                cmd = new SqlCommand("deletetb_laptop_information where ID=@id", con1);
                con1.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayData();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
