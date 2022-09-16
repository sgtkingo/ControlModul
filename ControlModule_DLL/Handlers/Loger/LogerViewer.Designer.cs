
namespace ControlModul.Handlers.Loger
{
    partial class LogerViewer
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
            this.checkedListBoxReports = new System.Windows.Forms.CheckedListBox();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.groupBboxTools = new System.Windows.Forms.GroupBox();
            this.buttonExBackup = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkBoxInfo = new System.Windows.Forms.CheckBox();
            this.checkBoxWarnings = new System.Windows.Forms.CheckBox();
            this.checkBoxErrors = new System.Windows.Forms.CheckBox();
            this.checkBoxExceptions = new System.Windows.Forms.CheckBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBboxTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxReports
            // 
            this.checkedListBoxReports.FormattingEnabled = true;
            this.checkedListBoxReports.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxReports.Name = "checkedListBoxReports";
            this.checkedListBoxReports.Size = new System.Drawing.Size(177, 484);
            this.checkedListBoxReports.Sorted = true;
            this.checkedListBoxReports.TabIndex = 0;
            this.checkedListBoxReports.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxReports_SelectedIndexChanged);
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Location = new System.Drawing.Point(195, 12);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.ReadOnly = true;
            this.richTextBoxReport.Size = new System.Drawing.Size(597, 514);
            this.richTextBoxReport.TabIndex = 3;
            this.richTextBoxReport.Text = "";
            // 
            // groupBboxTools
            // 
            this.groupBboxTools.Controls.Add(this.buttonExBackup);
            this.groupBboxTools.Controls.Add(this.buttonSearch);
            this.groupBboxTools.Controls.Add(this.checkBoxInfo);
            this.groupBboxTools.Controls.Add(this.checkBoxWarnings);
            this.groupBboxTools.Controls.Add(this.checkBoxErrors);
            this.groupBboxTools.Controls.Add(this.checkBoxExceptions);
            this.groupBboxTools.Controls.Add(this.labelSearch);
            this.groupBboxTools.Controls.Add(this.textBoxSearch);
            this.groupBboxTools.Controls.Add(this.buttonBackUp);
            this.groupBboxTools.Controls.Add(this.buttonDelete);
            this.groupBboxTools.Location = new System.Drawing.Point(12, 532);
            this.groupBboxTools.Name = "groupBboxTools";
            this.groupBboxTools.Size = new System.Drawing.Size(780, 85);
            this.groupBboxTools.TabIndex = 2;
            this.groupBboxTools.TabStop = false;
            this.groupBboxTools.Text = "Tools";
            // 
            // buttonExBackup
            // 
            this.buttonExBackup.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonExBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExBackup.Location = new System.Drawing.Point(76, 46);
            this.buttonExBackup.Name = "buttonExBackup";
            this.buttonExBackup.Size = new System.Drawing.Size(100, 30);
            this.buttonExBackup.TabIndex = 10;
            this.buttonExBackup.Text = "EX BACKUP";
            this.buttonExBackup.UseVisualStyleBackColor = false;
            this.buttonExBackup.Click += new System.EventHandler(this.buttonExBackup_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(685, 17);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(89, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "GO";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // checkBoxInfo
            // 
            this.checkBoxInfo.AutoSize = true;
            this.checkBoxInfo.Checked = true;
            this.checkBoxInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInfo.Location = new System.Drawing.Point(470, 45);
            this.checkBoxInfo.Name = "checkBoxInfo";
            this.checkBoxInfo.Size = new System.Drawing.Size(44, 17);
            this.checkBoxInfo.TabIndex = 7;
            this.checkBoxInfo.Text = "Info";
            this.checkBoxInfo.UseVisualStyleBackColor = true;
            // 
            // checkBoxWarnings
            // 
            this.checkBoxWarnings.AutoSize = true;
            this.checkBoxWarnings.Checked = true;
            this.checkBoxWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWarnings.Location = new System.Drawing.Point(393, 45);
            this.checkBoxWarnings.Name = "checkBoxWarnings";
            this.checkBoxWarnings.Size = new System.Drawing.Size(71, 17);
            this.checkBoxWarnings.TabIndex = 6;
            this.checkBoxWarnings.Text = "Warnings";
            this.checkBoxWarnings.UseVisualStyleBackColor = true;
            // 
            // checkBoxErrors
            // 
            this.checkBoxErrors.AutoSize = true;
            this.checkBoxErrors.Checked = true;
            this.checkBoxErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxErrors.Location = new System.Drawing.Point(334, 45);
            this.checkBoxErrors.Name = "checkBoxErrors";
            this.checkBoxErrors.Size = new System.Drawing.Size(53, 17);
            this.checkBoxErrors.TabIndex = 5;
            this.checkBoxErrors.Text = "Errors";
            this.checkBoxErrors.UseVisualStyleBackColor = true;
            // 
            // checkBoxExceptions
            // 
            this.checkBoxExceptions.AutoSize = true;
            this.checkBoxExceptions.Checked = true;
            this.checkBoxExceptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExceptions.Location = new System.Drawing.Point(247, 45);
            this.checkBoxExceptions.Name = "checkBoxExceptions";
            this.checkBoxExceptions.Size = new System.Drawing.Size(81, 17);
            this.checkBoxExceptions.TabIndex = 4;
            this.checkBoxExceptions.Text = "Exceptions ";
            this.checkBoxExceptions.UseVisualStyleBackColor = true;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(197, 22);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(44, 13);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Search:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(247, 19);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(432, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonBackUp
            // 
            this.buttonBackUp.BackColor = System.Drawing.Color.Aqua;
            this.buttonBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackUp.Location = new System.Drawing.Point(76, 15);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(100, 30);
            this.buttonBackUp.TabIndex = 9;
            this.buttonBackUp.Text = "BACKUP";
            this.buttonBackUp.UseVisualStyleBackColor = false;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDelete.Location = new System.Drawing.Point(6, 15);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(64, 64);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(109, 502);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(78, 17);
            this.checkBoxAll.TabIndex = 10;
            this.checkBoxAll.Text = "Select ALL";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRefresh.Location = new System.Drawing.Point(12, 502);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(81, 23);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "REFRESH";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // LogerViewer
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 621);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.groupBboxTools);
            this.Controls.Add(this.richTextBoxReport);
            this.Controls.Add(this.checkedListBoxReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LogerViewer";
            this.Text = "Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogerViewer_FormClosing);
            this.Load += new System.EventHandler(this.LogerViewer_Load);
            this.groupBboxTools.ResumeLayout(false);
            this.groupBboxTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxReports;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.GroupBox groupBboxTools;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxInfo;
        private System.Windows.Forms.CheckBox checkBoxWarnings;
        private System.Windows.Forms.CheckBox checkBoxErrors;
        private System.Windows.Forms.CheckBox checkBoxExceptions;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExBackup;
    }
}