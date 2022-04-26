
namespace ModuleTester
{
    partial class ProccesWorkerTestForm
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
            this.btn_Run = new System.Windows.Forms.Button();
            this.processWorker = new ControlModul.ProcessControl.ProcessWorker();
            this.SuspendLayout();
            // 
            // btn_Run
            // 
            this.btn_Run.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Run.Location = new System.Drawing.Point(0, 72);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(294, 56);
            this.btn_Run.TabIndex = 1;
            this.btn_Run.Text = "RUN";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // processWorker
            // 
            this.processWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processWorker.CausesValidation = false;
            this.processWorker.Location = new System.Drawing.Point(38, 12);
            this.processWorker.Name = "processWorker";
            this.processWorker.Size = new System.Drawing.Size(207, 48);
            this.processWorker.TabIndex = 2;
            this.processWorker.WorkerName = "My worker";
            // 
            // ProccesWorkerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 128);
            this.Controls.Add(this.processWorker);
            this.Controls.Add(this.btn_Run);
            this.Name = "ProccesWorkerTestForm";
            this.Text = "ProccesWorkerTestForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Run;
        private ControlModul.ProcessControl.ProcessWorker processWorker;
    }
}