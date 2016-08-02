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
        //++add return button 
        private void button4_Click(object sender, EventArgs e)
        {
            //text box string variables
            string ID = IDText.Text;
            string Name = oNameText.Text;
            string Phone = oNumberText.Text;
            string Email = oEmailText.Text;
            //string SearchFilter = " ";

            //open database connection
            sConnect.Open();

            //create sql command string variable
            SqlCommand command = sConnect.CreateCommand();

            command.CommandType = CommandType.Text;

            //select table entries where old CustomerID, CustomerName, PhoneNumber, Email are equal to 'old' text boxes
            command.CommandText = "select * from Customer where (CustomerID ='" + ID + "')" +
                " OR (CustomerName ='" + Name + "') " +
                " OR (PhoneNumber = '" + Phone + "') " +
                " OR (Email = '" + Email + "')";

            // ++attempt to narrow searches with more than one field
            /*
            if ( *.Text != SearchFilter )
            {
                command.CommandText = "select * from Customer where (CustomerID ='" + ID + "')" +
                " AND (CustomerName ='" + Name + "') " +
                " AND (PhoneNumber = '" + Phone + "') " +
                " AND (Email = '" + Email + "')";

            }
            
            else {
                command.CommandText = "select * from Customer where (CustomerID ='" + ID + "')" +
                " OR (CustomerName ='" + Name + "') " +
                " OR (PhoneNumber = '" + Phone + "') " +
                " OR (Email = '" + Email + "')";
            }
            */

            /*
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = dataGridView1.Columns[0].HeaderText.ToString() + " LIKE '%" + ID + "%'" +
                dataGridView1.Columns[1].HeaderText.ToString() + " LIKE '%" + Name + "%'" +
                dataGridView1.Columns[2].HeaderText.ToString() + " LIKE '%" + Phone + "%'" +
                dataGridView1.Columns[3].HeaderText.ToString() + " LIKE '%" + Email + "%'";

            dataGridView1.DataSource = bs;
            
            string rowFilter = string.Format("CustomerID LIKE '%{0}%' AND CustomerName LIKE '%{1}%'",
                                  ID, Name);
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            */

            command.ExecuteNonQuery();

            //fill the data table with selected entries
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sConnect.Close();
        }

        //update button
        //++SQL command error, likely the SQL query
        //++implement direct editting within the grid?
        //++highlight added entries?
        
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
        //add confirmation msg if info left out 
        //++clear text boxes after adding?
        //++add a clear button
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
        //++figure out how to remove primary key
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
