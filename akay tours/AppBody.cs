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
    public partial class AppBody : Form
    {

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");



        public AppBody()
        {
            InitializeComponent();
        }




        private void fl_button_Click(object sender, EventArgs e)
        {
            

            try
            {
                SqlCommand cmd = new SqlCommand("fl_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@src_from", fl_textBox1.Text);
                cmd.Parameters.AddWithValue("@src_to", fl_textBox2.Text);
                cmd.Parameters.AddWithValue("@src_departure", fl_dateTimePicker.Value);
                cmd.Parameters.AddWithValue("@src_traveller", fl_listBox1.Text);

                
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1+"<<<INVALID SQL OPERATION>>>");
                }
                con.Close();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }

            
            fl_srch_form obj = new fl_srch_form();
            obj.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hotels objfl_ho = new hotels();
            objfl_ho.Show();
            this.Close();
            
        }

        private void flbs_button_Click(object sender, EventArgs e)
        {
            buses objfl_bs = new buses();
            objfl_bs.Show();
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
