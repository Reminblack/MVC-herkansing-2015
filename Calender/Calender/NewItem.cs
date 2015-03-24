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
using System.Globalization;

namespace Calender
{
    public partial class NewItem : Form
    {
        SqlConnection database;

        public NewItem(SqlConnection conn)
        {
            InitializeComponent();
            database = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [Table] ([name], [startDate], [endDate], [description]) VALUES ( @name, @startdate, @enddate, @description)", database);
                cmd.Parameters.AddWithValue("@name", itemName.Text);
                cmd.Parameters.AddWithValue("@startdate", startDatePicker.Value);
                cmd.Parameters.AddWithValue("@enddate", endDatePicker.Value);
                cmd.Parameters.AddWithValue("@description", desciptionText.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Console.WriteLine(itemName.Text +" "+ startDatePicker.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
