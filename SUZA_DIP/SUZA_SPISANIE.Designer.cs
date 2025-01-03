namespace SUZA_DIP
{
    partial class SUZA_SPISANIE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_SPISANIE));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button4 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-84, -5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(619, 827);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(12, 135);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(148, 25);
            label1.TabIndex = 12;
            label1.Text = " Выбор запчасти";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(12, 232);
            label2.Name = "label2";
            label2.Size = new Size(133, 25);
            label2.TabIndex = 14;
            label2.Text = "Выбор работы";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(12, 285);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 15;
            label3.Text = "Выбор даты";
            // 
            // button1
            // 
            button1.Location = new Point(261, 398);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 18;
            button1.Text = "Списать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 398);
            button4.Name = "button4";
            button4.Size = new Size(173, 40);
            button4.TabIndex = 17;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(14, 337);
            label4.Name = "label4";
            label4.Size = new Size(114, 25);
            label4.TabIndex = 20;
            label4.Text = "Выбор МОЛ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(228, 338);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(206, 23);
            comboBox1.TabIndex = 22;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(228, 233);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(206, 23);
            comboBox3.TabIndex = 24;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(228, 135);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(206, 23);
            comboBox4.TabIndex = 25;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(228, 285);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(206, 23);
            dateTimePicker1.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(12, 180);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 27;
            label5.Text = "Количество";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(228, 184);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(209, 23);
            numericUpDown1.TabIndex = 29;
            // 
            // SUZA_SPISANIE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_SPISANIE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Списание";
            Load += SUZA_SPISANIE_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button4;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private NumericUpDown numericUpDown1;
    }
}