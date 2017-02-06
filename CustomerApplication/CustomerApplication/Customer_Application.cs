using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomerApplication
{
    public class Account 
    {
        public string ID { get; set; }
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
        private void UpdateButton(object sender, EventArgs e)
        {
            CustomerDB.Open();
            SqlCommand command = CustomerDB.CreateCommand();
            command.CommandType = CommandType.Text;
            if (UpdatingToNull())
            {
                MessageBox.Show("Cannot update Customer Data to a null value.");
                CustomerDB.Close();
            }
            else
            {
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


        // Delete button - only deletes by CustomerID
        private void DeleteButton(object sender, EventArgs e)
        {
            //open database connection
            CustomerDB.Open();

            //create sql command string variable
            SqlCommand command = CustomerDB.CreateCommand();

            command.CommandType = CommandType.Text;

            Account account = new Account();
            command.CommandText = "Select CustomerID from Customer where CustomerID = '" + IDText.Text + "'";
            account.ID = command.ExecuteScalar().ToString();

            if (string.IsNullOrWhiteSpace(IDText.Text))
            {
                MessageBox.Show("Please enter a CustomerID to delete an entry.");
                CustomerDB.Close();
            }
            
            else if (string.IsNullOrWhiteSpace(account.ID))
            {
                MessageBox.Show("Customer does not exist. Delete not performed.");
                CustomerDB.Close();
            }
            else
            {
                //delete Customer data by CustomerID 
                command.CommandText = "delete from Customer where CustomerID = '" + IDText.Text + "'";
                command.ExecuteNonQuery();
                CustomerDB.Close();
                live_update();
                MessageBox.Show("Customer data deleted.");
            }

        }


        //--------------------------------------------Functions to adjust queries depending on UI state--------------------------------------------//

        // Adjust search query depending on which text boxes are being used to search
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


        // Adjust update query depending on which text boxes are being used to search
        // Return empty command if nothing searched
        private string UpdateButtonSQLCommand()
        {
            string FinalResult = "";
            string SetResult = "UPDATE [CustomerData].[dbo].[Customer] SET ";
            string WhereResult = "WHERE ";
            string[] oldTextBoxArray = new string[3] { oNameText.Text, oNumberText.Text, oEmailText.Text };
            string[] newTextBoxArray = new string[3] { NameText.Text, NumberText.Text, EmailText.Text };
            int searchParamCount = 0;
            for (int i = 0; i < 3; i++)
            {
                if ( (oldTextBoxArray != null && newTextBoxArray != null ) 
                    && (!string.IsNullOrEmpty(oldTextBoxArray[i]) || !string.IsNullOrEmpty(newTextBoxArray[i])) )
                {
                    if (searchParamCount > 0)
                    {
                        SetResult += ", ";
                        WhereResult += "AND ";
                    }

                    if (i == 0)
                    {
                        SetResult += "CustomerName = '" + newTextBoxArray[0] + "' ";
                        WhereResult += "CustomerName = '" + oldTextBoxArray[0] + "' ";
                    }
                    else if (i == 1)
                    {
                        SetResult += "PhoneNumber = '" + newTextBoxArray[1] + "' ";
                        WhereResult += "PhoneNumber = '" + oldTextBoxArray[1] + "' ";
                    }
                    else if (i == 2)
                    {
                        SetResult += "Email = '" + newTextBoxArray[2] + "' ";
                        WhereResult += "Email = '" + oldTextBoxArray[2] + "' ";
                    }
                    searchParamCount++;
                    FinalResult = SetResult + WhereResult;
                }
                else if (searchParamCount == 0 && i == 2)
                {
                    break;
                }
            }
            return FinalResult;
        }


        // Return true if trying to update a value to null
        private Boolean UpdatingToNull()
        {
            Boolean res = false;

            string[] oldTextBoxArray = new string[3] { oNameText.Text, oNumberText.Text, oEmailText.Text };
            string[] newTextBoxArray = new string[3] { NameText.Text, NumberText.Text, EmailText.Text };

            for (int i=0; i<3; i++)
            {
                if (string.IsNullOrWhiteSpace(newTextBoxArray[i]) && !string.IsNullOrWhiteSpace(oldTextBoxArray[i]))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }


    }
}
