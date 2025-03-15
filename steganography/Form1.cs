using steganography.Classes;

namespace steganography
{
    public partial class Form1 : Form
    {
        private Steganography stego = new Steganography();
        private Bitmap originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFile.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {
            if (originalImage != null && !string.IsNullOrEmpty(txtMessage.Text))
            {
                Bitmap encodedImage = stego.HideMessage(txtMessage.Text, originalImage);
                string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\hidden_image.png";
                encodedImage.Save(savePath);


                MessageBox.Show("Message Hidden Successfully!");
            }
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                string message = stego.ExtractMessage(originalImage);
                MessageBox.Show("Hidden Message: " + message);
            }
        }
    }
}
