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
            ((System.ComponentModel.ISupportInitialize)imgPreviewBox).BeginInit();
            SuspendLayout();
            // 
            // btn_upload
            // 
            btn_upload.Location = new Point(12, 134);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(121, 44);
            btn_upload.TabIndex = 0;
            btn_upload.Text = "Upload Image";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // btn_inject
            // 
            btn_inject.Location = new Point(12, 36);
            btn_inject.Name = "btn_inject";
            btn_inject.Size = new Size(121, 41);
            btn_inject.TabIndex = 1;
            btn_inject.Text = "Inject";
            btn_inject.UseVisualStyleBackColor = true;
            btn_inject.Click += btn_inject_Click;
            // 
            // btn_extract
            // 
            btn_extract.Location = new Point(12, 83);
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
            textBoxMultiline.Location = new Point(591, 12);
            textBoxMultiline.MaxLength = 0;
            textBoxMultiline.Multiline = true;
            textBoxMultiline.Name = "textBoxMultiline";
            textBoxMultiline.ScrollBars = ScrollBars.Vertical;
            textBoxMultiline.Size = new Size(594, 374);
            textBoxMultiline.TabIndex = 4;
            // 
            // imgPreviewBox
            // 
            imgPreviewBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imgPreviewBox.BorderStyle = BorderStyle.FixedSingle;
            imgPreviewBox.Location = new Point(139, 12);
            imgPreviewBox.Name = "imgPreviewBox";
            imgPreviewBox.Size = new Size(442, 374);
            imgPreviewBox.SizeMode = PictureBoxSizeMode.Zoom;
            imgPreviewBox.TabIndex = 5;
            imgPreviewBox.TabStop = false;
            // 
            // lbl_infoSpace
            // 
            lbl_infoSpace.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_infoSpace.AutoSize = true;
            lbl_infoSpace.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_infoSpace.Location = new Point(12, 352);
            lbl_infoSpace.Name = "lbl_infoSpace";
            lbl_infoSpace.Size = new Size(100, 13);
            lbl_infoSpace.TabIndex = 6;
            lbl_infoSpace.Text = "Max hiding space:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 398);
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
    }
}
