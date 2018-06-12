using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace akay_tours
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;


        public String getlogin()
        {
            con.Open();
            String syntax = "select pass from login where user_id='username'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = (dr[0].ToString());
            con.Close();
            return temp;
        }

        public String getpassword()
        {
            con.Open();
            String syntax = "select pass from login where user_id='password'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp= (dr[0].ToString());
            con.Close();
            return temp;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            String uname=getlogin(), upass=getpassword();
            String name = textBox1.Text;
            String pass = textBox2.Text;

            if(name.Equals(uname)&&pass.Equals(upass))
            {
                label1.Hide();
                AppBody obj = new AppBody();
                this.Hide();
                obj.Show();

            }
            else
            {
                label1.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void min_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
