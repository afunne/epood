using System;
using System.Data.SqlClient;
using System.Data;

namespace epood
{
    public partial class Form1 : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Tooded_DB.mdf;Integrated Security = True");
        SqlCommand command;

        SqlDataAdapter adapter_toode, adapter_kategooria;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lisakatbtn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in katbox.Items)
            {
                if (item.ToString() == katbox.Text)
                {
                    on = true;
                }
            }
            if (on == false)
            {
                command = new SqlCommand("INSERT INTO kategooriatabel (Kategooria_nimetus) VALUES (@kat)", connect);
                command.Open();
                command.Parameters.AddWithValue("@kat", katbox.Text);
                command.Close();
                katbox.Items.Clear();
                NaitaKategooriad();

            }
            else
            {
                MessageBox.Show("Selline kategooriat in juba olemas!");
            }
        }

        private void NaitaKategooriad()
        {
            connect.Open();
            DataTable dt_kat = new SqlDataAdapter("SELECT Id,kategooria_nimetus FROM Kategooriatabel", connect);
            adapter_kategooria.Fill(dt_kat.Rows);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!katbox.Items.Contains(item["Kategooria_nimetus"]))
                {
                    katbox.Items.Add(item["Kategooria_Nimetus"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM Kategooriatabel WHERE id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["id"]);
                    command.ExucuteNonQuery();
                }
            }
            Connect.Close();
        }

        private void kustutabtn_Click(object sender, EventArgs e)
        {
            if (katbox.SelectedItem != null)
            {
                connect.Open;
                string kat_val = katbox.SelectedItem.ToString();
                command = 
            }
        }

        SaveFileDialog save;
        SaveFileDialog open;
        string extensions = null;

        private void otsi_fail_btn_Click(object sender, EventArgs e) 
        {
            open = new SaveFileDialog();
            open.InitialDirectory = @"C:\Users\marina.oleinik\Pildid";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg;*.bmp;*.png;*.jpg|*.jpeg;*.bmp;*.png;*.jpg)";

            FileInfo open_info = new FileInfo(@"C:\Users\marina.oleinik\Pictures\"+open.FileName);
            if (open.ShowDialog()==DialogResult.OK && toodetxt!= null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\pildid");
                extension = Path.GetExtension(open.FileName);
                save.FileName = toodetxt.Text + Path.GetExtension(open.FileName);
                save.Filter="Images"+Path.GetExtension(open.FileName)+"|"+Path.GetExtension(open.FileName);
                if (save.ShowDialog()== DialogResult.OK && toodetxt.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    toode_pb.Images=Image.FromFile(save.FileName);
                }
            }
            else
            {
                Message.Show("Puudub toode nimetus või oli vajutatud");
            }
        
        }
    }
}
