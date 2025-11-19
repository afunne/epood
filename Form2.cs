using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

namespace epood
{
    public partial class Form2 : Form
    {
        private SqlConnection _connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\tahma\Source\Repos\epood\ShopDB.mdf;
              Integrated Security=True;");

        private decimal wallet = 0m;
        private decimal billTotal = 0m;

        private ListBox billBox;
        private Label walletLabel;
        private Label billLabel;
        private FlowLayoutPanel productPanel;
        private ListBox categoryBox;
        private TextBox walletAddBox;

        public Form2()
        {
            InitializeComponent();
            BuildUI();
            LoadCategories();
        }

        private void BuildUI()
        {
            this.Text = "Pood — Kliendivaade";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            SplitContainer split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 250,
                IsSplitterFixed = false
            };

            // -------- LEFT PANEL --------
            split.Panel1.Padding = new Padding(10);

            walletLabel = new Label
            {
                Text = "Rahakott: 0.00€",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30
            };

            walletAddBox = new TextBox
            {
                PlaceholderText = "Lisa raha...",
                Dock = DockStyle.Top,
                Height = 30
            };

            Button addMoney = new Button
            {
                Text = "Lisa",
                Dock = DockStyle.Top,
                Height = 35
            };
            addMoney.Click += AddMoney;

            billLabel = new Label
            {
                Text = "Summa: 0.00€",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            billBox = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                SelectionMode = SelectionMode.MultiExtended
            };
            billBox.DoubleClick += BillBox_DoubleClick;

            Button purchaseButton = new Button
            {
                Text = "Osta kõik",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            purchaseButton.Click += PurchaseAll;

            split.Panel1.Controls.Add(purchaseButton);
            split.Panel1.Controls.Add(billBox);
            split.Panel1.Controls.Add(billLabel);
            split.Panel1.Controls.Add(addMoney);
            split.Panel1.Controls.Add(walletAddBox);
            split.Panel1.Controls.Add(walletLabel);

            // -------- RIGHT PANEL --------
            categoryBox = new ListBox
            {
                Dock = DockStyle.Top,
                Height = 150,
                Font = new Font("Segoe UI", 11)
            };
            categoryBox.SelectedIndexChanged += CategoryChanged;

            productPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(10)
            };

            split.Panel2.Controls.Add(productPanel);
            split.Panel2.Controls.Add(categoryBox);

            this.Controls.Add(split);
        }

        // -----------------------------
        // Load Categories
        // -----------------------------
        private void LoadCategories()
        {
            try
            {
                if (_connect.State != ConnectionState.Open)
                    _connect.Open();

                SqlDataAdapter adp = new SqlDataAdapter("SELECT Id, Kategooria_nim FROM KatTabel", _connect);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                categoryBox.DataSource = dt;
                categoryBox.DisplayMember = "Kategooria_nim";
                categoryBox.ValueMember = "Id";
            }
            finally
            {
                if (_connect.State == ConnectionState.Open)
                    _connect.Close();
            }
        }

