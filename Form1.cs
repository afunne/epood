using System.Data;
using Microsoft.Data.SqlClient;

namespace epood;

public partial class Form1 : Form
{
    // C:\Users\tahma\Source\Repos\epood\ShopDB.mdf - at home
    // C:\Users\opilane\Source\Repos\epood\ShopDB.mdf - in school
    private SqlCommand? _command;
    private SqlConnection _connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\epood\ShopDB.mdf;Integrated Security=True");
    private SqlDataAdapter? _adapterProduct;
    public Form1()
    {
        InitializeComponent();
        UpdateCategories();
        NaitaAndmed();
    }
    private void UpdateCategories()
    {
        _connect.Open();
        _adapterProduct = new SqlDataAdapter("SELECT Id, Kategooria_nim FROM KatTabel", _connect);
        DataTable dt = new();
        _adapterProduct.Fill(dt);

        foreach (DataRow item in dt.Rows)
        {
            if (!KategooriadBox.Items.Contains(item["Kategooria_nim"]))
                KategooriadBox.Items.Add(item["Kategooria_nim"]);
            else
            {
                _command = new SqlCommand("DELETE FROM KatTabel WHERE Id=@id", _connect);
                _command.Parameters.AddWithValue("@id", item["Id"]);
                _command.ExecuteNonQuery();
            }
        }

        _connect.Close();
    }
    private void LisaKat_Click(System.Object? sender, System.EventArgs e)
    {
        bool on = false;
        foreach (var item in KategooriadBox.Items)
        {
            if (item.ToString() == KategooriadBox.Text)
                on = true;
        }

        if (!on)
        {
            _command = new SqlCommand("INSERT INTO KatTabel (Kategooria_nim) VALUES (@cat)", _connect);
            _connect.Open();
            _command.Parameters.AddWithValue("@cat", KategooriadBox.Text);
            _command.ExecuteNonQuery();
            _connect.Close();
            KategooriadBox.Items.Clear();
            UpdateCategories();
            MessageBox.Show($"Kategooria {KategooriadBox.Text} on lisatud!");
        }
        else
            MessageBox.Show("Selline kategooriat on juba olemas!");
    }

    private void KustutaKat_Click(System.Object? sender, System.EventArgs e)
    {
        if (KategooriadBox.SelectedItem != null)
        {
            _connect.Open();
            string value = KategooriadBox.SelectedItem.ToString() ?? string.Empty;
            _command = new SqlCommand("DELETE FROM KatTabel WHERE Kategooria_nim=@cat", _connect);
            _command.Parameters.AddWithValue("@cat", value);
            _command.ExecuteNonQuery();
            _connect.Close();
            KategooriadBox.Items.Clear();
            UpdateCategories();
        }
    }

    private SaveFileDialog? _saveFileDialog;
    private OpenFileDialog? _openFileDialog;

    private void Otsi_Click(System.Object? sender, System.EventArgs e)
    {
        _openFileDialog = new OpenFileDialog();
        _openFileDialog.InitialDirectory = @"C:\Users\opilane\Pictures";
        _openFileDialog.Multiselect = true;
        _openFileDialog.Filter = "Pictures Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
        string product = Toode_txt.Text;

        FileInfo openInfo = new(@"C:\Users\opilane\Pictures" + _openFileDialog.FileName);
        if (_openFileDialog.ShowDialog() == DialogResult.OK && product != null)
        {
            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.InitialDirectory = Path.GetFullPath(@"..\..\Pictures");

            string ext = Path.GetExtension(_openFileDialog.FileName);
            _saveFileDialog.FileName = product + ext;
            _saveFileDialog.Filter = "Pictures" + ext + "|" + ext;

            if (_saveFileDialog.ShowDialog() == DialogResult.OK && product != null)
            {
                File.Copy(_openFileDialog.FileName, _saveFileDialog.FileName);
                PictureBox.Image = Image.FromFile(_saveFileDialog.FileName);
            }
        }
        else
            MessageBox.Show("Puudub toode nimetus või oli vajatud Cancel");
    }

