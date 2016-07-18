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


        //create connection object SqlConnection
        //specify connection string for object 
        //string: database location;database name;authentication type
        SqlConnection sConnect = new SqlConnection("data source = RK-PC\\SQLEXPRESS; database = CustomerData; integrated security = SSPI");

        public Customer_Application()
        {
            InitializeComponent();

            DataTable dt;
            dt = new DataTable();

            //SQL command to retrieve all data using sql connection
            sda = new SqlDataAdapter("select * from Customer", sConnect);

            //fill new datatable and assign data to dataGridView1
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            live_update();
        }


        //search button
        private void button4_Click(object sender, EventArgs e)
        {

            sConnect.Open();
            SqlCommand command = sConnect.CreateCommand();

            command.CommandType = CommandType.Text;

            //select table entries where old CustomerID, CustomerName, PhoneNumber, Email are equal to 'old' text boxes
            command.CommandText = "select * from Customer where (CustomerID ='" + IDText.Text + "') OR (CustomerName ='" + oNameText.Text + "') OR (PhoneNumber = '" + oNumberText.Text + "') OR (Email = '" + oEmailText.Text + "')";

            command.ExecuteNonQuery();

            //fill the data table with selected entries
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sConnect.Close();
        }

        //update button
        //SQL command error
        private void button3_Click(object sender, EventArgs e)
        {
            /*
            sConnect.Open();

            //create sql command string variable
            SqlCommand command = sConnect.CreateCommand();

            command.CommandType = CommandType.Text;

            //update table entries by replacing entries in 'old' text box entries with 'new' text box entries
            command.CommandText = "update Customer set ((CustomerName ='" + NameText.Text + "') where (CustomerName = ''" + oNameText.Text + "')) OR ((PhoneNumber = '" + NumberText.Text + "') where (PhoneNumber = '" + oNumberText.Text + "')) OR ((Email = '" + EmailText.Text + "' )  where (Email = '" + oEmailText.Text + "'))";

            command.ExecuteNonQuery();
            sConnect.Close();
            live_update();
            MessageBox.Show("Customer data updated.");
            */
        }

        //add button
        private void button1_Click(object sender, EventArgs e)
        {
            //open database connection
            sConnect.Open();

            //create sql command string variable
            SqlCommand command = sConnect.CreateCommand();

            command.CommandType = CommandType.Text;

            //insert 'new' Customer data entries
            command.CommandText = "insert into Customer values('"+NameText.Text+"','"+NumberText.Text+"','"+EmailText.Text+"')";

            command.ExecuteNonQuery();
            sConnect.Close();
            live_update();
            MessageBox.Show("Customer data added.");
        }

        //delete button
        //deletes by CustomerID
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //open database connection
            sConnect.Open();

            //create sql command string variable
            SqlCommand command = sConnect.CreateCommand();

            command.CommandType = CommandType.Text;

            //delete Customer data by CustomerID 
            command.CommandText = "delete from Customer where CustomerID = '" + IDText.Text + "'";

            command.ExecuteNonQuery();
            sConnect.Close();
            live_update();

            //attempt to reseed primary key
            command.CommandText = "DBCC CHECKIDENT (Customer, RESEED, 0)";
            live_update();

            MessageBox.Show("Customer data deleted.");
        }

        //live updates Customer table
        public void live_update()
        {
            sConnect.Open();
            SqlCommand command = sConnect.CreateCommand();
            command.CommandType = CommandType.Text;

            //selects current data from Customer db
            command.CommandText = "select * from Customer";
            command.ExecuteNonQuery();

            //fills current data in new table
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sConnect.Close();

        }


    }
}