        // -----------------------------
        // Category Changed
        // -----------------------------
        private void CategoryChanged(object? sender, EventArgs e)
        {
            if (categoryBox.SelectedItem == null) return;

            DataRowView row = categoryBox.SelectedItem as DataRowView;
            if (row == null) return;

            int catId = Convert.ToInt32(row["Id"]);
            productPanel.Controls.Clear();

            try
            {
                if (_connect.State != ConnectionState.Open)
                    _connect.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT Id, Toode_nim, Hind, Kogus, Bpilt, Pilt FROM ToodeTabel WHERE Kategooriad = @id",
                    _connect);
                cmd.Parameters.AddWithValue("@id", catId);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable products = new DataTable();
                adp.Fill(products);

                foreach (DataRow p in products.Rows)
                    AddProductCard(p);
            }
            finally
            {
                if (_connect.State == ConnectionState.Open)
                    _connect.Close();
            }
        }

        // -----------------------------
        // Build Product Cards
        // -----------------------------
        private void AddProductCard(DataRow productRow)
        {
            int id = Convert.ToInt32(productRow["Id"]);
            string name = productRow["Toode_nim"].ToString();
            decimal price = Convert.ToDecimal(productRow["Hind"]);
            int stock = Convert.ToInt32(productRow["Kogus"]);

            Panel card = new Panel
            {
                Width = 200,
                Height = 300,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(8)
            };

            PictureBox img = new PictureBox
            {
                Width = 180,
                Height = 150,
                Dock = DockStyle.Top,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            string defaultImage = Path.Combine(Path.GetFullPath(@"..\..\..\Images"), "epood.png");

            try
            {
                byte[]? data = productRow["Bpilt"] as byte[];
                if (data != null && data.Length > 0)
                {
                    using MemoryStream ms = new MemoryStream(data);
                    img.Image = Image.FromStream(ms);
                }
                else
                {
                    img.Image = Image.FromFile(defaultImage);
                }
            }
            catch
            {
                img.Image = Image.FromFile(defaultImage);
            }

            Label lblName = new Label
            {
                Text = name,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblPrice = new Label
            {
                Text = $"{price:N2} €",
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblStock = new Label
            {
                Text = $"Laos: {stock}",
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button addBtn = new Button
            {
                Text = "Lisa arvele",
                Dock = DockStyle.Bottom,
                Height = 35
            };

            addBtn.Click += (s, e) =>
            {
                if (stock <= 0)
                {
                    MessageBox.Show("Toode on otsas!");
                    return;
                }

                billBox.Items.Add($"{name} — {price:N2} € (ID:{id})");
                billTotal += price;
                billLabel.Text = $"Summa: {billTotal:N2}€";
            };

            card.Controls.Add(addBtn);
            card.Controls.Add(lblStock);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblName);
            card.Controls.Add(img);

            productPanel.Controls.Add(card);
        }

        // -----------------------------
        // Add Money
        // -----------------------------
        private void AddMoney(object? sender, EventArgs e)
        {
            if (decimal.TryParse(walletAddBox.Text.Replace(',', '.'), out decimal amount) && amount > 0)
            {
                wallet += amount;
                walletLabel.Text = $"Rahakott: {wallet:N2}€";
                walletAddBox.Clear();
            }
            else
            {
                MessageBox.Show("Sisesta korrektne summa!");
            }
        }

        // -----------------------------
        // Double-click to remove selected item(s)
        // -----------------------------
        private void BillBox_DoubleClick(object? sender, EventArgs e)
        {
            if (billBox.SelectedItems.Count == 0) return;

            var selectedItems = billBox.SelectedItems.Cast<object>().ToList();

            foreach (var item in selectedItems)
            {
                string selected = item.ToString()!;
                int euroIndex = selected.IndexOf("€");
                if (euroIndex > 0)
                {
                    string priceStr = selected.Substring(selected.IndexOf("—") + 1, euroIndex - selected.IndexOf("—") - 1).Trim();
                    if (decimal.TryParse(priceStr.Replace("€", "").Trim(), out decimal price))
                        billTotal -= price;
                }

                billBox.Items.Remove(item);
            }

            billLabel.Text = $"Summa: {billTotal:N2}€";
        }

        // -----------------------------
        // Purchase All
        // -----------------------------
        private void PurchaseAll(object? sender, EventArgs e)
        {
            if (billTotal <= 0)
            {
                MessageBox.Show("Arve on tühi!");
                return;
            }

            if (wallet < billTotal)
            {
                MessageBox.Show("Pole piisavalt raha!");
                return;
            }

            try
            {
                if (_connect.State != ConnectionState.Open)
                    _connect.Open();

                foreach (var item in billBox.Items)
                {
                    string text = item!.ToString()!;
                    int idIndex = text.IndexOf("ID:") + 3;
                    int id = int.Parse(new string(text.Substring(idIndex).Where(char.IsDigit).ToArray()));

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE ToodeTabel SET Kogus = Kogus - 1 WHERE Id = @id AND Kogus > 0",
                        _connect);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (_connect.State == ConnectionState.Open)
                    _connect.Close();
            }

            wallet -= billTotal;
            billTotal = 0;

            walletLabel.Text = $"Rahakott: {wallet:N2}€";
            billLabel.Text = "Summa: 0.00€";
            billBox.Items.Clear();

            MessageBox.Show("Ost sooritatud!");

            // Reload products
            CategoryChanged(null, null);
        }
    }
}