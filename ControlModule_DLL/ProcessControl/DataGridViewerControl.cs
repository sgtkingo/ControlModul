using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using ControlModul.DataControl;
using ControlModul.Handlers.Loger;
using ControlModul.Tools;

namespace ControlModul.ProcessControl
{
    /// <summary>
    /// Allows to show and working with data table or list
    /// </summary>
    public partial class DataGridViewerControl : UserControl
    {
        [Category("Data")]
        public object DataSource 
        {
            get 
            {
                return bindingNavigator.BindingSource.DataSource;
            }
            set 
            {
                bindingNavigator.BindingSource.DataSource = value;
            }
        }
        //Actions
        public Func<object, bool> OpenItemActionDelegate;
        public Func<object, bool> DeleteItemActionDelegate;

        public Func<bool> SaveChangesActionDelegate;

        public Action<object> PrintItemActionDelegate;

        //Help
        [DisplayName("HelpFile"), Category("Help")]
        public string HelpFile 
        {
            get 
            {
                return helpProvider.HelpNamespace;
            }
            set
            {
                helpProvider.HelpNamespace = value;
            }
        }

        //Style and Behavior
        [DisplayName("HidenCollums"), Category("Filters")]
        public string[] HidenCollums { get; set; }


        [DisplayName("AllowNew"), Category("Behavior")]
        public bool AllowNew { get; set; } = true;

        [DisplayName("AllowDelete"), Category("Behavior")]
        public bool AllowDelete { get; set; } = true;

        [DisplayName("AllowModify"), Category("Behavior")]
        public bool AllowModify { get; set; } = false;

        [DisplayName("AllowOpen"), Category("Behavior")]
        public bool AllowOpen { get; set; } = true;

        [DisplayName("AllowPreview"), Category("Behavior")]
        public bool AllowPreview { get; set; } = false;

        [DisplayName("AllowManualSourceSelect"), Category("Behavior")]
        public bool AllowManualSourceSelect { get; set; } = false;

        //Public members
        [Category("Hide")]
        public object SelectedItem 
        {
            get 
            {
                return bindingNavigator.BindingSource.Current;
            } 
        }

        [Category("DataGridView Properities")]
        public DataGridView DataGridView { get; private set; }

        //Private members
        private bool _unsavedChanges;
        private bool UnsavedChanges 
        {
            get 
            {
                return _unsavedChanges;
            }
            set 
            {
                _unsavedChanges = value;
                saveToolStripButton.Enabled = value && SaveChangesActionDelegate != null;
            } 
        }

        private bool WasCutted = false;

        //Data provider
        private IDataProvider _DataProvider;

        public DataGridViewerControl()
        {
            InitializeComponent();
        }

        private void DataGridViewerControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            DataGridView = dataGridViewObjects;

            InitControl();
        }

        public void InitControl()
        {
            SetEvents();
            SetControl();
        }

        #region Base_Methods
        private void SetControl()
        {
            //New
            bindingNavigatorAddNewItem.Enabled = AllowNew;
            //Delete
            bindingNavigatorDeleteItem.Enabled = AllowDelete;
            dataGridViewObjects.AllowUserToDeleteRows = AllowDelete;
            //Modify
            dataGridViewObjects.EditMode = AllowModify ? DataGridViewEditMode.EditOnEnter : DataGridViewEditMode.EditProgrammatically;
            //Open
            bindingNavigatorEditItem.Enabled = AllowOpen = OpenItemActionDelegate != null;
            //Prewiev
            propertyGrid.Enabled = propertyGrid.Visible = toolStripMenuItemShowPrewiev.Checked = AllowPreview;
            //Manual source select
            openSourceToolStripButton.Enabled = AllowManualSourceSelect;
            //Save
            saveToolStripButton.Enabled = SaveChangesActionDelegate != null;
            //Print
            printToolStripButton.Enabled = PrintItemActionDelegate != null;

            //CopyCutPaste
            pasteToolStripButton.Enabled = Manipulator.Exist();

            //Context menu
            fillToolStripMenuItem.Checked = dataGridViewObjects.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill;
            autoToolStripMenuItem.Checked = dataGridViewObjects.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader; ;

            //Refresh control
            this.Refresh();
        }

