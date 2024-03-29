﻿
namespace ControlModul.DBControl.SQL
{
    partial class SQLStatuserForm
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
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.labelDatabaseNameTag = new System.Windows.Forms.Label();
            this.processWorkerConnector = new ControlModul.ProcessControl.ProcessWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.Location = new System.Drawing.Point(30, 69);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(11, 13);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "-";
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRepeat.Location = new System.Drawing.Point(392, 12);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(50, 50);
            this.buttonRepeat.TabIndex = 3;
            this.buttonRepeat.Text = "TEST";
            this.buttonRepeat.UseVisualStyleBackColor = false;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackgroundImage = global::ControlModul.Properties.Resources.plug_disconnect_icon;
            this.pictureBoxResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxResult.Location = new System.Drawing.Point(12, 68);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxResult.TabIndex = 1;
            this.pictureBoxResult.TabStop = false;
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Location = new System.Drawing.Point(116, 94);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(10, 13);
            this.labelDatabaseName.TabIndex = 4;
            this.labelDatabaseName.Text = "-";
            // 
            // labelDatabaseNameTag
            // 
            this.labelDatabaseNameTag.AutoSize = true;
            this.labelDatabaseNameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDatabaseNameTag.Location = new System.Drawing.Point(9, 94);
            this.labelDatabaseNameTag.Name = "labelDatabaseNameTag";
            this.labelDatabaseNameTag.Size = new System.Drawing.Size(101, 13);
            this.labelDatabaseNameTag.TabIndex = 5;
            this.labelDatabaseNameTag.Text = "Database Name:";
            // 
            // processWorkerConnector
            // 
            this.processWorkerConnector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processWorkerConnector.CausesValidation = false;
            this.processWorkerConnector.Location = new System.Drawing.Point(12, 12);
            this.processWorkerConnector.Name = "processWorkerConnector";
            this.processWorkerConnector.Size = new System.Drawing.Size(374, 50);
            this.processWorkerConnector.TabIndex = 0;
            this.processWorkerConnector.WorkerName = "Connector";
            // 
            // SQLStatuserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 116);
            this.Controls.Add(this.labelDatabaseNameTag);
            this.Controls.Add(this.labelDatabaseName);
            this.Controls.Add(this.buttonRepeat);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.processWorkerConnector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLStatuserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Connection Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SQLStatuserForm_FormClosing);
            this.Load += new System.EventHandler(this.SQLStatuser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlModul.ProcessControl.ProcessWorker processWorkerConnector;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonRepeat;
        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.Label labelDatabaseNameTag;
    }
}