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
    public partial class NotifyForm : Form
    {
        public NotifyForm()
        {
            InitializeComponent();

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("select_all_resources", connection);

            checkedListBox1.Items.Clear();

            SqlDataReader dr = command.ExecuteReader();

            //Populez lista de resurse
            while (dr.Read())
            {
                checkedListBox1.Items.Add(dr.GetString(1).ToString());
            }
        }

        private void save_button_Click_1(object sender, EventArgs e)
        {
            string member_username = UserConnected.TextData;

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Choose an item.");
            }
            else
            {
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    listView1.Items.Add(checkedListBox1.CheckedItems[i].ToString());
                    //s = s + "Checked Item " + (x + 1).ToString() + " = " + checkedListBox1.CheckedItems[x].ToString() + "\n";
                    SqlCommand command = new SqlCommand("insert_favourite_classes", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@member_username", member_username));
                    command.Parameters.Add(new SqlParameter("@resource_name", checkedListBox1.CheckedItems[i].ToString()));

                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                
            }

            connection.Close();
        }
    }
}
