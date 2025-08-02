using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HideInImage
{
    public partial class Form1 : Form
    {

        private HiddenDataController hdc = new HiddenDataController();
        private BinaryHandler bc = new BinaryHandler();
        private Bitmap currentImageBitmap;
        private BitArray currentFileInBits;
        private int maxBytes = 0;
        private bool fileMode = false;

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
                    textBoxMultiline.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while selecting image: {ex.Message}");
                    return;
                }

                if (hdc.CurrentImageHasWatermark(currentImageBitmap))
                {
                    btn_extract.Enabled = true;
                    checkBoxFileExtract.Enabled = true;
                    btn_inject.Enabled = false;
                    radioHideFile.Enabled = false;
                    radioHideText.Enabled = false;
                    lbl_infoSpace.Text = "Max hiding space: \nAlready injected";
                }
                else
                {
                    btn_extract.Enabled = false;
                    checkBoxFileExtract.Enabled = false;
                    radioHideFile.Enabled = true;
                    radioHideText.Enabled = true;
                    btn_inject.Enabled = true;
                    lbl_infoSpace.Text = EstimateAvailableSpace();
                }
                lbl_status.Text = "Image selected";
            }
        }

        private string EstimateAvailableSpace()
        {
            maxBytes = ((currentImageBitmap.Height * currentImageBitmap.Width * 3) - 3) / 8;

            return "Max hiding space: \n~" + (maxBytes / 1024) + " KB";
        }

        private void btn_inject_Click(object sender, EventArgs e)
        {
            if (currentImageBitmap == null)
            {
                MessageBox.Show("Select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!fileMode)
            {
                if (Encoding.UTF8.GetBytes(textBoxMultiline.Text).Length >= (maxBytes - 1))
                {
                    MessageBox.Show("Provided text is too long!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hdc.InjectDataIntoImage(bc.ConvertStringToBitArray(textBoxMultiline.Text), currentImageBitmap);
                lbl_status.Text = "Data injected";

                if (SaveImage(currentImageBitmap))
                {
                    radioHideFile.Enabled = false;
                    radioHideText.Enabled = false;
                    btn_inject.Enabled = false;
                    btn_extract.Enabled = true;
                    lbl_infoSpace.Text = "Max hiding space: \nAlready injected";
                }
            }
            else if (currentFileInBits != null)
            {
                hdc.InjectDataIntoImage(currentFileInBits, currentImageBitmap);

                if (SaveImage(currentImageBitmap))
                {
                    radioHideFile.Enabled = false;
                    radioHideText.Enabled = false;
                    btn_inject.Enabled = false;
                    btn_extract.Enabled = true;
                    lbl_infoSpace.Text = "Max hiding space: \nAlready injected";
                }
            }
            else
            {
                UploadFileToHide();
            }
        }

        private bool SaveImage(Bitmap bitmapToSave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image|*png;*.jpg;*.jpeg";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.FileName = "Modified Image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmapToSave.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Image saved!", "Success!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            if (currentImageBitmap == null)
            {
                MessageBox.Show("Upload an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!checkBoxFileExtract.Checked)
            {
                textBoxMultiline.Text = bc.ConvertBitArrayToString(hdc.ExtractDataFromCurrentImage(currentImageBitmap));
                lbl_status.Text = "Data extracted";
            }
            else
            {
                BitArray retrievedFileInBits = hdc.ExtractDataFromCurrentImage(currentImageBitmap);

                byte[] retrievedFileInBytes = new byte[(retrievedFileInBits.Length + 7) / 8];
                retrievedFileInBits.CopyTo(retrievedFileInBytes, 0);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save File";
                saveDialog.Filter = "All Files|*.*";
                saveDialog.FileName = "retrievedFile";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDialog.FileName, retrievedFileInBytes);
                    MessageBox.Show("Retrieved file saved.", "Success!");
                    lbl_status.Text = "Data extracted";
                }
            }            
        }

        private void UploadFileToHide()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All files|*.*",
                Title = "Choose an File smaller than " + (maxBytes / 1024).ToString() + " KB"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                    if (fileInfo.Length >= maxBytes)
                    {
                        MessageBox.Show("File is too big! \nChoose a file smaller than " + (maxBytes / 1024).ToString() + " KB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string filePath = openFileDialog.FileName;

                        using var fileStream = File.OpenRead(filePath);
                        using var memoryStream = new MemoryStream();

                        fileStream.CopyTo(memoryStream);
                        BitArray fileInBits = new BitArray(memoryStream.ToArray());

                        currentFileInBits = fileInBits;
                        btn_inject.Text = "Inject File";
                        //lbl_status.Text = fileInfo.Name;
                        lbl_status.Text = "Payload Selected";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while uploading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioHideText_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHideText.Checked)
            {
                fileMode = false;
                textBoxMultiline.Enabled = true;
                btn_inject.Text = "Inject Text";
            }
            else
            {
                fileMode = true;
                textBoxMultiline.Enabled = false;
                btn_inject.Text = "Upload File to hide";
            }
        }
    }
}
