namespace HideInImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_upload = new Button();
            btn_inject = new Button();
            btn_extract = new Button();
            lbl_status = new Label();
            textBoxMultiline = new TextBox();
            imgPreviewBox = new PictureBox();
            lbl_infoSpace = new Label();
            radioHideText = new RadioButton();
            radioHideFile = new RadioButton();
            checkBoxFileExtract = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)imgPreviewBox).BeginInit();
            SuspendLayout();
            // 
            // btn_upload
            // 
            btn_upload.Location = new Point(12, 38);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(121, 45);
            btn_upload.TabIndex = 0;
            btn_upload.Text = "Select Image";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // btn_inject
            // 
            btn_inject.Enabled = false;
            btn_inject.Location = new Point(12, 139);
            btn_inject.Name = "btn_inject";
            btn_inject.Size = new Size(121, 45);
            btn_inject.TabIndex = 1;
            btn_inject.Text = "Inject Text";
            btn_inject.UseVisualStyleBackColor = true;
            btn_inject.Click += btn_inject_Click;
            // 
            // btn_extract
            // 
            btn_extract.Enabled = false;
            btn_extract.Location = new Point(12, 190);
            btn_extract.Name = "btn_extract";
            btn_extract.Size = new Size(121, 45);
            btn_extract.TabIndex = 2;
            btn_extract.Text = "Extract";
            btn_extract.UseVisualStyleBackColor = true;
            btn_extract.Click += btn_extract_Click;
            // 
            // lbl_status
            // 
            lbl_status.AutoSize = true;
            lbl_status.Location = new Point(12, 9);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(112, 15);
            lbl_status.TabIndex = 3;
            lbl_status.Text = "No image uploaded";
            // 
            // textBoxMultiline
            // 
            textBoxMultiline.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxMultiline.Location = new Point(686, 12);
            textBoxMultiline.MaxLength = 0;
            textBoxMultiline.Multiline = true;
            textBoxMultiline.Name = "textBoxMultiline";
            textBoxMultiline.ScrollBars = ScrollBars.Vertical;
            textBoxMultiline.Size = new Size(594, 505);
            textBoxMultiline.TabIndex = 4;
            // 
            // imgPreviewBox
            // 
            imgPreviewBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imgPreviewBox.BorderStyle = BorderStyle.FixedSingle;
            imgPreviewBox.Location = new Point(139, 12);
            imgPreviewBox.Name = "imgPreviewBox";
            imgPreviewBox.Size = new Size(537, 505);
            imgPreviewBox.SizeMode = PictureBoxSizeMode.Zoom;
            imgPreviewBox.TabIndex = 5;
            imgPreviewBox.TabStop = false;
            // 
            // lbl_infoSpace
            // 
            lbl_infoSpace.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_infoSpace.AutoSize = true;
            lbl_infoSpace.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_infoSpace.Location = new Point(12, 483);
            lbl_infoSpace.Name = "lbl_infoSpace";
            lbl_infoSpace.Size = new Size(100, 13);
            lbl_infoSpace.TabIndex = 6;
            lbl_infoSpace.Text = "Max hiding space:";
            // 
            // radioHideText
            // 
            radioHideText.AutoSize = true;
            radioHideText.Checked = true;
            radioHideText.Enabled = false;
            radioHideText.Location = new Point(38, 89);
            radioHideText.Name = "radioHideText";
            radioHideText.Size = new Size(74, 19);
            radioHideText.TabIndex = 7;
            radioHideText.TabStop = true;
            radioHideText.Text = "Hide Text";
            radioHideText.UseVisualStyleBackColor = true;
            radioHideText.CheckedChanged += radioHideText_CheckedChanged;
            // 
            // radioHideFile
            // 
            radioHideFile.AutoSize = true;
            radioHideFile.Enabled = false;
            radioHideFile.Location = new Point(38, 114);
            radioHideFile.Name = "radioHideFile";
            radioHideFile.Size = new Size(71, 19);
            radioHideFile.TabIndex = 8;
            radioHideFile.Text = "Hide File";
            radioHideFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileExtract
            // 
            checkBoxFileExtract.AutoSize = true;
            checkBoxFileExtract.Enabled = false;
            checkBoxFileExtract.Location = new Point(29, 241);
            checkBoxFileExtract.Name = "checkBoxFileExtract";
            checkBoxFileExtract.Size = new Size(83, 19);
            checkBoxFileExtract.TabIndex = 9;
            checkBoxFileExtract.Text = "Extract File";
            checkBoxFileExtract.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 529);
            Controls.Add(checkBoxFileExtract);
            Controls.Add(radioHideFile);
            Controls.Add(radioHideText);
            Controls.Add(lbl_infoSpace);
            Controls.Add(imgPreviewBox);
            Controls.Add(textBoxMultiline);
            Controls.Add(lbl_status);
            Controls.Add(btn_extract);
            Controls.Add(btn_inject);
            Controls.Add(btn_upload);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Hide In Image";
            ((System.ComponentModel.ISupportInitialize)imgPreviewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_upload;
        private Button btn_inject;
        private Button btn_extract;
        private Label lbl_status;
        private TextBox textBoxMultiline;
        private PictureBox imgPreviewBox;
        private Label lbl_infoSpace;
        private RadioButton radioHideText;
        private RadioButton radioHideFile;
        private CheckBox checkBoxFileExtract;
    }
}
