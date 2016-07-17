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


//application gives looping error when no entries

namespace CustomerApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //create connection object SqlConnection
            SqlConnection sConnect = new SqlConnection();

            //specify connection string for object 
            //string: database location;database name;authentication type
            sConnect.ConnectionString = "data source = RK-PC\\SQLEXPRESS;database = CustomerData;integrated security = SSPI";

            //SQL command to retrieve all data using sql connection
            SqlCommand command = new SqlCommand("select * from Customer", sConnect);

            //open connection to server
            sConnect.Open();

            //read all data
            SqlDataReader sdr = command.ExecuteReader();

            //store sql data source
            BindingSource source = new BindingSource();
            source.DataSource = sdr;

            //fill grid with retrieved data from db
            dataGridView1.DataSource = source;

            //close server connection
            sConnect.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
