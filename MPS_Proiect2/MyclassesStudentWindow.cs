using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS_Proiect2
{
    public partial class MyclassesStudentWindow : UserControl
    {
        public MyclassesStudentWindow()
        {
            InitializeComponent();

            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 120;
            listView1.Columns[2].Width = 80;
            listView1.Columns[3].Width = 65;
            listView1.Columns[4].Width = 120;
            listView1.Columns[5].Width = 120;
        }

        public ListView list1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
