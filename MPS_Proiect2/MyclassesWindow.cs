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
    public partial class MyclassesWindow : UserControl
    {
        public MyclassesWindow()
        {
            InitializeComponent();
            listView1.Columns[0].Width = 30;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 60;
            listView1.Columns[3].Width = 45;
            listView1.Columns[4].Width = 100;
            listView1.Columns[5].Width = 100;

            listView2.Columns[0].Width = 55;
            listView2.Columns[1].Width = 105;
        }

        public ListView list1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        public ListView list2
        {
            get { return listView2; }
            set { listView2 = value; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
