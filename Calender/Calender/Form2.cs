using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class Form2 : Form
    {
        Item item;
        public Form2(Item item)
        {
            this.item = item;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            infoName.Text = item.GetName();
            infoStart.Text = item.GetStartDate().ToString("ddd dd MMM yyyy h:mm");
            infoEnd.Text = item.GetEndDate().ToString("ddd dd MMM yyyy h:mm");
            infoDescription.Text = item.GetDescription();
        }

        private void infoDelete_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
