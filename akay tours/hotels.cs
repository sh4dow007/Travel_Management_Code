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
    public partial class hotels : Form
    {
        public hotels()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");



        private void hofl_button_Click(object sender, EventArgs e)
        {
            AppBody objho_fl = new AppBody();
            objho_fl.Show();
            this.Close();
            
        }

        private void hobs_button_Click(object sender, EventArgs e)
        {
            buses objho_bs = new buses();
            objho_bs.Show();
            this.Close();
            
        }

        private void ho_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ho_add_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@going_to", ho_textBox.Text);
                cmd.Parameters.AddWithValue("@checkin", ho_dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@checkout", ho_dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@rooms", ho_listBox.Text);

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

            ho_srch_form obj = new ho_srch_form();
            obj.Show();
            this.Close();
       
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void min_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
    
}

