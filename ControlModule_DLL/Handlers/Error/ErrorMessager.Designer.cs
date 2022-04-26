
namespace ControlModul.Handlers.Error
{
    partial class ErrorMessager
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
            this.propertyGrid_Error = new System.Windows.Forms.PropertyGrid();
            this.rtxt_ErrorDescription = new System.Windows.Forms.RichTextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.l_ErrorDescription = new System.Windows.Forms.Label();
            this.pictureBox_error = new System.Windows.Forms.PictureBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_error)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGrid_Error
            // 
            this.propertyGrid_Error.Location = new System.Drawing.Point(0, 99);
            this.propertyGrid_Error.Name = "propertyGrid_Error";
            this.propertyGrid_Error.Size = new System.Drawing.Size(465, 232);
            this.propertyGrid_Error.TabIndex = 0;
            // 
            // rtxt_ErrorDescription
            // 
            this.rtxt_ErrorDescription.Location = new System.Drawing.Point(12, 33);
            this.rtxt_ErrorDescription.Name = "rtxt_ErrorDescription";
            this.rtxt_ErrorDescription.ReadOnly = true;
            this.rtxt_ErrorDescription.Size = new System.Drawing.Size(371, 60);
            this.rtxt_ErrorDescription.TabIndex = 1;
            this.rtxt_ErrorDescription.Text = "";
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OK.Location = new System.Drawing.Point(264, 337);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(188, 47);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // l_ErrorDescription
            // 
            this.l_ErrorDescription.AutoSize = true;
            this.l_ErrorDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_ErrorDescription.Location = new System.Drawing.Point(13, 14);
            this.l_ErrorDescription.Name = "l_ErrorDescription";
            this.l_ErrorDescription.Size = new System.Drawing.Size(86, 13);
            this.l_ErrorDescription.TabIndex = 5;
            this.l_ErrorDescription.Text = "Error description:";
            // 
            // pictureBox_error
            // 
            this.pictureBox_error.Image = global::ControlModul.Properties.Resources.errorIcon;
            this.pictureBox_error.Location = new System.Drawing.Point(390, 33);
            this.pictureBox_error.Name = "pictureBox_error";
            this.pictureBox_error.Size = new System.Drawing.Size(62, 62);
            this.pictureBox_error.TabIndex = 6;
            this.pictureBox_error.TabStop = false;
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Send.Image = global::ControlModul.Properties.Resources.mail_send_icon;
            this.btn_Send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Send.Location = new System.Drawing.Point(103, 354);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Copy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Copy.Image = global::ControlModul.Properties.Resources.document_copy_icon;
            this.btn_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Copy.Location = new System.Drawing.Point(12, 354);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.btn_Copy.TabIndex = 2;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // ErrorMessager
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 388);
            this.Controls.Add(this.pictureBox_error);
            this.Controls.Add(this.l_ErrorDescription);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.rtxt_ErrorDescription);
            this.Controls.Add(this.propertyGrid_Error);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Messager";
            this.Load += new System.EventHandler(this.ErrorMessager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid_Error;
        private System.Windows.Forms.RichTextBox rtxt_ErrorDescription;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label l_ErrorDescription;
        private System.Windows.Forms.PictureBox pictureBox_error;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}