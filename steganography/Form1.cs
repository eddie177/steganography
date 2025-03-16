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
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png",
                Title = "Select a PNG Image"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFile.FileName).ToLower() == ".png")
                {
                    try
                    {
                        originalImage = new Bitmap(openFile.FileName);
                        pictureBox1.Image = originalImage;
                        label2.Text = openFile.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid PNG file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void encodeBtn_Click(object sender, EventArgs e)
        {
            if (originalImage != null && !string.IsNullOrEmpty(txtMessage.Text))
            {
                Bitmap encodedImage = stego.HideMessage(txtMessage.Text, originalImage);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\hidden_image_{timestamp}.png";
                encodedImage.Save(savePath);
                pictureBox1.Image = null;
                originalImage.Dispose(); // Free memory
                originalImage = null;
                label2.Text = "Accepted Format: .png";

                MessageBox.Show($"Message Hidden Successfully!\nFile saved in Desktop as: {Path.GetFileName(savePath)}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                string message = stego.ExtractMessage(originalImage);
                MessageBox.Show("Hidden Message: " + message);

                // Clear the image after showing the message
                pictureBox1.Image = null;
                originalImage.Dispose(); // Free memory
                originalImage = null;
                label2.Text = "Accepted Format: .png";
            }
        }

    }
}
