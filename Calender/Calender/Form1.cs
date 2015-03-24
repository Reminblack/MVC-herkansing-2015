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
using System.Collections;
using System.Globalization;

namespace Calender
{
    public partial class Form1 : Form
    {
        //database connection information
        SqlConnection calenderdb = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        ArrayList items = new ArrayList { };
        FlowLayoutPanel flow0;
        FlowLayoutPanel flow1;
        FlowLayoutPanel flow2;
        FlowLayoutPanel flow3;
        FlowLayoutPanel flow4;
        FlowLayoutPanel flow5;
        FlowLayoutPanel flow6;
        DateTime weekStart;
        DateTime weekEnd;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", calenderdb);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    //Console.WriteLine(reader.HasRows);
                    while (reader.Read())
                    {
                        //Console.WriteLine("TESTING DATA COLLECTION");
                        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", reader[0], reader[1], reader[2], reader[3], reader[4]));
                        Item item = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4));
                        items.Add(item);
                    }
                    Console.WriteLine(items.Count);
                }
                finally { reader.Close(); }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            NewItem item = new NewItem(calenderdb);
            item.Show();
        }

        private void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (monthRadio.Checked)
            {
                
            }
        }

        private void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            //remove all UI elements from the flowlayout
            while (calendarRender.Controls.Count > 0)
            {
                calendarRender.Controls[0].Dispose();
            }
            if (weekRadio.Checked)
            {
                
                flow0 = new FlowLayoutPanel();
                flow1 = new FlowLayoutPanel();
                flow2 = new FlowLayoutPanel();
                flow3 = new FlowLayoutPanel();
                flow4 = new FlowLayoutPanel();
                flow5 = new FlowLayoutPanel();
                flow6 = new FlowLayoutPanel();
                calendarRender.FlowDirection = FlowDirection.LeftToRight;
                flow0.FlowDirection = FlowDirection.TopDown;
                flow0.Width = 100;
                flow1.FlowDirection = FlowDirection.TopDown;
                flow1.Width = 100;
                flow2.FlowDirection = FlowDirection.TopDown;
                flow2.Width = 100;
                flow3.FlowDirection = FlowDirection.TopDown;
                flow3.Width = 100;
                flow4.FlowDirection = FlowDirection.TopDown;
                flow4.Width = 100;
                flow5.FlowDirection = FlowDirection.TopDown;
                flow5.Width = 100;
                flow6.FlowDirection = FlowDirection.TopDown;
                flow6.Width = 100;
                calendarRender.Controls.Add(flow0);
                Label day0 = new Label();
                day0.Text = "Sun";
                calendarRender.Controls.Add(flow1);
                Label day1 = new Label();
                day1.Text = "Mon";
                calendarRender.Controls.Add(flow2);
                Label day2 = new Label();
                day2.Text = "Tue";
                calendarRender.Controls.Add(flow3);
                Label day3 = new Label();
                day3.Text = "Wed";
                calendarRender.Controls.Add(flow4);
                Label day4 = new Label();
                day4.Text = "Thu";
                calendarRender.Controls.Add(flow5);
                Label day5 = new Label();
                day5.Text = "Fri";
                calendarRender.Controls.Add(flow6);
                Label day6 = new Label();
                day6.Text = "Sat";

                flow0.Controls.Add(day0);
                flow1.Controls.Add(day1);
                flow2.Controls.Add(day2);
                flow3.Controls.Add(day3);
                flow4.Controls.Add(day4);
                flow5.Controls.Add(day5);
                flow6.Controls.Add(day6);


                Control[] controls = new Control[] { flow0, flow1, flow2, flow3, flow4, flow5, flow6 };

                //check today and what weekday it is then create the week sunday to saturday.
                DateTime today = DateTime.Now;
                weekStart = today.AddDays(-((int)today.DayOfWeek));
                weekEnd = weekStart.AddDays(7);

                ArrayList weekItems = new ArrayList();
                //does it fall within this week?
                //Console.WriteLine("inweek check");
                foreach (Item item in items)
                {
                    if (item.GetStartDate() < weekEnd && item.GetEndDate() > weekStart)
                    {
                        //Console.WriteLine("ISINWEEK");
                        weekItems.Add(item);
                    }
                }
                //when is it going to start and end?
                //Console.WriteLine("does it fall on today?");
                foreach (Item item in weekItems)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (item.GetStartDate() <= weekStart.AddDays(i) && item.GetEndDate() >= weekStart.AddDays(i))
                        {
                            //Console.WriteLine(weekStart.AddDays(i) + "It falls on this day");
                            Button itemButton = new Button();
                            itemButton.Text = item.GetName();
                            controls[i].Controls.Add(itemButton);
                        }
                    }
                }
            }
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            //remove all elements from the flowlayout
            while (calendarRender.Controls.Count > 0)
            {
                calendarRender.Controls[0].Dispose();
            }
            calendarRender.FlowDirection = FlowDirection.TopDown;

            //create buttons for each event
            foreach(Item item in items)
            {
                String start = item.GetStartDate().ToString("ddd dd MMM yyyy h:mm");
                String end = item.GetEndDate().ToString("ddd dd MMM yyyy h:mm");
                Button itemButton = new Button();
                itemButton.Text = item.GetName() + " -- " + start +" : " + end;
                itemButton.Width = 500;
                itemButton.Click += (s1, e1) => { itemButton_Click(s1, e1, item); };
                calendarRender.Controls.Add(itemButton);
            }

        }

        private void calendarRender_Paint(object sender, PaintEventArgs e)
        {

        }

        //go to more information about one item
        private void itemButton_Click(Object sender, EventArgs e, Item item)
        {
            //Console.WriteLine(item.GetName());
            Form2 details = new Form2(item);
            details.Show();
        }

    }
}
