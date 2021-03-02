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
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public String username
        {
            get { return username_text.Text; }
            set { username_text.Text = value; }
        }

        public String password
        {
            get { return password_text.Text; }
            set { password_text.Text = value; }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void username_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
