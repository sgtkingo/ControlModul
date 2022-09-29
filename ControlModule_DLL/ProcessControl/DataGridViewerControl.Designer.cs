
namespace ControlModul.ProcessControl
{
    partial class DataGridViewerControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridViewerControl));
            this.dataGridViewObjects = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource_Data = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorEditItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_Search = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel_Search = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openSourceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowPrewiev = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemColumnsStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processWorker = new ControlModul.ProcessControl.ProcessWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Data)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewObjects
            // 
            this.dataGridViewObjects.AllowUserToAddRows = false;
            this.dataGridViewObjects.AllowUserToOrderColumns = true;
            this.dataGridViewObjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewObjects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.helpProvider.SetHelpKeyword(this.dataGridViewObjects, "dataGridView");
            this.helpProvider.SetHelpNavigator(this.dataGridViewObjects, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.dataGridViewObjects, "Records show here");
            this.dataGridViewObjects.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewObjects.MultiSelect = false;
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridViewObjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.helpProvider.SetShowHelp(this.dataGridViewObjects, true);
            this.dataGridViewObjects.Size = new System.Drawing.Size(800, 396);
            this.dataGridViewObjects.TabIndex = 0;
            this.dataGridViewObjects.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_OpenItemEvent);
            this.dataGridViewObjects.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRowEvent);
            // 
            // propertyGrid
            // 
            this.helpProvider.SetHelpKeyword(this.propertyGrid, "propertyGrid");
            this.helpProvider.SetHelpNavigator(this.propertyGrid, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.propertyGrid, "Selected record properities ");
            this.propertyGrid.Location = new System.Drawing.Point(457, 28);
            this.propertyGrid.Name = "propertyGrid";
            this.helpProvider.SetShowHelp(this.propertyGrid, true);
            this.propertyGrid.Size = new System.Drawing.Size(343, 396);
            this.propertyGrid.TabIndex = 4;
            this.toolTip.SetToolTip(this.propertyGrid, "Object properities");
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.bindingSource_Data;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.helpProvider.SetHelpKeyword(this.bindingNavigator, "navigatorToolbar");
            this.helpProvider.SetHelpNavigator(this.bindingNavigator, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.bindingNavigator, "Navigator controls and tools");
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorEditItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripTextBox_Search,
            this.toolStripLabel_Search,
            this.toolStripSeparator3,
            this.refreshToolStripButton,
            this.openSourceToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.helpProvider.SetShowHelp(this.bindingNavigator, true);
            this.bindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.bindingNavigator.TabIndex = 1;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "&Přidat nový";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.OpenCurrentItem_Event);
            // 
            // bindingSource_Data
            // 
            this.bindingSource_Data.AllowNew = true;
            this.bindingSource_Data.DataSourceChanged += new System.EventHandler(this.bindingSource_Data_DataSourceChanged);
            this.bindingSource_Data.CurrentChanged += new System.EventHandler(this.bindingSource_Data_CurrentChanged);
            this.bindingSource_Data.CurrentItemChanged += new System.EventHandler(this.bindingSource_Data_CurrentItemChanged);
            this.bindingSource_Data.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_Data_ListChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Celkový počet položek";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Přesunout na první";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Přesunout na předchozí";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Umístění";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuální pozice";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Přesunout na další";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Přesunout na poslední";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorEditItem
            // 
            this.bindingNavigatorEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorEditItem.Image = global::ControlModul.Properties.Resources.edit;
            this.bindingNavigatorEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorEditItem.Name = "bindingNavigatorEditItem";
            this.bindingNavigatorEditItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorEditItem.Text = "&Upravit";
            this.bindingNavigatorEditItem.Click += new System.EventHandler(this.OpenCurrentItem_Event);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "&Odstranit";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.DeleteCurrent_Event);
            // 
            // toolStripTextBox_Search
            // 
            this.toolStripTextBox_Search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_Search.Name = "toolStripTextBox_Search";
            this.toolStripTextBox_Search.Size = new System.Drawing.Size(250, 25);
            this.toolStripTextBox_Search.ToolTipText = "Zadej hledaný výraz...";
            // 
            // toolStripLabel_Search
            // 
            this.toolStripLabel_Search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_Search.Name = "toolStripLabel_Search";
            this.toolStripLabel_Search.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel_Search.Text = "Hledej";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::ControlModul.Properties.Resources.refresh_icon;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "&Obnovit";
            this.refreshToolStripButton.Click += new System.EventHandler(this.RefreshItems_Event);
            // 
            // openSourceToolStripButton
            // 
            this.openSourceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openSourceToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openSourceToolStripButton.Image")));
            this.openSourceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSourceToolStripButton.Name = "openSourceToolStripButton";
            this.openSourceToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openSourceToolStripButton.Text = "Otevřít zdroj";
            this.openSourceToolStripButton.Click += new System.EventHandler(this.openSourceToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Uložit";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Tisk";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "&Vyjmout";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Kopírovat";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Vložit";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "&Nápověda";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel files|*.xlsx|Text files|*.txt";
            this.openFileDialog.InitialDirectory = "%desktop%";
            this.openFileDialog.Title = "Select file as source of data";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowPrewiev,
            this.toolStripSeparator1,
            this.columnsToolStripMenuItem,
            this.toolStripMenuItemColumnsStyle});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(157, 76);
            // 
            // toolStripMenuItemShowPrewiev
            // 
            this.toolStripMenuItemShowPrewiev.Name = "toolStripMenuItemShowPrewiev";
            this.toolStripMenuItemShowPrewiev.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemShowPrewiev.Text = "Auto-Preview";
            this.toolStripMenuItemShowPrewiev.Click += new System.EventHandler(this.toolStripMenuItemShowPrewiev_Click);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.columnsToolStripMenuItem.Text = "Columns Select";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // toolStripMenuItemColumnsStyle
            // 
            this.toolStripMenuItemColumnsStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillToolStripMenuItem,
            this.autoToolStripMenuItem});
            this.toolStripMenuItemColumnsStyle.Name = "toolStripMenuItemColumnsStyle";
            this.toolStripMenuItemColumnsStyle.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemColumnsStyle.Text = "Columns Style";
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.fillToolStripMenuItem.Text = "Fill";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // processWorker
            // 
            this.processWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processWorker.CausesValidation = false;
            this.processWorker.Location = new System.Drawing.Point(644, 430);
            this.processWorker.Name = "processWorker";
            this.processWorker.Size = new System.Drawing.Size(153, 50);
            this.processWorker.TabIndex = 3;
            this.processWorker.WorkerName = "Databáze";
            this.processWorker.WorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GetWorkerResult);
            // 
            // DataGridViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.processWorker);
            this.Controls.Add(this.dataGridViewObjects);
            this.helpProvider.SetHelpKeyword(this, "aboutDataGridViewer");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "DataGridViewerControl";
            this.helpProvider.SetShowHelp(this, true);
            this.Size = new System.Drawing.Size(800, 480);
            this.Load += new System.EventHandler(this.DataGridViewerControl_Load);
            this.Leave += new System.EventHandler(this.DataGridViewerControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Data)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewObjects;
        private ControlModul.ProcessControl.ProcessWorker processWorker;
        private System.Windows.Forms.BindingSource bindingSource_Data;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorEditItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Search;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Search;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton openSourceToolStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPrewiev;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemColumnsStyle;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
    }
}
