using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String temp = textBox1.Text;
            try
            {
                int a = Convert.ToInt32(temp);
                string ConString = "server=localhost;user id=root;password=1234;persistsecurityinfo=True;database=cargo_database";
                MySqlConnection con = new MySqlConnection(ConString);
                string CmdString = "SELECT At.Cargo_ID,At.Received ,Branch.Name,Cargo.Status FROM (Branch JOIN  At ON Branch.ID=At.Branch_ID)JOIN Cargo ON Cargo.ID=At.Cargo_ID WHERE At.Cargo_ID="+temp;
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch
            {
                MessageBox.Show("Invalid input, please enter an integer value");
            }
            Form2 f1 = new Form2(temp);
            f1.Show();
           
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
