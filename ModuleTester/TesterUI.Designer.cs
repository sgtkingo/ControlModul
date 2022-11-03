
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
            this.buttonLogerManagerTest = new System.Windows.Forms.Button();
            this.buttonDataViewControlTest = new System.Windows.Forms.Button();
            this.buttonDriverSearchTest = new System.Windows.Forms.Button();
            this.buttonListDriversTest = new System.Windows.Forms.Button();
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
            this.buttonLogViewerTest.Location = new System.Drawing.Point(302, 12);
            this.buttonLogViewerTest.Name = "buttonLogViewerTest";
            this.buttonLogViewerTest.Size = new System.Drawing.Size(139, 118);
            this.buttonLogViewerTest.TabIndex = 1;
            this.buttonLogViewerTest.Text = "Log Viewer Test";
            this.buttonLogViewerTest.UseVisualStyleBackColor = true;
            this.buttonLogViewerTest.Click += new System.EventHandler(this.buttonLogViewerTest_Click);
            // 
            // buttonLogerManagerTest
            // 
            this.buttonLogerManagerTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogerManagerTest.Location = new System.Drawing.Point(157, 12);
            this.buttonLogerManagerTest.Name = "buttonLogerManagerTest";
            this.buttonLogerManagerTest.Size = new System.Drawing.Size(139, 118);
            this.buttonLogerManagerTest.TabIndex = 2;
            this.buttonLogerManagerTest.Text = "LogerManager test";
            this.buttonLogerManagerTest.UseVisualStyleBackColor = true;
            this.buttonLogerManagerTest.Click += new System.EventHandler(this.buttonLogerManagerTest_Click);
            // 
            // buttonDataViewControlTest
            // 
            this.buttonDataViewControlTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDataViewControlTest.Location = new System.Drawing.Point(447, 12);
            this.buttonDataViewControlTest.Name = "buttonDataViewControlTest";
            this.buttonDataViewControlTest.Size = new System.Drawing.Size(139, 118);
            this.buttonDataViewControlTest.TabIndex = 3;
            this.buttonDataViewControlTest.Text = "DataViewControlTest";
            this.buttonDataViewControlTest.UseVisualStyleBackColor = true;
            this.buttonDataViewControlTest.Click += new System.EventHandler(this.buttonDataViewControlTest_Click);
            // 
            // buttonDriverSearchTest
            // 
            this.buttonDriverSearchTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDriverSearchTest.Location = new System.Drawing.Point(157, 136);
            this.buttonDriverSearchTest.Name = "buttonDriverSearchTest";
            this.buttonDriverSearchTest.Size = new System.Drawing.Size(139, 118);
            this.buttonDriverSearchTest.TabIndex = 4;
            this.buttonDriverSearchTest.Text = "Driver Search Test";
            this.buttonDriverSearchTest.UseVisualStyleBackColor = true;
            this.buttonDriverSearchTest.Click += new System.EventHandler(this.buttonDriverSearchTest_Click);
            // 
            // buttonListDriversTest
            // 
            this.buttonListDriversTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonListDriversTest.Location = new System.Drawing.Point(12, 136);
            this.buttonListDriversTest.Name = "buttonListDriversTest";
            this.buttonListDriversTest.Size = new System.Drawing.Size(139, 118);
            this.buttonListDriversTest.TabIndex = 5;
            this.buttonListDriversTest.Text = "List Drivers Test";
            this.buttonListDriversTest.UseVisualStyleBackColor = true;
            this.buttonListDriversTest.Click += new System.EventHandler(this.buttonListDriversTest_Click);
            // 
            // TesterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 478);
            this.Controls.Add(this.buttonListDriversTest);
            this.Controls.Add(this.buttonDriverSearchTest);
            this.Controls.Add(this.buttonDataViewControlTest);
            this.Controls.Add(this.buttonLogerManagerTest);
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
        private System.Windows.Forms.Button buttonLogerManagerTest;
        private System.Windows.Forms.Button buttonDataViewControlTest;
        private System.Windows.Forms.Button buttonDriverSearchTest;
        private System.Windows.Forms.Button buttonListDriversTest;
    }
}