        private void SetEvents()
        {
            return;
        }

        /// <summary>
        /// Method for binding source directly.
        /// </summary>
        /// <param name="dataSource">
        /// Supports bindable object source or file name.
        /// </param>
        public void BindSources(object dataSource)
        {
            try
            {
                _DataProvider = DataProvider.Create(dataSource);
                processWorker.RunWorker(BindMethod_GetData);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        /// <summary>
        /// Method for binding source by delagete function.
        /// </summary>
        /// <param name="providerFunction">
        /// MUST return bindable data, support list, table or other data sources.
        /// </param>
        public void BindSources(Func<object> providerFunction)
        {
            try
            {
                _DataProvider = DataProvider.Create(providerFunction);
                processWorker.RunWorker(BindMethod_GetData);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        #endregion

        #region Main_Methods
        public void ResetBingindSources(params BindingSource[] bindingSources)
        {
            foreach (var source in bindingSources)
            {
                source.ResetBindings(true);
            }
        }

        private void bindingSource_Data_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewObjects.DataSource = bindingNavigator.BindingSource;
            //Hide columns by name
            HideColumns(HidenCollums);
            //Create new list
            CreateColumsToolStripList();
        }

        private void bindingSource_Data_CurrentChanged(object sender, EventArgs e)
        {
            PreviewItem(SelectedItem);
        }

        private void bindingSource_Data_CurrentItemChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void bindingSource_Data_ListChanged(object sender, ListChangedEventArgs e)
        {
            UnsavedChanges = true;
        }

        public void FillData(object data)
        {
            bindingNavigator.BindingSource.DataSource = data;
            dataGridViewObjects.DataSource = bindingNavigator.BindingSource;

            bindingNavigator.BindingSource.ResetBindings(true);
        }

        private void AddItem(object item)
        {
            if (item == null)
            {
                return;
            }

            try
            {
                Loger.Info($"Adding {item}...");

                bindingNavigator.BindingSource.Add(item);
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
            }
        }

        private void ShowItem(object item)
        {
            if (item == null)
            {
                return;
            }

            if (!OpenItemActionDelegate?.Invoke(item) ?? true)
            {
                Loger.Error("Chyba otevírání položky...", true);
            }
        }

        private void PreviewItem(object item)
        {
            if (item == null || !AllowPreview)
            {
                return;
            }

            propertyGrid.SelectedObject = item;
        }

        private void DeleteItem(object item, bool overdrive = false)
        {
            try
            {
                Loger.Info($"Deleting {item}...");

                if (overdrive)
                {
                    bindingNavigator.BindingSource.Remove(item);
                    DeleteItemActionDelegate?.Invoke(item);
                }
                else if (UserTryDeleteItem(item))
                {
                    bindingNavigator.BindingSource.Remove(item);
                    DeleteItemActionDelegate?.Invoke(item);
                }
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public bool UserTryDeleteItem(object item)
        {
            if (item == null) 
                return false;

            string txt = $"Opravdu smazat {item} ? Tato akce je nevratná!";
            return (MessageBox.Show(txt, "Smazat", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes);
        }
        #endregion

        #region Items_Events
        public void OpenCurrentItem_Event(object sender, EventArgs e)
        {
            try
            {
                ShowItem(SelectedItem);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public void DeleteCurrent_Event(object sender, EventArgs e)
        {
            try
            {
                DeleteItem(SelectedItem);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public void RefreshItems_Event(object sender, EventArgs e)
        {
            this.ResetBingindSources(bindingNavigator.BindingSource);
        }
        #endregion

        #region DataGrid_Events
        //DataGridEvents
        private void dataGridView_OpenItemEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenCurrentItem_Event(sender, e);
        }

        private void dataGridView_UserDeletingRowEvent(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                e.Cancel = !this.UserTryDeleteItem(SelectedItem);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
        #endregion

        #region Navigator_Events
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                SaveChangesActionDelegate?.Invoke();
                UnsavedChanges = false;
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintCurrent(SelectedItem);
        }

        private void PrintCurrent(object item)
        {
            try
            {
                PrintItemActionDelegate?.Invoke(item);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Manipulator.CopyObject(SelectedItem);
            DeleteItem(SelectedItem, true);

            WasCutted = true;
            pasteToolStripButton.Enabled = true;
            copyToolStripButton.Enabled = false;
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Manipulator.CopyObject(SelectedItem);

            WasCutted = false;
            pasteToolStripButton.Enabled = true;
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            var item = Manipulator.PasteObject<object>(WasCutted);
            AddItem(item);

            if( WasCutted )
            {
                pasteToolStripButton.Enabled = false;
                copyToolStripButton.Enabled = true;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if( string.IsNullOrEmpty(HelpFile) || !File.Exists(HelpFile) )
                {
                    MessageBox.Show("Help file cant be found, try to use F1 please...", "Help");
                    return;
                }

                Process.Start(HelpFile);
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
            }
        }

        private void openSourceToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BindSources(openFileDialog.FileName);
            }
        }
        #endregion

        #region SearchAndFilters

        public void HideColumns(string [] collumnsNames)
        {
            HidenCollums = collumnsNames;

            if (collumnsNames == null)
                return;
            foreach (var columnName in collumnsNames)
            {
                SetColumnVisibility(columnName, false);
            }

            dataGridViewObjects.Refresh();
            this.Refresh();
        }

        private void SetColumnVisibility(string columnName, bool visible)
        {
            if (!dataGridViewObjects.Columns.Contains(columnName))
                return;

            dataGridViewObjects.Columns[columnName].Visible = visible;
        }

        public void Search(string searchText, string collumnName)
        {
            bindingNavigator.BindingSource.Filter = $"{collumnName} LIKE %{searchText}%";
        }

        private void toolStripTextBox_Search_TextChanged(object sender, EventArgs e)
        {
            this.Search(toolStripLabel_Search.Text, "*");
        }
        #endregion

        #region ContextMenu
        private void toolStripMenuItemShowPrewiev_Click(object sender, EventArgs e)
        {
            AllowPreview =! AllowPreview;
            propertyGrid.Enabled = propertyGrid.Visible = toolStripMenuItemShowPrewiev.Checked = AllowPreview;
        }

        private void CreateColumsToolStripList()
        {
            this.columnsToolStripMenuItem.DropDownItems.Clear();
            foreach (DataGridViewColumn collumn in dataGridViewObjects.Columns)
            {
                var toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = collumn.Name;
                toolStripMenuItem.Size = new System.Drawing.Size(180, 22);
                toolStripMenuItem.Text = collumn.HeaderText;
                toolStripMenuItem.Checked = collumn.Visible;
                toolStripMenuItem.Click += toolStripMenuItemColumns_Click;

                this.columnsToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void toolStripMenuItemColumns_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripButton = (ToolStripMenuItem)sender;
                toolStripButton.Checked = !toolStripButton.Checked;

                SetColumnVisibility(toolStripButton.Name, toolStripButton.Checked);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewObjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            fillToolStripMenuItem.Checked = true;
            autoToolStripMenuItem.Checked = false;
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewObjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            fillToolStripMenuItem.Checked = false;
            autoToolStripMenuItem.Checked = true;
        }
        #endregion

        #region Worker_events
        private void BindMethod_GetData(DoWorkEventArgs e)
        {
            try
            {
                //Get data from method
                e.Result = _DataProvider?.GetData();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex); ;
                e.Cancel = true;
            }

        }

        private void GetWorkerResult(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.FillData(e.Result);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
        #endregion

        //Leave event
        private void DataGridViewerControl_Leave(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                if (MessageBox.Show(
                    "Unsaved changes detected, do you want save them?",
                    "UnsavedChanges",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }
        }
    }
}
