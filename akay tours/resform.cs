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
    public partial class resform : Form
    {
        public resform()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");

        private void resform_Load(object sender, EventArgs e)
        {
            refresh_resdataGridView();
        }

        public void refresh_resdataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("reserv_sp", con);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


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

                resdataGridView.DataSource = DS.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


            try
            {
                SqlCommand cmd = new SqlCommand("select * from reserv_log", con);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


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

                //resdataGridView.DataSource = DS.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }

        private void fl_book_button_Click(object sender, EventArgs e)
        {

            AppBody obj = new AppBody();
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
