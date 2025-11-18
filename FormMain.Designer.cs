namespace epood
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnOpenForm1;
        private Button btnOpenForm2;
        private Button btnOpenForm3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnOpenForm1 = new Button();
            btnOpenForm2 = new Button();
            btnOpenForm3 = new Button();
            SuspendLayout();
            // 
            // btnOpenForm1
            // 
            btnOpenForm1.Location = new Point(30, 30);
            btnOpenForm1.Name = "btnOpenForm1";
            btnOpenForm1.Size = new Size(120, 40);
            btnOpenForm1.TabIndex = 0;
            btnOpenForm1.Text = "Admin";
            btnOpenForm1.Click += btnOpenForm1_Click;
            // 
            // btnOpenForm2
            // 
            btnOpenForm2.Location = new Point(30, 80);
            btnOpenForm2.Name = "btnOpenForm2";
            btnOpenForm2.Size = new Size(120, 40);
            btnOpenForm2.TabIndex = 1;
            btnOpenForm2.Text = "Custumer";
            btnOpenForm2.Click += btnOpenForm2_Click;
            // 
            // btnOpenForm3
            // 
            btnOpenForm3.Location = new Point(0, 0);
            btnOpenForm3.Name = "btnOpenForm3";
            btnOpenForm3.Size = new Size(75, 23);
            btnOpenForm3.TabIndex = 0;
            // 
            // FormMain
            // 
            ClientSize = new Size(200, 200);
            Controls.Add(btnOpenForm1);
            Controls.Add(btnOpenForm2);
            Name = "FormMain";
            Text = "Select a Form";
            ResumeLayout(false);
        }
    }
}