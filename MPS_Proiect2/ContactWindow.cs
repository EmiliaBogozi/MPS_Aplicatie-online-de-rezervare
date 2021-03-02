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

namespace MPS_Proiect2
{
    public partial class ContactWindow : UserControl
    {
        public ContactWindow()
        {
            InitializeComponent();
        }

        private void sent_button_Click(object sender, EventArgs e)
        {
            if (first_name_text.Text == "" || last_name_text.Text == "" || email_text.Text == "" || message_text.Text == "")
            {
                MessageBox.Show("You have to complete every field.");
                return;
            }
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("contact_message", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@first_name", first_name_text.Text));
            command.Parameters.Add(new SqlParameter("@last_name", last_name_text.Text));
            command.Parameters.Add(new SqlParameter("@email", email_text.Text));
            command.Parameters.Add(new SqlParameter("@phone_number", phone_text.Text));
            command.Parameters.Add(new SqlParameter("@message", message_text.Text));

            int result = command.ExecuteNonQuery();

            first_name_text.Clear();
            last_name_text.Clear();
            email_text.Clear();
            phone_text.Clear();
            message_text.Clear();

            MessageBox.Show("Sent!");

        }


    }
}
