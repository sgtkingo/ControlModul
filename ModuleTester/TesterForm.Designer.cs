
namespace ModuleTester
{
    partial class TesterForm
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_TestAll = new System.Windows.Forms.Button();
            this.btn_TestSQLConnector = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_TestProcessWorker = new System.Windows.Forms.Button();
            this.btn_TestErrorLog = new System.Windows.Forms.Button();
            this.btn_TestLogger = new System.Windows.Forms.Button();
            this.btn_TestSQLStatuser = new System.Windows.Forms.Button();
            this.btn_TestReporter = new System.Windows.Forms.Button();
            this.buttonTestCrypto = new System.Windows.Forms.Button();
            this.buttonTestLogerManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TestAll
            // 
            this.btn_TestAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestAll.Location = new System.Drawing.Point(13, 13);
            this.btn_TestAll.Name = "btn_TestAll";
            this.btn_TestAll.Size = new System.Drawing.Size(206, 96);
            this.btn_TestAll.TabIndex = 0;
            this.btn_TestAll.Text = "TEST ALL";
            this.btn_TestAll.UseVisualStyleBackColor = true;
            this.btn_TestAll.Click += new System.EventHandler(this.btn_TestAll_Click);
            // 
            // btn_TestSQLConnector
            // 
            this.btn_TestSQLConnector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestSQLConnector.Location = new System.Drawing.Point(284, 12);
            this.btn_TestSQLConnector.Name = "btn_TestSQLConnector";
            this.btn_TestSQLConnector.Size = new System.Drawing.Size(206, 96);
            this.btn_TestSQLConnector.TabIndex = 1;
            this.btn_TestSQLConnector.Text = "TEST SQL CONNECTOR";
            this.btn_TestSQLConnector.UseVisualStyleBackColor = true;
            this.btn_TestSQLConnector.Click += new System.EventHandler(this.btn_TestSQLConnector_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Text|*.txt|Všechny soubory|*.*";
            this.openFileDialog.Title = "Select file";
            // 
            // button_TestProcessWorker
            // 
            this.button_TestProcessWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_TestProcessWorker.Location = new System.Drawing.Point(568, 177);
            this.button_TestProcessWorker.Name = "button_TestProcessWorker";
            this.button_TestProcessWorker.Size = new System.Drawing.Size(206, 96);
            this.button_TestProcessWorker.TabIndex = 2;
            this.button_TestProcessWorker.Text = "TEST PROCESS WORKER";
            this.button_TestProcessWorker.UseVisualStyleBackColor = true;
            this.button_TestProcessWorker.Click += new System.EventHandler(this.button_TestProcessWorker_Click);
            // 
            // btn_TestErrorLog
            // 
            this.btn_TestErrorLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestErrorLog.Location = new System.Drawing.Point(568, 328);
            this.btn_TestErrorLog.Name = "btn_TestErrorLog";
            this.btn_TestErrorLog.Size = new System.Drawing.Size(206, 96);
            this.btn_TestErrorLog.TabIndex = 3;
            this.btn_TestErrorLog.Text = "TEST ERROR LOG";
            this.btn_TestErrorLog.UseVisualStyleBackColor = true;
            this.btn_TestErrorLog.Click += new System.EventHandler(this.btn_TestErrorLog_Click);
            // 
            // btn_TestLogger
            // 
            this.btn_TestLogger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestLogger.Location = new System.Drawing.Point(13, 177);
            this.btn_TestLogger.Name = "btn_TestLogger";
            this.btn_TestLogger.Size = new System.Drawing.Size(206, 96);
            this.btn_TestLogger.TabIndex = 4;
            this.btn_TestLogger.Text = "TEST LOGGER";
            this.btn_TestLogger.UseVisualStyleBackColor = true;
            this.btn_TestLogger.Click += new System.EventHandler(this.btn_TestLogger_Click);
            // 
            // btn_TestSQLStatuser
            // 
            this.btn_TestSQLStatuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestSQLStatuser.Location = new System.Drawing.Point(568, 13);
            this.btn_TestSQLStatuser.Name = "btn_TestSQLStatuser";
            this.btn_TestSQLStatuser.Size = new System.Drawing.Size(206, 96);
            this.btn_TestSQLStatuser.TabIndex = 5;
            this.btn_TestSQLStatuser.Text = "TEST SQL STATUSER";
            this.btn_TestSQLStatuser.UseVisualStyleBackColor = true;
            this.btn_TestSQLStatuser.Click += new System.EventHandler(this.btn_TestSQLStatuser_Click);
            // 
            // btn_TestReporter
            // 
            this.btn_TestReporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_TestReporter.Location = new System.Drawing.Point(13, 328);
            this.btn_TestReporter.Name = "btn_TestReporter";
            this.btn_TestReporter.Size = new System.Drawing.Size(206, 96);
            this.btn_TestReporter.TabIndex = 6;
            this.btn_TestReporter.Text = "TEST REPORTER";
            this.btn_TestReporter.UseVisualStyleBackColor = true;
            this.btn_TestReporter.Click += new System.EventHandler(this.btn_TestReporter_Click);
            // 
            // buttonTestCrypto
            // 
            this.buttonTestCrypto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTestCrypto.Location = new System.Drawing.Point(284, 328);
            this.buttonTestCrypto.Name = "buttonTestCrypto";
            this.buttonTestCrypto.Size = new System.Drawing.Size(206, 96);
            this.buttonTestCrypto.TabIndex = 7;
            this.buttonTestCrypto.Text = "TEST CRYPTO";
            this.buttonTestCrypto.UseVisualStyleBackColor = true;
            this.buttonTestCrypto.Click += new System.EventHandler(this.buttonTestCrypto_Click);
            // 
            // buttonTestLogerManager
            // 
            this.buttonTestLogerManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTestLogerManager.Location = new System.Drawing.Point(284, 177);
            this.buttonTestLogerManager.Name = "buttonTestLogerManager";
            this.buttonTestLogerManager.Size = new System.Drawing.Size(206, 96);
            this.buttonTestLogerManager.TabIndex = 8;
            this.buttonTestLogerManager.Text = "TEST LOGGER MNG";
            this.buttonTestLogerManager.UseVisualStyleBackColor = true;
            this.buttonTestLogerManager.Click += new System.EventHandler(this.btn_TestLogerManager_Click);
            // 
            // TesterForm
            // 
            this.AcceptButton = this.btn_TestAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTestLogerManager);
            this.Controls.Add(this.buttonTestCrypto);
            this.Controls.Add(this.btn_TestReporter);
            this.Controls.Add(this.btn_TestSQLStatuser);
            this.Controls.Add(this.btn_TestLogger);
            this.Controls.Add(this.btn_TestErrorLog);
            this.Controls.Add(this.button_TestProcessWorker);
            this.Controls.Add(this.btn_TestSQLConnector);
            this.Controls.Add(this.btn_TestAll);
            this.Name = "TesterForm";
            this.Text = "Tester ";
            this.Load += new System.EventHandler(this.TesterForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TestAll;
        private System.Windows.Forms.Button btn_TestSQLConnector;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_TestProcessWorker;
        private System.Windows.Forms.Button btn_TestErrorLog;
        private System.Windows.Forms.Button btn_TestLogger;
        private System.Windows.Forms.Button btn_TestSQLStatuser;
        private System.Windows.Forms.Button btn_TestReporter;
        private System.Windows.Forms.Button buttonTestCrypto;
        private System.Windows.Forms.Button buttonTestLogerManager;
    }
}

