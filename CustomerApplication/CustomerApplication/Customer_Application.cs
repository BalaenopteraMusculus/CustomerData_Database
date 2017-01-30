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
        // Specify database location, database name, authentication type
        SqlConnection CustomerDB = new SqlConnection("data source = RK-PC\\SQLEXPRESS; database = CustomerData; integrated security = SSPI");


        // Open form and load all Customer information
        public Customer_Application()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Customer", CustomerDB);

            //fill new datatable and assign data to dataGridView1
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        //live updates Customer table
        public void live_update()
        {
            CustomerDB.Open();
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;

            //selects current data from Customer db
            command.CommandText = "select * from Customer";
            command.ExecuteNonQuery();

            //fills current data in new table
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            CustomerDB.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            live_update();
        }


        // Search button that searches for what is entered in the text boxes by
        // selecting table entries where old CustomerID, CustomerName, PhoneNumber, 
        // Email are equal to 'old' text boxes
        private void button4_Click(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = ButtonSQLCommand("read");
            Console.WriteLine("Displaying current SQL command: " + command.CommandText);

            if (!string.IsNullOrEmpty(command.CommandText))
            {
                command.ExecuteNonQuery();

                // Fill the data table with selected entries
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            } else
            {
                MessageBox.Show("Please enter a search parameter to search.");
            }
            CustomerDB.Close();
        }


        //update button
        //++SQL command error, likely the SQL query
        private void button3_Click(object sender, EventArgs e)
        {
            CustomerDB.Open();
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;

            //update table entries by replacing entries in 'old' text box entries with 'new' text box entries
            command.CommandText = "update Customer set ((CustomerName ='" + NameText.Text + "') " +
                "where (CustomerName = ''" + oNameText.Text + "')) " +
                "OR ((PhoneNumber = '" + NumberText.Text + "') " +
                "where (PhoneNumber = '" + oNumberText.Text + "'))" + 
                "OR ((Email = '" + EmailText.Text + "' ) " +
                "where (Email = '" + oEmailText.Text + "'))";

            command.ExecuteNonQuery();
            CustomerDB.Close();
            live_update();
            MessageBox.Show("Customer data updated.");   
        }


        // Add button to create customer entries
        private void button1_Click(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();

            command.CommandType = CommandType.Text;

            //insert 'new' Customer data entries
            command.CommandText = "insert into Customer values('" + NameText.Text + "','" + NumberText.Text + "','" + EmailText.Text + "')";

            command.ExecuteNonQuery();
            CustomerDB.Close();
            live_update();
            MessageBox.Show("Customer data added.");
        }


        //delete button
        //deletes by CustomerID
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();

            command.CommandType = CommandType.Text;

            //delete Customer data by CustomerID 
            command.CommandText = "delete from Customer where CustomerID = '" + IDText.Text + "'";

            command.ExecuteNonQuery();
            CustomerDB.Close();
            live_update();

            //attempt to reseed primary key
            command.CommandText = "DBCC CHECKIDENT (Customer, RESEED, 0)";
            live_update();

            MessageBox.Show("Customer data deleted.");
        }


        // Dynamically adjust query depending on which text boxes are being used to search
        // Append query command depending on what is currently entered in text boxes
        // Return empty command if nothing searched
        private string ButtonSQLCommand(string button)
        {
            string result = "";
            string[] TextBoxArray = new string[4] { IDText.Text, oNameText.Text, oNumberText.Text, oEmailText.Text };

            // Change query depending on button function
            if (button.Contains("read"))
            {
                result = "select * from Customer where";
            } else if (button.Contains("update"))
            {
                result = "";
            } else if (button.Contains("delete"))
            {
                result = "";
            }

            int searchParamCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (TextBoxArray != null && !string.IsNullOrEmpty(TextBoxArray[i]))
                {
                    if (searchParamCount > 0)
                    {
                        result += " AND ";
                    }

                    if (i == 0)
                    {
                        result += " (CustomerID ='" + TextBoxArray[0] + "')";
                    }
                    else if (i == 1)
                    {
                        result += " (CustomerName ='" + TextBoxArray[1] + "') ";
                    }
                    else if (i == 2)
                    {
                        result += " (PhoneNumber = '" + TextBoxArray[2] + "') ";
                    }
                    else if (i == 3)
                    {
                        result += " (Email = '" + TextBoxArray[3] + "')";
                    }
                    searchParamCount++;
                } else if (searchParamCount == 0 && i == 3)
                {
                    result = "";
                    break;
                }
            }
            return result;
        }


        /*
        // Store result of SQL command into string
        private string SQLtoString (SqlCommand command, string columnName)
        {
            string result = "";
            using (command)
            {
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = reader.GetString(reader.GetOrdinal(columnName));
                    }
                    command.Connection.Close();
                }
            }
            return result;
        }
        */

    }
}
