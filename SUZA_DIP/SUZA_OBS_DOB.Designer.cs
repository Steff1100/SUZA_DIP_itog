namespace SUZA_DIP
{
    partial class SUZA_OBS_DOB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_OBS_DOB));
            button1 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.Location = new Point(362, 328);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 28;
            button1.Text = "Списать запчасти";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.RosyBrown;
            button4.Location = new Point(12, 328);
            button4.Name = "button4";
            button4.Size = new Size(173, 40);
            button4.TabIndex = 27;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(249, 131);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 31);
            textBox1.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(12, 266);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 23;
            label3.Text = "Часы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(12, 201);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 22;
            label2.Text = "Авто ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(12, 137);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 21;
            label1.Text = "Вид ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-6, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(562, 403);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(249, 270);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(286, 23);
            numericUpDown1.TabIndex = 29;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(249, 204);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(286, 23);
            comboBox3.TabIndex = 30;
            // 
            // SUZA_OBS_DOB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 378);
            Controls.Add(comboBox3);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_OBS_DOB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить обслуживание";
            Load += SUZA_OBS_DOB_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox3;
    }
}