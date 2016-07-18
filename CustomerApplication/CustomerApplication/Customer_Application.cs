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

namespace CustomerApplication
{
    public partial class Customer_Application : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        //create sql command string variable
        SqlCommand command = new SqlCommand();

        //create connection object SqlConnection
        //specify connection string for object 
        //string: database location;database name;authentication type
        SqlConnection sConnect = new SqlConnection("data source = RK-PC\\SQLEXPRESS; database = CustomerData; integrated security = SSPI");

        public Customer_Application()
        {
            InitializeComponent();
 
            //sConnect.ConnectionString = "data source = RK-PC\\SQLEXPRESS; database = CustomerData; integrated security = SSPI";

            dt = new DataTable();

            //SQL command to retrieve all data using sql connection
            sda = new SqlDataAdapter("select * from Customer", sConnect);

            //fill new datatable and assign data to dataGridView1
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sets sql string command connection object
            command.Connection = sConnect;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
