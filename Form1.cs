using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HideInImage
{
    public partial class Form1 : Form
    {

        private HiddenDataController hdc = new HiddenDataController();
        private Bitmap currentImageBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;.*",
                Title = "Choose an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var tempImg = Image.FromFile(openFileDialog.FileName))
                    {
                        currentImageBitmap = new Bitmap(tempImg);
                        imgPreviewBox.Image = new Bitmap(tempImg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while uploading image: {ex.Message}");
                }

                lbl_status.Text = "image uploaded";
                //lbl_infoSpace.Text = EstimateAvailableSpace();
            }
        }

        private string EstimateAvailableSpace()
        {
           return "Max ~" + (currentImageBitmap.Height * currentImageBitmap.Width / 8).ToString() + " Chars"; 
        }

        private void btn_inject_Click(object sender, EventArgs e)
        {
            hdc.InjectDataIntoImage(ConvertStringToBinaryString(textBoxMultiline.Text), currentImageBitmap);
            lbl_status.Text = "Data injected";
            saveImage(currentImageBitmap);
        }

        private void saveImage(Bitmap bitmapToSave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.FileName = "Modified Image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmapToSave.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Image saved!");
            }
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            textBoxMultiline.Text = hdc.ExtractDataFromCurrentImage(currentImageBitmap);
            lbl_status.Text = "Data extracted";
        }

        private string ConvertStringToBinaryString(string input)
        {
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(input);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in utf8Bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
