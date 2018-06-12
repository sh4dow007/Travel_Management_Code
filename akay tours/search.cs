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
    public partial class bs_search_form : Form
    {
        public bs_search_form()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");



        private void srcdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fl_search_form_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

       
        public void refreshDataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("bs_search_sp", con);
                
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

                srcdataGridView.DataSource = DS.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            buses obj = new buses();
            obj.Show();
            this.Close();
        }

        private void bs_delete_form(object sender, FormClosingEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE from bs_srch", con);




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
            refreshDataGridView();
        }

        private void book_button_Click(object sender, EventArgs e)
        {
            try
            {
                string bs_id = srcdataGridView.SelectedRows[0].Cells[0].Value.ToString();
                string from = srcdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string to = srcdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                string date = srcdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                string seats = srcdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                string type = srcdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                string amount = srcdataGridView.SelectedRows[0].Cells[6].Value.ToString();

                SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");
                SqlCommand cmd = new SqlCommand("Insert into reservation(bs_id,value2,value3,value4,value5,value6,value7) " +
                    "values (@bs_id, @from, @to, @date, @seats,@type,@amount)", con);
                cmd.Parameters.AddWithValue("@bs_id", bs_id);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@seats", seats);
                cmd.Parameters.AddWithValue("@type", type);
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
                MessageBox.Show("Thank You for booking with Akay Tours\n\n\nBooking Detail:-\n \nBus id:\t\t" + bs_id + "\nFrom:\t\t" + from + "\nTo:\t\t" + to + "\nDate:\t\t" + date + "\nSeats:\t\t" + seats + "\n\n\nTotal amount to be paid:" + amount);

            }
            catch
            {
                MessageBox.Show("<<<<ERROR>>>>\n\n\nMake sure to select the desired row if present\n\n Or else there is no matching bus for your search");
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
