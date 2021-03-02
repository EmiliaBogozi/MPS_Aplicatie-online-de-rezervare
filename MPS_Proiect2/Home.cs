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
using Tulpep.NotificationWindow;

namespace MPS_Proiect2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            //Inchid paginile care nu apartin de Home
            contactWindow1.Visible = false;
            registerWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;

            //Deschid pagina Home
            homeWindow1.Visible = true;

            //Setez ca SlidePanel-ul sa fie initial pe Home
            SlidePanel.Height = home_button.Height;
            SlidePanel.Top = home_button.Top;
        }

        private void home_button_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie initial pe Home
            SlidePanel.Height = home_button.Height;
            SlidePanel.Top = home_button.Top;

            //Deschid pagina Home
            homeWindow1.Visible = true;

            //Inchid paginile care nu apartin de Home
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;
        }

        private void classrooms_button_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie pe Classrooms
            SlidePanel.Height = classrooms_button.Height;
            SlidePanel.Top = classrooms_button.Top;

            //Deschid pagina Classrooms
            classroomsWindow1.Visible = true;

            //Inchid paginile care nu apartin de Classrooms
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            homeWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;
        }

        private void contact_button_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie pe Contact
            SlidePanel.Height = contact_button.Height;
            SlidePanel.Top = contact_button.Top;

            //Inchid paginile care nu apartin de Contact
            registerWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            homeWindow1.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;

            //Deschid pagina Contact
            contactWindow1.Visible = true;
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie pe Register
            SlidePanel.Height = register_button.Height;
            SlidePanel.Top = register_button.Top;

            //Deschid pagina Register
            registerWindow1.Visible = true;

            //Inchid paginile care nu tin de Register
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            homeWindow1.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie pe Login
            SlidePanel.Height = login_button.Height;
            SlidePanel.Top = login_button.Top;

            //Inchid paginile care nu apartin de Login
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            homeWindow1.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;

            //Deschid pagina Login
            login_button2.Visible = true;
            loginWindow1.Visible = true;
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            //Numele user-ului conectat -> Neconectat
            user_connected_label.Text = "Neconectat";
            timer1.Stop();

            //Setez ca SlidePanel-ul sa fie initial pe Home
            SlidePanel.Height = home_button.Height;
            SlidePanel.Top = home_button.Top;

            //Deschid pagina Home
            homeWindow1.Visible = true;

            //Inchid paginile care nu tin de Home
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;

            //Dispare butonul de logout
            logout_button.Visible = false;

            //Apar butoanele de login si register
            login_button.Visible = true;
            register_button.Visible = true;

            //Dispare rolul
            role_label.Visible = false;
            role_label.Text = "";

            //Dispare butonul My Classes / Reserve
            myclassrooms_button.Visible = false;
            reserve_button.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Conectare/Login button
        private void login_button2_Click(object sender, EventArgs e)
        {
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string user_name = null;
            string password = null;
            bool user_exists = false;

            SqlCommand command = new SqlCommand("login_member", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@username", loginWindow1.username));
            command.Parameters.Add(new SqlParameter("@password", loginWindow1.password));

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                user_name = dr[0].ToString();
                password = dr[1].ToString();

                if (user_name.Equals(loginWindow1.username) && password.Equals(loginWindow1.password))
                {
                    user_exists = true;
                }
            }
            dr.Close();
            command.Dispose();

            if (user_exists == true)
            {
                MessageBox.Show("Connected!");

                //Obtin rolul student/proffesor pentru userul conectat
                command = new SqlCommand("get_role_member", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@username", loginWindow1.username));
                command.Parameters.Add("@member_role", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                string role = (string)command.Parameters["@member_role"].Value;

                command.Dispose();

                //Neconectat -> numele user-ului conectat
                user_connected_label.Text = loginWindow1.username;
                UserConnected.TextData = loginWindow1.username;
              
                loginWindow1.username = "";
                loginWindow1.password = "";

                //Setez ca SlidePanel-ul sa fie initial pe Home
                SlidePanel.Height = home_button.Height;
                SlidePanel.Top = home_button.Top;

                //Deschid pagina Home
                homeWindow1.Visible = true;

                //Apare butonul de logout
                logout_button.Visible = true;

                //Apare rolul
                role_label.Visible = true;
                role_label.Text = role;

                //Apare butonul My classes
                myclassrooms_button.Visible = true;

                //Inchid paginile care nu apartin de Home
                registerWindow1.Visible = false;
                contactWindow1.Visible = false;
                login_button2.Visible = false;
                loginWindow1.Visible = false;
                register_button.Visible = false;
                login_button.Visible = false;
                classroomsWindow1.Visible = false;
                myclassesWindow1.Visible = false;
                myclassesStudentWindow1.Visible = false;

                //Verific daca userul este student sau profesor
                if (role == "student")
                {
                    myclassrooms_button.Visible = true;
                }
                if(role == "proffesor")
                {
                    timer1.Start();
                    myclassrooms_button.Visible = true;
                    reserve_button.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }

            connection.Close();
        }

        private void myclassrooms_button_Click(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de My Classes
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            reserve1.Visible = false;
            book_classroom.Visible = false;
            notify_button.Visible = false;
            homeWindow1.Visible = false;
            classroomsWindow1.Visible = false;

            //Setez ca SlidePanel-ul sa fie initial pe My Classes
            SlidePanel.Height = myclassrooms_button.Height;
            SlidePanel.Top = myclassrooms_button.Top;

            // Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            if (role_label.Text == "student")
            {
                //Deschid My classrooms
                myclassesStudentWindow1.Visible = true;

                SqlCommand command = new SqlCommand("select_reservations_student", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@username", user_connected_label.Text));
                SqlDataReader dr = command.ExecuteReader();

                myclassesStudentWindow1.list1.Items.Clear();

                //Populez lista de clase din grupa utilizatorului
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //reservation id
                    lv.SubItems.Add(dr.GetString(1).ToString()); // name
                    lv.SubItems.Add(dr.GetString(2).ToString()); // resource
                    lv.SubItems.Add(dr.GetString(3).ToString()); // group
                    lv.SubItems.Add(dr.GetString(4).ToString()); // date start
                    lv.SubItems.Add(dr.GetString(5).ToString()); // date end

                    myclassesStudentWindow1.list1.Items.Add(lv);
                }

                dr.Close();
                command.Dispose();
            }
            else
            {
                //Deschid My classrooms
                myclassesWindow1.Visible = true;

                SqlCommand command = new SqlCommand("select_reservations_proffesor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@username", user_connected_label.Text));
                SqlDataReader dr = command.ExecuteReader();

                myclassesWindow1.list1.Items.Clear();

                //Populez lista de clase rezervate de profesor
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //reservation id
                    lv.SubItems.Add(dr.GetString(1).ToString()); // name
                    lv.SubItems.Add(dr.GetString(2).ToString()); // resource
                    lv.SubItems.Add(dr.GetString(3).ToString()); // group
                    lv.SubItems.Add(dr.GetString(4).ToString()); // date start
                    lv.SubItems.Add(dr.GetString(5).ToString()); // date end

                    myclassesWindow1.list1.Items.Add(lv);
                }

                dr.Close();
                command.Dispose();

                command = new SqlCommand("select_favourite_classes", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@member_username", user_connected_label.Text));
                dr = command.ExecuteReader();

                myclassesWindow1.list2.Items.Clear();

                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //resource id
                    lv.SubItems.Add(dr.GetString(1).ToString()); // resource name

                    myclassesWindow1.list2.Items.Add(lv);
                }

                dr.Close();
                command.Dispose();
            }
            connection.Close();
        }

        private void reserve_button_Click(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Reserve a class
            registerWindow1.Visible = false;
            contactWindow1.Visible = false;
            login_button2.Visible = false;
            loginWindow1.Visible = false;
            homeWindow1.Visible = false;
            classroomsWindow1.Visible = false;
            myclassesWindow1.Visible = false;
            myclassesStudentWindow1.Visible = false;

            //Setez ca SlidePanel-ul sa fie initial pe Reserve
            SlidePanel.Height = reserve_button.Height;
            SlidePanel.Top = reserve_button.Top;

            //Deschid pagina Reserve
            reserve1.Visible = true;
            book_classroom.Visible = true;
            notify_button.Visible = true;

            // Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("select_reservations", connection);
            SqlDataReader dr = command.ExecuteReader();

            reserve1.list1.Items.Clear();
            
            //Populez lista de produse
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //reservation id
                lv.SubItems.Add(dr.GetString(1).ToString()); // name
                lv.SubItems.Add(dr.GetString(2).ToString()); // resource
                lv.SubItems.Add(dr.GetString(3).ToString()); // group
                lv.SubItems.Add(dr.GetString(4).ToString()); // date start
                lv.SubItems.Add(dr.GetString(5).ToString()); // date end
                lv.SubItems.Add(dr.GetString(6).ToString()); // reason

                reserve1.list1.Items.Add(lv);
            }

            dr.Close();
            command.Dispose();
            connection.Close();
        }

        //Book a classroom button
        private void book_classroom_Click(object sender, EventArgs e)
        {
            Book_classroom f2 = new Book_classroom();
            f2.ShowDialog();

            //Dau refresh la History 
            if (f2.ok == 1)
            {
                // Open connection
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1433";
                builder.UserID = "SA";
                builder.Password = "parolaAiaPuternic4!";
                builder.InitialCatalog = "";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("select_reservations", connection);
                SqlDataReader dr = command.ExecuteReader();

                reserve1.list1.Items.Clear();

                //Populez lista de produse
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString()); //reservation id
                    lv.SubItems.Add(dr.GetString(1).ToString()); // name
                    lv.SubItems.Add(dr.GetString(2).ToString()); // resource
                    lv.SubItems.Add(dr.GetString(3).ToString()); // group
                    lv.SubItems.Add(dr.GetString(4).ToString()); // date start
                    lv.SubItems.Add(dr.GetString(5).ToString()); // date end

                    reserve1.list1.Items.Add(lv);
                }

                dr.Close();
                command.Dispose();
                connection.Close();
            }
        }

        //Botify button
        private void notify_button_Click(object sender, EventArgs e)
        {
            NotifyForm notify_form = new NotifyForm();
            notify_form.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<int> classes = new List<int>();

            string text;
            int class_no;

            // Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("select_favourite_classes", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@member_username", user_connected_label.Text));
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                text = dr.GetInt32(0).ToString();
                class_no = Int32.Parse(text);

                classes.Add(class_no);
            }

            dr.Close();
            command.Dispose();

            foreach (int i in classes)
            {
                command = new SqlCommand("check_availability", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@resource_id", i));
                command.Parameters.Add("@check", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                int result = (int)command.Parameters["@check"].Value;

                if(result == 0)
                {
                    command = new SqlCommand("get_resource_by_id", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@resource_id", i));
                    command.Parameters.Add("@resource_name", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    string resource_name = (string)command.Parameters["@resource_name"].Value;

                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Notification";
                    popup.Image = Properties.Resources.info;
                    popup.ContentText = "Classroom " + resource_name + " is now available.";
                    popup.Popup();

                    command = new SqlCommand("delete_resource_from_fav", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@resource_id", i));
                    command.Parameters.Add(new SqlParameter("@member_username", user_connected_label.Text));

                    command.ExecuteNonQuery();
                }

                command.Dispose();

            }

            connection.Close();
        }
    }
}
