namespace SUZA_DIP
{
    partial class SUZA_AUTO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_AUTO));
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-31, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(686, 466);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.Location = new Point(12, 111);
            button3.Name = "button3";
            button3.Size = new Size(173, 40);
            button3.TabIndex = 4;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.Location = new Point(12, 172);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 5;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.Location = new Point(14, 227);
            button2.Name = "button2";
            button2.Size = new Size(173, 40);
            button2.TabIndex = 6;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.RosyBrown;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(202, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(428, 327);
            dataGridView1.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackColor = Color.RosyBrown;
            button4.Location = new Point(12, 398);
            button4.Name = "button4";
            button4.Size = new Size(173, 40);
            button4.TabIndex = 8;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // SUZA_AUTO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 450);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_AUTO";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авто";
            Load += SUZA_AUTO_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button3;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button4;
    }
}