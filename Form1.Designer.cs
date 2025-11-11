namespace epood
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            katbox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            toodetxt = new TextBox();
            kogustxt = new TextBox();
            hindtxt = new TextBox();
            lisakatbtn = new Button();
            kustutakatbtn = new Button();
            lisabtn = new Button();
            uuendabtn = new Button();
            puhustabtn = new Button();
            toode_pb = new PictureBox();
            otsifailbtn = new Button();
            kustutabtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toode_pb).BeginInit();
            SuspendLayout();
            // 
            // katbox
            // 
            katbox.FormattingEnabled = true;
            katbox.Location = new Point(116, 130);
            katbox.Name = "katbox";
            katbox.Size = new Size(121, 23);
            katbox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 21);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 5;
            label1.Text = "Toode:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 58);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 6;
            label2.Text = "Kogus:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 97);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Hind:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 130);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 8;
            label4.Text = "Kategooriad:";
            label4.Click += label4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(73, 249);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(662, 189);
            dataGridView1.TabIndex = 9;
            // 
            // toodetxt
            // 
            toodetxt.Location = new Point(116, 21);
            toodetxt.Name = "toodetxt";
            toodetxt.Size = new Size(100, 23);
            toodetxt.TabIndex = 10;
            // 
            // kogustxt
            // 
            kogustxt.Location = new Point(116, 58);
            kogustxt.Name = "kogustxt";
            kogustxt.Size = new Size(100, 23);
            kogustxt.TabIndex = 11;
            // 
            // hindtxt
            // 
            hindtxt.Location = new Point(116, 94);
            hindtxt.Name = "hindtxt";
            hindtxt.Size = new Size(100, 23);
            hindtxt.TabIndex = 12;
            // 
            // lisakatbtn
            // 
            lisakatbtn.Location = new Point(73, 171);
            lisakatbtn.Name = "lisakatbtn";
            lisakatbtn.Size = new Size(101, 33);
            lisakatbtn.TabIndex = 13;
            lisakatbtn.Text = "Lisa kategooriat";
            lisakatbtn.UseVisualStyleBackColor = true;
            lisakatbtn.Click += lisakatbtn_Click;
            // 
            // kustutakatbtn
            // 
            kustutakatbtn.Location = new Point(190, 171);
            kustutakatbtn.Name = "kustutakatbtn";
            kustutakatbtn.Size = new Size(118, 33);
            kustutakatbtn.TabIndex = 14;
            kustutakatbtn.Text = "Kustuta kategoorat";
            kustutakatbtn.UseVisualStyleBackColor = true;
            // 
            // lisabtn
            // 
            lisabtn.Location = new Point(73, 220);
            lisabtn.Name = "lisabtn";
            lisabtn.Size = new Size(60, 23);
            lisabtn.TabIndex = 15;
            lisabtn.Text = "Lisa";
            lisabtn.UseVisualStyleBackColor = true;
            // 
            // uuendabtn
            // 
            uuendabtn.Location = new Point(139, 220);
            uuendabtn.Name = "uuendabtn";
            uuendabtn.Size = new Size(60, 23);
            uuendabtn.TabIndex = 16;
            uuendabtn.Text = "Uuenda";
            uuendabtn.UseVisualStyleBackColor = true;
            // 
            // puhustabtn
            // 
            puhustabtn.Location = new Point(286, 220);
            puhustabtn.Name = "puhustabtn";
            puhustabtn.Size = new Size(62, 23);
            puhustabtn.TabIndex = 17;
            puhustabtn.Text = "Puhasta";
            puhustabtn.UseVisualStyleBackColor = true;
            // 
            // toode_pb
            // 
            toode_pb.Location = new Point(344, 21);
            toode_pb.Name = "toode_pb";
            toode_pb.Size = new Size(391, 132);
            toode_pb.TabIndex = 18;
            toode_pb.TabStop = false;
            // 
            // otsifailbtn
            // 
            otsifailbtn.Location = new Point(344, 171);
            otsifailbtn.Name = "otsifailbtn";
            otsifailbtn.Size = new Size(75, 23);
            otsifailbtn.TabIndex = 19;
            otsifailbtn.Text = "Otsi fail";
            otsifailbtn.UseVisualStyleBackColor = true;
            // 
            // kustutabtn
            // 
            kustutabtn.Location = new Point(205, 220);
            kustutabtn.Name = "kustutabtn";
            kustutabtn.Size = new Size(75, 23);
            kustutabtn.TabIndex = 20;
            kustutabtn.Text = "kustuta";
            kustutabtn.UseVisualStyleBackColor = true;
            kustutabtn.Click += kustutabtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(kustutabtn);
            Controls.Add(otsifailbtn);
            Controls.Add(toode_pb);
            Controls.Add(puhustabtn);
            Controls.Add(uuendabtn);
            Controls.Add(lisabtn);
            Controls.Add(kustutakatbtn);
            Controls.Add(lisakatbtn);
            Controls.Add(hindtxt);
            Controls.Add(kogustxt);
            Controls.Add(toodetxt);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(katbox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)toode_pb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox katbox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private TextBox toodetxt;
        private TextBox kogustxt;
        private TextBox hindtxt;
        private Button lisakatbtn;
        private Button kustutakatbtn;
        private Button lisabtn;
        private Button uuendabtn;
        private Button puhustabtn;
        private PictureBox toode_pb;
        private Button otsifailbtn;
        private Button kustutabtn;
    }
}
