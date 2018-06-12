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
    public partial class ho_srch_form : Form
    {
        public ho_srch_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");

        private void ho_srch_form_Load(object sender, EventArgs e)
        {
            refreshho_srcdataGridView();
        }

        public void refreshho_srcdataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("hosearch_sp", con);

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

                ho_srcdataGridView.DataSource = DS.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void ho_button1_Click(object sender, EventArgs e)
        {
            
            hotels obj = new hotels();
            obj.Show();
            this.Close();
        }

        private void ho_delete_form(object sender, FormClosingEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE from ho_srch_tbl", con);




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
            refreshho_srcdataGridView();
        }

        private void ho_book_button_Click(object sender, EventArgs e)
        {
            try
            {
                string ho_id = ho_srcdataGridView.SelectedRows[0].Cells[0].Value.ToString();
                string going = ho_srcdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string checkin = ho_srcdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                string checkout = ho_srcdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                string rooms = ho_srcdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                string amount = ho_srcdataGridView.SelectedRows[0].Cells[5].Value.ToString();

                SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"|DataDirectory|\\AKDatabase.mdf\";Integrated Security = True");
                SqlCommand cmd = new SqlCommand("Insert into reservation(ho_id,value2,value3,value4,value5,value6) values (@ho_id, @going, @checkin, @checkout, @rooms,@amount)", con);
                cmd.Parameters.AddWithValue("@ho_id", ho_id);
                cmd.Parameters.AddWithValue("@going", going);
                cmd.Parameters.AddWithValue("@checkin", checkin);
                cmd.Parameters.AddWithValue("@checkout", checkout);
                cmd.Parameters.AddWithValue("@rooms", rooms);
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

                MessageBox.Show("Thank You for booking with Akay Tours\n\n\nBooking Detail:-\n \nHotel id:\t\t" + ho_id + "\nGoing to:\t\t" + going + "\nCheckIn Date:\t" + checkin + "\nCheckOut Date:\t" + checkout + "\nRooms:\t\t" + rooms + "\n\n\nTotal amount to be paid:" + amount);
            }
            catch
            {
                MessageBox.Show("<<<<ERROR>>>>\n\n\nMake sure to select the desired row if present\n\n Or else there is no matching hotel for your search");
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
