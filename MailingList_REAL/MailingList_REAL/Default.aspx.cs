using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MailingList_REAL
{
    public partial class _Default : Page
    {
        private List<String> receivers = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(Object sender, EventArgs e)
        {
            try
            {
                SqlConnection calenderdb = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MailingDb.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [Table] ([Name], [Email]) VALUES (@name, @email)", calenderdb);
                cmd.Parameters.AddWithValue("@name", TextBoxName.Text);
                cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Console.WriteLine(TextBoxName.Text + " : " + TextBoxEmail.Text);
                TextBoxName.Text = "";
                TextBoxEmail.Text = "";
                GridView newGrid = productGridView;
                newGrid.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HALP");
            }
        }

        protected void mailTest_Click(Object sender, EventArgs e)
        {
            Mailman.SendMail("Marinus.c.visser@gmail.com", receivers, "TestMail", TextBox1.Text, false);
        }

        void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Select")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = productGridView.Rows[index];
                TableCell contactName = selectedRow.Cells[1];
                receivers.Add(contactName.Text);
            }

        }
    }
}