
namespace ControlModul.ProcessControl
{
    partial class ProcessWorker
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_status = new System.Windows.Forms.Label();
            this.l_workerName = new System.Windows.Forms.Label();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pictureBox_Progress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Progress)).BeginInit();
            this.SuspendLayout();
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(57, 19);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(47, 13);
            this.l_status.TabIndex = 4;
            this.l_status.Text = "READY!";
            // 
            // l_workerName
            // 
            this.l_workerName.AutoSize = true;
            this.l_workerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_workerName.Location = new System.Drawing.Point(54, 0);
            this.l_workerName.Name = "l_workerName";
            this.l_workerName.Size = new System.Drawing.Size(112, 15);
            this.l_workerName.TabIndex = 3;
            this.l_workerName.Text = "Proccess worker";
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // pictureBox_Progress
            // 
            this.pictureBox_Progress.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_Progress.Image = global::ControlModul.Properties.Resources.loading_ready;
            this.pictureBox_Progress.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Progress.Name = "pictureBox_Progress";
            this.pictureBox_Progress.Size = new System.Drawing.Size(48, 50);
            this.pictureBox_Progress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Progress.TabIndex = 0;
            this.pictureBox_Progress.TabStop = false;
            // 
            // ProcessWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CausesValidation = false;
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.l_workerName);
            this.Controls.Add(this.pictureBox_Progress);
            this.Name = "ProcessWorker";
            this.Size = new System.Drawing.Size(170, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Progress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Progress;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Label l_workerName;
        public System.ComponentModel.BackgroundWorker BackgroundWorker;
    }
}
