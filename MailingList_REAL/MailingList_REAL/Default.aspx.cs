using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MailingList_REAL
{
    public partial class _Default : Page
    {
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
            Mailman.SendMail("Marinus.c.visser@gmail.com", "Marinus.c.visser@gmail.com", "TestMail", "This is a test mailbody <b> with some html stuff in it </b>");
        }
    }
}