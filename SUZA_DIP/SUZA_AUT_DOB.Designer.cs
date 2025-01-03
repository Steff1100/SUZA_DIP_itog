namespace SUZA_DIP
{
    partial class SUZA_AUT_DOB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_AUT_DOB));
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button4 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 13F);
            textBox2.Location = new Point(249, 260);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 31);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13F);
            textBox3.Location = new Point(249, 195);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(286, 31);
            textBox3.TabIndex = 8;
            // 
            // button4
            // 
            button4.BackColor = Color.RosyBrown;
            button4.Location = new Point(12, 346);
            button4.Name = "button4";
            button4.Size = new Size(173, 40);
            button4.TabIndex = 9;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.Location = new Point(362, 346);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 10;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(249, 136);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 31);
            textBox1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-14, -5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(566, 404);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(12, 142);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 22;
            label3.Text = "Авто";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(251, 187);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(12, 201);
            label5.Name = "label5";
            label5.Size = new Size(154, 25);
            label5.TabIndex = 24;
            label5.Text = "Объем двигателя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(12, 266);
            label4.Name = "label4";
            label4.Size = new Size(199, 25);
            label4.TabIndex = 25;
            label4.Text = "Регистрационный знак";
            // 
            // SUZA_AUT_DOB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(555, 398);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_AUT_DOB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить авто";
            Load += UMSZ_AUT_DOB_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button4;
        private Button button1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label1;
        private Label label5;
        private Label label4;
    }
}