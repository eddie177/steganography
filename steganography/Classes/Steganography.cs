using System.Text;

namespace steganography.Classes
{
    public class Steganography
    {
        // Hide Text in Image
        public Bitmap HideMessage(string message, Bitmap image)
        {
            int charIndex = 0;
            int pixelIndex = 0;
            string binaryMessage = ToBinaryString(message) + "00000000"; // Adding null terminator to mark the end of the message.

            for (int i = 0; i < image.Height && pixelIndex < binaryMessage.Length; i++)
            {
                for (int j = 0; j < image.Width && pixelIndex < binaryMessage.Length; j++)
                {
                    Color pixel = image.GetPixel(j, i);
                    int R = pixel.R;
                    int G = pixel.G;
                    int B = pixel.B;

                    // Embed 2 bits in R
                    if (pixelIndex < binaryMessage.Length)
                    {
                        R = (R & 0xFC) | int.Parse(binaryMessage.Substring(pixelIndex, 2), System.Globalization.NumberStyles.BinaryNumber);
                        pixelIndex += 2;
                    }

                    // Embed 2 bits in G
                    if (pixelIndex < binaryMessage.Length)
                    {
                        G = (G & 0xFC) | int.Parse(binaryMessage.Substring(pixelIndex, 2), System.Globalization.NumberStyles.BinaryNumber);
                        pixelIndex += 2;
                    }

                    // Embed 2 bits in B
                    if (pixelIndex < binaryMessage.Length)
                    {
                        B = (B & 0xFC) | int.Parse(binaryMessage.Substring(pixelIndex, 2), System.Globalization.NumberStyles.BinaryNumber);
                        pixelIndex += 2;
                    }

                    image.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }

            return image;
        }

        // Extract Text from Image
        public string ExtractMessage(Bitmap image)
        {
            StringBuilder binaryMessage = new StringBuilder();

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixel = image.GetPixel(j, i);
                    int R = pixel.R & 0x03; // Extract 2 bits from R
                    int G = pixel.G & 0x03; // Extract 2 bits from G
                    int B = pixel.B & 0x03; // Extract 2 bits from B

                    binaryMessage.Append(Convert.ToString(R, 2).PadLeft(2, '0'));
                    binaryMessage.Append(Convert.ToString(G, 2).PadLeft(2, '0'));
                    binaryMessage.Append(Convert.ToString(B, 2).PadLeft(2, '0'));
                }
            }

            // Convert binary string to text
            string binaryString = binaryMessage.ToString();
            StringBuilder message = new StringBuilder();

            for (int k = 0; k < binaryString.Length - 7; k += 8)
            {
                string byteString = binaryString.Substring(k, 8);
                if (byteString == "00000000") // Null terminator
                    break;
                message.Append((char)Convert.ToInt32(byteString, 2));
            }

            return message.ToString();
        }

        // convert string to binary
        private string ToBinaryString(string message)
        {
            StringBuilder binary = new StringBuilder();
            foreach (char c in message)
            {
                binary.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return binary.ToString();
        }
    }
}