
namespace ModuleTester
{
    partial class dgvControlTest
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
            this.dataGridViewerControl1 = new ControlModul.ProcessControl.DataGridViewerControl();
            this.SuspendLayout();
            // 
            // dataGridViewerControl1
            // 
            this.dataGridViewerControl1.AllowDelete = true;
            this.dataGridViewerControl1.AllowManualSourceSelect = false;
            this.dataGridViewerControl1.AllowModify = true;
            this.dataGridViewerControl1.AllowNew = true;
            this.dataGridViewerControl1.AllowOpen = false;
            this.dataGridViewerControl1.AllowPreview = true;
            this.dataGridViewerControl1.DataSource = null;
            this.dataGridViewerControl1.HidenCollums = new string[] {
        "ID"};
            this.dataGridViewerControl1.Location = new System.Drawing.Point(14, 12);
            this.dataGridViewerControl1.Name = "dataGridViewerControl1";
            this.dataGridViewerControl1.Size = new System.Drawing.Size(800, 480);
            this.dataGridViewerControl1.TabIndex = 0;
            // 
            // dgvControlTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 496);
            this.Controls.Add(this.dataGridViewerControl1);
            this.Name = "dgvControlTest";
            this.Text = "dgvControlTest";
            this.Load += new System.EventHandler(this.dgvControlTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlModul.ProcessControl.DataGridViewerControl dataGridViewerControl1;
    }
}