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
    public partial class fl_srch_form : Form
    {
        public fl_srch_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");

        private void fl_srch_form_Load(object sender, EventArgs e)
        {
            refreshfl_srcdataGridView();
        }

        public void refreshfl_srcdataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("flsearch_sp", con);

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
        }

        private void fl_button1_Click(object sender, EventArgs e)
        {
            
            AppBody obj = new AppBody();
            obj.Show();
            this.Close();
        }

        private void fl_delete_form(object sender, FormClosingEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE from fl_srch", con);




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
            refreshfl_srcdataGridView();
        }

        private void fl_book_button_Click(object sender, EventArgs e)
        {
           
            try
            {
                string fl_id = resdataGridView.SelectedRows[0].Cells[0].Value.ToString();
                string from = resdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string to = resdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                string departure = resdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                string traveller = resdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                string book_class = resdataGridView.SelectedRows[0].Cells[5].Value.ToString();
                string amount = resdataGridView.SelectedRows[0].Cells[6].Value.ToString();


                SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");
                SqlCommand cmd = new SqlCommand("Insert into reservation(fl_id,value2,value3,value4,value5,value6,value7) values (@fl_id, @from, @to, @departure, @traveller,@book_class,@amount)", con);
                cmd.Parameters.AddWithValue("@fl_id", fl_id);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                cmd.Parameters.AddWithValue("@departure", departure);
                cmd.Parameters.AddWithValue("@traveller", traveller);
                cmd.Parameters.AddWithValue("@book_class", book_class);
                cmd.Parameters.AddWithValue("@amount", amount);

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


                MessageBox.Show("Thank You for booking with Akay Tours\n\n\nBooking Detail:-\n \nFlight id:\t\t" + fl_id + "\nFrom:\t\t" + from + "\nTo:\t\t" + to + "\nDeparture:\t\t" + departure + "\nTravellers:\t\t" + traveller + "\nClass:\t\t" + book_class + "\n\n\nTotal amount to be paid: " + amount);
            }
            catch
            {
                MessageBox.Show("<<<<ERROR>>>>\n\n\nMake sure to select the desired row if present\n\n Or else there is no matching flight for your search");
            }
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
