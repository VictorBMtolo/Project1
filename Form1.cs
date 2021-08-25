using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CustomerdataEntities db = new CustomerdataEntities();
            db.Customers.Add(customerBindingSource.Current as Customer);
            int result = await db.SaveChangesAsync();
            if (result > 0)
                notifyIcon1.ShowBalloonTip(3000, "Message", "Your data has been successfully saved", ToolTipIcon.Info);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            customerBindingSource.DataSource = new Customer();
            notifyIcon1.Icon = SystemIcons.Application;
        }
    }
}
