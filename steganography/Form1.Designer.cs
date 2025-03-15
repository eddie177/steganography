namespace steganography
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
            encodeBtn = new Button();
            loadImageBtn = new Button();
            pictureBox1 = new PictureBox();
            txtMessage = new TextBox();
            decodeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // encodeBtn
            // 
            encodeBtn.Location = new Point(39, 367);
            encodeBtn.Name = "encodeBtn";
            encodeBtn.Size = new Size(226, 29);
            encodeBtn.TabIndex = 0;
            encodeBtn.Text = "Encode Image With Message";
            encodeBtn.UseVisualStyleBackColor = true;
            encodeBtn.Click += encodeBtn_Click;
            // 
            // loadImageBtn
            // 
            loadImageBtn.Location = new Point(39, 233);
            loadImageBtn.Name = "loadImageBtn";
            loadImageBtn.Size = new Size(226, 29);
            loadImageBtn.TabIndex = 1;
            loadImageBtn.Text = "Load Image";
            loadImageBtn.UseVisualStyleBackColor = true;
            loadImageBtn.Click += loadImageBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(39, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 129);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(412, 282);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(125, 27);
            txtMessage.TabIndex = 3;
            // 
            // decodeBtn
            // 
            decodeBtn.Location = new Point(287, 211);
            decodeBtn.Name = "decodeBtn";
            decodeBtn.Size = new Size(226, 29);
            decodeBtn.TabIndex = 4;
            decodeBtn.Text = "Show Hidden Message";
            decodeBtn.UseVisualStyleBackColor = true;
            decodeBtn.Click += decodeBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(decodeBtn);
            Controls.Add(txtMessage);
            Controls.Add(pictureBox1);
            Controls.Add(loadImageBtn);
            Controls.Add(encodeBtn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button encodeBtn;
        private Button loadImageBtn;
        private PictureBox pictureBox1;
        private TextBox txtMessage;
        private Button decodeBtn;
    }
}
