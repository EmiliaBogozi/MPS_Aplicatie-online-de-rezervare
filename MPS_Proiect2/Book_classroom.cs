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
    public partial class Book_classroom : Form
    {
        public Book_classroom()
        {
            InitializeComponent();
        }

        public int ok = 0;
        public string reason;

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
            ok = 1;
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            ReasonWindow r = new ReasonWindow();
            r.ShowDialog();
            reason = r.textbox;

            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            int hour = dateTimePicker2.Value.Hour;
            int minute = dateTimePicker2.Value.Minute;
            int time = 2;

            string group = group_text.Text;

            //Functie care selecteaza toate salile libere la data data;
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("select_resources_available", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@year", year));
            command.Parameters.Add(new SqlParameter("@month", month));
            command.Parameters.Add(new SqlParameter("@day", day));
            command.Parameters.Add(new SqlParameter("@hour", hour));
            command.Parameters.Add(new SqlParameter("@minute", minute));
            command.Parameters.Add(new SqlParameter("@time", time));

            listView1.Items.Clear();

            try { 
                SqlDataReader dr = command.ExecuteReader();

                //Populez lista de resurse disponibile
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //resource_id
                    lv.SubItems.Add(dr.GetString(1).ToString()); // resource
                    lv.SubItems.Add(dr.GetString(2).ToString()); //description
                    listView1.Items.Add(lv);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There are no classrooms available");
            }

           
            command.Dispose();
            connection.Close();
        }

        private void book_classroom_button_Click(object sender, EventArgs e)
        {
            int resource_id;

            if (listView1.SelectedItems.Count > 0)
            {
                String text = listView1.SelectedItems[0].Text;
                resource_id = Int32.Parse(text);
            }
            else {
                MessageBox.Show("You have to choose a classroom!");
                return;
            }
           
            int member_id;
            string member_username = UserConnected.TextData;

            string group_reservation = group_text.Text;
            if (group_reservation == "")
            {
                MessageBox.Show("Yoy have to choose a group!");
                return;
            }

            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            int hour = dateTimePicker2.Value.Hour;
            int minute = dateTimePicker2.Value.Minute;

            if (duration_text.Text == "")
            {
                MessageBox.Show("You have to complete duration");
                return;
            }
            int time = Int32.Parse(duration_text.Text);

            ReasonWindow r = new ReasonWindow();

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            //Functie care returneaza id-ul user-ului conectat -- member_id
            SqlCommand command = new SqlCommand("get_id_member", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@username", member_username));
            command.Parameters.Add("@member_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();
            member_id = (int)command.Parameters["@member_id"].Value;

            command.Dispose();

            //Functie care face rezervarea
            command = new SqlCommand("book_classroom", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@resource_id", resource_id));
            command.Parameters.Add(new SqlParameter("@member_id", member_id));
            command.Parameters.Add(new SqlParameter("@group_reservation", group_reservation));
            command.Parameters.Add(new SqlParameter("@reservation_year", year));
            command.Parameters.Add(new SqlParameter("@reservation_month", month));
            command.Parameters.Add(new SqlParameter("@reservation_day", day));
            command.Parameters.Add(new SqlParameter("@reservation_hour", hour));
            command.Parameters.Add(new SqlParameter("@reservation_minute", minute));
            command.Parameters.Add(new SqlParameter("@reservation_time", time));
            command.Parameters.Add(new SqlParameter("@reservation_reason", reason));

            int result = command.ExecuteNonQuery();

            if (result == 1)
            {
                MessageBox.Show("Successfully!");
                listView1.Items.Clear();
                group_text.Clear();
            }

            command.Dispose();
            connection.Close();
        }
    }
}
