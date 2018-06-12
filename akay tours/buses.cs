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

    public partial class buses : Form
    {



        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");




        public buses()
        {
            
            InitializeComponent();
        }

        private void bsfl_button_Click(object sender, EventArgs e)
        {
            AppBody objbs_fl = new AppBody();
            objbs_fl.Show();
            this.Close();
            
        }

        private void bsho_button_Click(object sender, EventArgs e)
        {
            hotels objbs_ho = new hotels();
            objbs_ho.Show();
            this.Close();
            
        }

        public void bs_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("bs_add_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bs_from", bs_textBox1.Text);
                cmd.Parameters.AddWithValue("@bs_to", bs_textBox2.Text);
                cmd.Parameters.AddWithValue("@bs_date", bs_dateTimePicker.Value);
                cmd.Parameters.AddWithValue("@bs_seats", bs_listBox.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1 + "<<<INVALID SQL OPERATION>>>");
                }
                con.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            bs_search_form obj = new bs_search_form();
            obj.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void min_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void reserve_Click(object sender, EventArgs e)
        {
            resform obj = new resform();
            obj.Show();
            this.Close();
        }
    }
}
