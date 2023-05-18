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


namespace ist
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        SqlConnection cn;
        SqlDataAdapter dr;
        SqlDataReader drr;
        SqlCommand cmd;
        DataSet ds;
        SqlParameter param = new SqlParameter();

        public static string sqllink = "Data Source=DAYANAALFARES SQLEXPRESS01;Initial Catalog=dayana;Integrated Security=True";

       

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2Button1.Text != string.Empty || guna2TextBox2.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from tb_login where usr='" + guna2TextBox1.Text + "' and pass='" + guna2TextBox2.Text + "'", cn);
                cmd.Connection = cn;
                try
                {
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (drr.Read())
                    {
                        cn.Close();
                        this.Hide();
                        HomeStor homeStor = new HomeStor();
                        homeStor.ShowDialog();
                    }
                    else
                    {
                        cn.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch
                {
                     
                    
                        MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
           
            }
            
           
        }
     
      
    

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
     

        
        

    
    

