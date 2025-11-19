using epood;
using System;
using System.Linq;
using System.Windows.Forms;

namespace epood
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpenForm1_Click(object sender, EventArgs e)
        {
            // Check if Form1 is already open
            Form1 existingForm1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (existingForm1 != null)
            {
                existingForm1.BringToFront(); // Focus the existing one
                existingForm1.WindowState = FormWindowState.Normal; // Restore if minimized
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            // Check if Form2 is already open
            Form2 existingForm2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
            if (existingForm2 != null)
            {
                existingForm2.BringToFront();
                existingForm2.WindowState = FormWindowState.Normal;
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }
    }
}
