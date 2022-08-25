
namespace ModuleTester
{
    partial class TesterUI
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
            this.buttonTestFTP = new System.Windows.Forms.Button();
            this.buttonLogViewerTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTestFTP
            // 
            this.buttonTestFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTestFTP.Location = new System.Drawing.Point(12, 12);
            this.buttonTestFTP.Name = "buttonTestFTP";
            this.buttonTestFTP.Size = new System.Drawing.Size(139, 118);
            this.buttonTestFTP.TabIndex = 0;
            this.buttonTestFTP.Text = "FTP Test";
            this.buttonTestFTP.UseVisualStyleBackColor = true;
            this.buttonTestFTP.Click += new System.EventHandler(this.buttonTestFTP_Click);
            // 
            // buttonLogViewerTest
            // 
            this.buttonLogViewerTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogViewerTest.Location = new System.Drawing.Point(168, 12);
            this.buttonLogViewerTest.Name = "buttonLogViewerTest";
            this.buttonLogViewerTest.Size = new System.Drawing.Size(139, 118);
            this.buttonLogViewerTest.TabIndex = 1;
            this.buttonLogViewerTest.Text = "Log Viewer Test";
            this.buttonLogViewerTest.UseVisualStyleBackColor = true;
            this.buttonLogViewerTest.Click += new System.EventHandler(this.buttonLogViewerTest_Click);
            // 
            // TesterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 478);
            this.Controls.Add(this.buttonLogViewerTest);
            this.Controls.Add(this.buttonTestFTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TesterUI";
            this.Text = "TesterUI";
            this.Load += new System.EventHandler(this.TesterUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTestFTP;
        private System.Windows.Forms.Button buttonLogViewerTest;
    }
}