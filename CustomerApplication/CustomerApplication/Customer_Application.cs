﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomerApplication
{
    public class Account 
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public partial class Customer_Application : Form
    {
        // Specify database location, database name, authentication type
        SqlConnection CustomerDB = new SqlConnection("data source = RK-PC\\SQLEXPRESS; " + 
            "database = CustomerData; integrated security = SSPI");


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


        // Live updates Customer table
        public void live_update()
        {
            CustomerDB.Open();
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;

            // Select all current data from Customer db
            command.CommandText = "select * from Customer";
            command.ExecuteNonQuery();

            // Fill table with current data
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            CustomerDB.Close();
        }


        private void LiveUpdater(object sender, EventArgs e)
        {
            live_update();
        }


        // Search button that searches for what is entered in the text boxes by
        // selecting table entries where old CustomerID, CustomerName, PhoneNumber, 
        // Email are equal to 'old' text boxes
        private void SearchButton(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;
            if (!string.IsNullOrEmpty(SearchButtonSQLCommand()))
            {
                command.CommandText = SearchButtonSQLCommand();
            }
            else
            {
                command.CommandText = "select * from Customer";
            }

            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            CustomerDB.Close();
        }


        // Update button
        // Update table entries by replacing entries in 'old' text 
        // box entries with 'new' text box entries
        // ** fix: unable to update more than one at a time
        private void UpdateButton(object sender, EventArgs e)
        {
            CustomerDB.Open();
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;
            if (!string.IsNullOrEmpty(UpdateButtonSQLCommand()))
            {
                command.CommandText = UpdateButtonSQLCommand();
            }
            else
            {
                command.CommandText = "select * from Customer";
            }
            command.ExecuteNonQuery();
            CustomerDB.Close();
            live_update();
        }


        // Add button to create customer entries
        // Does not allow empty/duplicate names and email
        private void CreateButton(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;

            if (string.IsNullOrWhiteSpace(NameText.Text) || string.IsNullOrWhiteSpace(NumberText.Text) || string.IsNullOrWhiteSpace(EmailText.Text))
            {
                MessageBox.Show("Please enter a name, phone number, and email.");
                CustomerDB.Close();
            }

            else 
            {
                Account account = new Account();
                command.CommandText = "Select CustomerName from Customer where CustomerName = '" + NameText.Text + "'";
                account.Name = (string)command.ExecuteScalar();

                command.CommandText = "Select Email from Customer where Email = '" + EmailText.Text + "'"; 
                account.Email = (string)command.ExecuteScalar();

                if (NameText.Text == account.Name)
                {
                    MessageBox.Show("This customer already exists.");
                    CustomerDB.Close();
                }

                else if (EmailText.Text == account.Email)
                {
                    MessageBox.Show("This email has already been used.");
                    CustomerDB.Close();
                }

                else
                {
                    //insert 'new' Customer data entries
                    command.CommandText = "insert into Customer values('" + NameText.Text + "','" + NumberText.Text + "','" + EmailText.Text + "')";

                    command.ExecuteNonQuery();
                    CustomerDB.Close();
                    live_update();
                    MessageBox.Show("Customer data added.");
                }
            }

        }


        // Delete button - deletes by CustomerID
        // try to delete by other param
        // 
        private void DeleteButton(object sender, EventArgs e)
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

            MessageBox.Show("Customer data deleted.");
        }


        //--------------------------------------------Functions to adjust queries depending on UI state--------------------------------------------

        // Adjust query depending on which text boxes are being used to search
        // Return empty command if nothing searched
        private string SearchButtonSQLCommand()
        {
            string result = "select * from Customer where";
            string[] TextBoxArray = new string[4] { @IDText.Text, @oNameText.Text, @oNumberText.Text, @oEmailText.Text };
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
                }
                else if (searchParamCount == 0 && i == 3)
                {
                    result = "";
                    break;
                }
            }
            return result;
        }


        // Dynamically adjust query depending on which text boxes are being used to search
        // Return empty command if nothing searched
        private string UpdateButtonSQLCommand()
        {
            string result = "UPDATE [CustomerData].[dbo].[Customer] ";
            string[] oldTextBoxArray = new string[3] { oNameText.Text, oNumberText.Text, oEmailText.Text };
            string[] newTextBoxArray = new string[3] { NameText.Text, NumberText.Text, EmailText.Text };
            int searchParamCount = 0;
            for (int i = 0; i < 3; i++)
            {
                if (oldTextBoxArray != null && newTextBoxArray != null 
                    && !string.IsNullOrEmpty(oldTextBoxArray[i]) && !string.IsNullOrEmpty(newTextBoxArray[i]))
                {
                    if (searchParamCount > 0)
                    {
                        result += " AND ";
                    }

                    if (i == 0)
                    {
                        result += "SET CustomerName = '" + newTextBoxArray[0] + "' where CustomerName = '" + oldTextBoxArray[0] + "'";
                    }
                    else if (i == 1)
                    {
                        result += "SET PhoneNumber = '" + newTextBoxArray[1] + "' where PhoneNumber = '" + oldTextBoxArray[1] + "'";
                    }
                    else if (i == 2)
                    {
                        result += "SET Email = '" + newTextBoxArray[2] + "' where Email = '" + oldTextBoxArray[2] + "'"; 
                    }
                    searchParamCount++;
                }
                else if (searchParamCount == 0 && i == 2)
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
                //command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = reader.GetString(reader.GetOrdinal(columnName));
                    }
                    //command.Connection.Close();
                }
            }
            return result;
        }
       */ 

    }
}