    private void NaitaAndmed()
    {
        _connect.Open();
        DataTable dt_toode = new DataTable();
        _adapterProduct = new SqlDataAdapter("SELECT ToodeTabel.Id,ToodeTabel.Toode_nim,ToodeTabel.Kogus, " +
            "ToodeTabel.Hind, ToodeTabel.Pilt, ToodeTabel.Bpilt, KatTable.Kategooria_nim " +
            "as Kategooria_nim FROM ToodeTabel INNER JOIN KatTabel on ToodeTabel.Kategooriad=KatTabel.Id ", _connect);
        _adapterProduct.Fill(dt_toode);
        DataGridView1.Columns.Clear();
        DataGridView1.DataSource = dt_toode;
        DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
        combo_kat.DataPropertyName = "Kategooria_nimetus";
        HashSet<string> keys = new HashSet<string>();
        foreach (DataRow item in dt_toode.Rows)
        {
            string kat_n = item["Kategooria_nimetus"].ToString();
            if (!keys.Contains(kat_n))
            {
                keys.Add(kat_n);
                combo_kat.Items.Add(kat_n);
            }
        }
        DataGridView1.Columns.Add(combo_kat);
        PictureBox.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Images"), "epood.png"));
        _connect.Close();
    }

    Form popupForm;

    private void Loopilt(Image image, int r)
    {
        popupForm = new Form();
        popupForm.FormBorderStyle = FormBorderStyle.None;
        popupForm.StartPosition = FormStartPosition.Manual;
        popupForm.Size = new Size(200, 200);

        PictureBox pictureBox = new PictureBox();
        pictureBox.Image = image;
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        popupForm.Controls.Add(pictureBox);

        System.Drawing.Rectangle cellRectangle = DataGridView1.GetCellDisplayRectangle(4, r, true);
        System.Drawing.Point popupLocation = DataGridView1.PointToScreen(cellRectangle.Location);

        popupForm.Location = new System.Drawing.Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
        popupForm.Show();
    }

    byte[] imageData;
    private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 4)
        {
            imageData = DataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    Loopilt(image, e.RowIndex);
                }

            }
        }
    }

    private void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {
        if (popupForm != null && !popupForm.IsDisposed)
        {
            popupForm.Close();
        }
    }
    string extention = null;
    
    private void Lisa_Click(object sender, EventArgs e)
    {
        if (Toode_txt.Text.Trim()!= string.Empty &&
            KogusBox.Text.Trim()!=string.Empty &&
            HindBox.Text.Trim()!=string.Empty && KategooriadBox.SelectedItem != null)
        {
            try
            {
                _connect.Open();
                _command = new SqlCommand("SELECT Id FROM KatTabel WHERE Kategooria_nimetus=@kat", _connect);
                _command.Parameters.AddWithValue("@kat", KategooriadBox.Text);
                _command.ExecuteNonQuery();
                int Id = Convert.ToInt32(_command.ExecuteScalar());
                _command = new SqlCommand("INSERT INTO Toodetabel (Toode_nim,kogus,Hind.Pilt,Bpilt,Kategooriad)_" +
                    " VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", _connect);
                _command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                _command.Parameters.AddWithValue("@kogus",KogusBox.Text);
                _command.Parameters.AddWithValue("@hind", HindBox.Text);
                extention = Path.GetExtension(_openFileDialog.FileName);
                _command.Parameters.AddWithValue("@Bpilt", Toode_txt.Text + extention);
                _command.Parameters.AddWithValue("@kat", Id);
                _command.ExecuteNonQuery();
                _connect.Close();
                NaitaAndmed();
            }
            catch (Exception){
                MessageBox.Show("Andmebaasiga viga!");
            }
        }
    }
}